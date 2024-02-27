/*
   This example code is in the Public Domain (or CC0 licensed, at your option.)

   Unless required by applicable law or agreed to in writing, this
   software is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
   CONDITIONS OF ANY KIND, either express or implied.
*/

#include <stdint.h>
#include <string.h>
#include <stdbool.h>
#include "freertos/xtensa_api.h"
#include "freertos/FreeRTOSConfig.h"
#include "freertos/FreeRTOS.h"
#include "freertos/queue.h"
#include "freertos/task.h"
#include "esp_log.h"
#include "bt_app_core.h"
#include "driver/i2s.h"
#include "freertos/ringbuf.h"
#include "dsp.h"
#include "esp_task_wdt.h"

static void bt_app_task_handler(void *arg);
static bool bt_app_send_msg(bt_app_msg_t *msg);
static void bt_app_work_dispatched(bt_app_msg_t *msg);

static xQueueHandle s_bt_app_task_queue = NULL;
static xTaskHandle s_bt_app_task_handle = NULL;
static xTaskHandle s_aux_i2s_task_handle = NULL;


//i2s helper 
size_t bytes_written = 0;
size_t readsize = 0;
int blocksize = 512;
	
	
	



//fifo
int data32b[128], data32b2[128], data32b3[128];
#define fifomax 16384*2
//short btbuffer[fifomax];
short * btbuffer;
int wptr=0, rptr=0;
uint64_t wptrtotal=0, rptrtotal=0;

static int entries() {
	return wptrtotal-rptrtotal;
		
}



bool bt_app_work_dispatch(bt_app_cb_t p_cback, uint16_t event, void *p_params, int param_len, bt_app_copy_cb_t p_copy_cback)
{
    ESP_LOGD(BT_APP_CORE_TAG, "%s event 0x%x, param len %d", __func__, event, param_len);

    bt_app_msg_t msg;
    memset(&msg, 0, sizeof(bt_app_msg_t));

    msg.sig = BT_APP_SIG_WORK_DISPATCH;
    msg.event = event;
    msg.cb = p_cback;

    if (param_len == 0) {
        return bt_app_send_msg(&msg);
    } else if (p_params && param_len > 0) {
        if ((msg.param = malloc(param_len)) != NULL) {
            memcpy(msg.param, p_params, param_len);
            /* check if caller has provided a copy callback to do the deep copy */
            if (p_copy_cback) {
                p_copy_cback(&msg, msg.param, p_params);
            }
            return bt_app_send_msg(&msg);
        }
    }

    return false;
}

static bool bt_app_send_msg(bt_app_msg_t *msg)
{
    if (msg == NULL) {
        return false;
    }

    if (xQueueSend(s_bt_app_task_queue, msg, 10 / portTICK_RATE_MS) != pdTRUE) {
        ESP_LOGE(BT_APP_CORE_TAG, "%s xQueue send failed", __func__);
        return false;
    }
    return true;
}

static void bt_app_work_dispatched(bt_app_msg_t *msg)
{
    if (msg->cb) {
        msg->cb(msg->event, msg->param);
    }
}

static void bt_app_task_handler(void *arg)
{
    bt_app_msg_t msg;
    for (;;) {
        if (pdTRUE == xQueueReceive(s_bt_app_task_queue, &msg, (portTickType)portMAX_DELAY)) {
            ESP_LOGD(BT_APP_CORE_TAG, "%s, sig 0x%x, 0x%x", __func__, msg.sig, msg.event);
            switch (msg.sig) {
            case BT_APP_SIG_WORK_DISPATCH:
                bt_app_work_dispatched(&msg);
                break;
            default:
                ESP_LOGW(BT_APP_CORE_TAG, "%s, unhandled sig: %d", __func__, msg.sig);
                break;
            } // switch (msg.sig)

            if (msg.param) {
                free(msg.param);
            }
        }
    }
}

void bt_app_task_start_up(void)
{
    s_bt_app_task_queue = xQueueCreate(10, sizeof(bt_app_msg_t));
    xTaskCreate(bt_app_task_handler, "BtAppT", 3072, NULL, configMAX_PRIORITIES - 3, &s_bt_app_task_handle);
    return;
}

void bt_app_task_shut_down(void)
{
    if (s_bt_app_task_handle) {
        vTaskDelete(s_bt_app_task_handle);
        s_bt_app_task_handle = NULL;
    }
    if (s_bt_app_task_queue) {
        vQueueDelete(s_bt_app_task_queue);
        s_bt_app_task_queue = NULL;
    }
}



