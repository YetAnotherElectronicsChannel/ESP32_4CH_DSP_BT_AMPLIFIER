#include <stdint.h>
#include <string.h>
#include <stdbool.h>
#include "freertos/xtensa_api.h"
#include "freertos/FreeRTOSConfig.h"
#include "freertos/FreeRTOS.h"
#include "freertos/queue.h"
#include "esp_task_wdt.h"
#include "freertos/task.h"
#include "esp_log.h"
#include "bt_app_core.h"
#include "driver/i2s.h"
#include "freertos/ringbuf.h"
#include "nvs.h"
#include "nvs_flash.h"
#include "dsps.h"
#include "dsp.h"
#include <math.h>

#define pi 3.14159265359f
#define delaysize 1500
float fs; 


//highpass + lopass
float iir_lp[4][10];
float iir_lp_polate[4][10];
float iir_hp[4][10];
float iir_hp_polate[4][10];
float iir_del_lp[4][4];
float iir_del_hp[4][4];

//eq
float iir_eq[4][25];
float iir_eq_polate[4][25];
float iir_del_eq[4][10];


//gain limiter volume peak detect
float peak_detect[4];
float peak_detect_temp[4];
uint8_t peak_counter = 0;
float channel_gains[4];

float master_volume = 1.0f;
float bt_volume;

int limiter_timeout[4];
float limiter_gains[4];
float limiter_threshold[4];
float limiter_release_gain[4];
int limiter_timeout_default = 1000;

//mute, phase and delay :-( hate those ones
int delaybuffers[4][delaysize];

int delay_w_ptr[4];
int delay_r_ptr;

//bassenhancement vars
float bass_enhance_lastval_in = 0.0f;
float bass_enhance_lastval_out = 0.0f;
float bass_enhance_lp[10];
float bass_enhance_lp_del[4];
float bass_enhance_hp[5];
float bass_enhance_hp_del[2];
float bass_enhance_buff[2][64];
float bass_enhance_gain = 0.0f;


//dyn bass parameters
float dyn_bass_biquads[10];
float dyn_bass_biquads_del[4];
float dyn_bass_buffer[64];
float dyn_bass_hp_buffer[64];
float dynbass_peak_temp;
float dynbass_peak;
int dynbass_peak_counter = 0;
int dynbass_watchtime = 0;
float dynbass_threshold = 0;
float dynbass_gain = 0.0f;
float dynbass_desired_gain = 0.0f;
float dynbass_gainspeed = 0.0f;

//input buffers
float inputbuff[3][64];

//pingbong buffers
float ftemp[4][2][64];




float polate(float ins, float * delay) {
	
	float outval =  0.04102272606396773f*ins + 0.9589772739360323f*(*delay);
	*delay = outval;
	return outval;

}

