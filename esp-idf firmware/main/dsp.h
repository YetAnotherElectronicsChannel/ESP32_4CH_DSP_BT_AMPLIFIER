
typedef struct  {
	int sourceselect[4];
	int par_lp[4][3];
	int par_hp[4][3];
	int par_eq[4][15];
	int par_channel_gains[4];
	int par_limiter_threshold[4];
	int par_limiter_release[4];
	uint8_t mute[4];
	uint8_t polarity[4];
	int delay[4];
	int irparams[8];
	int bassenhance[2];
	int dynbass[5];
	uint8_t channel_bypass[4][7];
	uint8_t global_bypass[5];
	
} dspsettings;


dspsettings settings;
void SetBTConnected(uint8_t onoff);
uint8_t IsBTConnected();
void SetBTVolume (uint8_t vol);
void DoDSP(int * data, int * data2, size_t size, float rampupgain);
void initDSPParameters();
void PrintParameters();
void initDSPFilters(float fsin);
void calculateCoefficients(float fsin);

void SetSource (int channel0, int channel1, int channel2, int channel3);
void GetSource (int* r_ch0, int* r_ch1, int* r_ch2, int* r_ch3);

void SetLowPass(int channel, int order, int frequency, int q);
void GetLowPass(int channel, int* r_order, int* r_frequency, int* r_q);

void SetHighPass(int channel, int order, int frequency, int q);
void GetHighPass(int channel, int* r_order, int* r_frequency, int* r_q);

void SetEQ (int channel, int no, int frequency, int gain, int q);
void GetEQ (int channel, int no, int* r_frequency, int* r_gain, int* r_q);

void SetGain (int channel0, int channel1, int channel2, int channel3);
void GetGain(int* r_ch0, int* r_ch1, int* r_ch2, int* r_ch3);

void SetLimiter(int thres_ch0, int thres_ch1, int thres_ch2, int thres_ch3, int rel_ch0, int rel_ch1, int rel_ch2, int rel_ch3);
void GetLimiter(int* thres_ch0, int* thres_ch1, int* thres_ch2, int* thres_ch3, int* rel_ch0, int* rel_ch1, int* rel_ch2, int* rel_ch3);

void SetPolarity(int channel0, int channel1, int channel2, int channel3);
void GetPolarity(int* r_ch0, int* r_ch1, int* r_ch2, int* r_ch3);

void SetMute(int channel0, int channel1, int channel2, int channel3);
void GetMute(int* r_ch0, int* r_ch1, int* r_ch2, int* r_ch3);

void SetDelay(int channel0, int channel1, int channel2, int channel3);
void GetDelay(int* r_ch0, int* r_ch1, int* r_ch2, int* r_ch3);

void SetBassEnhance(int bassfreq, int gain);
void GetBassEnhance(int* bassfreq, int* gain);

void SetDynBass(int watchtime, int threshold, int frequency, int gain, int gainspeed);
void GetDynBass(int* watchtime, int* threshold, int* frequency, int* gain, int* gainspeed);

void GetDynBassGain (float *gain);
void SetMasterVolume (int vol);


int SaveParametersToFlash();
void RestoreParametersFromFlash();
void CalculateFilters();
void GetLevelActive(int* r_ch0, int* r_ch1, int* r_ch2, int* r_ch3);
void GetLimiterActive (int* r_ch0, int* r_ch1, int* r_ch2, int* r_ch3);

void SetIRParams(int addr_onoff, int cmd_onoff, int addr_volup, int cmd_volup, int addr_voldown, int cmd_voldown, int addr_mute, int cmd_mute);
void GetIRParams(int* addr_onoff, int* cmd_onoff, int* addr_volup, int* cmd_volup, int* addr_voldown, int* cmd_voldown, int* addr_mute, int* cmd_mute);

void SetChannelBypass(int channel, int lp, int hp, int eq0, int eq1, int eq2, int eq3, int eq4);
void GetChannelBypass(int channel, int * lp, int * hp, int * eq0, int * eq1, int * eq2, int * eq3, int * eq4);
void SetGlobalBypass(int vbs, int dynbass, int res0, int res1, int res2);
void GetGlobalBypass(int * vbs, int * dynbass, int * res0, int * res1, int * res2);