static void aux_i2s_task_handler(void *arg) {
	
	ESP_LOGI("I2S", "I2S Task started on Core %d", xPortGetCoreID());
	
	
	
	
	uint32_t * data32bunsigned = (uint32_t *) data32b;
	uint32_t * data32bunsigned2 = (uint32_t *) data32b2;
	int emptybuffer[128];
	
	
	for (int i=0; i<128;i++) {
		data32b[i] = 0;
		emptybuffer[i]=0;
	}
	
	for (int i=0; i<5; i++) {
			
			i2s_write(0, data32b, blocksize, &bytes_written, portMAX_DELAY);			
			i2s_write(1, data32b, blocksize, &bytes_written, portMAX_DELAY);
			
	}

	
	
	uint8_t lastbtstate=0;
	
	int bufferprintcount = 0;
	int critical = 0;
	int mute = 0;
	
	while (1) {
	
		
		if (IsBTConnected()==1 && lastbtstate==0) {			
			
			while (entries() < 8000) {
				i2s_write(0, emptybuffer, blocksize, &bytes_written, portMAX_DELAY);			
				i2s_write(1, emptybuffer, blocksize, &bytes_written, portMAX_DELAY);
			}
			mute=0;
		}
		
		if (IsBTConnected()==0)  {
			lastbtstate=0;
			wptr=0; 
			rptr=0;
			wptrtotal=0; 
			rptrtotal=0;
			
			
			
			i2s_read(0,data32b,blocksize, &readsize, portMAX_DELAY);
			
			
			DoDSP(data32b, data32b2,blocksize,1.0f);		
			
			
			i2s_write(0, data32b, blocksize, &bytes_written, portMAX_DELAY);	
			i2s_write(1, data32b2, blocksize, &bytes_written, portMAX_DELAY);
			
			
		}
		else if (IsBTConnected()==1 && entries()<128) {
			critical++;
			lastbtstate=1;			
			while (entries() < 8000) {
				//i2s_write(0, emptybuffer, blocksize, &bytes_written, portMAX_DELAY);			
				//i2s_write(1, emptybuffer, blocksize, &bytes_written, portMAX_DELAY);
				i2s_write(0, &data32b[126], 8, &bytes_written, portMAX_DELAY);			
				i2s_write(1, &data32b2[126], 8, &bytes_written, portMAX_DELAY);
			}
			//mute=0;
			
		}
		else if (IsBTConnected()==1) {
			bufferprintcount++;
			if (bufferprintcount%200==0) ESP_LOGI("i2s buffer log","%d, %d", entries(), critical);
			lastbtstate=1;
			
		
			for (int i=0; i<128; i++) {
					//data32b[i] = ((int)btbuffer[rptr])<<16;	
					data32b[i] = (int) (*(btbuffer+rptr))<<16;					
					rptr++;
					if (rptr==fifomax) rptr=0;	
			}
			
			rptrtotal += 128;
			
			if (mute < 500) mute++;
			
			float mutegain = ((float)mute)/500.0f;
			
			DoDSP(data32b, data32b2,blocksize,mutegain);			
			
									
			i2s_write(0, data32b, blocksize, &bytes_written, portMAX_DELAY);				
			i2s_write(1, data32b2, blocksize, &bytes_written, portMAX_DELAY);
				
			
			
		}
			
		 
    
    
		
	
	}


}


void aux_i2s_task_start_up(void) {

	btbuffer = (short*) malloc(fifomax*sizeof(short));
	//startup Aux Task
	if (s_aux_i2s_task_handle==NULL) { 
    xTaskCreate(aux_i2s_task_handler, "AuxI2ST", 3072, NULL, configMAX_PRIORITIES, &s_aux_i2s_task_handle);
    
    }
    

}








size_t write_ringbuf(const uint8_t *data, size_t size)
{

	short * data16 = (short *) data;
	int noinsamples = size/2;	
	
	int freefifoentries = fifomax-entries();
	//ESP_LOGE ("BT-Stream","%d in %d fifofree, w %d, r %d, entries %d",noinsamples,freefifoentries, wptr,rptr, entries()); 
	if (freefifoentries>=noinsamples) {
		for (int i=0; i<noinsamples; i++) {
			//btbuffer[wptr] = data16[i];
			*(btbuffer+wptr) =  data16[i];
			wptr++;
			if (wptr==fifomax) wptr=0;  
			//wptrtotal++;
			
		}
		wptrtotal += noinsamples;
	
	}
	else {
		if (freefifoentries%2 == 1) freefifoentries -=1;
		for (int i=0; i<freefifoentries; i++) {
           	//btbuffer[wptr] = data16[i];
			*(btbuffer+wptr) =  data16[i];
			wptr++;
			if (wptr==fifomax) wptr=0; 
			//wptrtotal++; 
			 				
        }
        wptrtotal += freefifoentries;
        ESP_LOGE("BT","skipped %d samples",noinsamples - freefifoentries); 
       
       
	}
	
	return size;

}