void DoDSP(int * data, int * data2, size_t item_size, float rampupgain) {



	
	int y=0;
	for (int i=0; i<item_size/4;i=i+2) {	
		inputbuff[0][y] = (float) data[i];		
		inputbuff[1][y] = (float) data[i+1];
		y++;
	}
	
	
	
	float volume = master_volume*rampupgain;
	if (IsBTConnected()) volume *= bt_volume;
	
	dsps_mulc_f32_ae32(inputbuff[0], inputbuff[0],y, volume, 1,1);
	dsps_mulc_f32_ae32(inputbuff[1], inputbuff[1],y, volume, 1,1);
	
	
	//do bassenhance before dynbass
	
	//make sum signal
	dsps_add_f32_ae32(inputbuff[0], inputbuff[1], inputbuff[2], y, 1,1,1);	
	dsps_mulc_f32_ae32(inputbuff[2], inputbuff[2],y, 0.5f, 1,1);
	
	
	// do bass enhancement
	dsps_biquad_f32_ae32(inputbuff[2], bass_enhance_buff[0],y,&bass_enhance_lp[0],&bass_enhance_lp_del[0]);
	
	//for (int i=0; i<item_size/4; i++) {	
	for (int i=0; i<y; i++) {
		if (bass_enhance_buff[0][i]<0.0f) bass_enhance_buff[0][i]=0.0f;
		
	}
	
	dsps_biquad_f32_ae32(bass_enhance_buff[0], bass_enhance_buff[1],y,&bass_enhance_hp[0],&bass_enhance_hp_del[0]);
	dsps_biquad_f32_ae32(bass_enhance_buff[1], bass_enhance_buff[0],y,&bass_enhance_lp[5],&bass_enhance_lp_del[2]);
	dsps_mulc_f32_ae32(bass_enhance_buff[0], bass_enhance_buff[0],y, bass_enhance_gain, 1,1);
	
	if (settings.global_bypass[0]==0) {	
		dsps_add_f32_ae32(inputbuff[0], bass_enhance_buff[0], inputbuff[0], y, 1,1,1);
		dsps_add_f32_ae32(inputbuff[1], bass_enhance_buff[0], inputbuff[1], y, 1,1,1);
		dsps_add_f32_ae32(inputbuff[2], bass_enhance_buff[0], inputbuff[2], y, 1,1,1);
	}
	
	
	//do dynbass
	//todo: do dynbass configurable and check with bass_enhancement to do before dynbass
	
	
	dsps_biquad_f32_ae32(inputbuff[2], dyn_bass_hp_buffer,y,&dyn_bass_biquads[5],&dyn_bass_biquads_del[2]);
	float t = 0.0f;
	for (int i=0; i<y;i++) {
		t = dyn_bass_hp_buffer[i];	
		if (t>dynbass_peak_temp) dynbass_peak_temp=t;			
	}
	
	dynbass_peak_counter++;
	if (dynbass_peak_counter >= dynbass_watchtime) {
		dynbass_peak_counter=0;
		dynbass_peak = dynbass_peak_temp;
		dynbass_peak_temp = 0.0f;
		
	}
	
	
	float desired_gain = (dynbass_threshold/dynbass_peak)*dynbass_desired_gain;
	
	
	
	
	if(desired_gain>dynbass_desired_gain) desired_gain = dynbass_desired_gain;
	
	if (desired_gain == 0.0f) dynbass_gain = 0.0f;
	else if (dynbass_gain < desired_gain) dynbass_gain += dynbass_gainspeed;
	else if (dynbass_gain > desired_gain && dynbass_gain > dynbass_gainspeed) dynbass_gain -= dynbass_gainspeed;
		
	
	
	dsps_biquad_f32_ae32(inputbuff[2], dyn_bass_buffer,y,&dyn_bass_biquads[0],&dyn_bass_biquads_del[0]);	
	dsps_mulc_f32_ae32(dyn_bass_buffer, dyn_bass_buffer,y, dynbass_gain, 1,1);
	
	if (settings.global_bypass[1]==0) {
		dsps_add_f32_ae32(inputbuff[0], dyn_bass_buffer, inputbuff[0], y, 1,1,1);
		dsps_add_f32_ae32(inputbuff[1], dyn_bass_buffer, inputbuff[1], y, 1,1,1);	
		dsps_add_f32_ae32(inputbuff[2], dyn_bass_buffer, inputbuff[2], y, 1,1,1);	
	}
	
	
	
	

	//do normal filters now
	for (int i=0; i<4; i++) {
		
		
		
		float lp_new[10], hp_new[10], eq_new[25];
		for (int h=0; h<25; h++) {
			if (h<10) {
				lp_new[h] = polate(iir_lp[i][h],&iir_lp_polate[i][h]);
				hp_new[h] = polate(iir_hp[i][h],&iir_hp_polate[i][h]);
			}
			eq_new[h] = polate(iir_eq[i][h],&iir_eq_polate[i][h]);
		}
		
		//do lowpassfilters ch0
		if(settings.channel_bypass[i][0]==0) { 
			dsps_biquad_f32_ae32(inputbuff[settings.sourceselect[i]], ftemp[i][0],y,&lp_new[0],&iir_del_lp[i][0]);	
			dsps_biquad_f32_ae32(ftemp[i][0], ftemp[i][1],y,&lp_new[5],&iir_del_lp[i][2]);	
		}
		else {		
			for (int t=0; t<y; t++) { ftemp[i][1][t] = inputbuff[settings.sourceselect[i]][t];	}			
		}
		
		
		//do highpassfilters ch0
		if (settings.channel_bypass[i][1]==0) {
			dsps_biquad_f32_ae32(ftemp[i][1], ftemp[i][0],y,&hp_new[0],&iir_del_hp[i][0]);
			dsps_biquad_f32_ae32(ftemp[i][0], ftemp[i][1],y,&hp_new[5],&iir_del_hp[i][2]);	
		}
		else {
			//nothing todo -> buffer will stay ftemp[i][1]...			
		}
		
			
		//do eq left
		
		if (settings.channel_bypass[i][2]==0) { dsps_biquad_f32_ae32(ftemp[i][1], ftemp[i][0],y,&eq_new[0],&iir_del_eq[i][0]); }
		else { for (int t=0; t<y; t++) { ftemp[i][0][t] = ftemp[i][1][t];	} }	
		
		if (settings.channel_bypass[i][3]==0) { dsps_biquad_f32_ae32(ftemp[i][0], ftemp[i][1],y,&eq_new[5],&iir_del_eq[i][2]); }
		else { for (int t=0; t<y; t++) { ftemp[i][1][t] = ftemp[i][0][t];	} }
			
		if (settings.channel_bypass[i][4]==0) { dsps_biquad_f32_ae32(ftemp[i][1], ftemp[i][0],y,&eq_new[10],&iir_del_eq[i][4]); }
		else { for (int t=0; t<y; t++) { ftemp[i][0][t] = ftemp[i][1][t];	} }
		
		if (settings.channel_bypass[i][5]==0) { dsps_biquad_f32_ae32(ftemp[i][0], ftemp[i][1],y,&eq_new[15],&iir_del_eq[i][6]); }
		else { for (int t=0; t<y; t++) { ftemp[i][1][t] = ftemp[i][0][t];	} }
		
		if (settings.channel_bypass[i][6]==0) { dsps_biquad_f32_ae32(ftemp[i][1], ftemp[i][0],y,&eq_new[20],&iir_del_eq[i][8]); }
		else { for (int t=0; t<y; t++) { ftemp[i][0][t] = ftemp[i][1][t];	} }
	
		
		//gain mute and polarity
		float gain = channel_gains[i];
		if (settings.mute[i] == 1) gain *= 0.0f;
		if (settings.polarity[i] == 1) gain *= -1.0f;
		dsps_mulc_f32_ae32(ftemp[i][0], ftemp[i][1],y, gain, 1,1);
		
	}
	
	
	

	float chann_abs[4];	
	
	//do peak detect and limiter start
	for (int channel=0; channel<4; channel++) {
	
		for (int i=0; i<y; i++) {
				
			chann_abs[channel] = fabsf(ftemp[channel][1][i]);
			
			if (chann_abs[channel]>peak_detect_temp[channel]) peak_detect_temp[channel] = chann_abs[channel];			
			
			if (chann_abs[channel]>limiter_threshold[channel]) {
				
				float gainnew = limiter_threshold[channel] / chann_abs[channel];
				limiter_timeout[channel] = settings.par_limiter_release[channel];
				
				
				if (gainnew < limiter_gains[channel]) {					
					limiter_gains[channel] = gainnew;	
					limiter_release_gain[channel] = (1.0f-gainnew)/((float)settings.par_limiter_release[channel]/2);
									
				}
						
		}
	}
	}
	
	peak_counter++;
	if (peak_counter == 70) {
	
		for (int i=0; i<4; i++) {
			peak_detect[i] = peak_detect_temp[i];
			peak_detect_temp[i] = 0.0f;
		}
		
		peak_counter=0;
	}
	
	
	//do limiter
	
	for (int i=0; i<4; i++) {
	
		if (limiter_timeout[i] > 0) {
			
			dsps_mulc_f32_ae32(ftemp[i][1], ftemp[i][1],y, limiter_gains[i], 1,1);
			limiter_timeout[i]--;
			if (limiter_timeout[i]<settings.par_limiter_release[i]/2) limiter_gains[i] += limiter_release_gain[i];
			//for (int x=0; x<y;x++) { ftemp[i][1][x] = ftemp[i][0][x];}
		}
		else {
			limiter_gains[i] = 1.0f;
		}
	
	}
	
	y=0;
	

	for (int i=0; i<item_size/4; i=i+2) {
    			
    			
    			delaybuffers[0][delay_w_ptr[0]] = (int) ftemp[0][1][y];
    			delaybuffers[1][delay_w_ptr[1]] = (int) ftemp[1][1][y]; 
    			delaybuffers[2][delay_w_ptr[2]] = (int) ftemp[2][1][y];
    			delaybuffers[3][delay_w_ptr[3]] = (int) ftemp[3][1][y];
    		
    			data[i] = delaybuffers[0][delay_r_ptr];
        		data[i+1] = delaybuffers[1][delay_r_ptr];      		
        		data2[i] = delaybuffers[2][delay_r_ptr];
        		data2[i+1] = delaybuffers[3][delay_r_ptr];
        		delay_r_ptr++;
        		if (delay_r_ptr == delaysize) delay_r_ptr=0;  
        		
        		
        		for (int z=0; z<4; z++) {
        			delay_w_ptr[z]++;        			
        			if (delay_w_ptr[z] == delaysize) delay_w_ptr[z]=0;        			      			
        		}
        		
        		y++;
    }
}

