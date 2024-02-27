#include <stdio.h>
#include "esp_log.h"
#include "driver/i2c.h"
#include "sdkconfig.h"

uint8_t i2cinitdone = 0;

static esp_err_t i2c_master_init(void)
{
    int i2c_master_port = 0;
    i2c_config_t conf;
    conf.mode = I2C_MODE_MASTER;
    conf.sda_io_num = 18;
    conf.sda_pullup_en = GPIO_PULLUP_ENABLE;
    conf.scl_io_num = 19;
    conf.scl_pullup_en = GPIO_PULLUP_ENABLE;
    conf.master.clk_speed = 100000;
    i2c_param_config(i2c_master_port, &conf);
    return i2c_driver_install(i2c_master_port, conf.mode, 0, 0, 0);
}

static esp_err_t i2c_master_write_slave(i2c_port_t i2c_num, uint8_t slave_addr, uint8_t *data_wr, size_t size)
{
    i2c_cmd_handle_t cmd = i2c_cmd_link_create();
    i2c_master_start(cmd);
    i2c_master_write_byte(cmd, (slave_addr << 1) | I2C_MASTER_WRITE, 0x1);
    i2c_master_write(cmd, data_wr, size, 0x1);
    i2c_master_stop(cmd);
    esp_err_t ret = i2c_master_cmd_begin(i2c_num, cmd, 1000 / portTICK_RATE_MS);
    i2c_cmd_link_delete(cmd);
    return ret;
}


static void MA120x0_Write(uint8_t addr, uint8_t data) {
	uint8_t i2cdat[2];
	i2cdat[0] = addr;
	i2cdat[1] = data;
	
	i2c_master_write_slave(0,0x20,i2cdat,4);

}

void InitExtAudioDevices() {

	


	i2c_master_init();
	i2cinitdone = 1;	
	
	MA120x0_Write(0x1d,0x04);
	
	
	
	
}
