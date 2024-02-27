// Copyright 2018-2019 Espressif Systems (Shanghai) PTE LTD
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


#ifndef _dsps_H_
#define _dsps_H_

#include "dsp_err.h"


#ifdef __cplusplus
extern "C"
{
#endif



esp_err_t dsps_biquad_f32_ae32(const float *input, float *output, int len, float *coef, float *w);
esp_err_t dsps_mul_f32_ae32(const float *input1, const float *input2, float *output, int len, int step1, int step2, int step_out);
esp_err_t dsps_add_f32_ae32(const float *input1, const float *input2, float *output, int len, int step1, int step2, int step_out);
esp_err_t dsps_mulc_f32_ae32(const float *input, float *output, int len, float C, int step_in, int step_out);
/**@}*/ 


#ifdef __cplusplus
}
#endif




#endif // _dsps_biquad_H_