void SetDynBass(int watchtime, int threshold, int frequency, int gain, int gainspeed) {
	
	
	if (watchtime < 10 || watchtime > 5000) return;
	if (threshold <0 ) return;
	if (frequency < 30 || frequency > 200) return;
	if (gain < 0 || gain > 100) return;
	if (gainspeed < 1 || gainspeed > 100) return;
	
	settings.dynbass[0] = watchtime;
	settings.dynbass[1] = threshold;
	settings.dynbass[2] = frequency;
	settings.dynbass[3] = gain;
	settings.dynbass[4] = gainspeed;
	
	//lowpass
	float fc = (float) frequency;	
	float k = tan(pi*(fc/fs));
	float qf = 0.7f;
	float norm = 1.0f/(1.0f+k/qf+k*k);
	float a0 = k*k*norm;
	float a1 = 2.0f*a0;
	float a2 = a0;
	float b1 = 2.0f * (k*k-1.0f)*norm;
	float b2 = (1.0f-k/qf+k*k)*norm;
	dyn_bass_biquads[0] = a0;
	dyn_bass_biquads[1] = a1;
	dyn_bass_biquads[2] = a2;
	dyn_bass_biquads[3] = b1;
	dyn_bass_biquads[4] = b2;
	
	//highpass
	fc = ((float)frequency)*1.3f;	
	k = tan(pi*(fc/fs));
	qf=0.7f;
	norm = 1.0f/(1.0f+k/qf+k*k);
	a0 = norm;
	a1 = -2.0f*a0;
	a2 = a0;
	b1 = 2.0f * (k*k-1.0f)*norm;
	b2 = (1.0f-k/qf+k*k)*norm;
	dyn_bass_biquads[5] = a0;
 	dyn_bass_biquads[6] = a1;
 	dyn_bass_biquads[7] = a2;
 	dyn_bass_biquads[8] = b1;
 	dyn_bass_biquads[9] = b2;
	
	
	float buffertimequanta = 64.0f/fs;
	dynbass_watchtime = (int) round( (((float)watchtime)/1000.0f)/buffertimequanta);
	dynbass_threshold = (float)threshold;
	dynbass_desired_gain = ((float) gain)/10.0f;
	
	float bufferspersec = fs/64.0f;
	dynbass_gainspeed = (((float)gainspeed)/bufferspersec)/10.0f;
	ESP_LOGI ("dynbass", "wt: %d, th: %f, freq: %d, gain: %f, gainspeed: %f", dynbass_watchtime, dynbass_threshold, frequency, dynbass_desired_gain, dynbass_gainspeed);
	


}

void GetDynBass(int* watchtime, int* threshold, int* frequency, int* gain, int* gainspeed) {

	*watchtime = settings.dynbass[0];
	*threshold = settings.dynbass[1];
	*frequency = settings.dynbass[2];
	*gain = settings.dynbass[3];
	*gainspeed = settings.dynbass[4];
	
}

void SetBassEnhance(int bassfreq, int gain) {

	if (bassfreq <30 || bassfreq>200) return;
	if (gain <0 || gain>500) return;
	
	
	
	settings.bassenhance[1] = gain;
	settings.bassenhance[0] = bassfreq;
	
	bass_enhance_gain = ((float)gain)/100.0f;
	
	//lp for basssignal	
	float fc = (float) bassfreq;	
	float k = tan(pi*(fc/fs));
	float qf= 0.7f;
	float norm = 1.0f/(1.0f+k/qf+k*k);
	float a0 = k*k*norm;
	float a1 = 2.0f*a0;
	float a2 = a0;
	float b1 = 2.0f * (k*k-1.0f)*norm;
	float b2 = (1.0f-k/qf+k*k)*norm;
	bass_enhance_lp[0] = a0;
 	bass_enhance_lp[1] = a1;
 	bass_enhance_lp[2] = a2;
 	bass_enhance_lp[3] = b1;
 	bass_enhance_lp[4] = b2;
	
	//hp for distorted signal
	fc = (float) bassfreq*1.3f;	
	k = tan(pi*(fc/fs));
	qf=0.7f;
	norm = 1.0f/(1.0f+k/qf+k*k);
	a0 = norm;
	a1 = -2.0f*a0;
	a2 = a0;
	b1 = 2.0f * (k*k-1.0f)*norm;
	b2 = (1.0f-k/qf+k*k)*norm;
	bass_enhance_hp[0] = a0;
 	bass_enhance_hp[1] = a1;
 	bass_enhance_hp[2] = a2;
 	bass_enhance_hp[3] = b1;
 	bass_enhance_hp[4] = b2;
 	
 	//lp for distorted
	fc = (float) bassfreq*2.3f;	
	k = tan(pi*(fc/fs));
	qf= 0.7f;
	norm = 1.0f/(1.0f+k/qf+k*k);
	a0 = k*k*norm;
	a1 = 2.0f*a0;
	a2 = a0;
	b1 = 2.0f * (k*k-1.0f)*norm;
	b2 = (1.0f-k/qf+k*k)*norm;
	bass_enhance_lp[5] = a0;
 	bass_enhance_lp[6] = a1;
 	bass_enhance_lp[7] = a2;
 	bass_enhance_lp[8] = b1;
 	bass_enhance_lp[9] = b2;
	

}

void GetBassEnhance(int* bassfreq, int* gain) {
	*bassfreq = settings.bassenhance[0];	
	*gain = settings.bassenhance[1];
}


