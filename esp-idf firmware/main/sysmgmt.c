#include <stdio.h>
#include <string.h>
#include "sdkconfig.h"
#include "freertos/FreeRTOS.h"
#include "freertos/task.h"
#include "esp_log.h"
#include "driver/rmt.h"
#include "ir_tools.h"
#include "sysmgmt.h"
#include "server.h"
#include "dsp.h"
#include "MA120x0.h"
#include "bt_app_core.h"
#include "bt_app_av.h"
#include "esp_bt_main.h"
#include "esp_bt_device.h"
#include "esp_gap_bt_api.h"
#include "esp_a2dp_api.h"
#include "esp_avrc_api.h"

#include <rom/rtc.h>
int irparams[8];
int IsMute = 0;
int IsBluetoothActive = 0;
uint16_t bt_pair_timeout = 0;

uint32_t __attribute__((section(".rtc_noinit"))) survivedata;

static void WriteSurvive(int8_t volumein, uint8_t nextmode) {

	ESP_LOGI("sysmgmt","written vol %d",volumein);
	survivedata = (volumein<<8)|nextmode;
}

static int8_t GetSurviveVolume() {

	int8_t survivevol = (survivedata&0x0000ff00)>>8;
	ESP_LOGI("sysmgmt","read vol %d",survivevol);
	return survivevol;

}

static uint8_t GetSurviveMode() {

	return survivedata&0x000000ff;
}


static void MuteUnMute() {
	if (IsMute == 0) {
		SetMasterVolume(-100);
		IsMute=1;		
	}
	else {
		int8_t volume = GetSurviveVolume();
		SetMasterVolume(volume);
		IsMute=0;
	}
}

static void VolumeUp() {
	int8_t volume = GetSurviveVolume();
	if (volume < 30) volume += 3;
	SetMasterVolume (volume);	
	WriteSurvive(volume, GetSurviveMode());
	IsMute=0;
}

static void VolumeDown() {
	int8_t volume = GetSurviveVolume();
	if (volume>-75) volume -= 3;
	SetMasterVolume (volume);
	WriteSurvive(volume, GetSurviveMode());
	IsMute=0;
}

void SetBluetoothReady() {
	IsBluetoothActive = 1;
	
}

