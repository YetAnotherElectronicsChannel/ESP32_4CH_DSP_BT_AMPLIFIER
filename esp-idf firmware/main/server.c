#include <string.h>
#include <sys/param.h>
#include "freertos/FreeRTOS.h"
#include "freertos/task.h"
#include "esp_system.h"
#include "esp_wifi.h"
#include "esp_event.h"
#include "esp_log.h"
#include "nvs_flash.h"
#include "esp_netif.h"
#include "server.h"
#include "lwip/err.h"
#include "lwip/sockets.h"
#include "lwip/sys.h"
#include <lwip/netdb.h>
#include "dsp.h"
#include "driver/gpio.h"

#define PORT 77

static const char *TAG = "example";
char rx_buffer[256];




//IR vars
int irvars[3] = {0,0,0};

void SetLastIRReceived(int addr, int cmd) {

	irvars[0] = 1;
	irvars[1] = addr;
	irvars[2] = cmd;


}

static void handleData () {
char del[] = ",";
char* ptr;

int params[10];
uint8_t count=0;
ptr=strtok(rx_buffer,del);

uint8_t foundStart = 0;

int tempdata[20];
while (ptr != NULL) {
	if (foundStart==0) {
		if (strstr(ptr,"?")) {
			foundStart=1;
			ptr = strtok(NULL,del);
			ESP_LOGI("QM", "QM found on core %d", xPortGetCoreID());
		}
		else {
			ESP_LOGI("QM","QM not found");
			return;
		}
	
	}
	else {
		params[count] = atoi(ptr);
		count++;
		ptr = strtok(NULL,del);
	}
	
}
	
	//Lowpass
	if ( (params[0]==0 && count==5) || (params[0]==25 && count==2)) {
		
		if (params[0]==0) {			
			for (int chann=0; chann<4; chann++) {
				if (params[1]&(1<<chann)) {
					ESP_LOGI("DSP","Set LowPass Request %d, %d, %d %d",chann,params[2],params[3],params[4]);		
					SetLowPass(chann,params[2],params[3],params[4]);
					
				}
			}
			sprintf(rx_buffer,"!,0,1,?");
		}
		else {
			GetLowPass(params[1], &tempdata[0], &tempdata[1], &tempdata[2]);
			ESP_LOGI("DSP","LowPass Request CH:%d, Ord.:%d, Freq: %d, Q:%f",params[1], tempdata[0], tempdata[1], (float)tempdata[2]/10.0f);
			sprintf(rx_buffer,"!,25,%d,%d,%d,%d,?",params[1], tempdata[0], tempdata[1], tempdata[2]);
		}
			
	}
	
	//HighPass
	if ( (params[0]==1 && count==5) || (params[0]==26 && count==2) ) {
		
		if (params[0]==1) {
			
			for (int chann=0; chann<4; chann++) {
				if (params[1]&(1<<chann)) {
					ESP_LOGI("DSP","Set HighPass Request %d, %d, %d %d",chann,params[2],params[3],params[4]);
					SetHighPass(chann,params[2],params[3],params[4]);
					
				}
			}
			sprintf(rx_buffer,"!,1,1,?");
		}
		else {
			GetHighPass(params[1], &tempdata[0], &tempdata[1], &tempdata[2]);
			ESP_LOGI("DSP","HighPass Request CH:%d, Ord.:%d, Freq: %d, Q:%f",params[1], tempdata[0], tempdata[1], (float)tempdata[2]/10.0f);
			sprintf(rx_buffer,"!,26,%d,%d,%d,%d,?",params[1], tempdata[0], tempdata[1], tempdata[2]);
		}
	
	}
	
	//EQ
	if ( (params[0]==2 && count==6) || (params[0]==27 && count==3) ) {
		
		if (params[0]==2) {
			
			for (int chann=0; chann<4; chann++) {
				if (params[1]&(1<<chann)) {
					ESP_LOGI("DSP", "Set EQ Request %d %d %d %d %d", chann, params[2], params[3], params[4], params[5]);
					SetEQ (chann, params[2], params[3], params[4], params[5]);
					
				}
			}
			sprintf(rx_buffer,"!,2,1,?");
		}
		else {
			GetEQ (params[1], params[2], &tempdata[0], &tempdata[1], &tempdata[2]);
			ESP_LOGI("DSP","EQ Request CH:%d, No.:%d, Freq: %d, Gain: %d, Q:%d",params[1], params[2], tempdata[0], tempdata[1], tempdata[2]);
			sprintf(rx_buffer,"!,27,%d,%d,%d,%d,%d,?",params[1], params[2], tempdata[0], tempdata[1], tempdata[2]);
		}
		
	

	}
	
	//Gains
	if ( (params[0]==3 && count==5) || (params[0]==28 && count==1)) {
	
		if(params[0]==3) {
			ESP_LOGI("DSP", "Set Gain Request %d %d %d %d", params[1],params[2],params[3],params[4]);
			SetGain(params[1],params[2],params[3],params[4]);	
			sprintf(rx_buffer,"!,3,1,?");	
		}
		else {
			GetGain(&tempdata[0], &tempdata[1], &tempdata[2], &tempdata[3]);
			ESP_LOGI("DSP","GAIN Request: %d, %d, %d, %d",tempdata[0], tempdata[1], tempdata[2], tempdata[3]);
			sprintf(rx_buffer,"!,28,%d,%d,%d,%d,?",tempdata[0], tempdata[1], tempdata[2], tempdata[3]);
		}
	
	}


	//Limiter Thresholds
	if ( (params[0]==4 && count==9) || (params[0]==29 && count==1) ) {
	
		if (params[0]==4) {
			ESP_LOGI("DSP", "Set Limiter Request %d %d %d %d %d %d %d %d", params[1],params[2],params[3],params[4], params[5],params[6],params[7],params[8]);
			SetLimiter(params[1],params[2],params[3],params[4], params[5],params[6],params[7],params[8]);
			sprintf(rx_buffer,"!,4,1,?");
		}
		else {
			GetLimiter(&tempdata[0], &tempdata[1], &tempdata[2], &tempdata[3],&tempdata[4], &tempdata[5], &tempdata[6], &tempdata[7]);
			ESP_LOGI("DSP","LIMITER Request %d, %d, %d, %d, %d, %d, %d, %d",tempdata[0], tempdata[1], tempdata[2], tempdata[3],tempdata[4], tempdata[5], tempdata[6], tempdata[7]);
			sprintf(rx_buffer,"!,29,%d,%d,%d,%d,%d,%d,%d,%d,?",tempdata[0], tempdata[1], tempdata[2], tempdata[3],tempdata[4], tempdata[5], tempdata[6], tempdata[7]);	
		}
		
	}
	
	//level and limiter monitoring
	if (params[0]==30 && count==1) {
		ESP_LOGI("DSP","Get Level Limiter Request");	
		GetLevelActive(&tempdata[0], &tempdata[1], &tempdata[2], &tempdata[3]);
		GetLimiterActive (&tempdata[4], &tempdata[5], &tempdata[6], &tempdata[7]);
		float dbgain;
		GetDynBassGain(&dbgain);
		int dbgainint = (int) (dbgain*1000.0f);
		
		if (irvars[0]==0) {
			sprintf(rx_buffer,"!,55,%d,%d,%d,%d,%d,%d,%d,%d,%d,?",tempdata[0], tempdata[1], tempdata[2], tempdata[3], tempdata[4], tempdata[5], tempdata[6], tempdata[7],dbgainint );
			ESP_LOGI("DSP","Levels: %d,%d,%d,%d Limiters: %d,%d,%d,%d Dyngain: %f",tempdata[0], tempdata[1], tempdata[2], tempdata[3], tempdata[4], tempdata[5], tempdata[6], tempdata[7], dbgain);
		}
		else {
			sprintf(rx_buffer,"!,555,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,?",tempdata[0], tempdata[1], tempdata[2], tempdata[3], tempdata[4], tempdata[5], tempdata[6], tempdata[7],dbgainint,irvars[1],irvars[2]);
			irvars[0] = 0;
			ESP_LOGI("DSP","Levels: %d,%d,%d,%d Limiters: %d,%d,%d,%d Dyngain: %f IR: %d,%d",tempdata[0], tempdata[1], tempdata[2], tempdata[3], tempdata[4], tempdata[5], tempdata[6], tempdata[7],dbgain, 						irvars[1],irvars[2]);
		}
	
	}
	
	//Muting
	if ( (params[0]==6 && count==5) || (params[0]==31 && count==1)) {
	
		if (params[0]==6) {
			ESP_LOGI("DSP","Set Mute Request %d %d %d %d", params[1],params[2],params[3],params[4]);
			SetMute(params[1],params[2],params[3],params[4]);
			sprintf(rx_buffer,"!,6,1,?");
		}
		else {
			GetMute(&tempdata[0], &tempdata[1], &tempdata[2], &tempdata[3]);
			ESP_LOGI("DSP","Mute: %d, %d, %d, %d",tempdata[0], tempdata[1], tempdata[2], tempdata[3]);
			sprintf(rx_buffer,"!,31,%d,%d,%d,%d,?",tempdata[0], tempdata[1], tempdata[2], tempdata[3]);
		}
			
	}
	
	//Polarity
	if ( (params[0]==7 && count==5) || (params[0]==32 && count==1)) {
	
		if (params[0]==7) {
			ESP_LOGI("DSP", "Set Polarity Request %d %d %d %d", params[1],params[2],params[3],params[4]);
			SetPolarity(params[1],params[2],params[3],params[4]);
			sprintf(rx_buffer,"!,7,1,?");		
		}
		else {
			GetPolarity(&tempdata[0], &tempdata[1], &tempdata[2], &tempdata[3]);
			ESP_LOGI("DSP","Polarity: %d, %d, %d, %d",tempdata[0], tempdata[1], tempdata[2], tempdata[3]);
			sprintf(rx_buffer,"!,32,%d,%d,%d,%d,?",tempdata[0], tempdata[1], tempdata[2], tempdata[3]);
		}
	}
	
	
	//source 
	if ( (params[0]==13 && count==5) || (params[0]==38 && count==1)) {
	
		if(params[0]==13) {
			ESP_LOGI("DSP", "Set Source Request %d %d %d %d",params[1],params[2],params[3],params[4]);
			SetSource(params[1],params[2],params[3],params[4]);	
			sprintf(rx_buffer,"!,13,1,?");	
		}
		else {
			GetSource(&tempdata[0], &tempdata[1], &tempdata[2], &tempdata[3]);
			ESP_LOGI("DSP","Source Request: %d, %d, %d, %d",tempdata[0], tempdata[1], tempdata[2], tempdata[3]);
			sprintf(rx_buffer,"!,38,%d,%d,%d,%d,?",tempdata[0], tempdata[1], tempdata[2], tempdata[3]);		
		}
	
	}
	
	//delay
	if ( (params[0]==8 && count==5) || (params[0]==33 && count==1)) {
	
		if(params[0]==8) {
			ESP_LOGI("DSP", "Set Delay Request %d %d %d %d",params[1],params[2],params[3],params[4]);
			SetDelay(params[1],params[2],params[3],params[4]);	
			sprintf(rx_buffer,"!,8,1,?");	
		}
		else {
			GetDelay(&tempdata[0], &tempdata[1], &tempdata[2], &tempdata[3]);
			ESP_LOGI("DSP","Delay Request: %d, %d, %d, %d",tempdata[0], tempdata[1], tempdata[2], tempdata[3]);
			sprintf(rx_buffer,"!,33,%d,%d,%d,%d,?",tempdata[0], tempdata[1], tempdata[2], tempdata[3]);	
		}
	
	}
	
	
	//bassenhance
	if ( (params[0]==11 && count==3) || (params[0]==36 && count==1)) {
	
		if(params[0]==11) {
			ESP_LOGI("DSP", "Set BassEnhance %d %d",params[1],params[2]);
			SetBassEnhance(params[1],params[2]);
			sprintf(rx_buffer,"!,11,1,?");		
		}
		else {
			GetBassEnhance(&tempdata[0], &tempdata[1]);
			ESP_LOGI("DSP","BassEnhance Request: %d, %d",tempdata[0], tempdata[1]);
			sprintf(rx_buffer,"!,36,%d,%d,?",tempdata[0], tempdata[1]);		
		}
	
	}
	
	//dynbass
	if ( (params[0]==14 && count==6) || (params[0]==39 && count==1)) {
	
		if(params[0]==14) {
			ESP_LOGI("DSP", "Set DynBass");
			SetDynBass(params[1],params[2],params[3],params[4],params[5]);	
			sprintf(rx_buffer,"!,14,1,?");			
		}
		else {
			GetDynBass(&tempdata[0], &tempdata[1], &tempdata[2], &tempdata[3],&tempdata[4]);
			ESP_LOGI("DSP","DynBass Request: %d, %d, %d, %d, %d",tempdata[0], tempdata[1], tempdata[2], tempdata[3], tempdata[4]);
			sprintf(rx_buffer,"!,39,%d,%d,%d,%d,%d,?",tempdata[0], tempdata[1], tempdata[2], tempdata[3], tempdata[4]);	
		}
	
	}
	
	//bypass global
	if ( (params[0]==41 && count==3) || (params[0]==66 && count==1)) {
	
		if(params[0]==41) {
			ESP_LOGI("DSP", "Set ByPass Global %d %d",params[1], params[2]);
			SetGlobalBypass(params[1], params[2], 1,1,1);
			sprintf(rx_buffer,"!,41,1,?");			
		}
		else {
			GetGlobalBypass(&tempdata[0], &tempdata[1], &tempdata[2], &tempdata[3],&tempdata[4]);
			ESP_LOGI("DSP","Global Bypass Request: %d, %d",tempdata[0], tempdata[1]);
			sprintf(rx_buffer,"!,66,%d,%d,?",tempdata[0], tempdata[1]);	
		}
	
	}
	
	//bypass channel
	if ( (params[0]==40 && count==9) || (params[0]==65 && count==2)) {
	
		
			if(params[0]==40) {
				for (int chann=0; chann<4; chann++) {
					if (params[1]&(1<<chann)) {
					
						ESP_LOGI("DSP", "Set ByPass Channel:%d %d %d %d %d %d %d %d",chann, params[2],params[3], params[4],params[5], params[6],params[7], params[8]);
						SetChannelBypass(chann, params[2],params[3], params[4],params[5], params[6],params[7], params[8]);
					}								
				}
				sprintf(rx_buffer,"!,40,1,?");
			}
			else {
				GetChannelBypass(params[1], &tempdata[0], &tempdata[1], &tempdata[2], &tempdata[3], &tempdata[4], &tempdata[5], &tempdata[6]);
				ESP_LOGI("DSP","Channel Bypass Request: %d %d %d %d %d %d %d %d",params[1], tempdata[0], tempdata[1], tempdata[2], tempdata[3], tempdata[4], tempdata[5], tempdata[6]);
				sprintf(rx_buffer,"!,65,%d,%d,%d,%d,%d,%d,%d,%d,?",params[1], tempdata[0], tempdata[1], tempdata[2], tempdata[3], tempdata[4], tempdata[5], tempdata[6]);	
			}
		
	
	}
	
	
	//IR Remote
	if ( (params[0]==12 && count==9) || (params[0]==37 && count==1)) {
	
		if (params[0]==12) {
			ESP_LOGI("DSP", "Set IR Request %d %d %d %d %d %d %d %d",params[1], params[2],params[3],params[4],params[5],params[6],params[7],params[8]);
			SetIRParams(params[1], params[2],params[3],params[4],params[5],params[6],params[7],params[8]);					
			sprintf(rx_buffer,"!,12,1,?");
		}
		else {
			GetIRParams(&tempdata[0],&tempdata[1],&tempdata[2],&tempdata[3],&tempdata[4],&tempdata[5], &tempdata[6], &tempdata[7]);		
			ESP_LOGI("DSP","IR Params: %d, %d, %d, %d, %d, %d, %d, %d",tempdata[0], tempdata[1], tempdata[2], tempdata[3], tempdata[4], tempdata[5], tempdata[6], tempdata[7]);
			sprintf(rx_buffer,"!,37,%d,%d,%d,%d,%d,%d,%d,%d,?",tempdata[0], tempdata[1], tempdata[2], tempdata[3], tempdata[4], tempdata[5], tempdata[6], tempdata[7]);
		}
	}
	
	
	
	
	if (params[0]==9 && count==1) {
		ESP_LOGI("DSP","Init Filters");
		initDSPParameters();
		initDSPFilters(48000.0f);
		strcpy(rx_buffer,"!,9,1,?");	
	}
	
	if (params[0]==10 && count==1) {
		ESP_LOGI("DSP","SaveToFlash");
		tempdata[0] = SaveParametersToFlash();
		sprintf(rx_buffer,"!,10,%d,?",tempdata[0]);
	}
	
	if (params[0]==11 && count==1) {
		ESP_LOGI("Params","PrintParams");
		PrintParameters();
		strcpy(rx_buffer,"ok\n");	
	}
	if (params[0]==12 && count==1) {
	
		RestoreParametersFromFlash();
		PrintParameters();
		esp_restart();
		strcpy(rx_buffer,"ok\n");
	
	}

}