void SetSource (int channel0, int channel1, int channel2, int channel3) {

	if (channel0 <0 || channel0 > 2) return;
	if (channel1 <0 || channel1 > 2) return;
	if (channel2 <0 || channel2 > 2) return;
	if (channel3 <0 || channel3 > 2) return;
	
	settings.sourceselect[0] = channel0;
	settings.sourceselect[1] = channel1;
	settings.sourceselect[2] = channel2;
	settings.sourceselect[3] = channel3;
}
	
void GetSource (int* r_ch0, int* r_ch1, int* r_ch2, int* r_ch3) {

	*r_ch0 = settings.sourceselect[0];
	*r_ch1 = settings.sourceselect[1];
	*r_ch2 = settings.sourceselect[2];
	*r_ch3 = settings.sourceselect[3];
}

void GetDynBassGain (float *gain) {
	*gain = dynbass_gain;
}
void GetLevelActive (int* r_ch0, int* r_ch1, int* r_ch2, int* r_ch3) {

	
	if (peak_detect[0] > limiter_threshold[0]) *r_ch0 = settings.par_limiter_threshold[0];
	else *r_ch0 = peak_detect[0];
	
	if (peak_detect[1] > limiter_threshold[1]) *r_ch1 = settings.par_limiter_threshold[1];
	else *r_ch1 = peak_detect[1];
	
	if (peak_detect[2] > limiter_threshold[2]) *r_ch2 = settings.par_limiter_threshold[2];
	else *r_ch2 = peak_detect[2];
	
	if (peak_detect[3] > limiter_threshold[3]) *r_ch3 = settings.par_limiter_threshold[3];
	else *r_ch3 = peak_detect[3];
	

}

void GetLimiterActive (int* r_ch0, int* r_ch1, int* r_ch2, int* r_ch3) {

	
	
	if (limiter_timeout[0]>0) *r_ch0=1;
	else *r_ch0=0;
	
	if (limiter_timeout[1]>0) *r_ch1=1;
	else *r_ch1=0;
	
	if (limiter_timeout[2]>0) *r_ch2=1;
	else *r_ch2=0;
	
	if (limiter_timeout[3]>0) *r_ch3=1;
	else *r_ch3=0;
	

}

void GetLimiter(int* thres_ch0, int* thres_ch1, int* thres_ch2, int* thres_ch3, int* rel_ch0, int* rel_ch1, int* rel_ch2, int* rel_ch3) {

	*thres_ch0 = settings.par_limiter_threshold[0];
	*thres_ch1 = settings.par_limiter_threshold[1];
	*thres_ch2 = settings.par_limiter_threshold[2];
	*thres_ch3 = settings.par_limiter_threshold[3];
	*rel_ch0 = settings.par_limiter_release[0];
	*rel_ch1 = settings.par_limiter_release[1];
	*rel_ch2 = settings.par_limiter_release[2];
	*rel_ch3 = settings.par_limiter_release[3];

}

void SetLimiter(int thres_ch0, int thres_ch1, int thres_ch2, int thres_ch3, int rel_ch0, int rel_ch1, int rel_ch2, int rel_ch3) {

	if (thres_ch0<1) return;
	if (thres_ch1<1) return;
	if (thres_ch2<1) return;
	if (thres_ch3<1) return;
	if (rel_ch0<1) return;
	if (rel_ch1<1) return;
	if (rel_ch2<1) return;
	if (rel_ch3<1) return;
	
	settings.par_limiter_threshold[0] = thres_ch0;
	settings.par_limiter_threshold[1] = thres_ch1;
	settings.par_limiter_threshold[2] = thres_ch2;
	settings.par_limiter_threshold[3] = thres_ch3;
	settings.par_limiter_release[0] = rel_ch0;
	settings.par_limiter_release[1] = rel_ch1;
	settings.par_limiter_release[2] = rel_ch2;
	settings.par_limiter_release[3] = rel_ch3;
	
	for (int i=0; i<4; i++) limiter_threshold[i] = (float) settings.par_limiter_threshold[i];
	
}

void GetGain(int* r_ch0, int* r_ch1, int* r_ch2, int* r_ch3) {

	*r_ch0 = settings.par_channel_gains[0];
	*r_ch1 = settings.par_channel_gains[1];
	*r_ch2 = settings.par_channel_gains[2];
	*r_ch3 = settings.par_channel_gains[3];
}

void SetGain (int channel0, int channel1, int channel2, int channel3) {

	if (channel0 < -20 || channel0 > 20) return;
	if (channel1 < -20 || channel1 > 20) return;
	if (channel2 < -20 || channel2 > 20) return;
	if (channel3 < -20 || channel3 > 20) return;
	
	settings.par_channel_gains[0] = channel0;
	settings.par_channel_gains[1] = channel1;
	settings.par_channel_gains[2] = channel2;
	settings.par_channel_gains[3] = channel3;
	
	channel_gains[0] = pow(10.0f, (float)channel0/20.0f);
	channel_gains[1] = pow(10.0f, (float)channel1/20.0f);
	channel_gains[2] = pow(10.0f, (float)channel2/20.0f);
	channel_gains[3] = pow(10.0f, (float)channel3/20.0f);
}

void SetMasterVolume (int vol) {
	if (vol == -100) master_volume = 0.0f;
	else {
		if (vol <-80 || vol>30) return;
		master_volume = pow(10.0f, (float)vol/20.0f);
	}

}


void GetEQ (int channel, int no, int* r_frequency, int* r_gain, int* r_q) {
	if (channel <0 || channel>3) return;
	if (no <0 || no > 4) return;
	
	*r_frequency = settings.par_eq[channel][no*3+0];
	*r_gain = settings.par_eq[channel][no*3+1];
	*r_q = settings.par_eq[channel][no*3+2];
}

