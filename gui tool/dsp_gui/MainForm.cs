
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using dsp_gui;
  
namespace dsp_gui
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	/// 
	 
	
	

	
	public partial class MainForm : Form
	{
		
		bool masterchange = true;
		int starttimeout = 50;
		
		int irlighttimeout = 0;
		
		//dsp params
		public int[] sourceselect = new int[4];
		
		public int[,] dsp_par_lp = new int[4,3];		
		public int[,] dsp_par_hp = new int[4,3];
		public int[,] dsp_par_eq = new int[4,15];
		
		public int[] channelgains = new int[4];
		public int[] limiterthresholds = new int[4];
		public int[] limitereleases = new int[4];
		public int[] channelmute = new int[4];
		public int[] channelpolarity = new int[4];
		public int[] channeldelay = new int[4];
		public int[] irparams = new int[8];
		public int[] vbsdata = new int[2];
		public int[] dynbassdata = new int[5];
		public int[,] channel_bypass = new int[4,7];
		public int[] global_bypass = new int[2];
		
		//TextBox[] eqfreqs = {EQ0Freq, EQ1Freq, EQ2Freq, EQ3Freq, EQ4Freq};
		//static TextBox[] eqgains = {EQ0Gain, EQ1Gain, EQ2Gain, EQ3Gain, EQ4Gain};
		//static TextBox[] eqqs = {EQ0Q, EQ1Q, EQ2Q, EQ3Q, EQ4Q};
		//static ComboBox[] eqtypes = {EQ0Type, EQ1Type, EQ2Type, EQ3Type, EQ4Type};
		int hplpeqselect = 0;
		int eqparselect = 0;		
		public int channelselect = 0;
		
		TCP_Connect connect = null; 
		DSPPlotter dsp = null;
		int maxval = 0;
		
		bool isloadingdata = false;
		
		FileSaveLoad fileop = null;
		
		LimitCalc limitcalc = null;
		
		//0=lp, 1 = hp, 2=eq
		int lphpeqselect = 0;
		
		//0 = freq, 1=q, 2=gain		
		int lphpeqtypeselect = 0;
		
		//bar
		int bar20hz = 6050;
		int bar20khz = 20000;
		
		public bool[] link = new bool[4];
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			
			InitializeComponent();
			dsp = new DSPPlotter();			
			connect = new TCP_Connect(this);			
			connect.connect("192.168.4.1",77);		
			
			fileop = new FileSaveLoad(this);
			limitcalc = new LimitCalc();
			
			dsp.StartRenderPlot();
			FirstInitElements();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void PictureBox1Click(object sender, EventArgs e)
		{
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			fileop.SaveFile();
		     				
		}
		
	
		
		
		public void lustig() {
			MessageBox.Show("Lustig");
		}
		
		void TabPage2Click(object sender, EventArgs e)
		{
			
		}
		
		
		
		void MainFormLoad(object sender, EventArgs e)
		{
						
		}
		void MainFormClose(object sender, System.ComponentModel.CancelEventArgs e)
		{
						
			connect.close();
			Environment.Exit(0);
			e.Cancel = true;
		}
		void Button6Click(object sender, EventArgs e)
		{
			
			if (connect.IsLoadingData()) return;			
			connect.StartLoadData();
			
			
			
			
		}
		
		
		
		void Label6Click(object sender, EventArgs e)
		{
			
		}
		
		void FirstInitElements() {
			
			sourceselect[0] = 0;
			sourceselect[1] = 1;
			sourceselect[2] = 0;
			sourceselect[3] = 1;
			
			dynbassdata[0] = 30;
			dynbassdata[1] = 678941;
			dynbassdata[2] = 90;
			dynbassdata[3] = 0;
			dynbassdata[4] = 10;
			
			vbsdata[0] = 80;
			vbsdata[1] = 0;
			
			for (int i=0; i<8; i++) {
				irparams[i] = 0;
			}
			
			for (int channel=0; channel<4; channel++) {
				channelgains[channel] = 0;
				limiterthresholds[channel] = 2147000000;
				limitereleases[channel] = 1000;
				channelmute[channel] = 0;
				channelpolarity[channel] = 0;
				channeldelay[channel] = 0;
				
				
				dsp_par_lp[channel,0] = 0;
				dsp_par_lp[channel,1] = 1000;
				dsp_par_lp[channel,2] = 7;
				dsp_par_hp[channel,0] = 0;
				dsp_par_hp[channel,1] = 1000;
				dsp_par_hp[channel,2] = 7;
				
				for (int eqno=0; eqno<5; eqno++) {
					dsp_par_eq[channel,eqno*3+0] = 1000;
					dsp_par_eq[channel,eqno*3+1] = 0;
					dsp_par_eq[channel,eqno*3+2] = 7;
				}
				for (int i=0;i<7;i++) {
					channel_bypass[channel,i] = 1;
				}
				
			}
			global_bypass[0]=1;
			global_bypass[1]=1;
			
			for (int i=0; i<8; i++) irparams[i]=0;
			
			Source0Select.SelectedIndex = 0;
			Source1Select.SelectedIndex = 1;
			Source2Select.SelectedIndex = 0;
			Source3Select.SelectedIndex = 1;
			
			LPOrder.SelectedIndex=0;
			HPOrder.SelectedIndex=0;
			EQ0Type.SelectedIndex=0;
			EQ1Type.SelectedIndex=0;
			EQ2Type.SelectedIndex=0;
			EQ3Type.SelectedIndex=0;
			EQ4Type.SelectedIndex=0;
			
			
			GainCH0Bar.Value=0;
			GainCH1Bar.Value=0;
			GainCH2Bar.Value=0;
			GainCH3Bar.Value=0;
			
			
			
			//init DSP Params
			
		}
		
		
		void DataBufferToUI () {
			masterchange = true;
			
			Source0Select.SelectedIndex = sourceselect[0];
			Source1Select.SelectedIndex = sourceselect[1];
			Source2Select.SelectedIndex = sourceselect[2];
			Source3Select.SelectedIndex = sourceselect[3];
			
			if (channelmute[0]==0) MuteCH0.Checked = false;
			else MuteCH0.Checked = true;			
			if (channelmute[1]==0) MuteCH1.Checked = false;
			else MuteCH1.Checked = true;			
			if (channelmute[2]==0) MuteCH2.Checked = false;
			else MuteCH2.Checked = true;			
			if (channelmute[3]==0) MuteCH3.Checked = false;
			else MuteCH3.Checked = true;
			
			if (channelpolarity[0]==0) PolCH0.Checked = false;
			else PolCH0.Checked = true;
			if (channelpolarity[1]==0) PolCH1.Checked = false;
			else PolCH1.Checked = true;
			if (channelpolarity[2]==0) PolCH2.Checked = false;
			else PolCH2.Checked = true;
			if (channelpolarity[3]==0) PolCH3.Checked = false;
			else PolCH3.Checked = true;
			
			GainCH0Bar.Value = channelgains[0];
			GainCH1Bar.Value = channelgains[1];
			GainCH2Bar.Value = channelgains[2];
			GainCH3Bar.Value = channelgains[3];
			GainCH0Text.Text = channelgains[0].ToString() + " dB";
			GainCH1Text.Text = channelgains[1].ToString() + " dB";
			GainCH2Text.Text = channelgains[2].ToString() + " dB";
			GainCH3Text.Text = channelgains[3].ToString() + " dB";
			
			HPFreq.Text = dsp_par_hp[channelselect,1].ToString();
			HPQ.Text = (((double)dsp_par_hp[channelselect,2])/10.0f).ToString();
			HPOrder.SelectedIndex = dsp_par_hp[channelselect,0];
			ChangeLPHPEQBypassColors(1, channel_bypass[channelselect,1]);
			
			LPFreq.Text = dsp_par_lp[channelselect,1].ToString();
			LPQ.Text = (((double)dsp_par_lp[channelselect,2])/10.0f).ToString();
			LPOrder.SelectedIndex = dsp_par_lp[channelselect,0];
			ChangeLPHPEQBypassColors(0, channel_bypass[channelselect,0]);
		
			
			EQ0Freq.Text = dsp_par_eq[channelselect,0*3+0].ToString();
			EQ0Gain.Text = dsp_par_eq[channelselect,0*3+1].ToString();
			EQ0Q.Text = (((double)dsp_par_eq[channelselect,0*3+2])/10.0f).ToString();
			ChangeLPHPEQBypassColors(2, channel_bypass[channelselect,2]);
			
			EQ1Freq.Text = dsp_par_eq[channelselect,1*3+0].ToString();
			EQ1Gain.Text = dsp_par_eq[channelselect,1*3+1].ToString();
			EQ1Q.Text = (((double)dsp_par_eq[channelselect,1*3+2])/10.0f).ToString();
			ChangeLPHPEQBypassColors(3, channel_bypass[channelselect,3]);
			
			EQ2Freq.Text = dsp_par_eq[channelselect,2*3+0].ToString();
			EQ2Gain.Text = dsp_par_eq[channelselect,2*3+1].ToString();
			EQ2Q.Text = (((double)dsp_par_eq[channelselect,2*3+2])/10.0f).ToString();
			ChangeLPHPEQBypassColors(4, channel_bypass[channelselect,4]);
			
			EQ3Freq.Text = dsp_par_eq[channelselect,3*3+0].ToString();
			EQ3Gain.Text = dsp_par_eq[channelselect,3*3+1].ToString();
			EQ3Q.Text = (((double)dsp_par_eq[channelselect,3*3+2])/10.0f).ToString();
			ChangeLPHPEQBypassColors(5, channel_bypass[channelselect,5]);
			
			EQ4Freq.Text = dsp_par_eq[channelselect,4*3+0].ToString();
			EQ4Gain.Text = dsp_par_eq[channelselect,4*3+1].ToString();
			EQ4Q.Text = (((double)dsp_par_eq[channelselect,4*3+2])/10.0f).ToString();
			ChangeLPHPEQBypassColors(6, channel_bypass[channelselect,6]);
			
			
					
			
			LimiterTresholdBar.Value = LimiterFullScaletodB(limiterthresholds[channelselect]);
			LimiterReleaseBar.Value = limitereleases[channelselect];
			LimitRelVal.Text = LimiterRelToMS(LimiterReleaseBar.Value).ToString() + " ms";
			LimitThresVal.Text = LimiterTresholdBar.Value.ToString()+" dB";
			
			DelayBar0.Value = channeldelay[0];
			double x = ((double)DelayBar0.Value)/100;
			DelayVal0.Text = x+ " ms";
			DelayBar1.Value = channeldelay[1];
			x = ((double)DelayBar1.Value)/100;
			DelayVal1.Text = x+ " ms";
			DelayBar2.Value = channeldelay[2];
			x = ((double)DelayBar2.Value)/100;
			DelayVal2.Text = x+ " ms";
			DelayBar3.Value = channeldelay[3];
			x = ((double)DelayBar3.Value)/100;
			DelayVal3.Text = x+ " ms";
			
			VBS_FreqBar.Value = vbsdata[0];
			VBS_FreqVal.Text = vbsdata[0].ToString() + " Hz";
			VBS_GainBar.Value = vbsdata[1];
			VBS_GainVal.Text = vbsdata[1].ToString() + " %";
			
			
			
			DynBassWatchtime_Bar.Value = dynbassdata[0];
			DynBassWatchtime_Val.Text = dynbassdata[0].ToString() + " ms";
			DynBassThres_Bar.Value = LimiterFullScaletodB(dynbassdata[1]);
			DynBassThres_Val.Text = LimiterFullScaletodB(dynbassdata[1]).ToString() + " dB";
			DynBassFreq_Bar.Value = dynbassdata[2];
			DynBassFreq_Val.Text = dynbassdata[2].ToString() + " Hz";
			
			DynBassMaxGain_Bar.Value = dynbassdata[3];
			float linval = 0.0f;
			if (DynBassMaxGain_Bar.Value == 0) {
				DynBassMaxGain_Val.Text = "Off";
			}
			else {
				 linval= 1.0f + ((float) DynBassMaxGain_Bar.Value)/10.0f;
				DynBassMaxGain_Val.Text = Math.Round(20.0f*Math.Log10(linval),1) + " dB";
			}
			
			DynBassGainSpeed_Bar.Value = dynbassdata[4];
			linval = 1.0f + ((float) DynBassGainSpeed_Bar.Value)/10.0f;
			DynBassGainSpeed_Val.Text = Math.Round(20.0f*Math.Log10(linval),1) + " dB/sec";
			
			IR_ONOFF_ADDR.Text = irparams[0].ToString();
			IR_ONOFF_CMD.Text = irparams[1].ToString();
			IR_VOLUP_ADDR.Text = irparams[2].ToString();
			IR_VOLUP_CMD.Text = irparams[3].ToString();
			IR_VOLDOWN_ADDR.Text = irparams[4].ToString();
			IR_VOLDOWN_CMD.Text = irparams[5].ToString();
			IR_MUTE_ADDR.Text = irparams[6].ToString();
			IR_MUTE_CMD.Text = irparams[7].ToString();
			
			masterchange = false;
			
		}
		
		void BlackAllEQElements() {
			HPFreq.BackColor = Color.Black;
			HPQ.BackColor = Color.Black;
			LPFreq.BackColor = Color.Black;
			LPQ.BackColor = Color.Black;
			EQ0Freq.BackColor = Color.Black;
			EQ0Gain.BackColor = Color.Black;
			EQ0Q.BackColor = Color.Black;
			EQ1Freq.BackColor = Color.Black;
			EQ1Gain.BackColor = Color.Black;
			EQ1Q.BackColor = Color.Black;
			EQ2Freq.BackColor = Color.Black;
			EQ2Gain.BackColor = Color.Black;
			EQ2Q.BackColor = Color.Black;
			EQ3Freq.BackColor = Color.Black;
			EQ3Gain.BackColor = Color.Black;
			EQ3Q.BackColor = Color.Black;
			EQ4Freq.BackColor = Color.Black;
			EQ4Gain.BackColor = Color.Black;
			EQ4Q.BackColor = Color.Black;			
			
		}
		
		void ChangeLPHPEQBypassColors(int filter, int state) {
			if (filter==0) {
				if (state==1) {
					LPBypass.BackColor = Color.Red;
					LPBypass.Text = "OFF";		
				}
				else {
					LPBypass.BackColor = Color.Lime;
					LPBypass.Text = "ON";		
				}
							
			}
			
			else if (filter==1) {
				if (state==1) {
					HPBypass.BackColor = Color.Red;
					HPBypass.Text = "OFF";		
				}
				else {
					HPBypass.BackColor = Color.Lime;
					HPBypass.Text = "ON";		
				}
			}
			
			else if (filter==2) {
				if (state==1) {
					EQ0Bypass.BackColor = Color.Red;
					EQ0Bypass.Text = "OFF";		
				}
				else {
					EQ0Bypass.BackColor = Color.Lime;
					EQ0Bypass.Text = "ON";		
				}
			}
			
			else if (filter==3) {
				if (state==1) {
					EQ1Bypass.BackColor = Color.Red;
					EQ1Bypass.Text = "OFF";		
				}
				else {
					EQ1Bypass.BackColor = Color.Lime;
					EQ1Bypass.Text = "ON";		
				}
			}
			
			else if (filter==4) {
				if (state==1) {
					EQ2Bypass.BackColor = Color.Red;
					EQ2Bypass.Text = "OFF";		
				}
				else {
					EQ2Bypass.BackColor = Color.Lime;
					EQ2Bypass.Text = "ON";		
				}
			}
			
			else if (filter==5) {
				if (state==1) {
					EQ3Bypass.BackColor = Color.Red;
					EQ3Bypass.Text = "OFF";		
				}
				else {
					EQ3Bypass.BackColor = Color.Lime;
					EQ3Bypass.Text = "ON";		
				}
			}
			
			else if (filter==6) {
				if (state==1) {
					EQ4Bypass.BackColor = Color.Red;
					EQ4Bypass.Text = "OFF";		
				}
				else {
					EQ4Bypass.BackColor = Color.Lime;
					EQ4Bypass.Text = "ON";		
				}
			}
		}
		void ConnectButtonClick(object sender, EventArgs e)
		{
			//if (connect.IsRXAvailable()) DataInterpreter(connect.RxData());		
			                     
		}
		
		void Label11Click(object sender, EventArgs e)
		{
			
		}
		
			
		
		void ConnectionTimerTick(object sender, EventArgs e)
		{
			if (starttimeout > 0) starttimeout--;
			if (starttimeout==0) masterchange=false;
			
			double[] levelinfo;
			int[] ircode;
			bool iractive;
			connect.GetLevelInformation(out levelinfo,out ircode, out iractive);
			UpdateLevelInformation(levelinfo);
			
			if (iractive) {
				irlighttimeout = 30;
				iractivityled.BackColor = Color.Lime;
				IR_RX_ADDR.Text = ircode[0].ToString();
				IR_RX_CMD.Text = ircode[1].ToString();
			}
				
			if (irlighttimeout>0) {
				irlighttimeout--;
				iractivityled.BackColor = Color.Lime;
			}
			else {
				iractivityled.BackColor = Color.Black;
			}
			if (dsp.IsRenderFinished()) pictureBox1.Image = dsp.GetPlot();
			
			
			
			if(connect.IsLoadingData()) { 
				LoadProgress.Visible = true;
				LoadProgress.Value = connect.LoadingStatus();
				isloadingdata = true;
				
			}
			if (!connect.IsLoadingData() && isloadingdata) {
				isloadingdata = false;
				DataBufferToUI();
				UpdateDSPPlotter();
				LoadProgress.Visible = false;
				
			}
			
			
			
		}
		
		
		
		void UpdateLevelInformation(double[] levelinfo) {
			int[] levelmeter = {DSPLvlToPercent(levelinfo[0]), DSPLvlToPercent(levelinfo[1]),DSPLvlToPercent(levelinfo[2]),DSPLvlToPercent(levelinfo[3]) };
			peakMeterCtrl2.SetData(levelmeter,0,4);
			//Console.WriteLine(levelinfo[4]);
			if (levelinfo[4]==1) Limiter0Show.BackColor = Color.Red;
			else Limiter0Show.BackColor = Color.Lime;
			if (levelinfo[5]==1) Limiter1Show.BackColor = Color.Red;
			else Limiter1Show.BackColor = Color.Lime;
			if (levelinfo[6]==1) Limiter2Show.BackColor = Color.Red;
			else Limiter2Show.BackColor = Color.Lime;
			if (levelinfo[7]==1) Limiter3Show.BackColor = Color.Red;
			else Limiter3Show.BackColor = Color.Lime;
			
			float DynBass = ((float)levelinfo[8])/1000.0f;
			DynBassLatestGain.Text = Math.Round(20.0f*Math.Log10(1.0f+DynBass),1).ToString() + " dB";
			
		}
		
		int map(int x, int in_min, int in_max, int out_min, int out_max)
		{
  			return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
		}
		
		int DSPLvlToPercent(double val) {
			
			if (val < -100.0f) val = -100.0f;
			int valint = (int) val;
			
			valint += 100;
			try {
				 
			}
			catch {
				
				//MessageBox.Show(val.ToString());
			}
			if (valint > 100) valint = 100;
			if (valint < 45) valint = 0;
			valint = map(valint,45,100,0,100);
			
			if (valint > maxval) {
				
				maxval = valint;
					
			}
			return  valint;
		}
		
		
		void TabChangedEventHandler(object sender, EventArgs e) {
			//if (tabControl1.SelectedIndex==1) SetDrawToLatestEQHPLP(EQChannelSelect.SelectedIndex);
		}
		
		void SetDrawToLatestEQHPLP(int newchecked) {
			
			if (Out1Draw.Checked) Out1Draw.Checked = false;
			if (Out2Draw.Checked) Out2Draw.Checked = false;
			if (Out3Draw.Checked) Out3Draw.Checked = false;
			if (Out4Draw.Checked) Out4Draw.Checked = false;
			
			if (newchecked==0) Out1Draw.Checked = true;
			if (newchecked==1) Out2Draw.Checked = true;
			if (newchecked==2) Out3Draw.Checked = true;
			if (newchecked==3) Out4Draw.Checked = true;
			
		}
		void ChangeDrawEnable() {
			if (Out1Draw.Checked == true) {
				dsp.EnabledDraw(0);
				channelselect=0;
			}
			if (Out2Draw.Checked == true) {
				dsp.EnabledDraw(1);
				channelselect=1;
			}
			if (Out3Draw.Checked == true) {
				dsp.EnabledDraw(2);
				channelselect=2;
			}
			if (Out4Draw.Checked == true) {
				dsp.EnabledDraw(3);
				channelselect=3;
			}
			
			
			UpdateLPHPEQFieldToSelectedChannel();
			dsp.StartRenderPlot();
		}
		
		void Out1DrawCheckedChanged(object sender, EventArgs e)
		{
			ChangeDrawEnable();
		}
		
		void Out2DrawCheckedChanged(object sender, EventArgs e)
		{
			ChangeDrawEnable();
		}
		
		void Out3DrawCheckedChanged(object sender, EventArgs e)
		{
			ChangeDrawEnable();
		}
		
		void Out4DrawCheckedChanged(object sender, EventArgs e)
		{
			ChangeDrawEnable();	
		}
		
		void EqFreqFieldEnterPressed(object sender, KeyEventArgs e) {
			/*
			if(masterchange) return;
			if (e.KeyCode != Keys.Enter) return;
			int n;
			if (!int.TryParse(EQFreqField.Text,out n)) {
				EQFreqField.Text = "1000";
				EQFreqBar.Value = (int) (dsp.GetXByFrequency(1000,20000)+1.0f);
				MessageBox.Show("Only numeric values allowed");
				return;	
			}
			if (n < 10 ) {
				EQFreqField.Text = "10";
				EQFreqBar.Value = (int) (dsp.GetXByFrequency(10,20000)+1.0f);
				MessageBox.Show("Value must be between 10 and 20000");
				return;	
			}			
			
			if (n > 20000) {
				EQFreqField.Text = "20000";
				EQFreqBar.Value = (int) (dsp.GetXByFrequency(20000,20000)+1.0f);
				MessageBox.Show("Value must be between 10 and 20000");
				return;	
			}	
			
			EQFreqBar.Value = (int) (dsp.GetXByFrequency(n,20000)+1.0f);
			
			e.Handled = true;
			e.SuppressKeyPress = true;
			*/
			
		}
		
		void EqGainFieldEnterPressed(object sender, KeyEventArgs e) {
			/*
			if(masterchange) return;
			if (e.KeyCode != Keys.Enter) return;
			
			int n;
			if (!int.TryParse(EQGainField.Text,out n)) {
				EQGainField.Text = "0";
				EQGainBar.Value = 0;
				MessageBox.Show("Value must be between -15 to +15");
				return;
			}
			
			if (n < -15 ) {
				EQGainField.Text = "-15";
				EQGainBar.Value = -15;
				MessageBox.Show("Value must be between -15 to +15");
				return;
			}
			
			if (n > 15 ) {
				EQGainField.Text = "15";
				EQGainBar.Value = 15;
				MessageBox.Show("Value must be between -15 to +15");
				return;
			}
			
			EQGainBar.Value = n;
			e.Handled = true;
			e.SuppressKeyPress = true;
			*/
		}
		
		void EqQFieldEnterPressed(object sender, KeyEventArgs e) {
			/*
			if(masterchange) return;
			if (e.KeyCode != Keys.Enter) return;
			
			float n;
			EQQField.Text = EQQField.Text.Replace(".",",");
			
			if (!float.TryParse(EQQField.Text, out n)) {
				EQQField.Text = "0,7";
				EQQBar.Value = 7;
				MessageBox.Show("Value must be between 0.5 and 3.0");
				return;
			}
			
			if (n < 0.5f) {
				EQQField.Text = "0,1";
				EQQBar.Value = 1;
				MessageBox.Show("Value must be between 0.5 and 3.0");
				return;
			}
			if (n > 3.0f) {
				EQQField.Text = "3";
				EQQBar.Value = 30;
				MessageBox.Show("Value must be between 0.5 and 3.0");
				return;
			}
			
			EQQBar.Value = (int) (n*10.0f);
			e.Handled = true;
			e.SuppressKeyPress = true;
			*/
		}
		
		void EQConnRequest() {
			/*
			if(masterchange) return;
			int q = 0;
			if (EQTypeSelect.SelectedIndex==0) q = EQQBar.Value;
			else q = - EQTypeSelect.SelectedIndex;
			
			if (link[EQChannelSelect.SelectedIndex]) connect.EQRequest(GetLinkBitMask(),EQNoSelect.SelectedIndex,(int) dsp.GetFrequencyByX(EQFreqBar.Value,20000),EQGainBar.Value,q);
			else connect.EQRequest(GetChannelBitMask(EQChannelSelect.SelectedIndex),EQNoSelect.SelectedIndex,(int) dsp.GetFrequencyByX(EQFreqBar.Value,20000),EQGainBar.Value,q);
			*/
			
		}
		
		
		void EQUpdateLinks() {
			/*
			int inputid = EQChannelSelect.SelectedIndex;
			int eqsel = EQNoSelect.SelectedIndex;
			int freq = (int) dsp.GetFrequencyByX(EQFreqBar.Value,20000);
			int q = EQQBar.Value;
			int gain = EQGainBar.Value;
			
			if (link[inputid]==false) return;
			else {
				for (int i=0; i<4;i++) {
					if (link[i] && inputid != i) {
						dsp_par_eq[i,eqsel*3+0] = freq;
						dsp_par_eq[i,eqsel*3+1] = EQGainBar.Value;
						if (EQTypeSelect.SelectedIndex==0) dsp_par_eq[i,eqsel*3+2] = q;
						else dsp_par_eq[i,eqsel*3+2] = -EQTypeSelect.SelectedIndex;
						
					}
				}
			}
			
			*/
		}
		void EQQBarValueChanged(object sender, decimal value)
		{
			/*
			if(masterchange) return;
			EQQField.Text = ((float)EQQBar.Value/10.0f).ToString();
			dsp_par_eq[EQChannelSelect.SelectedIndex,EQNoSelect.SelectedIndex*3+2] = EQQBar.Value;
			EQUpdateLinks();
			EQConnRequest();
			UpdateDSPPlotter();
			*/
		}
		
		//EQGainBar
		void MacTrackBar2ValueChanged(object sender, decimal value)
		{
			/*
			if(masterchange) return;
			EQGainField.Text = EQGainBar.Value.ToString();
			dsp_par_eq[EQChannelSelect.SelectedIndex,EQNoSelect.SelectedIndex*3+1] = EQGainBar.Value;
			EQUpdateLinks();
			EQConnRequest();
			UpdateDSPPlotter();
			*/
		}
		
		
		void EQFreqBarValueChanged(object sender, decimal value)
		{
			/*
			if(masterchange) return;
			int fout = (int) dsp.GetFrequencyByX(EQFreqBar.Value,20000);
			EQFreqField.Text = fout.ToString();			
			dsp_par_eq[EQChannelSelect.SelectedIndex,EQNoSelect.SelectedIndex*3+0] = fout;
			EQUpdateLinks();
			EQConnRequest();
			UpdateDSPPlotter();
			*/
		}
		
		
		void LPUpdateLinks() {
			/*
			int inputid = channelselect;
			int order = LPOrderSelect.SelectedIndex;
			int fout = (int) dsp.GetFrequencyByX(LPFreqBar.Value,20000);
			int q = LPQBar.Value;
			
			if (link[inputid]==false) return;
			else {
				for (int i=0; i<4;i++) {
					if (link[i] && inputid != i) {
						dsp_par_lp[i,0] = order;
						dsp_par_lp[i,1] = fout;
						dsp_par_lp[i,2] = q;
						
					}
				}
				
			}
			*/
		}
		
		void LPConnRequest() {
			/*
			if(masterchange) return;
			if (link[channelselect]) connect.LowPassRequest(GetLinkBitMask(),LPOrderSelect.SelectedIndex,(int) dsp.GetFrequencyByX(LPFreqBar.Value,20000),LPQBar.Value);
			else connect.LowPassRequest(GetChannelBitMask(channelselect),LPOrderSelect.SelectedIndex,(int) dsp.GetFrequencyByX(LPFreqBar.Value,20000),LPQBar.Value);
			*/
		}
		
		
		
		void HPUpdateLinks() {
			/*
			int inputid = channelselect;
			int order = HPOrderSelect.SelectedIndex;
			int fout = (int) dsp.GetFrequencyByX(HPFreqBar.Value,20000);
			int q = HPQBar.Value;
			
			if (link[inputid]==false) return;
			else {
				for (int i=0; i<4;i++) {
					if (link[i] && inputid != i) {
						dsp_par_hp[i,0] = order;
						dsp_par_hp[i,1] = fout;
						dsp_par_hp[i,2] = q;
						
					}
				}
				
			}
			*/
		}
		
		void HPConnRequest() {
			/*
			if(masterchange) return;
			if(link[channelselect]) connect.HighPassRequest(GetLinkBitMask(), HPOrderSelect.SelectedIndex,(int) dsp.GetFrequencyByX(HPFreqBar.Value,20000),HPQBar.Value);
			else connect.HighPassRequest(GetChannelBitMask(channelselect), HPOrderSelect.SelectedIndex, (int) dsp.GetFrequencyByX(HPFreqBar.Value,20000), HPQBar.Value);
		*/
		}
		
		void LPFreqBarValueChanged(object sender, decimal value)
		{
			/*
			if(masterchange) return;
			int fout = (int) dsp.GetFrequencyByX(LPFreqBar.Value,20000);
			LPFreqField.Text = fout.ToString();
			dsp_par_lp[channelselect, 1] = fout;
			LPUpdateLinks();
			LPConnRequest();
			UpdateDSPPlotter();
			*/
			
		}
		
		void HPFreqBarValueChanged(object sender, decimal value)
		{
			/*
			if(masterchange) return;
			int fout = (int) dsp.GetFrequencyByX(HPFreqBar.Value,20000);
			HPFreqField.Text = fout.ToString();
			dsp_par_hp[channelselect, 1] = fout;
			HPUpdateLinks();
			HPConnRequest();
			UpdateDSPPlotter();
			*/
		}
		
		
		void LPQBarValueChanged(object sender, decimal value)
		{
			/*
			if(masterchange) return;
			LPQField.Text = ((float)LPQBar.Value/10.0f).ToString();
			dsp_par_lp[channelselect,2] = LPQBar.Value;	
			LPUpdateLinks();
			LPConnRequest();			
			UpdateDSPPlotter();
			*/
		}
		
		void HPQBarValueChanged(object sender, decimal value)
		{
			/*
			if(masterchange) return;
			HPQField.Text = ((float)HPQBar.Value/10.0f).ToString();
			dsp_par_hp[channelselect,2] = HPQBar.Value;
			HPUpdateLinks();
			HPConnRequest();
			UpdateDSPPlotter();
			*/
		}
		
		//LP Order Select
		void ComboBox1SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*
			if(masterchange) return;
			dsp_par_lp[channelselect,0] = LPOrderSelect.SelectedIndex;
			LPUpdateLinks();
			LPConnRequest();
			UpdateDSPPlotter();
			*/
		}
		
		void HPOrderSelectSelectedIndexChanged(object sender, EventArgs e)
		{
			/*
			if(masterchange) return;
			dsp_par_hp[channelselect,0] = HPOrderSelect.SelectedIndex;
			HPUpdateLinks();
			HPConnRequest();
			UpdateDSPPlotter();	
			*/		
		}
		
		void LPFreqFieldEnterPressed(object sender, KeyEventArgs e) {
			/*
			if(masterchange) return;
			if (e.KeyCode != Keys.Enter) return;
			int n;
			if (!int.TryParse(LPFreqField.Text,out n)) {
				LPFreqField.Text = "1000";
				LPFreqBar.Value = (int) (dsp.GetXByFrequency(1000,20000)+1.0f);
				MessageBox.Show("Only numeric values allowed");
				return;	
			}
			if (n < 10 ) {
				LPFreqField.Text = "10";
				LPFreqBar.Value = (int) (dsp.GetXByFrequency(10,20000)+1.0f);
				MessageBox.Show("Value must be between 10 and 20000");
				return;	
			}			
			
			if (n > 20000) {
				LPFreqField.Text = "20000";
				LPFreqBar.Value = (int) (dsp.GetXByFrequency(20000,20000)+1.0f);
				MessageBox.Show("Value must be between 10 and 20000");
				return;	
			}	
			
			LPFreqBar.Value = (int) (dsp.GetXByFrequency(n,20000)+1.0f);
			
			e.Handled = true;
			e.SuppressKeyPress = true;
			*/
		}
		void LPQFieldEnterPressed(object sender, KeyEventArgs e) {
			/*
			if(masterchange) return;
			if (e.KeyCode != Keys.Enter) return;
			
			float n;
			LPQField.Text = LPQField.Text.Replace(".",",");
			
			if (!float.TryParse(LPQField.Text, out n)) {
				LPQField.Text = "0,7";
				LPQBar.Value = 7;
				MessageBox.Show("Value must be between 0.5 and 3.0");
				return;
			}
			
			if (n < 0.5f) {
				LPQField.Text = "0,5";
				
				LPQBar.Value = 5;
				MessageBox.Show("Value must be between 0.5 and 3.0");
				return;
			}
			if (n > 3.0f) {
				LPQField.Text = "3";
				LPQBar.Value = 30;
				MessageBox.Show("Value must be between 0.5 and 3.0");
				return;
			}
			
			LPQBar.Value = (int) (n*10.0f);
			e.Handled = true;
			e.SuppressKeyPress = true;
			*/
		}
		
		void HPFreqFieldEnterPressed(object sender, KeyEventArgs e) {
			/*
			if(masterchange) return;
			if (e.KeyCode != Keys.Enter) return;
			int n;
			if (!int.TryParse(HPFreqField.Text,out n)) {
				HPFreqField.Text = "1000";
				HPFreqBar.Value = (int) (dsp.GetXByFrequency(1000,20000)+1.0f);
				MessageBox.Show("Only numeric values allowed");
				return;	
			}
			if (n < 10 ) {
				HPFreqField.Text = "10";
				HPFreqBar.Value = (int) (dsp.GetXByFrequency(10,20000)+1.0f);
				MessageBox.Show("Value must be between 10 and 20000");
				return;	
			}			
			
			if (n > 20000) {
				HPFreqField.Text = "20000";
				HPFreqBar.Value = (int) (dsp.GetXByFrequency(20000,20000)+1.0f);
				MessageBox.Show("Value must be between 10 and 20000");
				return;	
			}	
			
			HPFreqBar.Value = (int) (dsp.GetXByFrequency(n,20000)+1.0f);
			
			e.Handled = true;
			e.SuppressKeyPress = true;
			*/
		}
		void HPQFieldEnterPressed(object sender, KeyEventArgs e) {
			/*
			if(masterchange) return;
			if (e.KeyCode != Keys.Enter) return;
			
			float n;
			HPQField.Text = HPQField.Text.Replace(".",",");
			
			if (!float.TryParse(HPQField.Text, out n)) {
				HPQField.Text = "0,7";
				HPQBar.Value = 7;
				MessageBox.Show("Value must be between 0.5 and 3.0");
				return;
			}
			
			if (n < 0.5f) {
				HPQField.Text = "0,5";
				HPQBar.Value = 5;
				MessageBox.Show("Value must be between 0.5 and 3.0");
				return;
			}
			if (n > 3.0f) {
				HPQField.Text = "3";
				HPQBar.Value = 30;
				MessageBox.Show("Value must be between 0.5 and 3.0");
				return;
			}
			
			HPQBar.Value = (int) (n*10.0f);
			e.Handled = true;
			e.SuppressKeyPress = true;
			*/
		}
		
	
		
		void EQTypeSelectSelectedIndexChanged(object sender, EventArgs e)
		{
			/*
			if(masterchange) return;
			if (EQTypeSelect.SelectedIndex == 0) {
				EQQField.Visible = true;
				EQQBar.Visible = true;
				EQQLabel.Visible = true;
				if (dsp_par_eq[EQChannelSelect.SelectedIndex,EQNoSelect.SelectedIndex*3+2] == -1 || dsp_par_eq[EQChannelSelect.SelectedIndex,EQNoSelect.SelectedIndex*3+2] == -2) {
					dsp_par_eq[EQChannelSelect.SelectedIndex,EQNoSelect.SelectedIndex*3+2] = 7;
					EQQBar.Value = 7;
				}
			}
			else {
				EQQLabel.Visible = false;
				EQQField.Visible = false;
				EQQBar.Visible = false;
				dsp_par_eq[EQChannelSelect.SelectedIndex,EQNoSelect.SelectedIndex*3+2] = -EQTypeSelect.SelectedIndex;
			}
			EQUpdateLinks();
			EQConnRequest();
			UpdateDSPPlotter();
			*/
		}
		
		
		void UpdateDSPPlotter() {
			for (int channel=0; channel<4; channel++) {
				dsp.SetHighPass(channel,dsp_par_hp[channel,0],dsp_par_hp[channel,1],dsp_par_hp[channel,2], channel_bypass[channel,1]);
				dsp.SetLowPass(channel,dsp_par_lp[channel,0],dsp_par_lp[channel,1],dsp_par_lp[channel,2], channel_bypass[channel,0]);
				
				for (int eqno=0; eqno<5; eqno++) {
					dsp.SetEQ(channel,eqno,dsp_par_eq[channel,eqno*3+0],dsp_par_eq[channel,eqno*3+1],dsp_par_eq[channel,eqno*3+2],channel_bypass[channel,2+eqno]);
				}
				                               
				
			}
			dsp.StartRenderPlot();
		}
		
		void EQNoSelectSelectedIndexChanged(object sender, EventArgs e)
		{
			/*
			if(masterchange) return;
			if (dsp_par_eq[EQChannelSelect.SelectedIndex,EQNoSelect.SelectedIndex*3+2] != -1 && dsp_par_eq[EQChannelSelect.SelectedIndex,EQNoSelect.SelectedIndex*3+2] != -2) {
				EQQField.Visible = true;
				EQQBar.Visible = true;
				EQQLabel.Visible = true;				
				EQQBar.Value = dsp_par_eq[EQChannelSelect.SelectedIndex,EQNoSelect.SelectedIndex*3+2];
				EQTypeSelect.SelectedIndex = 0;
				
			}
			else {
				EQQLabel.Visible = false;
				EQQField.Visible = false;
				EQQBar.Visible = false;
				if (dsp_par_eq[EQChannelSelect.SelectedIndex,EQNoSelect.SelectedIndex*3+2]==-1) EQTypeSelect.SelectedIndex = 1;
				if (dsp_par_eq[EQChannelSelect.SelectedIndex,EQNoSelect.SelectedIndex*3+2]==-2) EQTypeSelect.SelectedIndex = 2;
			}
			
			EQGainBar.Value = dsp_par_eq[EQChannelSelect.SelectedIndex, EQNoSelect.SelectedIndex*3+1];
			if (dsp_par_eq[EQChannelSelect.SelectedIndex, EQNoSelect.SelectedIndex*3+0]!=0) {
				EQFreqBar.Value = (int) (dsp.GetXByFrequency(dsp_par_eq[EQChannelSelect.SelectedIndex, EQNoSelect.SelectedIndex*3+0],20000)+1.0f);
			}
			
		*/
			
		}
		
		void EQChannelSelectSelectedIndexChanged(object sender, EventArgs e)
		{
			/*
			if(masterchange) return;
			EQNoSelect.SelectedIndex = 0;
			SetDrawToLatestEQHPLP(EQChannelSelect.SelectedIndex);
			EQNoSelectSelectedIndexChanged(null,null);
			*/
		}
		
		void SourceSelectUpdateLinks(int inputid, int select) {
			if (link[inputid]==false) return;
			else {
				if (link[0] && inputid != 0) Source0Select.SelectedIndex = select;
				if (link[1] && inputid != 1) Source1Select.SelectedIndex = select;
				if (link[2] && inputid != 2) Source2Select.SelectedIndex = select;
				if (link[3] && inputid != 3) Source3Select.SelectedIndex = select;
			}
		}
		
		void Source0SelectSelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(masterchange) return;
			SourceSelectUpdateLinks(0,Source0Select.SelectedIndex);
			connect.SetSourceRequest(Source0Select.SelectedIndex,Source1Select.SelectedIndex,Source2Select.SelectedIndex,Source3Select.SelectedIndex);
		}
		
		void Source1SelectSelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(masterchange) return;
			SourceSelectUpdateLinks(1,Source1Select.SelectedIndex);
			connect.SetSourceRequest(Source0Select.SelectedIndex,Source1Select.SelectedIndex,Source2Select.SelectedIndex,Source3Select.SelectedIndex);			
		}
		
		void Source2SelectSelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(masterchange) return;
			SourceSelectUpdateLinks(2,Source2Select.SelectedIndex);
			connect.SetSourceRequest(Source0Select.SelectedIndex,Source1Select.SelectedIndex,Source2Select.SelectedIndex,Source3Select.SelectedIndex);			
		}
		
		void Source3SelectSelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(masterchange) return;
			SourceSelectUpdateLinks(3,Source3Select.SelectedIndex);
			connect.SetSourceRequest(Source0Select.SelectedIndex,Source1Select.SelectedIndex,Source2Select.SelectedIndex,Source3Select.SelectedIndex);			
		}
		
		
		void MuteUpdateLinks(int inputid, bool select) {
			if (link[inputid]==false) return;
			else {
				if (link[0] && inputid != 0) MuteCH0.Checked = select;
				if (link[1] && inputid != 1) MuteCH1.Checked = select;
				if (link[2] && inputid != 2) MuteCH2.Checked = select;
				if (link[3] && inputid != 3) MuteCH3.Checked = select;
			}
		}
		void MuteCH0CheckedChanged(object sender, System.EventArgs e)
		{
			if(masterchange) return;
			MuteUpdateLinks(0,MuteCH0.Checked);
			connect.SetMuteRequest(MuteCH0.Checked,	MuteCH1.Checked, MuteCH2.Checked, MuteCH3.Checked);
		}
		void MuteCH1CheckedChanged(object sender, System.EventArgs e)
		{
			if(masterchange) return;
			MuteUpdateLinks(1,MuteCH1.Checked);
			connect.SetMuteRequest(MuteCH0.Checked,	MuteCH1.Checked, MuteCH2.Checked, MuteCH3.Checked);			
		}
		
		
		void MuteCH2CheckedChanged(object sender, System.EventArgs e)
		{
			if(masterchange) return;
			MuteUpdateLinks(2,MuteCH2.Checked);
			connect.SetMuteRequest(MuteCH0.Checked,	MuteCH1.Checked, MuteCH2.Checked, MuteCH3.Checked);			
		}
		
		void MuteCH3CheckedChanged(object sender, System.EventArgs e)
		{
			if(masterchange) return;
			MuteUpdateLinks(3,MuteCH3.Checked);
			connect.SetMuteRequest(MuteCH0.Checked,	MuteCH1.Checked, MuteCH2.Checked, MuteCH3.Checked);			
		}
		
		
		void PolUpdateLinks(int inputid, bool select) {
			if (link[inputid]==false) return;
			else {
				if (link[0] && inputid != 0) PolCH0.Checked = select;
				if (link[1] && inputid != 1) PolCH1.Checked = select;
				if (link[2] && inputid != 2) PolCH2.Checked = select;
				if (link[3] && inputid != 3) PolCH3.Checked = select;
			}
		}
			
		void PolCH0CheckedChanged(object sender, System.EventArgs e)
		{
			if(masterchange) return;
			PolUpdateLinks(0,PolCH0.Checked);
			connect.SetPolarityRequest(PolCH0.Checked,PolCH1.Checked,PolCH2.Checked,PolCH3.Checked);
		}
		
		void PolCH1CheckedChanged(object sender, System.EventArgs e)
		{
			if(masterchange) return;
			PolUpdateLinks(1,PolCH1.Checked);
			connect.SetPolarityRequest(PolCH0.Checked,PolCH1.Checked,PolCH2.Checked,PolCH3.Checked);			
		}
		
		void PolCH2CheckedChanged(object sender, System.EventArgs e)
		{
			if(masterchange) return;
			PolUpdateLinks(2,PolCH2.Checked);
			connect.SetPolarityRequest(PolCH0.Checked,PolCH1.Checked,PolCH2.Checked,PolCH3.Checked);			
		}
		
		void PolCH3CheckedChanged(object sender, System.EventArgs e)
		{
			if(masterchange) return;
			PolUpdateLinks(3,PolCH3.Checked);
			connect.SetPolarityRequest(PolCH0.Checked,PolCH1.Checked,PolCH2.Checked,PolCH3.Checked);			
		}
		
		
		void GainUpdateLinks(int inputid, int val) {
			if (link[inputid]==false) return;
			else {
				if (link[0] && inputid != 0) {
					GainCH0Bar.Value = val;
					GainCH0Text.Text = GainCH0Bar.Value.ToString()+ " dB";
				}
				if (link[1] && inputid != 1) {
					GainCH1Bar.Value = val;
					GainCH1Text.Text = GainCH1Bar.Value.ToString()+ " dB";	
				}
				if (link[2] && inputid != 2) {
					GainCH2Bar.Value = val;
					GainCH2Text.Text = GainCH2Bar.Value.ToString()+ " dB";	
				}
				if (link[3] && inputid != 3) {
					GainCH3Bar.Value = val;
					GainCH3Text.Text = GainCH3Bar.Value.ToString()+ " dB";	
				}
			}
		}
		
						
		
		void Link0CheckedChanged(object sender, EventArgs e)
		{
			link[0] = Link0.Checked;
		}
		
		void Link1CheckedChanged(object sender, EventArgs e)
		{
			link[1] = Link1.Checked;
		}
		
		void Link2CheckedChanged(object sender, EventArgs e)
		{
			link[2] = Link2.Checked;
		}
		
		void Link3CheckedChanged(object sender, EventArgs e)
		{
			link[3] = Link3.Checked;
		}
		
		
		int GetLinkBitMask() {
			int val = 0;
			if (link[0]) val += 1;
			if (link[1]) val += 2;
			if (link[2]) val += 4;
			if (link[3]) val += 8;
			//Console.WriteLine(val.ToString());
			return val;
		}
		public int GetChannelBitMask(int ch) {
			//Console.WriteLine(ch.ToString());
			if (ch==0) return 1;
			if (ch==1) return 2;
			if (ch==2) return 4;
			if (ch==3) return 8;
			return 0;
		}
		
		void GainCH0BarValueChanged(object sender, decimal value)
		{
			if(masterchange) return;
			GainUpdateLinks(0,GainCH0Bar.Value);
			GainCH0Text.Text = GainCH0Bar.Value.ToString()+ " dB";
			connect.SetGainRequest(GainCH0Bar.Value, GainCH1Bar.Value, GainCH2Bar.Value, GainCH3Bar.Value);
		}
		
		void GainCH1BarValueChanged(object sender, decimal value)
		{
			if(masterchange) return;
			GainUpdateLinks(1,GainCH1Bar.Value);
			GainCH1Text.Text = GainCH1Bar.Value.ToString()+ " dB";		
			connect.SetGainRequest(GainCH0Bar.Value, GainCH1Bar.Value, GainCH2Bar.Value, GainCH3Bar.Value);	
		}
		
		void GainCH2BarValueChanged(object sender, decimal value)
		{
			if(masterchange) return;
			GainUpdateLinks(2,GainCH2Bar.Value);
			GainCH2Text.Text = GainCH2Bar.Value.ToString()+ " dB";	
			connect.SetGainRequest(GainCH0Bar.Value, GainCH1Bar.Value, GainCH2Bar.Value, GainCH3Bar.Value);				
		}
		
		void GainCH3BarValueChanged(object sender, decimal value)
		{
			if(masterchange) return;
			GainUpdateLinks(3,GainCH3Bar.Value);
			GainCH3Text.Text = GainCH3Bar.Value.ToString()+ " dB";	
			connect.SetGainRequest(GainCH0Bar.Value, GainCH1Bar.Value, GainCH2Bar.Value, GainCH3Bar.Value);	
		}
		
		void LimiterUpdateLinks(int inputid) {
			if (link[inputid]==false) return;
			else {
				if (link[0] && inputid != 0) {
					limiterthresholds[0] = limiterthresholds[inputid];
					limitereleases[0] = limitereleases[inputid];
					
				}
				if (link[1] && inputid != 1) {
					limiterthresholds[1] = limiterthresholds[inputid];
					limitereleases[1] = limitereleases[inputid];
				}
				if (link[2] && inputid != 2) {
					limiterthresholds[2] = limiterthresholds[inputid];
					limitereleases[2] = limitereleases[inputid];
				}
				if (link[3] && inputid != 3) {
					limiterthresholds[3] = limiterthresholds[inputid];
					limitereleases[3] = limitereleases[inputid];
				}
			}
		}
		
	
		int LimiterRelToMS(int val) {
			return (val*64*1000)/46060;
		}
		void LimiterBar0ValueChanged(object sender, decimal value)
		{
			if(masterchange) return;
			limiterthresholds[channelselect] = LimiterdBtoFullScale(LimiterTresholdBar.Value);
			LimiterUpdateLinks(channelselect);
			LimitThresVal.Text = LimiterTresholdBar.Value.ToString()+" dB";
			
			int val = LimiterdBtoFullScale (LimiterTresholdBar.Value);
			float valf = (float) val;
				
			float ampvoltage = 	valf*1.254575838479479e-8f;
			float ampvoltagerms = ampvoltage/1.4142f;
			
			float power8ohm = ampvoltagerms*ampvoltagerms/8.0f;
			float power4ohm = ampvoltagerms*ampvoltagerms/4.0f;
			if (power8ohm < 0.01f) ampoutvoltage.Text = "Amp Output: " + Math.Round((double)ampvoltage,3) + "V (PEAK) | "+Math.Round((double)ampvoltagerms,3)+"V (RMS) | " + Math.Round((double)power4ohm,4)+ "W @ 4 Ohms | " + Math.Round((double)power8ohm,4)+ "W @ 8 Ohms";
			else ampoutvoltage.Text = "Amp Output: " + Math.Round((double)ampvoltage,2) + "V (PEAK) | "+Math.Round((double)ampvoltagerms,2)+"V (RMS) | " + Math.Round((double)power4ohm,2)+ "W @ 4 Ohms | " + Math.Round((double)power8ohm,2)+ "W @ 8 Ohms";
			
			connect.SetLimiterRequest(limiterthresholds[0],limiterthresholds[1],limiterthresholds[2],limiterthresholds[3], limitereleases[0],limitereleases[1],limitereleases[2],limitereleases[3]);
		
		}
	
		void LimiterReleaseBarValueChanged(object sender, decimal value)
		{
			if (masterchange) return;
			limitereleases[channelselect] = LimiterReleaseBar.Value;
			LimiterUpdateLinks(channelselect);
			LimitRelVal.Text = LimiterRelToMS(LimiterReleaseBar.Value).ToString() + " ms";
			connect.SetLimiterRequest(limiterthresholds[0],limiterthresholds[1],limiterthresholds[2],limiterthresholds[3], limitereleases[0],limitereleases[1],limitereleases[2],limitereleases[3]);
		
			
		}
		
		int LimiterdBtoFullScale(int val) {
			
			double valf = (double) val;
			valf = Math.Pow(10.0f,valf/20.0f)*2147000000.0f;			
			return (int) valf;
		}
		int LimiterFullScaletodB(int val) {
			double valf = (double) val;
			return (int) (20.0f*Math.Log10(valf/2147000000.0f));
		}
		
		
		void DelayUpdateLinks(int inputid, int val) {
			if (link[inputid]==false) return;
			else {
				double x=0.0f;
				if (link[0] && inputid != 0) {
					DelayBar0.Value = val;
					x = ((double)DelayBar0.Value)/100;
					DelayVal0.Text = x+ " ms";
				}
				if (link[1] && inputid != 1) {
					DelayBar1.Value = val;
					x = ((double)DelayBar1.Value)/100;
					DelayVal1.Text = x+ " ms";
				}
				if (link[2] && inputid != 2) {
					DelayBar2.Value = val;
					x = ((double)DelayBar2.Value)/100;
					DelayVal2.Text = x+ " ms";
				}
				if (link[3] && inputid != 3) {
					DelayBar3.Value = val;
					x = ((double)DelayBar3.Value)/100;
					DelayVal3.Text = x+ " ms";
				}
			}			
		}
		void DelayBar0ValueChanged(object sender, decimal value)
		{
			if(masterchange) return;
			DelayUpdateLinks(0,DelayBar0.Value);
			double x = ((double)DelayBar0.Value)/100;
			DelayVal0.Text = x+ " ms";
			connect.SetDelayRequest(DelayBar0.Value,DelayBar1.Value,DelayBar2.Value,DelayBar3.Value);
			
		}
		
		void DelayBar1ValueChanged(object sender, decimal value)
		{
			if(masterchange) return;
			DelayUpdateLinks(1,DelayBar1.Value);
			double x = ((double)DelayBar1.Value)/100;
			DelayVal1.Text = x+ " ms";
			connect.SetDelayRequest(DelayBar0.Value,DelayBar1.Value,DelayBar2.Value,DelayBar3.Value);
		}
		
		void DelayBar2ValueChanged(object sender, decimal value)
		{
			if(masterchange) return;
			DelayUpdateLinks(2,DelayBar2.Value);
			double x = ((double)DelayBar2.Value)/100;
			DelayVal2.Text = x+ " ms";	
			connect.SetDelayRequest(DelayBar0.Value,DelayBar1.Value,DelayBar2.Value,DelayBar3.Value);			
		}
		
		void DelayBar3ValueChanged(object sender, decimal value)
		{
			if(masterchange) return;
			DelayUpdateLinks(3,DelayBar3.Value);
			DelayVal3.Text = DelayBar3.Value.ToString()+ " cm";	
			double x = ((double)DelayBar3.Value)/100;
			DelayVal3.Text = x+ " ms";
			connect.SetDelayRequest(DelayBar0.Value,DelayBar1.Value,DelayBar2.Value,DelayBar3.Value);			
		}
		
		
		
		void Label24Click(object sender, EventArgs e)
		{
			
		}
		
		void VBS_FreqBarValueChanged(object sender, decimal value)
		{
			if(masterchange) return;
			VBS_FreqVal.Text = VBS_FreqBar.Value.ToString()+" Hz";
			connect.SetBassEnhanceRequest(VBS_FreqBar.Value,VBS_GainBar.Value);
		}
		
		void VBS_GainBarValueChanged(object sender, decimal value)
		{
			if(masterchange) return;
			VBS_GainVal.Text = VBS_GainBar.Value.ToString()+" %";
			connect.SetBassEnhanceRequest(VBS_FreqBar.Value,VBS_GainBar.Value);
		}
		
		
		
		void DynBassGainSpeed_BarValueChanged(object sender, decimal value)
		{
			if(masterchange) return;
			float linval = 1.0f + ((float) DynBassGainSpeed_Bar.Value)/10.0f;
			DynBassGainSpeed_Val.Text = Math.Round(20.0f*Math.Log10(linval),1) + " dB/sec";
			connect.SetDynBassRequest(DynBassWatchtime_Bar.Value,LimiterdBtoFullScale(DynBassThres_Bar.Value),DynBassFreq_Bar.Value,DynBassMaxGain_Bar.Value,DynBassGainSpeed_Bar.Value);
		}
		
		void DynBassMaxGain_BarValueChanged(object sender, decimal value)
		{
			if(masterchange) return;
			if (DynBassMaxGain_Bar.Value == 0) {
				DynBassMaxGain_Val.Text = "Off";
			}
			else {
				float linval = 1.0f + ((float) DynBassMaxGain_Bar.Value)/10.0f;
				DynBassMaxGain_Val.Text = Math.Round(20.0f*Math.Log10(linval),1) + " dB";
			}
			connect.SetDynBassRequest(DynBassWatchtime_Bar.Value,LimiterdBtoFullScale(DynBassThres_Bar.Value),DynBassFreq_Bar.Value,DynBassMaxGain_Bar.Value,DynBassGainSpeed_Bar.Value);
		}
		
		void DynBassThres_BarValueChanged(object sender, decimal value)
		{
			if(masterchange) return;
			DynBassThres_Val.Text = DynBassThres_Bar.Value.ToString() + " dB";
			connect.SetDynBassRequest(DynBassWatchtime_Bar.Value,LimiterdBtoFullScale(DynBassThres_Bar.Value),DynBassFreq_Bar.Value,DynBassMaxGain_Bar.Value,DynBassGainSpeed_Bar.Value);
			
		}
		
		void DynBassWatchtime_BarValueChanged(object sender, decimal value)
		{
			if(masterchange) return;
			DynBassWatchtime_Val.Text = DynBassWatchtime_Bar.Value + " ms";	
			connect.SetDynBassRequest(DynBassWatchtime_Bar.Value,LimiterdBtoFullScale(DynBassThres_Bar.Value),DynBassFreq_Bar.Value,DynBassMaxGain_Bar.Value,DynBassGainSpeed_Bar.Value);			
		}
		
		void DynBassFreq_BarValueChanged(object sender, decimal value)
		{
			if(masterchange) return;
			DynBassFreq_Val.Text = DynBassFreq_Bar.Value + " Hz";
			connect.SetDynBassRequest(DynBassWatchtime_Bar.Value,LimiterdBtoFullScale(DynBassThres_Bar.Value),DynBassFreq_Bar.Value,DynBassMaxGain_Bar.Value,DynBassGainSpeed_Bar.Value);			
		}
		
		void GroupBox5Enter(object sender, EventArgs e)
		{
			
		}
		
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			connect.SetPollLevels(checkBox1.Checked);
		}
		
		
		void IRNetRequest() {
			if (masterchange) return;
			connect.IRRequest (
				int.Parse(IR_ONOFF_ADDR.Text),
				int.Parse(IR_ONOFF_CMD.Text),
				int.Parse(IR_VOLUP_ADDR.Text),
				int.Parse(IR_VOLUP_CMD.Text),
				int.Parse(IR_VOLDOWN_ADDR.Text),
				int.Parse(IR_VOLDOWN_CMD.Text),
				int.Parse(IR_MUTE_ADDR.Text),
				int.Parse(IR_MUTE_CMD.Text)
			);
			
		}
		void IR_ONOFF_PASTEClick(object sender, EventArgs e)
		{
			IR_ONOFF_ADDR.Text = IR_RX_ADDR.Text;
			IR_ONOFF_CMD.Text = IR_RX_CMD.Text;
			IRNetRequest();
		}
		
		void IR_MUTE_PASTEClick(object sender, EventArgs e)
		{
			IR_MUTE_ADDR.Text = IR_RX_ADDR.Text;
			IR_MUTE_CMD.Text = IR_RX_CMD.Text;
			IRNetRequest();
		}
		
		void IR_VOLUP_PASTEClick(object sender, EventArgs e)
		{
			IR_VOLUP_ADDR.Text = IR_RX_ADDR.Text;
			IR_VOLUP_CMD.Text = IR_RX_CMD.Text;
			IRNetRequest();
		}
		
		void IR_VOLDOWN_PASTEClick(object sender, EventArgs e)
		{
			IR_VOLDOWN_ADDR.Text = IR_RX_ADDR.Text;
			IR_VOLDOWN_CMD.Text = IR_RX_CMD.Text;
			IRNetRequest();
		}
		
		void Button7Click(object sender, EventArgs e)
		{
			connect.ResetAllRequest();
			FirstInitElements();
			DataBufferToUI();
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			connect.SaveSettingsRequest();
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			if (connect.IsLoadingData()) return;			
			string[] filedata;
			if (fileop.LoadFile(out filedata)) {
				connect.ExecuteCMDs(filedata);
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			limitcalc.ShowDialog();
		}
		
		void Label35Click(object sender, EventArgs e)
		{
			
		}
		
		void Label12Click(object sender, EventArgs e)
		{
			
		}
		
		
		
		
		
		
		
		
		
		void Label45Click(object sender, EventArgs e)
		{
			
		}
		
		void Label50Click(object sender, EventArgs e)
		{
			
		}
		
		void TextBox6TextChanged(object sender, EventArgs e)
		{
			
		}
		
		void EqFieldEnterPressed(object sender, KeyEventArgs e) {
			
		}
		
		void UpdateLPHPEQFieldToSelectedChannel() {
			LPBypassButtonUpdateColor();
			HPBypassButtonUpdateColor();
			EQ0BypassButtonUpdateColor();
			EQ1BypassButtonUpdateColor();
			EQ2BypassButtonUpdateColor();
			EQ3BypassButtonUpdateColor();
			EQ4BypassButtonUpdateColor();
			LPFreq.Text = dsp_par_lp[channelselect,1].ToString();
			LPQ.Text = ((float)dsp_par_lp[channelselect,2]/10.0f).ToString();
			LPOrder.SelectedIndex = dsp_par_lp[channelselect,0];
			
			HPFreq.Text = dsp_par_hp[channelselect,1].ToString();
			HPQ.Text = ((float)dsp_par_hp[channelselect,2]/10.0f).ToString();
			HPOrder.SelectedIndex = dsp_par_hp[channelselect,0];
			
			
			int eqnum = 0;
			EQ0Freq.Text = dsp_par_eq[channelselect,eqnum*3+0].ToString();
			EQ0Q.Visible = true;
			if (dsp_par_eq[channelselect,eqnum*3+2]>0) {
				EQ0Type.SelectedIndex = 0;
				EQ0Q.Visible = true;
			}
			else {
				EQ0Type.SelectedIndex = -dsp_par_eq[channelselect,eqnum*3+2];
				EQ0Q.Visible = false;
			}
			EQ0Q.Text = ((float)dsp_par_eq[channelselect,eqnum*3+2]/10.0f).ToString();
			EQ0Gain.Text = 	dsp_par_eq[channelselect,eqnum*3+1].ToString();
			if (dsp_par_eq[channelselect,eqnum*3+2]<0) {
				EQ0Q.Visible = false;
				EQ0Type.SelectedIndex = -dsp_par_eq[channelselect,eqnum*3+2];
			}
			
			eqnum = 1;
			EQ1Freq.Text = dsp_par_eq[channelselect,eqnum*3+0].ToString();
			EQ1Q.Visible = true;
			if (dsp_par_eq[channelselect,eqnum*3+2]>0) {
				EQ1Type.SelectedIndex = 0;
				EQ1Q.Visible = true;
			}
			else {
				EQ1Type.SelectedIndex = -dsp_par_eq[channelselect,eqnum*3+2];
				EQ1Q.Visible = false;
			}
			EQ1Q.Text = ((float)dsp_par_eq[channelselect,eqnum*3+2]/10.0f).ToString();
			EQ1Gain.Text = 	dsp_par_eq[channelselect,eqnum*3+1].ToString();
			if (dsp_par_eq[channelselect,eqnum*3+2]<0) {
				EQ1Q.Visible = false;
				EQ1Type.SelectedIndex = -dsp_par_eq[channelselect,eqnum*3+2];
			}
			
			eqnum = 2;
			EQ2Freq.Text = dsp_par_eq[channelselect,eqnum*3+0].ToString();
			EQ2Q.Visible = true;
			if (dsp_par_eq[channelselect,eqnum*3+2]>0) {
				EQ2Type.SelectedIndex = 0;
				EQ2Q.Visible = true;
			}
			else {
				EQ2Type.SelectedIndex = -dsp_par_eq[channelselect,eqnum*3+2];
				EQ2Q.Visible = false;
			}
			
			EQ2Q.Text = ((float)dsp_par_eq[channelselect,eqnum*3+2]/10.0f).ToString();
			EQ2Gain.Text = 	dsp_par_eq[channelselect,eqnum*3+1].ToString();
			if (dsp_par_eq[channelselect,eqnum*3+2]<0) {
				EQ2Q.Visible = false;
				EQ2Type.SelectedIndex = -dsp_par_eq[channelselect,eqnum*3+2];
			}
			
			eqnum = 3;
			EQ3Freq.Text = dsp_par_eq[channelselect,eqnum*3+0].ToString();
			EQ3Q.Visible = true;
			if (dsp_par_eq[channelselect,eqnum*3+2]>0) {
				EQ3Type.SelectedIndex = 0;
				EQ3Q.Visible = true;
			}
			else {
				EQ3Type.SelectedIndex = -dsp_par_eq[channelselect,eqnum*3+2];
				EQ3Q.Visible = false;
			}
			EQ3Q.Text = ((float)dsp_par_eq[channelselect,eqnum*3+2]/10.0f).ToString();
			EQ3Gain.Text = 	dsp_par_eq[channelselect,eqnum*3+1].ToString();
			if (dsp_par_eq[channelselect,eqnum*3+2]<0) {
				EQ3Q.Visible = false;
				EQ3Type.SelectedIndex = -dsp_par_eq[channelselect,eqnum*3+2];
			}
			
			eqnum = 4;
			EQ4Freq.Text = dsp_par_eq[channelselect,eqnum*3+0].ToString();
			EQ4Q.Visible = true;
			if (dsp_par_eq[channelselect,eqnum*3+2]>0) {
				EQ4Type.SelectedIndex = 0;
				EQ4Q.Visible = true;
			}
			else {
				EQ4Type.SelectedIndex = -dsp_par_eq[channelselect,eqnum*3+2];
				EQ4Q.Visible = false;
			}
			EQ4Q.Text = ((float)dsp_par_eq[channelselect,eqnum*3+2]/10.0f).ToString();
			EQ4Gain.Text = 	dsp_par_eq[channelselect,eqnum*3+1].ToString();
			if (dsp_par_eq[channelselect,eqnum*3+2]<0) {
				EQ4Q.Visible = false;
				EQ4Type.SelectedIndex = -dsp_par_eq[channelselect,eqnum*3+2];
			}
			
			
			
			LimiterTresholdBar.Value = LimiterFullScaletodB(limiterthresholds[channelselect]);
			LimiterReleaseBar.Value = limitereleases[channelselect];
			LimitRelVal.Text = LimiterRelToMS(LimiterReleaseBar.Value).ToString() + " ms";
			LimitThresVal.Text = LimiterTresholdBar.Value.ToString()+" dB";
			
			
		}
		
		
		
		void LPFreqClicked(object sender, EventArgs e ) {
			BlackAllEQElements();
			LPFreq.BackColor=Color.Gray;
			lphpeqselect = 0;
			lphpeqtypeselect = 0;
			lphpeqbar.Minimum = bar20hz;
			lphpeqbar.Maximum = bar20khz;
			lphpeqbar.Value = (int) Math.Round(dsp.GetXByFrequency(dsp_par_lp[channelselect,1],20000));
			LPFreq.SelectAll();
			
		}
		void LPQClicked(object sender, EventArgs e ) {
			BlackAllEQElements();
			LPQ.BackColor=Color.Gray;
			lphpeqselect = 0;
			lphpeqtypeselect = 1;
			lphpeqbar.Minimum = 5;
			lphpeqbar.Maximum = 30;
			lphpeqbar.Value = dsp_par_lp[channelselect,2];
			LPQ.SelectAll();
			
		}
		void HPFreqClicked(object sender, EventArgs e ) {
			BlackAllEQElements();
			HPFreq.BackColor = Color.Gray;
			lphpeqselect = 1;
			lphpeqtypeselect = 0;
			lphpeqbar.Minimum = bar20hz;
			lphpeqbar.Maximum = bar20khz;
			lphpeqbar.Value = (int) Math.Round(dsp.GetXByFrequency(dsp_par_hp[channelselect,1],20000));
			HPFreq.SelectAll();
		}
		void HPQClicked(object sender, EventArgs e ) {
			BlackAllEQElements();
			HPQ.BackColor = Color.Gray;
			lphpeqselect = 1;
			lphpeqtypeselect = 1;
			lphpeqbar.Minimum = 5;
			lphpeqbar.Maximum = 30;
			lphpeqbar.Value = dsp_par_hp[channelselect,2];
			HPQ.SelectAll();
		}
		
		void EQ0FreqClicked(object sender, EventArgs e ) {
			BlackAllEQElements();
			EQ0Freq.BackColor = Color.Gray;
			lphpeqselect = 2;
			lphpeqtypeselect = 0;
			lphpeqbar.Minimum = bar20hz;
			lphpeqbar.Maximum = bar20khz;
			lphpeqbar.Value = (int) Math.Round(dsp.GetXByFrequency(dsp_par_eq[channelselect,0*3+0],20000));
			EQ0Freq.SelectAll();
			
			
		}
		void EQ1FreqClicked(object sender, EventArgs e ) {
			BlackAllEQElements();
			EQ1Freq.BackColor = Color.Gray;
			lphpeqselect = 3;
			lphpeqtypeselect = 0;
			lphpeqbar.Minimum = bar20hz;
			lphpeqbar.Maximum = bar20khz;
			lphpeqbar.Value = (int) Math.Round(dsp.GetXByFrequency(dsp_par_eq[channelselect,1*3+0],20000));
			EQ1Freq.SelectAll();
		}
		
		void EQ2FreqClicked(object sender, EventArgs e ) {
			BlackAllEQElements();
			EQ2Freq.BackColor = Color.Gray;
			lphpeqselect = 4;
			lphpeqtypeselect = 0;
			lphpeqbar.Minimum = bar20hz;
			lphpeqbar.Maximum = bar20khz;
			lphpeqbar.Value = (int) Math.Round(dsp.GetXByFrequency(dsp_par_eq[channelselect,2*3+0],20000));
			EQ2Freq.SelectAll();
		}
		void EQ3FreqClicked(object sender, EventArgs e ) {
			BlackAllEQElements();
			EQ3Freq.BackColor = Color.Gray;
			lphpeqselect = 5;
			lphpeqtypeselect = 0;
			lphpeqbar.Minimum = bar20hz;
			lphpeqbar.Maximum = bar20khz;
			lphpeqbar.Value = (int) Math.Round(dsp.GetXByFrequency(dsp_par_eq[channelselect,3*3+0],20000));
			EQ3Freq.SelectAll();
		}
		void EQ4FreqClicked(object sender, EventArgs e ) {
			BlackAllEQElements();
			EQ4Freq.BackColor = Color.Gray;
			lphpeqselect = 6;
			lphpeqtypeselect = 0;
			lphpeqbar.Minimum = bar20hz;
			lphpeqbar.Maximum = bar20khz;
			lphpeqbar.Value = (int) Math.Round(dsp.GetXByFrequency(dsp_par_eq[channelselect,4*3+0],20000));
			EQ4Freq.SelectAll();
		}
		
		void EQ0GainClicked(object sender, EventArgs e ) {
			BlackAllEQElements();
			EQ0Gain.BackColor = Color.Gray;
			lphpeqselect = 2;
			lphpeqtypeselect = 2;
			lphpeqbar.Minimum = -15;
			lphpeqbar.Maximum = +15;
			lphpeqbar.Value = dsp_par_eq[channelselect,0*3+1];
			EQ0Gain.SelectAll();
		}
		void EQ1GainClicked(object sender, EventArgs e ) {
			BlackAllEQElements();
			EQ1Gain.BackColor = Color.Gray;
			lphpeqselect = 3;
			lphpeqtypeselect = 2;
			lphpeqbar.Minimum = -15;
			lphpeqbar.Maximum = +15;
			lphpeqbar.Value = dsp_par_eq[channelselect,1*3+1];
			EQ1Gain.SelectAll();
		}
		void EQ2GainClicked(object sender, EventArgs e ) {
			BlackAllEQElements();
			EQ2Gain.BackColor = Color.Gray;
			lphpeqselect = 4;
			lphpeqtypeselect = 2;
			lphpeqbar.Minimum = -15;
			lphpeqbar.Maximum = +15;
			lphpeqbar.Value = dsp_par_eq[channelselect,2*3+1];
			EQ2Gain.SelectAll();
		}
		void EQ3GainClicked(object sender, EventArgs e ) {
			BlackAllEQElements();
			EQ3Gain.BackColor = Color.Gray;
			lphpeqselect = 5;
			lphpeqtypeselect = 2;
			lphpeqbar.Minimum = -15;
			lphpeqbar.Maximum = +15;
			lphpeqbar.Value = dsp_par_eq[channelselect,3*3+1];
			EQ3Gain.SelectAll();
		}
		void EQ4GainClicked(object sender, EventArgs e ) {
			BlackAllEQElements();
			EQ4Gain.BackColor = Color.Gray;
			lphpeqselect = 6;
			lphpeqtypeselect = 2;
			lphpeqbar.Minimum = -15;
			lphpeqbar.Maximum = +15;
			lphpeqbar.Value = dsp_par_eq[channelselect,4*3+1];
			EQ4Gain.SelectAll();
		}
		
		void EQ0QClicked(object sender, EventArgs e ) {
			BlackAllEQElements();
			EQ0Q.BackColor = Color.Gray;
			lphpeqselect = 2;
			lphpeqtypeselect = 1;
			lphpeqbar.Minimum = 5;
			lphpeqbar.Maximum = 100;
			lphpeqbar.Value = dsp_par_eq[channelselect,0*3+2];
			EQ0Q.SelectAll();
		}
		void EQ1QClicked(object sender, EventArgs e ) {
			BlackAllEQElements();
			EQ1Q.BackColor = Color.Gray;
			lphpeqselect = 3;
			lphpeqtypeselect = 1;
			lphpeqbar.Minimum = 5;
			lphpeqbar.Maximum = 100;
			lphpeqbar.Value = dsp_par_eq[channelselect,1*3+2];
			EQ1Q.SelectAll();
		}
		void EQ2QClicked(object sender, EventArgs e ) {
			BlackAllEQElements();
			EQ2Q.BackColor = Color.Gray;
			lphpeqselect = 4;
			lphpeqtypeselect = 1;
			lphpeqbar.Minimum = 5;
			lphpeqbar.Maximum = 100;
			lphpeqbar.Value = dsp_par_eq[channelselect,2*3+2];
			EQ2Q.SelectAll();
		}
		void EQ3QClicked(object sender, EventArgs e ) {
			BlackAllEQElements();
			EQ3Q.BackColor = Color.Gray;
			lphpeqselect = 5;
			lphpeqtypeselect = 1;
			lphpeqbar.Minimum = 5;
			lphpeqbar.Maximum = 100;
			lphpeqbar.Value = dsp_par_eq[channelselect,3*3+2];
			EQ3Q.SelectAll();
		}
		void EQ4QClicked(object sender, EventArgs e ) {
			BlackAllEQElements();
			EQ4Q.BackColor = Color.Gray;
			lphpeqselect = 6;
			lphpeqtypeselect = 1;
			lphpeqbar.Minimum = 5;
			lphpeqbar.Maximum = 100;
			lphpeqbar.Value = dsp_par_eq[channelselect,4*3+2];
			EQ4Q.SelectAll();
		}
		
		void EQKeyDown(object sender, KeyEventArgs e) {
			if(masterchange) return;
			if (e.KeyCode != Keys.Enter) return;
			string erroronlynumeric = "Only numeric values allowed";
			string errorfreq = "Value must be between 20 and 20000";
			string errorqhplp = "Value must be between 0.5 and 3.0";
			string erroreq = "Value must be between 0.5 and 10.0";
			string errorgain = "Value must be between -15 and +15";
			
			int n;
			
			//parse lpfreq
			if (!int.TryParse(LPFreq.Text,out n)) {				
				LPFreq.Text = "1000";
				dsp_par_lp[channelselect,1] = 1000;
				MessageBox.Show(erroronlynumeric);				
			}
			else if (n < 20 ) {
				LPFreq.Text = "20";
				dsp_par_lp[channelselect,1] = 20;
				MessageBox.Show(errorfreq);
			
			}
			else if (n > 20000) {
				LPFreq.Text = "20000";
				dsp_par_lp[channelselect,1] = 20000;
				MessageBox.Show(errorfreq);
				return;	
			}				
			else dsp_par_lp[channelselect,1] = n;
			
			if (lphpeqselect==0 && lphpeqtypeselect == 0) {
				LPFreq.SelectAll();
				lphpeqbar.Minimum = bar20hz;
				lphpeqbar.Maximum = bar20khz;
				lphpeqbar.Value = (int) Math.Round(dsp.GetXByFrequency(dsp_par_lp[channelselect,1],20000));
				
			}
			
			//parse hpfreq
			if (!int.TryParse(HPFreq.Text,out n)) {				
				HPFreq.Text = "1000";
				dsp_par_hp[channelselect,1] = 1000;
				MessageBox.Show(erroronlynumeric);				
			}
			else if (n < 20 ) {
				HPFreq.Text = "20";
				dsp_par_hp[channelselect,1] = 20;
				MessageBox.Show(errorfreq);
			
			}
			else if (n > 20000) {
				HPFreq.Text = "20000";
				dsp_par_hp[channelselect,1] = 20000;
				MessageBox.Show(errorfreq);
				return;	
			}				
			else dsp_par_hp[channelselect,1] = n;
			
			if (lphpeqselect==1 && lphpeqtypeselect == 0) {	
				HPFreq.SelectAll();
				lphpeqbar.Minimum = bar20hz;
				lphpeqbar.Maximum = bar20khz;
				lphpeqbar.Value = (int) Math.Round(dsp.GetXByFrequency(dsp_par_hp[channelselect,1],20000));
				
			}
			
			//parse eq0freq
			int eqnum = 0;
			if (!int.TryParse(EQ0Freq.Text,out n)) {				
				EQ0Freq.Text = "1000";
				dsp_par_eq[channelselect,eqnum*3+0] = 1000;
				MessageBox.Show(erroronlynumeric);				
			}
			else if (n < 20 ) {
				EQ0Freq.Text = "20";
				dsp_par_eq[channelselect,eqnum*3+0] = 20;
				MessageBox.Show(errorfreq);
			
			}
			else if (n > 20000) {
				EQ0Freq.Text = "20000";
				dsp_par_eq[channelselect,eqnum*3+0] = 20000;
				MessageBox.Show(errorfreq);
				return;	
			}				
			else dsp_par_eq[channelselect,eqnum*3+0] = n;
			
			if (lphpeqselect==2 && lphpeqtypeselect == 0) {
				EQ0Freq.SelectAll();
				lphpeqbar.Minimum = bar20hz;
				lphpeqbar.Maximum = bar20khz;
				lphpeqbar.Value = (int) Math.Round(dsp.GetXByFrequency(dsp_par_eq[channelselect,eqnum*3+0],20000));
			}
			
			//parse eq1freq
			eqnum = 1;
			if (!int.TryParse(EQ1Freq.Text,out n)) {				
				EQ1Freq.Text = "1000";
				dsp_par_eq[channelselect,eqnum*3+0] = 1000;
				MessageBox.Show(erroronlynumeric);				
			}
			else if (n < 20 ) {
				EQ1Freq.Text = "20";
				dsp_par_eq[channelselect,eqnum*3+0] = 20;
				MessageBox.Show(errorfreq);
			
			}
			else if (n > 20000) {
				EQ1Freq.Text = "20000";
				dsp_par_eq[channelselect,eqnum*3+0] = 20000;
				MessageBox.Show(errorfreq);
				return;	
			}				
			else dsp_par_eq[channelselect,eqnum*3+0] = n;
			
			if (lphpeqselect==3 && lphpeqtypeselect == 0) {	
				EQ1Freq.SelectAll();
				lphpeqbar.Minimum = bar20hz;
				lphpeqbar.Maximum = bar20khz;
				lphpeqbar.Value = (int) Math.Round(dsp.GetXByFrequency(dsp_par_eq[channelselect,eqnum*3+0],20000));
			}
			
			//parse eq2 freq
			eqnum = 2;
			if (!int.TryParse(EQ2Freq.Text,out n)) {				
				EQ2Freq.Text = "1000";
				dsp_par_eq[channelselect,eqnum*3+0] = 1000;
				MessageBox.Show(erroronlynumeric);				
			}
			else if (n < 20 ) {
				EQ2Freq.Text = "20";
				dsp_par_eq[channelselect,eqnum*3+0] = 20;
				MessageBox.Show(errorfreq);
			
			}
			else if (n > 20000) {
				EQ2Freq.Text = "20000";
				dsp_par_eq[channelselect,eqnum*3+0] = 20000;
				MessageBox.Show(errorfreq);
				return;	
			}				
			else dsp_par_eq[channelselect,eqnum*3+0] = n;
			
			if (lphpeqselect==4 && lphpeqtypeselect == 0) {	
				EQ2Freq.SelectAll();
				lphpeqbar.Minimum = bar20hz;
				lphpeqbar.Maximum = bar20khz;
				lphpeqbar.Value = (int) Math.Round(dsp.GetXByFrequency(dsp_par_eq[channelselect,eqnum*3+0],20000));
			}
			
			//parse eq3 freq
			eqnum = 3;
			if (!int.TryParse(EQ3Freq.Text,out n)) {				
				EQ3Freq.Text = "1000";
				dsp_par_eq[channelselect,eqnum*3+0] = 1000;
				MessageBox.Show(erroronlynumeric);				
			}
			else if (n < 20 ) {
				EQ3Freq.Text = "20";
				dsp_par_eq[channelselect,eqnum*3+0] = 20;
				MessageBox.Show(errorfreq);
			
			}
			else if (n > 20000) {
				EQ3Freq.Text = "20000";
				dsp_par_eq[channelselect,eqnum*3+0] = 20000;
				MessageBox.Show(errorfreq);
				return;	
			}				
			else dsp_par_eq[channelselect,eqnum*3+0] = n;
			
			if (lphpeqselect==5 && lphpeqtypeselect == 0) {	
				EQ3Freq.SelectAll();
				lphpeqbar.Minimum = bar20hz;
				lphpeqbar.Maximum = bar20khz;
				lphpeqbar.Value = (int) Math.Round(dsp.GetXByFrequency(dsp_par_eq[channelselect,eqnum*3+0],20000));
			}
			
			//parse eq4 freq
			eqnum = 4;
			if (!int.TryParse(EQ4Freq.Text,out n)) {				
				EQ4Freq.Text = "1000";
				dsp_par_eq[channelselect,eqnum*3+0] = 1000;
				MessageBox.Show(erroronlynumeric);				
			}
			else if (n < 20 ) {
				EQ4Freq.Text = "20";
				dsp_par_eq[channelselect,eqnum*3+0] = 20;
				MessageBox.Show(errorfreq);
			
			}
			else if (n > 20000) {
				EQ4Freq.Text = "20000";
				dsp_par_eq[channelselect,eqnum*3+0] = 20000;
				MessageBox.Show(errorfreq);
				return;	
			}				
			else dsp_par_eq[channelselect,eqnum*3+0] = n;
			
			if (lphpeqselect==6 && lphpeqtypeselect == 0) {	
				EQ4Freq.SelectAll();
				lphpeqbar.Minimum = bar20hz;
				lphpeqbar.Maximum = bar20khz;
				lphpeqbar.Value = (int) Math.Round(dsp.GetXByFrequency(dsp_par_eq[channelselect,eqnum*3+0],20000));
			}
			
			//handle q hp
			float nf;
			HPQ.Text = HPQ.Text.Replace(".",",");
			
			if (!float.TryParse(HPQ.Text, out nf)) {
				HPQ.Text = "0,7";
				dsp_par_hp[channelselect,2] = 7;
				MessageBox.Show(erroronlynumeric);				
			}
			
			else if (nf < 0.5f) {
				HPQ.Text = "0,5";
				dsp_par_hp[channelselect,2] = 5;
				MessageBox.Show(errorqhplp);				
			}
			else if (nf > 3.0f) {
				HPQ.Text = "3";
				dsp_par_hp[channelselect,2] = 30;
				MessageBox.Show(errorqhplp);
				
			}
			else dsp_par_hp[channelselect,2] = (int)(nf*10.0f);
			
			if (lphpeqselect==1 && lphpeqtypeselect == 1) {	
				HPQ.SelectAll();
				lphpeqbar.Minimum = 5;
				lphpeqbar.Maximum = 30;
				lphpeqbar.Value = dsp_par_hp[channelselect,2];
			}
			
			//handle q lp
			LPQ.Text = LPQ.Text.Replace(".",",");
			
			if (!float.TryParse(LPQ.Text, out nf)) {
				LPQ.Text = "0,7";
				dsp_par_lp[channelselect,2] = 7;
				MessageBox.Show(erroronlynumeric);				
			}
			
			else if (nf < 0.5f) {
				LPQ.Text = "0,5";
				dsp_par_lp[channelselect,2] = 5;
				MessageBox.Show(errorqhplp);				
			}
			else if (nf > 3.0f) {
				LPQ.Text = "3";
				dsp_par_lp[channelselect,2] = 30;
				MessageBox.Show(errorqhplp);
				
			}
			else dsp_par_lp[channelselect,2] = (int)(nf*10.0f);
			
			if (lphpeqselect==0 && lphpeqtypeselect == 1) {	
				LPQ.SelectAll();
				lphpeqbar.Minimum = 5;
				lphpeqbar.Maximum = 30;
				lphpeqbar.Value = dsp_par_lp[channelselect,2];
			}
			
			//handle q eq0
			eqnum=0;
			EQ0Q.Text = EQ0Q.Text.Replace(".",",");
			
			if (!float.TryParse(EQ0Q.Text, out nf)) {
				EQ0Q.Text = "0,7";
				dsp_par_eq[channelselect,eqnum*3+2] = 7;
				MessageBox.Show(erroronlynumeric);				
			}
			
			else if (nf < 0.5f) {
				EQ0Q.Text = "0,5";
				dsp_par_eq[channelselect,eqnum*3+2] = 5;
				MessageBox.Show(erroreq);				
			}
			else if (nf > 10.0f) {
				EQ0Q.Text = "10";
				dsp_par_eq[channelselect,eqnum*3+2] = 100;
				MessageBox.Show(erroreq);
				
			}
			else dsp_par_eq[channelselect,eqnum*3+2] = (int)(nf*10.0f);
			
			if (lphpeqselect==2 && lphpeqtypeselect == 1) {	
				EQ0Q.SelectAll();
				lphpeqbar.Minimum = 5;
				lphpeqbar.Maximum = 100;
				lphpeqbar.Value = dsp_par_eq[channelselect,eqnum*3+2];
			}
			
			//handle q eq1
			eqnum=1;
			EQ1Q.Text = EQ1Q.Text.Replace(".",",");
			
			if (!float.TryParse(EQ1Q.Text, out nf)) {
				EQ1Q.Text = "0,7";
				dsp_par_eq[channelselect,eqnum*3+2] = 7;
				MessageBox.Show(erroronlynumeric);				
			}
			
			else if (nf < 0.5f) {
				EQ1Q.Text = "0,5";
				dsp_par_eq[channelselect,eqnum*3+2] = 5;
				MessageBox.Show(erroreq);				
			}
			else if (nf > 10.0f) {
				EQ1Q.Text = "10";
				dsp_par_eq[channelselect,eqnum*3+2] = 100;
				MessageBox.Show(erroreq);
				
			}
			else dsp_par_eq[channelselect,eqnum*3+2] = (int)(nf*10.0f);
			
			if (lphpeqselect==3 && lphpeqtypeselect == 1) {	
				EQ1Q.SelectAll();
				lphpeqbar.Minimum = 5;
				lphpeqbar.Maximum = 100;
				lphpeqbar.Value = dsp_par_eq[channelselect,eqnum*3+2];
			}
			
			//handle q eq2
			eqnum=2;
			EQ2Q.Text = EQ2Q.Text.Replace(".",",");
			
			if (!float.TryParse(EQ2Q.Text, out nf)) {
				EQ2Q.Text = "0,7";
				dsp_par_eq[channelselect,eqnum*3+2] = 7;
				MessageBox.Show(erroronlynumeric);				
			}
			
			else if (nf < 0.5f) {
				EQ2Q.Text = "0,5";
				dsp_par_eq[channelselect,eqnum*3+2] = 5;
				MessageBox.Show(erroreq);				
			}
			else if (nf > 10.0f) {
				EQ2Q.Text = "10";
				dsp_par_eq[channelselect,eqnum*3+2] = 100;
				MessageBox.Show(erroreq);
				
			}
			else dsp_par_eq[channelselect,eqnum*3+2] = (int)(nf*10.0f);
			
			if (lphpeqselect==4 && lphpeqtypeselect == 1) {	
				EQ2Q.SelectAll();
				lphpeqbar.Minimum = 5;
				lphpeqbar.Maximum = 100;
				lphpeqbar.Value = dsp_par_eq[channelselect,eqnum*3+2];
			}
			
			//handle q eq3
			eqnum=3;
			EQ3Q.Text = EQ3Q.Text.Replace(".",",");
			
			if (!float.TryParse(EQ3Q.Text, out nf)) {
				EQ3Q.Text = "0,7";
				dsp_par_eq[channelselect,eqnum*3+2] = 7;
				MessageBox.Show(erroronlynumeric);				
			}
			
			else if (nf < 0.5f) {
				EQ3Q.Text = "0,5";
				dsp_par_eq[channelselect,eqnum*3+2] = 5;
				MessageBox.Show(erroreq);				
			}
			else if (nf > 10.0f) {
				EQ3Q.Text = "10";
				dsp_par_eq[channelselect,eqnum*3+2] = 100;
				MessageBox.Show(erroreq);
				
			}
			else dsp_par_eq[channelselect,eqnum*3+2] = (int)(nf*10.0f);
			
			if (lphpeqselect==5 && lphpeqtypeselect == 1) {	
				EQ3Q.SelectAll();
				lphpeqbar.Minimum = 5;
				lphpeqbar.Maximum = 100;
				lphpeqbar.Value = dsp_par_eq[channelselect,eqnum*3+2];
			}
			//handle q eq4
			eqnum=4;
			EQ4Q.Text = EQ4Q.Text.Replace(".",",");
			
			if (!float.TryParse(EQ4Q.Text, out nf)) {
				EQ4Q.Text = "0,7";
				dsp_par_eq[channelselect,eqnum*3+2] = 7;
				MessageBox.Show(erroronlynumeric);				
			}
			
			else if (nf < 0.5f) {
				EQ4Q.Text = "0,5";
				dsp_par_eq[channelselect,eqnum*3+2] = 5;
				MessageBox.Show(erroreq);				
			}
			else if (nf > 10.0f) {
				EQ4Q.Text = "10";
				dsp_par_eq[channelselect,eqnum*3+2] = 100;
				MessageBox.Show(erroreq);
				
			}
			else dsp_par_eq[channelselect,eqnum*3+2] = (int)(nf*10.0f);
			
			if (lphpeqselect==6 && lphpeqtypeselect == 1) {	
				EQ4Q.SelectAll();
				lphpeqbar.Minimum = 5;
				lphpeqbar.Maximum = 100;
				lphpeqbar.Value = dsp_par_eq[channelselect,eqnum*3+2];
			}
			
			//handle gain eq0
			eqnum=0;	
			if (!int.TryParse(EQ0Gain.Text,out n)) {
				EQ0Gain.Text = "0";
				dsp_par_eq[channelselect,eqnum*3+1] = 0;
				MessageBox.Show(erroronlynumeric);
			}
			
			else if (n < -15 ) {
				EQ0Gain.Text = "-15";
				dsp_par_eq[channelselect,eqnum*3+1] = -15;
				MessageBox.Show(errorgain);				
			}
			
			else if (n > 15 ) {
				EQ0Gain.Text = "15";
				dsp_par_eq[channelselect,eqnum*3+1] = 15;
				MessageBox.Show("Value must be between -15 to +15");				
			}			
			else dsp_par_eq[channelselect,eqnum*3+1]= n;
			
			if (lphpeqselect==2 && lphpeqtypeselect == 2) {	
				EQ0Gain.SelectAll();
				lphpeqbar.Minimum = -15;
				lphpeqbar.Maximum = +15;
				lphpeqbar.Value = dsp_par_eq[channelselect,eqnum*3+1];
			}
			
			//handle gain eq1
			eqnum=1;	
			if (!int.TryParse(EQ1Gain.Text,out n)) {
				EQ1Gain.Text = "0";
				dsp_par_eq[channelselect,eqnum*3+1] = 0;
				MessageBox.Show(erroronlynumeric);
			}
			
			else if (n < -15 ) {
				EQ1Gain.Text = "-15";
				dsp_par_eq[channelselect,eqnum*3+1] = -15;
				MessageBox.Show(errorgain);				
			}
			
			else if (n > 15 ) {
				EQ1Gain.Text = "15";
				dsp_par_eq[channelselect,eqnum*3+1] = 15;
				MessageBox.Show("Value must be between -15 to +15");				
			}			
			else dsp_par_eq[channelselect,eqnum*3+1]= n;
			
			if (lphpeqselect==3 && lphpeqtypeselect == 2) {	
				EQ1Gain.SelectAll();
				lphpeqbar.Minimum = -15;
				lphpeqbar.Maximum = +15;
				lphpeqbar.Value = dsp_par_eq[channelselect,eqnum*3+1];
			}
			
			//handle gain eq2
			eqnum=2;	
			if (!int.TryParse(EQ2Gain.Text,out n)) {
				EQ2Gain.Text = "0";
				dsp_par_eq[channelselect,eqnum*3+1] = 0;
				MessageBox.Show(erroronlynumeric);
			}
			
			else if (n < -15 ) {
				EQ2Gain.Text = "-15";
				dsp_par_eq[channelselect,eqnum*3+1] = -15;
				MessageBox.Show(errorgain);				
			}
			
			else if (n > 15 ) {
				EQ2Gain.Text = "15";
				dsp_par_eq[channelselect,eqnum*3+1] = 15;
				MessageBox.Show("Value must be between -15 to +15");				
			}			
			else dsp_par_eq[channelselect,eqnum*3+1]= n;
			
			if (lphpeqselect==4 && lphpeqtypeselect == 2) {	
				EQ2Gain.SelectAll();
				lphpeqbar.Minimum = -15;
				lphpeqbar.Maximum = +15;
				lphpeqbar.Value = dsp_par_eq[channelselect,eqnum*3+1];
			}
			
			//handle gain eq3
			eqnum=3;	
			if (!int.TryParse(EQ3Gain.Text,out n)) {
				EQ3Gain.Text = "0";
				dsp_par_eq[channelselect,eqnum*3+1] = 0;
				MessageBox.Show(erroronlynumeric);
			}
			
			else if (n < -15 ) {
				EQ3Gain.Text = "-15";
				dsp_par_eq[channelselect,eqnum*3+1] = -15;
				MessageBox.Show(errorgain);				
			}
			
			else if (n > 15 ) {
				EQ3Gain.Text = "15";
				dsp_par_eq[channelselect,eqnum*3+1] = 15;
				MessageBox.Show("Value must be between -15 to +15");				
			}			
			else dsp_par_eq[channelselect,eqnum*3+1]= n;
			
			if (lphpeqselect==5 && lphpeqtypeselect == 2) {	
				EQ3Gain.SelectAll();
				lphpeqbar.Minimum = -15;
				lphpeqbar.Maximum = +15;
				lphpeqbar.Value = dsp_par_eq[channelselect,eqnum*3+1];
			}
			
			//handle gain eq4
			eqnum=4;	
			if (!int.TryParse(EQ4Gain.Text,out n)) {
				EQ4Gain.Text = "0";
				dsp_par_eq[channelselect,eqnum*3+1] = 0;
				MessageBox.Show(erroronlynumeric);
			}
			
			else if (n < -15 ) {
				EQ4Gain.Text = "-15";
				dsp_par_eq[channelselect,eqnum*3+1] = -15;
				MessageBox.Show(errorgain);				
			}
			
			else if (n > 15 ) {
				EQ4Gain.Text = "15";
				dsp_par_eq[channelselect,eqnum*3+1] = 15;
				MessageBox.Show("Value must be between -15 to +15");				
			}			
			else dsp_par_eq[channelselect,eqnum*3+1]= n;
			
			if (lphpeqselect==6 && lphpeqtypeselect == 2) {	
				EQ4Gain.SelectAll();
				lphpeqbar.Minimum = -15;
				lphpeqbar.Maximum = +15;
				lphpeqbar.Value = dsp_par_eq[channelselect,eqnum*3+1];
			}
			
			
			e.Handled = true;
			e.SuppressKeyPress = true;
			HPLPEQUpdateLinks();
			SendLPHPEQ();
			UpdateDSPPlotter();
			
		}
		
		void UpdateHPLPEQSliderToField() {
			
		}
		void VBS_BypassClick(object sender, EventArgs e)
		{
			if (global_bypass[0]==1) {
				global_bypass[0] = 0;
				VBS_Bypass.BackColor = Color.Lime;
				VBS_Bypass.Text = "ON";
				connect.PublicBypassRequest(global_bypass[0],global_bypass[1]);
			}
			else {
				global_bypass[0] = 1;
				VBS_Bypass.BackColor = Color.Red;
				VBS_Bypass.Text = "OFF";
				connect.PublicBypassRequest(global_bypass[0],global_bypass[1]);
			}
		}
		
		void DynBass_BypassClick(object sender, EventArgs e)
		{
			if (global_bypass[1]==1) {
				global_bypass[1] = 0;
				DynBass_Bypass.BackColor = Color.Lime;
				DynBass_Bypass.Text = "ON";
				connect.PublicBypassRequest(global_bypass[0],global_bypass[1]);
			}
			else {
				global_bypass[1] = 1;
				DynBass_Bypass.BackColor = Color.Red;
				DynBass_Bypass.Text = "OFF";
				connect.PublicBypassRequest(global_bypass[0],global_bypass[1]);
			}
		}
		
		void HPBypassButtonUpdateColor() {
			if (channel_bypass[channelselect,1]==0) {
				HPBypass.BackColor = Color.Lime;
				HPBypass.Text = "ON";		
				
			}
			else {
				HPBypass.BackColor = Color.Red;
				HPBypass.Text = "OFF";				
			}
		}
		void HPBypassClick(object sender, EventArgs e)
		{
			if (channel_bypass[channelselect,1]==0) channel_bypass[channelselect,1]=1;
			else channel_bypass[channelselect,1] = 0;
			HPBypassButtonUpdateColor();
			ChannelBypassUpdateLinks();
			UpdateDSPPlotter();
			ChannelBypassConnectionRequest();
		}
		
		void ChannelBypassUpdateLinks() {
			
			if (link[channelselect]==false) return;
			else {
				for (int i=0; i<4;i++) {
					if (link[i] && channelselect != i) {
						
						for (int j=0; j<7; j++)
							channel_bypass[i,j]=channel_bypass[channelselect,j];
						
						
					}
				}
			}
		}
		
		void HPLPEQUpdateLinks() {
			if (link[channelselect]==false) return;
			else {
				for (int i=0; i<4;i++) {
					if (link[i] && channelselect!= i) {
						dsp_par_hp[i,0] = dsp_par_hp[channelselect,0];
						dsp_par_hp[i,1] = dsp_par_hp[channelselect,1];
						dsp_par_hp[i,2] = dsp_par_hp[channelselect,2];
						dsp_par_lp[i,0] = dsp_par_lp[channelselect,0];
						dsp_par_lp[i,1] = dsp_par_lp[channelselect,1];
						dsp_par_lp[i,2] = dsp_par_lp[channelselect,2];
						for (int y=0; y<15; y++) {
							dsp_par_eq[i,y] = dsp_par_eq[channelselect,y];
						}
					}
				}
				
			}
		}
		void ChannelBypassConnectionRequest() {
			if (link[channelselect]) connect.ChannelBypassRequest(GetLinkBitMask(),
				                             channel_bypass[channelselect,0],
				                             channel_bypass[channelselect,1],
				                             channel_bypass[channelselect,2],
				                             channel_bypass[channelselect,3],
				                             channel_bypass[channelselect,4],
				                             channel_bypass[channelselect,5],
				                             channel_bypass[channelselect,6]
				                            );
			
			else connect.ChannelBypassRequest(GetChannelBitMask(channelselect),
				                             channel_bypass[channelselect,0],
				                             channel_bypass[channelselect,1],
				                             channel_bypass[channelselect,2],
				                             channel_bypass[channelselect,3],
				                             channel_bypass[channelselect,4],
				                             channel_bypass[channelselect,5],
				                             channel_bypass[channelselect,6]
				                            );
		}
		void LPBypassButtonUpdateColor() {
			if (channel_bypass[channelselect,0]==0) {
				LPBypass.BackColor = Color.Lime;
				LPBypass.Text = "ON";			
				
			}
			else {
				LPBypass.BackColor = Color.Red;
				LPBypass.Text = "OFF";			
			}
		}
		
		void LPBypassClick(object sender, EventArgs e)
		{
			
			if (channel_bypass[channelselect,0]==0) channel_bypass[channelselect,0]=1;
			else channel_bypass[channelselect,0] = 0;
			LPBypassButtonUpdateColor();
			UpdateDSPPlotter();
			ChannelBypassUpdateLinks();
			ChannelBypassConnectionRequest();
		}
		
		void EQ0BypassButtonUpdateColor() {
			if (channel_bypass[channelselect,2]==0) {
				EQ0Bypass.BackColor = Color.Lime;
				EQ0Bypass.Text = "ON";			
				
			}
			else {
				EQ0Bypass.BackColor = Color.Red;
				EQ0Bypass.Text = "OFF";			
			}	
		}
		
		void EQ0BypassClick(object sender, EventArgs e)
		{
			if (channel_bypass[channelselect,2]==0) channel_bypass[channelselect,2]=1;
			else channel_bypass[channelselect,2] = 0;	
			EQ0BypassButtonUpdateColor();			
			ChannelBypassUpdateLinks();
			UpdateDSPPlotter();
			ChannelBypassConnectionRequest();			
		}
		
		void EQ1BypassButtonUpdateColor() {
			if (channel_bypass[channelselect,3]==0) {
				EQ1Bypass.BackColor = Color.Lime;
				EQ1Bypass.Text = "ON";		
				
			}
			else {
				EQ1Bypass.BackColor = Color.Red;
				EQ1Bypass.Text = "OFF";			
			}
		}
		void EQ1BypassClick(object sender, EventArgs e)
		{
			if (channel_bypass[channelselect,3]==0) channel_bypass[channelselect,3]=1;
			else channel_bypass[channelselect,3] = 0;
			EQ1BypassButtonUpdateColor();				
			ChannelBypassUpdateLinks();
			UpdateDSPPlotter();
			ChannelBypassConnectionRequest();	
		}
		
		void EQ2BypassButtonUpdateColor() {
			if (channel_bypass[channelselect,4]==0) {
				EQ2Bypass.BackColor = Color.Lime;
				EQ2Bypass.Text = "ON";							
			}
			else {
				EQ2Bypass.BackColor = Color.Red;
				EQ2Bypass.Text = "OFF";			
			}	
		}
		void EQ2BypassClick(object sender, EventArgs e)
		{
			if (channel_bypass[channelselect,4]==0) channel_bypass[channelselect,4]=1;
			else channel_bypass[channelselect,4] = 0;
			EQ2BypassButtonUpdateColor();			
			ChannelBypassUpdateLinks();
			UpdateDSPPlotter();
			ChannelBypassConnectionRequest();				
		}
		
		void EQ3BypassButtonUpdateColor() {
			if (channel_bypass[channelselect,5]==0) {
				EQ3Bypass.BackColor = Color.Lime;
				EQ3Bypass.Text = "ON";			
				
			}
			else {
				EQ3Bypass.BackColor = Color.Red;
				EQ3Bypass.Text = "OFF";			
			}	
		}
		void EQ3BypassClick(object sender, EventArgs e)
		{
			if (channel_bypass[channelselect,5]==0) channel_bypass[channelselect,5]=1;
			else channel_bypass[channelselect,5] = 0;
			EQ3BypassButtonUpdateColor();						
			ChannelBypassUpdateLinks();
			UpdateDSPPlotter();	
			ChannelBypassConnectionRequest();				
		}
		
		void EQ4BypassButtonUpdateColor() {
			if (channel_bypass[channelselect,6]==0) {
				EQ4Bypass.BackColor = Color.Lime;
				EQ4Bypass.Text = "ON";			
				
			}
			else {
				EQ4Bypass.BackColor = Color.Red;
				EQ4Bypass.Text = "OFF";			
			}
		}
		void EQ4BypassClick(object sender, EventArgs e)
		{
			if (channel_bypass[channelselect,6]==0) channel_bypass[channelselect,6]=1;
			else channel_bypass[channelselect,6] = 0;
			EQ4BypassButtonUpdateColor();			
			ChannelBypassUpdateLinks();
			UpdateDSPPlotter();
			ChannelBypassConnectionRequest();				
		}
		
		
		
		void HPOrderSelectedIndexChanged(object sender, EventArgs e)
		{
			dsp_par_hp[channelselect,0] = HPOrder.SelectedIndex;
			HPFreqClicked(null,null);
			HPLPEQUpdateLinks();
			SendLPHPEQ();
			UpdateDSPPlotter();
		}
		
		void LPOrderSelectedIndexChanged(object sender, EventArgs e)
		{
			dsp_par_lp[channelselect,0] = LPOrder.SelectedIndex;
			LPFreqClicked(null,null);
			HPLPEQUpdateLinks();
			SendLPHPEQ();
			UpdateDSPPlotter();
		}
		
		void Limiter3ShowClick(object sender, EventArgs e)
		{
			
		}
		
		
	
		
		void HPFreqTextChanged(object sender, EventArgs e)
		{
			
		}
		
		void LphpeqbarValueChanged(object sender, decimal value)
		{
			if (lphpeqselect == 0 && lphpeqtypeselect == 0) {
				dsp_par_lp[channelselect,1] = (int) Math.Round(dsp.GetFrequencyByX(lphpeqbar.Value,20000));
				LPFreq.Text = dsp_par_lp[channelselect,1].ToString();
				LPFreq.SelectAll();
				
			}
			
			if (lphpeqselect == 1 && lphpeqtypeselect == 0) {
				dsp_par_hp[channelselect,1] = (int) Math.Round(dsp.GetFrequencyByX(lphpeqbar.Value,20000));
				HPFreq.Text = dsp_par_hp[channelselect,1].ToString();
				HPFreq.SelectAll();				
			}
			
			if (lphpeqselect == 2 && lphpeqtypeselect == 0) {
				dsp_par_eq[channelselect,0*3+0] = (int) Math.Round(dsp.GetFrequencyByX(lphpeqbar.Value,20000));
				EQ0Freq.Text = dsp_par_eq[channelselect,0*3+0].ToString();
				EQ0Freq.SelectAll();				
			}
			if (lphpeqselect == 3 && lphpeqtypeselect == 0) {
				dsp_par_eq[channelselect,1*3+0] = (int) Math.Round(dsp.GetFrequencyByX(lphpeqbar.Value,20000));
				EQ1Freq.Text = dsp_par_eq[channelselect,1*3+0].ToString();
				EQ1Freq.SelectAll();							
			}
			if (lphpeqselect == 4 && lphpeqtypeselect == 0) {
				dsp_par_eq[channelselect,2*3+0] = (int) Math.Round(dsp.GetFrequencyByX(lphpeqbar.Value,20000));
				EQ2Freq.Text = dsp_par_eq[channelselect,2*3+0].ToString();
				EQ2Freq.SelectAll();					
			}	
			if (lphpeqselect == 5 && lphpeqtypeselect == 0) {
				dsp_par_eq[channelselect,3*3+0] = (int) Math.Round(dsp.GetFrequencyByX(lphpeqbar.Value,20000));
				EQ3Freq.Text = dsp_par_eq[channelselect,3*3+0].ToString();
				EQ3Freq.SelectAll();				
						
			}
			if (lphpeqselect == 6 && lphpeqtypeselect == 0) {
				dsp_par_eq[channelselect,4*3+0] = (int) Math.Round(dsp.GetFrequencyByX(lphpeqbar.Value,20000));
				EQ4Freq.Text = dsp_par_eq[channelselect,4*3+0].ToString();
				EQ4Freq.SelectAll();		
						
			}
			
			
			if (lphpeqselect == 0 && lphpeqtypeselect == 1) {
				dsp_par_lp[channelselect,2] = lphpeqbar.Value;
				LPQ.Text = (((double)dsp_par_lp[channelselect,2])/10.0f).ToString();
				LPQ.SelectAll();
				
			}
			
			if (lphpeqselect == 1 && lphpeqtypeselect == 1) {
				dsp_par_hp[channelselect,2] = lphpeqbar.Value;
				HPQ.Text = (((double)dsp_par_hp[channelselect,2])/10.0f).ToString();
				HPQ.SelectAll();
				
			}
			
			if (lphpeqselect == 2 && lphpeqtypeselect == 1) {
				dsp_par_eq[channelselect,0*3+2] = lphpeqbar.Value;
				EQ0Q.Text = (((double)dsp_par_eq[channelselect,0*3+2])/10.0f).ToString();
				EQ0Q.SelectAll();
			}
			if (lphpeqselect == 3 && lphpeqtypeselect == 1) {
				dsp_par_eq[channelselect,1*3+2] = lphpeqbar.Value;
				EQ1Q.Text = (((double)dsp_par_eq[channelselect,1*3+2])/10.0f).ToString();
				EQ1Q.SelectAll();
			}
			if (lphpeqselect == 4 && lphpeqtypeselect == 1) {
				dsp_par_eq[channelselect,2*3+2] = lphpeqbar.Value;
				EQ2Q.Text = (((double)dsp_par_eq[channelselect,2*3+2])/10.0f).ToString();
				EQ2Q.SelectAll();
			}
			if (lphpeqselect == 5 && lphpeqtypeselect == 1) {
				dsp_par_eq[channelselect,3*3+2] = lphpeqbar.Value;
				EQ3Q.Text = (((double)dsp_par_eq[channelselect,3*3+2])/10.0f).ToString();
				EQ3Q.SelectAll();
			}
			
			if (lphpeqselect == 6 && lphpeqtypeselect == 1) {
				dsp_par_eq[channelselect,4*3+2] = lphpeqbar.Value;
				EQ4Q.Text = (((double)dsp_par_eq[channelselect,4*3+2])/10.0f).ToString();
				EQ4Q.SelectAll();
			}
			
			if (lphpeqselect==2 && lphpeqtypeselect==2) {
				dsp_par_eq[channelselect,0*3+1] = lphpeqbar.Value;
				EQ0Gain.Text = dsp_par_eq[channelselect,0*3+1].ToString();
				EQ0Gain.SelectAll();
			}
			if (lphpeqselect==3 && lphpeqtypeselect==2) {
				dsp_par_eq[channelselect,1*3+1] = lphpeqbar.Value;
				EQ1Gain.Text = dsp_par_eq[channelselect,1*3+1].ToString();
				EQ1Gain.SelectAll();
			}
			if (lphpeqselect==4 && lphpeqtypeselect==2) {
				dsp_par_eq[channelselect,2*3+1] = lphpeqbar.Value;
				EQ2Gain.Text = dsp_par_eq[channelselect,2*3+1].ToString();
				EQ2Gain.SelectAll();
			}
			if (lphpeqselect==5 && lphpeqtypeselect==2) {
				dsp_par_eq[channelselect,3*3+1] = lphpeqbar.Value;
				EQ3Gain.Text = dsp_par_eq[channelselect,3*3+1].ToString();
				EQ3Gain.SelectAll();
			}
			if (lphpeqselect==6 && lphpeqtypeselect==2) {
				dsp_par_eq[channelselect,4*3+1] = lphpeqbar.Value;
				EQ4Gain.Text = dsp_par_eq[channelselect,4*3+1].ToString();
				EQ4Gain.SelectAll();
			}
			
			HPLPEQUpdateLinks();
			SendLPHPEQ();
			UpdateDSPPlotter();
		}
		
		void SendLPHPEQ() {
			
			if (masterchange) return;
			
					
			if (lphpeqselect==0) {
				if (link[channelselect]) connect.LowPassRequest(GetLinkBitMask(),dsp_par_lp[channelselect,0],dsp_par_lp[channelselect,1],dsp_par_lp[channelselect,2]);
				else connect.LowPassRequest(GetChannelBitMask(channelselect),dsp_par_lp[channelselect,0],dsp_par_lp[channelselect,1],dsp_par_lp[channelselect,2]);
			}
			if (lphpeqselect==1) {
				if(link[channelselect]) connect.HighPassRequest(GetLinkBitMask(), dsp_par_hp[channelselect,0],dsp_par_hp[channelselect,1],dsp_par_hp[channelselect,2]);
				else connect.HighPassRequest(GetChannelBitMask(channelselect), dsp_par_hp[channelselect,0],dsp_par_hp[channelselect,1],dsp_par_hp[channelselect,2]);
			}
			if(lphpeqselect==2) {
				if (link[channelselect]) connect.EQRequest(GetLinkBitMask(),0,dsp_par_eq[channelselect,0*3+0],dsp_par_eq[channelselect,0*3+1],dsp_par_eq[channelselect,0*3+2]);
				else connect.EQRequest(GetChannelBitMask(channelselect),0,dsp_par_eq[channelselect,0*3+0],dsp_par_eq[channelselect,0*3+1],dsp_par_eq[channelselect,0*3+2]);
		
			}
			if(lphpeqselect==3) {
				if (link[channelselect]) connect.EQRequest(GetLinkBitMask(),1,dsp_par_eq[channelselect,1*3+0],dsp_par_eq[channelselect,1*3+1],dsp_par_eq[channelselect,1*3+2]);
				else connect.EQRequest(GetChannelBitMask(channelselect),1,dsp_par_eq[channelselect,1*3+0],dsp_par_eq[channelselect,1*3+1],dsp_par_eq[channelselect,1*3+2]);
		
			}
			if(lphpeqselect==4) {
				if (link[channelselect]) connect.EQRequest(GetLinkBitMask(),2,dsp_par_eq[channelselect,2*3+0],dsp_par_eq[channelselect,2*3+1],dsp_par_eq[channelselect,2*3+2]);
				else connect.EQRequest(GetChannelBitMask(channelselect),2,dsp_par_eq[channelselect,2*3+0],dsp_par_eq[channelselect,2*3+1],dsp_par_eq[channelselect,2*3+2]);
		
			}
			if(lphpeqselect==5) {
				if (link[channelselect]) connect.EQRequest(GetLinkBitMask(),3,dsp_par_eq[channelselect,3*3+0],dsp_par_eq[channelselect,3*3+1],dsp_par_eq[channelselect,3*3+2]);
				else connect.EQRequest(GetChannelBitMask(channelselect),3,dsp_par_eq[channelselect,3*3+0],dsp_par_eq[channelselect,3*3+1],dsp_par_eq[channelselect,3*3+2]);
		
			}
			if(lphpeqselect==6) {
				if (link[channelselect]) connect.EQRequest(GetLinkBitMask(),4,dsp_par_eq[channelselect,4*3+0],dsp_par_eq[channelselect,4*3+1],dsp_par_eq[channelselect,4*3+2]);
				else connect.EQRequest(GetChannelBitMask(channelselect),4,dsp_par_eq[channelselect,4*3+0],dsp_par_eq[channelselect,4*3+1],dsp_par_eq[channelselect,4*3+2]);
		
			}	
							
		}
		
		void EQ0TypeSelectedIndexChanged(object sender, EventArgs e)
		{
			if (EQ0Type.SelectedIndex == 0) {
				EQ0Q.Visible = true;
				EQ0Q.Text = "0.7";
				dsp_par_eq[channelselect,0*3+2] = 7;			
			}
			else {
				EQ0Q.Visible = false;
				dsp_par_eq[channelselect,0*3+2] = -EQ0Type.SelectedIndex;
				EQ0FreqClicked(null,null);
			}
			HPLPEQUpdateLinks();
			SendLPHPEQ();
			UpdateDSPPlotter();
		}
		
		void EQ1TypeSelectedIndexChanged(object sender, EventArgs e)
		{
			if (EQ1Type.SelectedIndex == 0) {
				EQ1Q.Visible = true;
				EQ1Q.Text = "0.7";
				dsp_par_eq[channelselect,1*3+2] = 7;			
			}
			else {
				EQ1Q.Visible = false;
				dsp_par_eq[channelselect,1*3+2] = -EQ1Type.SelectedIndex;
				EQ1FreqClicked(null,null);
			}
			HPLPEQUpdateLinks();
			SendLPHPEQ();
			UpdateDSPPlotter();
		}
		
		void EQ2TypeSelectedIndexChanged(object sender, EventArgs e)
		{
			if (EQ2Type.SelectedIndex == 0) {
				EQ2Q.Visible = true;
				EQ2Q.Text = "0.7";
				dsp_par_eq[channelselect,2*3+2] = 7;			
			}
			else {
				EQ2Q.Visible = false;
				dsp_par_eq[channelselect,2*3+2] = -EQ2Type.SelectedIndex;
				EQ2FreqClicked(null,null);
			}
			HPLPEQUpdateLinks();
			SendLPHPEQ();
			UpdateDSPPlotter();			
		}
		
		
		void EQ3TypeSelectedIndexChanged(object sender, EventArgs e)
		{
			if (EQ3Type.SelectedIndex == 0) {
				EQ3Q.Visible = true;
				EQ3Q.Text = "0.7";
				dsp_par_eq[channelselect,3*3+2] = 7;			
			}
			else {
				EQ3Q.Visible = false;
				dsp_par_eq[channelselect,3*3+2] = -EQ3Type.SelectedIndex;
				EQ3FreqClicked(null,null);
			}
			HPLPEQUpdateLinks();
			SendLPHPEQ();
			UpdateDSPPlotter();				
		}
		
		void EQ4TypeSelectedIndexChanged(object sender, EventArgs e)
		{
			if (EQ4Type.SelectedIndex == 0) {
				EQ4Q.Visible = true;
				EQ4Q.Text = "0.7";
				dsp_par_eq[channelselect,4*3+2] = 7;			
			}
			else {
				EQ4Q.Visible = false;
				dsp_par_eq[channelselect,4*3+2] = -EQ4Type.SelectedIndex;
				EQ3FreqClicked(null,null);
			}
			HPLPEQUpdateLinks();
			SendLPHPEQ();
			UpdateDSPPlotter();				
		}
	}
}