static void do_retransmit(const int sock)
{
    int len;
    

    do {
        len = recv(sock, rx_buffer, sizeof(rx_buffer) - 1, 0);
        if (len < 0) {
            ESP_LOGE(TAG, "Error occurred during receiving: errno %d", errno);
        } else if (len == 0) {
            ESP_LOGW(TAG, "Connection closed");
        } else {
            rx_buffer[len] = 0; // Null-terminate whatever is received and treat it like a string
            ESP_LOGI(TAG, "Received %d bytes: %s", len, rx_buffer);

            // send() can return less bytes than supplied length.
            // Walk-around for robust implementation. 
            handleData();
            int to_write = strlen(rx_buffer);
            int written=0;
            while (to_write > 0) {
                written = send(sock, rx_buffer+written, to_write, 0);
                if (written < 0) {
                    ESP_LOGE(TAG, "Error occurred during sending: errno %d", errno);
                }
                to_write -= written;
            }
        }
    } while (len > 0);
}

void tcp_server_task(void *pvParameters)
{

		
	
    
    char addr_str[128];
    int addr_family = (int)pvParameters;
    int ip_protocol = 0;
    struct sockaddr_in6 dest_addr;

    if (addr_family == AF_INET) {
        struct sockaddr_in *dest_addr_ip4 = (struct sockaddr_in *)&dest_addr;
        dest_addr_ip4->sin_addr.s_addr = htonl(INADDR_ANY);
        dest_addr_ip4->sin_family = AF_INET;
        dest_addr_ip4->sin_port = htons(PORT);
        ip_protocol = IPPROTO_IP;
    } else if (addr_family == AF_INET6) {
        bzero(&dest_addr.sin6_addr.un, sizeof(dest_addr.sin6_addr.un));
        dest_addr.sin6_family = AF_INET6;
        dest_addr.sin6_port = htons(PORT);
        ip_protocol = IPPROTO_IPV6;
    }

    int listen_sock = socket(addr_family, SOCK_STREAM, ip_protocol);
    if (listen_sock < 0) {
        ESP_LOGE(TAG, "Unable to create socket: errno %d", errno);
        vTaskDelete(NULL);
        return;
    }

    int opt = 1;
    setsockopt(listen_sock, SOL_SOCKET, SO_REUSEADDR, &opt, sizeof(opt));


    ESP_LOGI(TAG, "Socket created");

    int err = bind(listen_sock, (struct sockaddr *)&dest_addr, sizeof(dest_addr));
    if (err != 0) {
        ESP_LOGE(TAG, "Socket unable to bind: errno %d", errno);
        ESP_LOGE(TAG, "IPPROTO: %d", addr_family);
        goto CLEAN_UP;
    }
    ESP_LOGI(TAG, "Socket bound, port %d", PORT);

    err = listen(listen_sock, 1);
    if (err != 0) {
        ESP_LOGE(TAG, "Error occurred during listen: errno %d", errno);
        goto CLEAN_UP;
    }

    while (1) {

        ESP_LOGI(TAG, "Socket listening");

        struct sockaddr_in6 source_addr; // Large enough for both IPv4 or IPv6
        uint addr_len = sizeof(source_addr);
        int sock = accept(listen_sock, (struct sockaddr *)&source_addr, &addr_len);
        if (sock < 0) {
            ESP_LOGE(TAG, "Unable to accept connection: errno %d", errno);
            break;
        }

        // Convert ip address to string
        if (source_addr.sin6_family == PF_INET) {
            inet_ntoa_r(((struct sockaddr_in *)&source_addr)->sin_addr.s_addr, addr_str, sizeof(addr_str) - 1);
        } else if (source_addr.sin6_family == PF_INET6) {
            inet6_ntoa_r(source_addr.sin6_addr, addr_str, sizeof(addr_str) - 1);
        }
        ESP_LOGI(TAG, "Socket accepted ip address: %s", addr_str);

        do_retransmit(sock);

        shutdown(sock, 0);
        close(sock);
    }

CLEAN_UP:
    close(listen_sock);
    vTaskDelete(NULL);
}