void SetEQ (int channel, int no, int frequency, int gain, int q) {
	if (channel<0 || channel>3) return;
	if (frequency <0 || frequency>20000) return;
	if (q< -2 || q>30 || (q>=0&&q<5) ) return;
	if (q>=0&&q<1) return;
	if (no<0 || no>4) return;
	if (gain< -15 || gain > 15) return;
	
	
	settings.par_eq[channel][no*3+0] = frequency;
	settings.par_eq[channel][no*3+1] = gain;
	settings.par_eq[channel][no*3+2] = q;
	
	
	if (gain==0) {
	
		
		iir_eq[channel][no*5+0] = 1.0f;
		iir_eq[channel][no*5+1] = 0.0f;
		iir_eq[channel][no*5+2] = 0.0f;
		iir_eq[channel][no*5+3] = 0.0f;
		iir_eq[channel][no*5+4] = 0.0f;
		
		return;
	
	}
	
	float fc = (float) frequency;
	float sqrt2 = 1.41421356f;
	float k = tan(pi*(fc/fs));
	float norm=0.0f, a0=0.0f, a1=0.0f, a2=0.0f, b1=0.0f, b2=0.0f;
	float qf=((float)q)/10.0f;
	float gainf = (float) gain;
	float v = pow(10.0f, abs(gainf)/20.0f);
	

	//standard peak eq
	if (q>1) {
	
		if (gain>=0) {
			
			norm = 1.0f/(1.0f+1.0f/qf*k+k*k);
			a0 = (1.0f+v/qf*k+k*k)*norm;
			a1 = 2.0f*(k*k-1.0f)*norm;
			a2 = (1.0f-v/qf*k+k*k)*norm;
			b1 = a1;
			b2 = (1.0f-1.0f/qf*k+k*k)*norm;
		}
		else {
		
			norm = 1.0f/(1.0f+v/qf*k+k*k);
			a0 = (1.0f+1.0f/qf*k+k*k)*norm;
			a1 = 2.0f*(k*k-1.0f)*norm;
			a2 = (1.0f-1.0f/qf*k+k*k)*norm;
			b1=a1;
			b2 = (1.0f-v/qf*k+k*k)*norm;
		}
	
	}
	
	//highshelf
   	if (q==-1) {
	
		if (gain>=0) {
		
			norm = 1.0f/(1.0f+sqrt2*k+k*k);
			a0 = (v+sqrt(2.0f*v)*k+k*k)*norm;
			a1 = 2.0f*(k*k-v)*norm;
			a2 = (v-sqrt(2*v)*k+k*k)*norm;
			b1 = 2.0f*(k*k-1.0f)*norm;
			b2 = (1.0f-sqrt2*k+k*k)*norm;
		}
		else {
		
			norm = 1.0f/(v+sqrt(2*v)*k+k*k);
			a0 = (1.0f+sqrt2*k+k*k)*norm;
			a1 = 2.0f*(k*k-1.0f)*norm;
			a2 = (1.0f-sqrt2*k+k*k)*norm;
			b1 = 2.0f*(k*k-v)*norm;
			b2 = (v-sqrt(2.0f*v)*k+k*k)*norm;
		}
	
	}
	
		//lowshelf
   	if (q==-2) {
	
		if (gain>=0) {
		
			norm = 1.0f/(1.0f+sqrt2*k+k*k);
			a0 = (1.0f+sqrt(2.0f*v)*k+v*k*k)*norm;
			a1 = 2.0f*(v*k*k-1.0f)*norm;
			a2 = (1.0f-sqrt(2.0f*v)*k+v*k*k)*norm;
			b1 = 2.0f*(k*k-1.0f)*norm;
			b2 = (1.0f-sqrt2*k+k*k)*norm;
		}
		else {
		
			norm = 1.0f/(1.0f+sqrt(2.0f*v)*k+v*k*k);
			a0 = (1.0f+sqrt2*k+k*k)*norm;
			a1 = 2.0f*(k*k-1.0f)*norm;
			a2 = (1.0f-sqrt2*k+k*k)*norm;
			b1 = 2.0f*(v*k*k-1.0f)*norm;
			b2 = (1.0f-sqrt(2.0f*v)*k+v*k*k)*norm;
		}
	
	}
	
	
	
	iir_eq[channel][no*5+0] = a0;
	iir_eq[channel][no*5+1] = a1;
	iir_eq[channel][no*5+2] = a2;
	iir_eq[channel][no*5+3] = b1;
	iir_eq[channel][no*5+4] = b2;
	
	
	
}

void GetHighPass(int channel, int* r_order, int* r_frequency, int* r_q) {

	if (channel <0 || channel>3) return;
	*r_order = settings.par_hp[channel][0];
	*r_frequency = settings.par_hp[channel][1];	
	*r_q = settings.par_hp[channel][2];

}

void SetHighPass(int channel, int order, int frequency, int q) {
	if (channel<0 || channel>3) return;
	if (order<0 || order>2) return;
	if (frequency <0 || frequency>20000) return;
	if (q<5 || q>30) return;
	
	
	settings.par_hp[channel][0] = order;
	settings.par_hp[channel][1] = frequency;	
	settings.par_hp[channel][2] = q;
	
	if (order==0) {	
		
			for (int i=0; i<10;i++) {
			
				iir_hp[channel][i]=0.0f;				
				
				if (i%5==0) {
					iir_hp[channel][i]=1.0f;
				}
			}			
			
		
		return;
	}

	float fc = (float) frequency;
	
	float k = tan(pi*(fc/fs));
	float qf=((float)q)/10.0f;
	float norm = 1.0f/(1.0f+k/qf+k*k);
	float a0 = norm;
	float a1 = -2.0f*a0;
	float a2 = a0;
	float b1 = 2.0f * (k*k-1.0f)*norm;
	float b2 = (1.0f-k/qf+k*k)*norm;
	
	
	if (order==1) {	
		iir_hp[channel][0] = a0;
		iir_hp[channel][1] = a1;
		iir_hp[channel][2] = a2;
		iir_hp[channel][3] = b1;
		iir_hp[channel][4] = b2;
		iir_hp[channel][5] = 1.0f;
		iir_hp[channel][6] = 0.0f;
		iir_hp[channel][7] = 0.0f;
		iir_hp[channel][8] = 0.0f;
		iir_hp[channel][9] = 0.0f;
	}
	else {
		iir_hp[channel][0] = a0;
		iir_hp[channel][1] = a1;
		iir_hp[channel][2] = a2;
		iir_hp[channel][3] = b1;
		iir_hp[channel][4] = b2;
		iir_hp[channel][5] = a0;
		iir_hp[channel][6] = a1;
		iir_hp[channel][7] = a2;
		iir_hp[channel][8] = b1;
		iir_hp[channel][9] = b2;
	
	}
	
	
	

	




}

void GetLowPass(int channel, int* r_order, int* r_frequency, int* r_q) {
	if (channel <0 || channel>3) return;
	*r_order = settings.par_lp[channel][0];
	*r_frequency = settings.par_lp[channel][1];	
	*r_q = settings.par_lp[channel][2];
}


