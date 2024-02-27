ESP32 4CH Class-D / DSP amplifier with Bluetooth & AUX
==========================================================
This project is a 4-Channel Class-D DSP-amplifier based on a ESP32 / MA12070P chipset with Bluetooth- & AUX-input with graphical programming by a Windows tool and was designed as an alternative to all those chinese audio-boards usually designed around TPA3116 amps, ADAU1701 DSPs and Zhuhai Jieli bluetooth-IC's.<br>

After multiple requests I have finally decided to publish the whole project under [GPL-3.0 license](LICENSE).<br>
This repository contains all hardware-design, firmware-files, documentation as well as preliminary EMI compliance measurements.<br><br>


<img src=docs/mainboard_top.png width=400><img src=docs/mainboard_bot.png height=250><br>
<img src=docs/ext_board_top.png width=400><img src=docs/stackup_full.png width=400><br>
<img src=docs/tool_screenshot.png width=500>

<br><br>
     
YouTube
=======
I have uploaded two videos on my YouTube channel where I presented the project one time in general and another follow-up video doing a live-demonstration with a Bose Acoustimass 5 system. Please watch those videos to get a feeling for the project scope:<br>
[Project Description & Overview](https://youtu.be/IkDLlTarcUw)<br>
[Live Demo on Bose AM5 system](https://youtu.be/zn5gu4S4gQQ)
<br><br>

Features
========
* Bluetooth Wirless Audio & Analog Audio Input
* DSP with following features
  * Gain / Polarity / Mute / Sourceselect / Internal Mono-Summing
  * Individual Highpass / Lowpass per channel
  * 5 parametric equalizer per channel (Bell, HighShelf, LowShelf)
  * Delay up to 30ms per channel
  * Power output limiter
  * Virtual Bass Enhancement
  * Dynamic Bass Boost
* IrDA remote control receiver
  * Support to learn commands from any IR remote for basic control
* Integrated WiFi Access Point and Windows based UI software
  * Enables realtime DSP modification
  * One software-tool to configure everything (DSP, system-control, IrDA, etc..) and supports saving/loading presets as file
* Class-D amplifier with 2 channels (+2 additional channels with extension board)
  * Intergrating state-of-the-art Class-D amplifier technology based on Infineon Merus
  * 80 Watts / Channel @ 4 Ohm

Some things you should know
=======================================
* In sum I designed three board-revisions (the schematics & gerber-files in this project as well as the board shown in the YouTube videos are the latest ones)
* I also did some EMI compliance measurements based on an earlier rev2 board.
  * The radiated emission-tests (30 MHz upwards) were fine and I had met the requirements of CISPR32:2015 / DIN EN 55032.
  * There were some issues with the conducted emissions test (150 kHz - 30 MHz) with 24V/6A Meanwell reference-SMPS. It turned out that the CMC filter I used on rev2 was useless and redesigned it to a standard LC input filter on rev3. But I never did retest the rev3 for conducted emissions.
  * [I uploaded some photos](EME%20Testing%20Feb%2025th%202021) from the EMI-chamber test-setup and sprectrum-analyzer-screenshots from this test here also
* The firmware was only a proof-of-concept work for me. While it was overall in a more or less functional condition, it definitely needs some major refactoring, rework & cleanup. Not to mention that I did not document or made any comments on the code. As I was pretty new to FreeRTOS on ESP32 I also did not use the FreeRTOS probably always in the correct way as intended.
* I did not touch the uploaded code for almost three years (it was just laying around on my Dropbox) and I also didn't test it now. I cannot tell you if this code will or will not compile or function at all with current ESP-IDF version or that I might have made some changes I wanted to fix but forgot about and didn't track. Same applies for the UI tool. So just try it out & find out :)
* I have documented the protocol between the ESP and the UI-tool in the [commands.txt](commands.txt) file.
* The Gui-Tool is C# based and was developed using [SharpDevelop](https://sourceforge.net/projects/sharpdevelop/) which is a very lightweight C# development environment. It might be possible to run the UI tool also on Mac or Linux using [mono](https://www.mono-project.com/).