void SetBluetoothConnected() {
	bt_pair_timeout = 3;
	esp_bt_gap_set_scan_mode(ESP_BT_CONNECTABLE, ESP_BT_NON_DISCOVERABLE);
	gpio_set_level(14,1); 
}
static void IR_TaskHandler(void * arg) {

	rmt_channel_t example_rx_channel = RMT_CHANNEL_1;
    
    uint32_t addr = 0;
    uint32_t cmd = 0;
    uint32_t length = 0;
    bool repeat = false;
    RingbufHandle_t rb = NULL;
    rmt_item32_t *items = NULL;

    rmt_config_t rmt_rx_config = RMT_DEFAULT_CONFIG_RX(34, example_rx_channel);
    rmt_config(&rmt_rx_config);
    rmt_driver_install(example_rx_channel, 1000, 0);
    ir_parser_config_t ir_parser_config = IR_PARSER_DEFAULT_CONFIG((ir_dev_t)example_rx_channel);
    ir_parser_config.flags |= IR_TOOLS_FLAGS_PROTO_EXT; // Using extended IR protocols (both NEC and RC5 have extended version)
    ir_parser_t *ir_parser = NULL;

    ir_parser = ir_parser_rmt_new_nec(&ir_parser_config);


    //get RMT RX ringbuffer
    rmt_get_ringbuf_handle(example_rx_channel, &rb);
    assert(rb != NULL);
    // Start receive
    rmt_rx_start(example_rx_channel, true);
    
    while (1) {
        items = (rmt_item32_t *) xRingbufferReceive(rb, &length, 100);
       
        if (items) {
            length /= 4; // one RMT = 4 Bytes
            if (ir_parser->input(ir_parser, items, length) == ESP_OK) {
                if (ir_parser->get_scan_code(ir_parser, &addr, &cmd, &repeat) == ESP_OK) {
                	GetIRParams(&irparams[0],&irparams[1],&irparams[2],&irparams[3],&irparams[4],&irparams[5],&irparams[6],&irparams[7]);
                    ESP_LOGI("IR", "Scan Code %s --- addr: 0x%04x cmd: 0x%04x", repeat ? "(repeat)" : "", addr, cmd);
                    
                    
                    	SetLastIRReceived(addr, cmd);
                    	if (irparams[0]==addr && irparams[1]==cmd && repeat==0) {
                    		ESP_LOGE("SYSMGT","ONOFF");
                    		if (GetSurviveMode()!=2) {
                    			WriteSurvive(GetSurviveVolume(),2);                    			
                    			gpio_set_level(12, 0);
                    			esp_restart();
                    		}
                    		else {
                    			WriteSurvive(GetSurviveVolume(),0);
                    			esp_restart();
                    		} 	
                    	}
                    	if (irparams[2]==addr && irparams[3]==cmd && GetSurviveMode()!=2 ) {
                    		ESP_LOGE("SYSMGT","VOLUP");
                    		VolumeUp();
                    	}	
                    	if (irparams[4]==addr && irparams[5]==cmd && GetSurviveMode()!=2 ) {
                    		ESP_LOGE("SYSMGT","VOLDOWN");
                    		VolumeDown();
                    	}
                    	if (irparams[6]==addr && irparams[7]==cmd && repeat==0 && GetSurviveMode()!=2 ) {
                    		ESP_LOGE("SYSMGT", "(Un)Mute");
                    		MuteUnMute();
                    	}
                    
                    
                }
            }
            //after parsing the data, return spaces to ringbuffer.
            vRingbufferReturnItem(rb, (void *) items);
        } 
    }
    ir_parser->del(ir_parser);
    rmt_driver_uninstall(example_rx_channel);
    vTaskDelete(NULL);
    
}


static void ButtonLEDPowerTask (void * arg) {

	uint8_t emptybitmask = 0x3F;
	uint8_t currentbitmask = 0x00f;
	uint8_t lastbitmask = 0x00f;
	
	uint8_t ledblinkcounter = 0;
	uint8_t ledblinkstate = 0;
	
	
	while (1) {
		currentbitmask = (gpio_get_level(35)<<5) | (gpio_get_level(33)<<4) | (gpio_get_level(23)<<3) | (gpio_get_level(13)<<2) | (gpio_get_level(32)<<1) | gpio_get_level(17);
		
		
		if (lastbitmask == emptybitmask && currentbitmask == 0b00011111) {
			ESP_LOGI ("SW","Power Button pressed");
			if (GetSurviveMode()!=2) {
                WriteSurvive(GetSurviveVolume(),2);                
                gpio_set_level(12, 0);
                esp_restart();
            }
            else {
                WriteSurvive(GetSurviveVolume(),0);
                esp_restart();
            } 
		}
		else if (lastbitmask == emptybitmask && currentbitmask == 0b00101111 && GetSurviveMode()!=2) {
			ESP_LOGI ("SW","DSP Button pressed");
			WriteSurvive(GetSurviveVolume(),1);           
            gpio_set_level(12, 0);
            esp_restart();
		}
		else if (lastbitmask == emptybitmask && currentbitmask == 0b00110111 && GetSurviveMode()!=2) {
			ESP_LOGI ("SW","VOL UP Button pressed");
			VolumeUp();
		}
		else if (lastbitmask == emptybitmask && currentbitmask == 0b00111011 && GetSurviveMode()!=2) {
			ESP_LOGI ("SW","VOL down Button pressed");
			VolumeDown();
		}
		else if (lastbitmask == emptybitmask && currentbitmask == 0b00111101 && GetSurviveMode()!=2) {
			ESP_LOGI ("SW","mute Button pressed");
			MuteUnMute();
		}
		else if (lastbitmask == emptybitmask && currentbitmask == 0b00111110 && GetSurviveMode()!=2) {
			ESP_LOGI ("SW","pair Button pressed");
			esp_bt_gap_set_scan_mode(ESP_BT_CONNECTABLE, ESP_BT_GENERAL_DISCOVERABLE);
			bt_pair_timeout = 600;
		}
		lastbitmask = currentbitmask;
		vTaskDelay(50 / portTICK_PERIOD_MS);
		
		if (bt_pair_timeout > 0) {
				if (ledblinkstate==0) { gpio_set_level(14,1); ledblinkstate=1; }
				else { gpio_set_level(14,0); ledblinkstate=0; }
				
				bt_pair_timeout--;
				if (bt_pair_timeout == 0) {
					esp_bt_gap_set_scan_mode(ESP_BT_CONNECTABLE, ESP_BT_NON_DISCOVERABLE);
					gpio_set_level(14,1); 
				}
				
		}
		
		if (GetSurviveMode()==1) {
			ledblinkcounter++;
			if (ledblinkcounter==4) {
				ledblinkcounter=0;
				if (ledblinkstate==0) { gpio_set_level(14,1); ledblinkstate=1; }
				else { gpio_set_level(14,0); ledblinkstate=0; }
			}
		}
		
	}

}