void SetLowPass(int channel, int order, int frequency, int q) {
	
	
	if (channel<0 || channel>3) return;
	if (order<0 || order>2) return;
	if (frequency <0 || frequency>20000) return;
	if (q<5 || q>30) return;
	
	
	settings.par_lp[channel][0] = order;
	settings.par_lp[channel][1] = frequency;	
	settings.par_lp[channel][2] = q;
	
	if (order==0) {
	
		
		for (int i=0; i<10;i++) {
		
			iir_lp[channel][i]=0.0f;				
			
			if (i%5==0) {
				iir_lp[channel][i]=1.0f;
			}
		}
		
			
		return;
	}
	
	

	float fc = (float) frequency;
	
	float k = tan(pi*(fc/fs));
	float qf=((float)q)/10.0f;
	float norm = 1.0f/(1.0f+k/qf+k*k);
	float a0 = k*k*norm;
	float a1 = 2.0f*a0;
	float a2 = a0;
	float b1 = 2.0f * (k*k-1.0f)*norm;
	float b2 = (1.0f-k/qf+k*k)*norm;
	

	for (int i=0; i<4; i++) {
	
		//iir_del_lp[channel][i] = 0.0f;
	}
	
	
	
	if (order==1) {	
		iir_lp[channel][0] = a0;
		iir_lp[channel][1] = a1;
		iir_lp[channel][2] = a2;
		iir_lp[channel][3] = b1;
		iir_lp[channel][4] = b2;
		iir_lp[channel][5] = 1.0f;
		iir_lp[channel][6] = 0.0f;
		iir_lp[channel][7] = 0.0f;
		iir_lp[channel][8] = 0.0f;
		iir_lp[channel][9] = 0.0f;
	}
	else {
		iir_lp[channel][0] = a0;
		iir_lp[channel][1] = a1;
		iir_lp[channel][2] = a2;
		iir_lp[channel][3] = b1;
		iir_lp[channel][4] = b2;
		iir_lp[channel][5] = a0;
		iir_lp[channel][6] = a1;
		iir_lp[channel][7] = a2;
		iir_lp[channel][8] = b1;
		iir_lp[channel][9] = b2;
	
	}
	
	
	



}
void initDSPParameters() {

	settings.sourceselect[0] = 0;
	settings.sourceselect[1] = 1;
	settings.sourceselect[2] = 0;
	settings.sourceselect[3] = 1;
	
	
	
	
	
	for (int channel=0; channel<4; channel++) {
		settings.par_lp[channel][0] = 0;
		settings.par_lp[channel][1] = 1000;
		settings.par_lp[channel][2] = 7;		
		settings.par_hp[channel][0] = 0;
		settings.par_hp[channel][1] = 1000;
		settings.par_hp[channel][2] = 7;
		
		for (int i=0;i<5;i++) {
			settings.par_eq[channel][i*3+0] = 1000;
			settings.par_eq[channel][i*3+1] = 0;
			settings.par_eq[channel][i*3+2] = 7;			
		}
		
		settings.par_channel_gains[channel] = 0;
		settings.par_limiter_threshold[channel] = 2147000000;
		settings.par_limiter_release[channel] = 1000;
		settings.mute[channel] = 0;
		settings.polarity[channel] = 0;
		
		settings.delay[channel] = 0;
		
		delay_w_ptr[channel] = 0;
		
		for (int i=0; i<7;i++) {
			settings.channel_bypass[channel][i] = 1;
		}
		
	
	}
	
	for (int i=0; i<5; i++) {
		settings.global_bypass[i] = 1;
	}
	
	settings.bassenhance[0] = 80;
	settings.bassenhance[1] = 0;
	
	settings.dynbass[0] = 30;
	//-70 dB
	settings.dynbass[1]= 678941;
	//90 Hz
	settings.dynbass[2] = 90;
	//gain = 0 = off
	settings.dynbass[3] = 0;
	//10 = 6 dB/sec
	settings.dynbass[4] = 10;
	
	delay_r_ptr = 0;
	
	for (int i=0; i<8; i++) {
		settings.irparams[i] = 0;
	}
	
}
void PrintParameters() {
	ESP_LOGE("PAR","Source: %d %d %d %d", settings.sourceselect[0] ,settings.sourceselect[1] ,settings.sourceselect[2] ,settings.sourceselect[3] );
	ESP_LOGE("PAR","MUTE: %d %d %d %d", settings.mute[0], settings.mute[1], settings.mute[2], settings.mute[3] );
	ESP_LOGE("PAR", "POL: %d %d %d %d", settings.polarity[0], settings.polarity[1], settings.polarity[2], settings.polarity[3]);
	ESP_LOGE("PAR", "GAINS: %d %d %d %d", settings.par_channel_gains[0], settings.par_channel_gains[1], settings.par_channel_gains[2],settings.par_channel_gains[3]);
	ESP_LOGE("PAR", "LIMITER: %d %d %d %d %d %d %d %d", settings.par_limiter_threshold[0], settings.par_limiter_threshold[1], settings.par_limiter_threshold[2], settings.par_limiter_threshold[3],
			settings.par_limiter_release[0],settings.par_limiter_release[1],settings.par_limiter_release[2],settings.par_limiter_release[3] );
	ESP_LOGE("PAR", "Delay: %d %d %d %d", settings.delay[0], settings.delay[1],settings.delay[2],settings.delay[3]);
	ESP_LOGE("PAR", "BassEnhance: %d %d", settings.bassenhance[0], settings.bassenhance[1]);
	ESP_LOGE("PAR", "DynBass: %d %d %d %d %d", settings.dynbass[0], settings.dynbass[1], settings.dynbass[2], settings.dynbass[3], settings.dynbass[4]);
	ESP_LOGE("PAR", "Bypass Global: %d %d %d %d %d",settings.global_bypass[0],settings.global_bypass[1],settings.global_bypass[2],settings.global_bypass[3],settings.global_bypass[4]);
	
	for (int channel=0; channel<4; channel++) {
		
		ESP_LOGE("PAR","LP CH%d: %d %d %d",channel, settings.par_lp[channel][0],settings.par_lp[channel][1],settings.par_lp[channel][2]);
		ESP_LOGE("PAR","HP CH%d: %d %d %d",channel, settings.par_hp[channel][0],settings.par_hp[channel][1],settings.par_hp[channel][2]);
		
		
		for (int i=0;i<5;i++) {
			ESP_LOGE("PAR","EQ CH%d: %d %d %d",channel, settings.par_eq[channel][i*3+0],settings.par_eq[channel][i*3+1],settings.par_eq[channel][i*3+2]);
				
		}	
		
		ESP_LOGE("PAR", "Bypass CH%d: %d %d %d %d %d %d %d",channel,settings.channel_bypass[channel][0],settings.channel_bypass[channel][1], settings.channel_bypass[channel][2], 
			settings.channel_bypass[channel][3],settings.channel_bypass[channel][4],settings.channel_bypass[channel][5],settings.channel_bypass[channel][6]);	
	}
	
	for (int i=0; i<8; i=i+2) {
		ESP_LOGE("PAR", "IR Addr: %d CMD: %d", settings.irparams[i], settings.irparams[i+1]);
	}

}

void initDSPFilters(float fsin) {

	fs = fsin;
	
	SetGain (settings.par_channel_gains[0], settings.par_channel_gains[1], settings.par_channel_gains[2], settings.par_channel_gains[3]);
	SetLimiter(settings.par_limiter_threshold[0],settings.par_limiter_threshold[1],settings.par_limiter_threshold[2],settings.par_limiter_threshold[3],
				settings.par_limiter_release[0],settings.par_limiter_release[1],settings.par_limiter_release[2],settings.par_limiter_release[3]);
	SetMute(settings.mute[0],settings.mute[1],settings.mute[2],settings.mute[3]);
	SetPolarity(settings.polarity[0],settings.polarity[1],settings.polarity[2],settings.polarity[3]);
	SetDelay(settings.delay[0],settings.delay[1],settings.delay[2],settings.delay[3]);
	SetBassEnhance(settings.bassenhance[0],settings.bassenhance[1]);
	SetDynBass(settings.dynbass[0],settings.dynbass[1],settings.dynbass[2],settings.dynbass[3],settings.dynbass[4]);
	SetGlobalBypass(settings.global_bypass[0], settings.global_bypass[1], settings.global_bypass[2], settings.global_bypass[3], settings.global_bypass[4]);
	
	for (int channel=0; channel<4; channel++) {
		SetLowPass(channel, settings.par_lp[channel][0], settings.par_lp[channel][1], settings.par_lp[channel][2]);
		SetHighPass(channel, settings.par_hp[channel][0], settings.par_hp[channel][1], settings.par_hp[channel][2]);
					
		
		for (int i=0;i<5;i++) {
			SetEQ (channel, i, settings.par_eq[channel][i*3+0], settings.par_eq[channel][i*3+1], settings.par_eq[channel][i*3+2]);
						
		}
		
		SetChannelBypass(channel, settings.channel_bypass[channel][0],settings.channel_bypass[channel][1], settings.channel_bypass[channel][2], settings.channel_bypass[channel][3], 
		settings.channel_bypass[channel][4], settings.channel_bypass[channel][5], settings.channel_bypass[channel][6]);
				
		
	}

}


void SetChannelBypass(int channel, int lp, int hp, int eq0, int eq1, int eq2, int eq3, int eq4) {
	if (channel<0 || channel>3) return;
	if (lp<0 ||lp>1) return;
	if (hp<0 || hp>1) return;
	if (eq0<0 || eq0>1) return;
	if (eq1<0 || eq1>1) return;
	if (eq2<0 || eq2>1) return;
	if (eq3<0 || eq3>1) return;
	if (eq4<0 || eq4>1) return;
	
	settings.channel_bypass[channel][0] = (uint8_t) lp;
	settings.channel_bypass[channel][1] = (uint8_t) hp;
	settings.channel_bypass[channel][2] = (uint8_t) eq0;
	settings.channel_bypass[channel][3] = (uint8_t) eq1;
	settings.channel_bypass[channel][4] = (uint8_t) eq2;
	settings.channel_bypass[channel][5] = (uint8_t) eq3;
	settings.channel_bypass[channel][6] = (uint8_t) eq4;



}
 
void GetChannelBypass(int channel, int * lp, int * hp, int * eq0, int * eq1, int * eq2, int * eq3, int * eq4) {

	*lp = (int) settings.channel_bypass[channel][0];
	*hp = (int) settings.channel_bypass[channel][1];
	*eq0 = (int) settings.channel_bypass[channel][2];
	*eq1 = (int) settings.channel_bypass[channel][3];
	*eq2 = (int) settings.channel_bypass[channel][4];
	*eq3 = (int) settings.channel_bypass[channel][5];
	*eq4 = (int) settings.channel_bypass[channel][6];

}

void SetGlobalBypass(int vbs, int dynbass, int res0, int res1, int res2) {
	if (vbs<0 || vbs>1) return;
	if (dynbass<0 || dynbass>1) return;
	if (res0<0 || res0>1) return;
	if (res1<0 || res1>1) return;
	if (res2<0 || res2>1) return;
	settings.global_bypass[0]=(uint8_t) vbs;
	settings.global_bypass[1]=(uint8_t) dynbass;
	settings.global_bypass[2]=(uint8_t) res0;
	settings.global_bypass[3]=(uint8_t) res1;
	settings.global_bypass[4]=(uint8_t) res2;	

}

void GetGlobalBypass(int * vbs, int * dynbass, int * res0, int * res1, int * res2) {

	*vbs = (int) settings.global_bypass[0];
	*dynbass = (int) settings.global_bypass[1];
	*res0 = (int) settings.global_bypass[2];
	*res1 = (int) settings.global_bypass[3];
	*res2 = (int) settings.global_bypass[4];	

}
void GetPolarity(int* r_ch0, int* r_ch1, int* r_ch2, int* r_ch3) {
	*r_ch0 = settings.polarity[0];
	*r_ch1 = settings.polarity[1];
	*r_ch2 = settings.polarity[2];
	*r_ch3 = settings.polarity[3];	

}

void SetPolarity(int channel0, int channel1, int channel2, int channel3){
	if (channel0 <0 || channel0 >1) return;
	if (channel1 <0 || channel1 >1) return;
	if (channel2 <0 || channel2 >1) return;
	if (channel3 <0 || channel3 >1) return;
	
	settings.polarity[0] = channel0;
	settings.polarity[1] = channel1;
	settings.polarity[2] = channel2;
	settings.polarity[3] = channel3;

}