void initSysmgmt(uint8_t * mode, uint8_t * initaudiodevice) {

	//button inputs
	gpio_config_t io_conf3;    
    io_conf3.intr_type = GPIO_INTR_DISABLE;    
    io_conf3.mode = GPIO_MODE_INPUT;
    io_conf3.pin_bit_mask = ((1ULL<<35) | (1ULL<<17)| (1ULL<<13)| (1ULL<<32)| (1ULL<<33) | (1ULL<<23));   
    io_conf3.pull_down_en = 0;
    io_conf3.pull_up_en = 0;
    gpio_config(&io_conf3);  
    
    //power led and trigger
    gpio_config_t io_conf2;    
    io_conf2.intr_type = GPIO_INTR_DISABLE;    
    io_conf2.mode = GPIO_MODE_OUTPUT;
    io_conf2.pin_bit_mask = ((1ULL<<14) | (1ULL<<15));   
    io_conf2.pull_down_en = 0;
    io_conf2.pull_up_en = 0;
    gpio_config(&io_conf2);    
	gpio_set_level(14, 0);
    gpio_set_level(15, 0);
    
    //mute and enable pin for ma120x0
    gpio_config_t io_conf;    
    io_conf.intr_type = GPIO_INTR_DISABLE;    
    io_conf.mode = GPIO_MODE_OUTPUT;
    io_conf.pin_bit_mask = ((1ULL<<21) | (1ULL<<12));   
    io_conf.pull_down_en = 0;
    io_conf.pull_up_en = 0;
    gpio_config(&io_conf);    
	gpio_set_level(21, 0);
    gpio_set_level(12, 0);
    
	xTaskCreatePinnedToCore(IR_TaskHandler, "ir_rx_task", 2048, NULL, configMAX_PRIORITIES-3, NULL,0);
	xTaskCreatePinnedToCore(ButtonLEDPowerTask, "power_task", 2048, NULL, configMAX_PRIORITIES-3, NULL,0);
	
	//12 = selfreboot
	if (rtc_get_reset_reason(0) == 12) {
		if (GetSurviveMode()==2) {
			ESP_LOGI("sysmgmt","I'm in sleep mode...");
			while (1) { vTaskDelay(1); }
		} 
		else {
			
			SetMasterVolume (GetSurviveVolume());
			
			*mode = GetSurviveMode();
			*initaudiodevice=0;
			ESP_LOGI("sysmgmt", "Start with mode %d", *mode);
			gpio_set_level(14,1);
			gpio_set_level(15,1);
		}
	}
	
	else {
		ESP_LOGI("sysmgmt", "Cold POR");
		WriteSurvive(-9, 0);
		SetMasterVolume(-9);
		
		*mode = 0;
		*initaudiodevice=1;
		gpio_set_level(14,1);
		gpio_set_level(15,1);
	}
	
}

void PowerUpMA120x0() {
	gpio_set_level(12, 1);
}