void GetMute(int* r_ch0, int* r_ch1, int* r_ch2, int* r_ch3) {
	
	*r_ch0 = settings.mute[0];
	*r_ch1 = settings.mute[1];
	*r_ch2 = settings.mute[2];
	*r_ch3 = settings.mute[3];
}
void SetMute(int channel0, int channel1, int channel2, int channel3) {
	if (channel0 <0 || channel0 >1) return;
	if (channel1 <0 || channel1 >1) return;
	if (channel2 <0 || channel2 >1) return;
	if (channel3 <0 || channel3 >1) return;
	
	settings.mute[0] = channel0;
	settings.mute[1] = channel1;
	settings.mute[2] = channel2;
	settings.mute[3] = channel3;

}

void SetDelay(int channel0, int channel1, int channel2, int channel3) {
	if (channel0 <0 || channel0 >3000) return;
	if (channel1 <0 || channel1 >3000) return;
	if (channel2 <0 || channel2 >3000) return;
	if (channel3 <0 || channel3 >3000) return;
	
	settings.delay[0] = channel0;
	settings.delay[1] = channel1;
	settings.delay[2] = channel2;
	settings.delay[3] = channel3;
	
	delay_w_ptr[0] = (int) round((((float)channel0)/100000.0f)*fs);
	delay_w_ptr[1] = (int) round((((float)channel1)/100000.0f)*fs);
	delay_w_ptr[2] = (int) round((((float)channel2)/100000.0f)*fs);
	delay_w_ptr[3] = (int) round((((float)channel3)/100000.0f)*fs);
	
	
	for (int i=0; i<4;i++) {
		if (delay_w_ptr[i] <0. || delay_w_ptr[i]>1500) delay_w_ptr[i]=0;
		
	}
	delay_r_ptr = 0;
	ESP_LOGI("DELDEL", "%d %d %d %d", delay_w_ptr[0], delay_w_ptr[1], delay_w_ptr[2], delay_w_ptr[3]);
	
}

void GetDelay(int* r_ch0, int* r_ch1, int* r_ch2, int* r_ch3) {
		
	*r_ch0 = settings.delay[0];
	*r_ch1 = settings.delay[1];
	*r_ch2 = settings.delay[2];
	*r_ch3 = settings.delay[3];

}



uint8_t BT_Connected = 0;

void SetBTConnected(uint8_t onoff){
	BT_Connected = onoff;
	
}
uint8_t IsBTConnected() {
 	return BT_Connected;
}

void SetBTVolume (uint8_t vol) {
	if (vol>127) return;
	if (vol==0) {
		bt_volume = 0.0f;
		return;
	}
	int temp = -(127-vol);
	temp /= 2;
	bt_volume = pow(10.0f, (float)temp/20.0f);
	
	 
}

int SaveParametersToFlash() {

	nvs_handle_t nvs_handle;
	esp_err_t err;
	//nvs_flash_erase();
	err = nvs_open ("storage", NVS_READWRITE, &nvs_handle);
	if (err != ESP_OK) {
		ESP_LOGE("NVS", "Error opening Flash");
		return 0;
	}
	
	size_t size = sizeof(settings);		
	ESP_LOGI("NVS","DSP Settings has size: %d", size);
	err = nvs_set_blob(nvs_handle,"dspsettings",&settings, size);
	if (err != ESP_OK) {
		ESP_LOGE("NVS", "Error doing nvs_set_blob");
		return 0;
	}
	err = nvs_commit(nvs_handle);
	if (err != ESP_OK) {
		ESP_LOGE("NVS", "Error doing nvs_commit");
		return 0;
	}
	nvs_close(nvs_handle);
	ESP_LOGI("NVS", "written data successfully");
	return 1;
}
void RestoreParametersFromFlash() {
	nvs_handle_t nvs_handle;
	esp_err_t err;
	
	err = nvs_open ("storage", NVS_READWRITE, &nvs_handle);
	if (err != ESP_OK) ESP_LOGE("NVS", "Error opening Flash");
	
	
	size_t size = sizeof(settings);
	size_t readsize = 0;
	err = nvs_get_blob(nvs_handle,"dspsettings",NULL, &readsize);
	err = nvs_get_blob(nvs_handle,"dspsettings",&settings, &readsize);
	
	//for (int i=0;i<500;i++) ESP_LOGI("dat","%d",dat[i]);
	if ( (err!= ESP_OK && err==ESP_ERR_NVS_NOT_FOUND) || readsize != size) {
		ESP_LOGE("NVS","Settings not found or size mismatch");
		initDSPParameters();
		err = nvs_set_blob(nvs_handle,"dspsettings",&settings, size);
		if (err != ESP_OK) ESP_LOGE("NVS", "Error doing nvs_set_blob");
		err = nvs_commit(nvs_handle);
		if (err != ESP_OK) ESP_LOGE("NVS", "Error doing nvs_commit");
		ESP_LOGI("NVS","Updated Filters in storage");
	}
	ESP_LOGI("NVS", "ReadSize: %d, originalsize: %d", readsize, size);
	nvs_close(nvs_handle);

}

void SetIRParams(int addr_onoff, int cmd_onoff, int addr_volup, int cmd_volup, int addr_voldown, int cmd_voldown, int addr_mute, int cmd_mute) {
	settings.irparams[0] = addr_onoff;
	settings.irparams[1] = cmd_onoff;
	settings.irparams[2] = addr_volup;
	settings.irparams[3] = cmd_volup;
	settings.irparams[4] = addr_voldown;
	settings.irparams[5] = cmd_voldown;
	settings.irparams[6] = addr_mute;
	settings.irparams[7] = cmd_mute;
}

void GetIRParams(int* addr_onoff, int* cmd_onoff, int* addr_volup, int* cmd_volup, int* addr_voldown, int* cmd_voldown, int* addr_mute, int* cmd_mute) {

	*addr_onoff = settings.irparams[0];
	*cmd_onoff = settings.irparams[1];
	*addr_volup = settings.irparams[2];
	*cmd_volup = settings.irparams[3];
	*addr_voldown = settings.irparams[4];
	*cmd_voldown = settings.irparams[5];
	*addr_mute = settings.irparams[6];
	*cmd_mute = settings.irparams[7];

}

