
using System;
using System.Net.Sockets;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
namespace dsp_gui
{
	/// <summary>
	/// Description of TCP_Connect.
	/// </summary>
	public class TCP_Connect
	{
		MainForm parent = null;
		TcpClient client = null;
		NetworkStream stream = null;
		System.Timers.Timer timerrx = null;
		System.Timers.Timer timertx = null;
		StringFIFO cmdfifo = new StringFIFO();
		
		bool loaddatainprogress = false;
		int loadcmds = 0;
		
		bool levelpingping = true;
		
		bool waitanswer = false;
		
		bool TXAvailable = false;
		string TXData = String.Empty;
		
		bool IsError = false;
				
		bool sourcerequest = false;	
		bool muterequest = false;
		bool polarityrequest = false;
		int[] polarity = new int[4];
		
		bool lowpassrequest = false;
		int[] lowpass = new int[4]; 
		
		bool highpassrequest = false;
		int[] highpass = new int[4];
		
		bool eqrequest = false;
		int[] eq = new int[5];
		
		bool gainrequest = false;	
		bool limiterrequest = false;
		bool delayrequest = false;
		bool bassenhancerequest = false;
		bool dynbassrequest = false;
		
		bool globalbypassrequest = false;
		bool channelbypassrequest = false;
		
		int[] channelbypass = new int[8];
		
		bool irrequest = false;
		bool resetallrequest = false;
		bool savetoflashrequest = false;
		
		double[] levels = new double[9];
		int[] ircode = new int[2];
		bool wasir = false;
		string inputbuffer = "";
		
		bool polllevels = true;
		
		public TCP_Connect(MainForm input)
			
		{
			parent = input;
		}
		
		public bool connect(string ip, int port) {
			try {
				client = new TcpClient(ip,port);
				stream = client.GetStream();
				
			    timertx = new System.Timers.Timer(50);
				timertx.Elapsed += TimerTXEvent;
				timertx.AutoReset = true;
				timertx.Enabled = true;
				
				timerrx = new System.Timers.Timer(50);
				timerrx.Elapsed += TimerRXEvent;
				timerrx.AutoReset = true;
				timerrx.Enabled = true;
				
			
				return true;
			}
			catch {
				MessageBox.Show("Connection to device failed! Please check your Wi-Fi connection","Network Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				System.Environment.Exit(0);
				IsError = true;
				return false;
			}
			
		}
		
		public void close() {
			timertx.Enabled = false;
			timerrx.Enabled = false;
			stream.Close();
			client.Close();
			
		}
		
	
				
		public bool IsErrorHappened() {
			return IsError;
		}
		
		public void  TimerTXEvent(Object source, ElapsedEventArgs e) {
									
				if (waitanswer == true) return;
				
				string txstring = "";
				if (cmdfifo.size()>0) {
					
					txstring = cmdfifo.pop();
					//Console.WriteLine(cmdfifo.size().ToString() + " " + txstring);
					WriteData(txstring);
					return;
				}
				
				if (levelpingping) {
					txstring = "?,30";
					if (polllevels) WriteData(txstring);
					levelpingping = false;
					return;
				}
				else levelpingping = true;
				
				
				
				if (sourcerequest) {				
					txstring = "?,13,"+parent.sourceselect[0].ToString()+","+parent.sourceselect[1].ToString()+","+parent.sourceselect[2].ToString()+","+parent.sourceselect[3].ToString();
					sourcerequest=false;
					WriteData(txstring);
				}
				
				
				else if (muterequest) {
					txstring = "?,6,"+parent.channelmute[0].ToString()+","+parent.channelmute[1].ToString()+","+parent.channelmute[2].ToString()+","+parent.channelmute[3].ToString();
					muterequest=false;
					WriteData(txstring);
				}
				
				else if (polarityrequest) {					
					txstring = "?,7,"+parent.channelpolarity[0].ToString()+","+parent.channelpolarity[1].ToString()+","+parent.channelpolarity[2].ToString()+","+parent.channelpolarity[3].ToString();
					polarityrequest=false;
					WriteData(txstring);
				}
				
				else if (gainrequest) {
					
					txstring = "?,3,"+parent.channelgains[0].ToString()+","+parent.channelgains[1].ToString()+","+parent.channelgains[2].ToString()+","+parent.channelgains[3].ToString();
					gainrequest=false;
					WriteData(txstring);
				}
				
				else if (lowpassrequest) {
					txstring = "?,0,"+lowpass[0].ToString()+","+lowpass[1].ToString()+","+lowpass[2].ToString()+","+lowpass[3].ToString();
					lowpassrequest=false;	
					WriteData(txstring);	
								
					
				}
				else if (highpassrequest) {
					txstring = "?,1,"+highpass[0].ToString()+","+highpass[1].ToString()+","+highpass[2].ToString()+","+highpass[3].ToString();
					highpassrequest=false;	
					WriteData(txstring);	
					
				}
				
				else if (eqrequest) {
					txstring = "?,2,"+eq[0].ToString()+","+eq[1].ToString()+","+eq[2].ToString()+","+eq[3].ToString()+","+eq[4].ToString();
					eqrequest = false;
					WriteData(txstring);
					
				}
				
				else if (limiterrequest) {
					txstring = "?,4,"+parent.limiterthresholds[0].ToString()+","+parent.limiterthresholds[1].ToString()+","+parent.limiterthresholds[2].ToString()+","+parent.limiterthresholds[3].ToString() +
						","+parent.limitereleases[0].ToString() + ","+parent.limitereleases[1].ToString() + ","+parent.limitereleases[2].ToString() + ","+parent.limitereleases[3].ToString();
					
					limiterrequest = false;
					WriteData(txstring);
				}
				
				else if (delayrequest) {
					
					txstring = "?,8,"+parent.channeldelay[0].ToString()+","+parent.channeldelay[1].ToString()+","+parent.channeldelay[2].ToString()+","+parent.channeldelay[3].ToString();						
					delayrequest = false;
					WriteData(txstring);
				}
				
				else if (bassenhancerequest) {
					txstring = "?,11,"+parent.vbsdata[0].ToString()+","+parent.vbsdata[1].ToString();
					bassenhancerequest = false;
					WriteData(txstring);
				}
				
				else if (dynbassrequest) {
					
					txstring = "?,14,"+parent.dynbassdata[0].ToString()+","+parent.dynbassdata[1].ToString()+","+parent.dynbassdata[2].ToString()+","+parent.dynbassdata[3].ToString()+","+parent.dynbassdata[4].ToString();
					dynbassrequest = false;
					WriteData(txstring);
				}
				
				else if (irrequest) {
					txstring = "?,12,"+parent.irparams[0].ToString()+","+parent.irparams[1].ToString()+","+parent.irparams[2].ToString()+","+parent.irparams[3].ToString()+","+parent.irparams[4].ToString()+","+parent.irparams[5].ToString()+","+parent.irparams[6].ToString()+","+parent.irparams[7].ToString();
					irrequest = false;
					WriteData(txstring);
				}
				else if (globalbypassrequest) {
					txstring = "?,41,"+parent.global_bypass[0].ToString()+","+parent.global_bypass[1].ToString();
					globalbypassrequest=false;
					WriteData(txstring);
				}
				else if (channelbypassrequest) {
					txstring = "?,40,"+channelbypass[0].ToString()
							+ ","+channelbypass[1].ToString()
							+ ","+channelbypass[2].ToString()
							+ ","+channelbypass[3].ToString()
							+ ","+channelbypass[4].ToString()
							+ ","+channelbypass[5].ToString()
							+ ","+channelbypass[6].ToString()
							+ ","+channelbypass[7].ToString();
					channelbypassrequest = false;
					WriteData(txstring);
				}
				
				else if (savetoflashrequest) {
					txstring = "?,10";
					savetoflashrequest = false;
					WriteData(txstring);
				}
				
				else if (resetallrequest) {
					txstring = "?,9";
					resetallrequest = false;
					WriteData(txstring);
				}
				else {
					txstring = "?,30";
					if (polllevels) WriteData(txstring);
				}
			
			
				
				
				
		}
		
		public void SetPollLevels(bool input) {
			polllevels = input;
		}
		public void SetSourceRequest(int ch0, int ch1, int ch2, int ch3) {
			parent.sourceselect[0] = ch0;
			parent.sourceselect[1] = ch1;
			parent.sourceselect[2] = ch2;
			parent.sourceselect[3] = ch3;
			sourcerequest = true;
		}
		
		public void SetMuteRequest(bool ch0, bool ch1, bool ch2, bool ch3) {
			
			
			if (ch0) parent.channelmute[0] = 1;
			else parent.channelmute[0] = 0;
			if (ch1) parent.channelmute[1] = 1;
			else parent.channelmute[1] = 0;
			if (ch2) parent.channelmute[2] = 1;
			else parent.channelmute[2] = 0;
			if (ch3) parent.channelmute[3] = 1;
			else parent.channelmute[3] = 0;
			
			muterequest = true;
			
		}
		
		public void SetPolarityRequest(bool ch0, bool ch1, bool ch2, bool ch3) {
			if (ch0) parent.channelpolarity[0] = 1;
			else parent.channelpolarity[0] = 0;
			if (ch1) parent.channelpolarity[1] = 1;
			else parent.channelpolarity[1] = 0;
			if (ch2) parent.channelpolarity[2] = 1;
			else parent.channelpolarity[2] = 0;
			if (ch3) parent.channelpolarity[3] = 1;
			else parent.channelpolarity[3] = 0;
			
			polarityrequest = true;
		}
		
		public void SetGainRequest(int ch0, int ch1, int ch2, int ch3) {
			parent.channelgains[0] = ch0;
			parent.channelgains[1] = ch1;
			parent.channelgains[2] = ch2;
			parent.channelgains[3] = ch3;
			
			gainrequest = true;			
		}
		
		public void SetLimiterRequest(int thres_ch0, int thres_ch1, int thres_ch2, int thres_ch3, int rel_ch0, int rel_ch1, int rel_ch2, int rel_ch3) {
			
			
			parent.limiterthresholds[0] = thres_ch0;
			parent.limiterthresholds[1] = thres_ch1;
			parent.limiterthresholds[2] = thres_ch2;
			parent.limiterthresholds[3] = thres_ch3;
			parent.limitereleases[0] = rel_ch0;
			parent.limitereleases[1] = rel_ch1;
			parent.limitereleases[2] = rel_ch2;
			parent.limitereleases[3] = rel_ch3;
			
			limiterrequest = true;
		}
		
		public void SetDelayRequest (int ch0, int ch1, int ch2, int ch3) {
			parent.channeldelay[0] = ch0;
			parent.channeldelay[1] = ch1;
			parent.channeldelay[2] = ch2;
			parent.channeldelay[3] = ch3;
			
			delayrequest = true;
		}
		
		public void SetBassEnhanceRequest(int freq, int gain) {
			
			parent.vbsdata[0] = freq;
			parent.vbsdata[1] = gain;
			bassenhancerequest = true;
			
		}
		
		public void SetDynBassRequest(int watchtime, int threshold, int frequency, int gain, int gainspeed) {
			parent.dynbassdata[0] = watchtime;
			parent.dynbassdata[1] = threshold;
			parent.dynbassdata[2] = frequency;
			parent.dynbassdata[3] = gain;
			parent.dynbassdata[4] = gainspeed;
			dynbassrequest = true;
		}
		
		public void LowPassRequest(int channel, int order, int frequency, int q) {
			lowpass[0] = channel;
			lowpass[1] = order;
			lowpass[2] = frequency;
			lowpass[3] = q;
			lowpassrequest = true;
			
		}
		
		public void HighPassRequest(int channel, int order, int frequency, int q) {
			highpass[0] = channel;
			highpass[1] = order;
			highpass[2] = frequency;
			highpass[3] = q;
			highpassrequest = true;
			
		}
		
		public void EQRequest(int channel, int eqno, int freq, int gain, int q) {
			
			eq[0] = channel;
			eq[1] = eqno;
			eq[2] = freq;
			eq[3] = gain;
			eq[4] = q;
			eqrequest = true;
		}
		
		public void IRRequest(int onoffaddr, int onoffcmd, int volupaddr, int volupcmd, int voldownaddr, int voldowncmd, int muteaddr, int mutecmd) {
			parent.irparams[0] = onoffaddr;
			parent.irparams[1] = onoffcmd;
			parent.irparams[2] = volupaddr;
			parent.irparams[3] = volupcmd;
			parent.irparams[4] = voldownaddr;
			parent.irparams[5] = voldowncmd;
			parent.irparams[6] = muteaddr;
			parent.irparams[7] = mutecmd;
			irrequest = true;
		}
		
		public void PublicBypassRequest (int vbs, int dynbass) {
			parent.global_bypass[0] = vbs;
			parent.global_bypass[1] = dynbass;
			globalbypassrequest = true;
		}
		
		public void ChannelBypassRequest(int channel, int lp, int hp, int eq0, int eq1, int eq2, int eq3, int eq4) {
			channelbypass[0] = channel;
			channelbypass[1] = lp;
			channelbypass[2] = hp;
			channelbypass[3] = eq0;
			channelbypass[4] = eq1;
			channelbypass[5] = eq2;
			channelbypass[6] = eq3;
			channelbypass[7] = eq4;
			channelbypassrequest = true;
			
		}
		public void SaveSettingsRequest() {
			savetoflashrequest = true;
		}
		
		public void ResetAllRequest() {
			resetallrequest = true;
		}
		
		void WriteData(string strin) {
			
			try {
				Byte[] txdata = System.Text.Encoding.ASCII.GetBytes(strin);
				stream.Write(txdata,0,txdata.Length);
				waitanswer = true;	
				
			}
			catch {
				IsError = true;
				
			}
		}
		
		public void TimerRXEvent(Object source, ElapsedEventArgs e) {
			
			
			Byte[] data = new Byte[256];
			//Console.WriteLine("Input Buffer: "+inputbuffer);
			
			if (stream.DataAvailable) {
						
				try {
					Int32 bytes = stream.Read ( data, 0, data.Length);
					string RXData = System.Text.Encoding.ASCII.GetString(data,0,bytes);
					inputbuffer += RXData;	
										
				}
				catch {
					
					IsError = true;
					
				}
			}
			
				if (inputbuffer.Contains("!") && inputbuffer.Contains("?")) {
						waitanswer = false;
						int indexstart = inputbuffer.IndexOf('!');
						int indexstop = inputbuffer.IndexOf('?');
						//Console.WriteLine("start: "+indexstart+" stop:"+indexstop);
						string interpret = inputbuffer.Substring(indexstart,(indexstop-indexstart)+1);
						inputbuffer = inputbuffer.Substring(indexstop+1);
						//Console.WriteLine("interpet: "+interpret);
						DataInterpreter(interpret);
					
				}
				
				
			
			
		}
		
		void DataInterpreter(string input) {
			
			//Console.WriteLine("Interpret: "+input);
			string[] split = input.Split(',');
			if (!(split[0].Equals("!")&&split[split.Length-1].Equals("?"))) {
				Console.WriteLine("Wrong format received:" + input);
				
				return;
			}
			
			int[] ints = new int[split.Length-2];
			int y=0;
			
			for (int i=1; i<split.Length-1; i++) {				
				 ints[y] = Int32.Parse(split[i]); 					
					y++;
			}
			
			
			if (ints[0] == 55 || ints[0] == 555) InterpretLevel(ints);
			
			if (ints[0] == 10 && ints[1] == 1) MessageBox.Show("Settings saved on device!");
			
			if (ints[0]==38) {
				parent.sourceselect[0] = ints[1];
				parent.sourceselect[1] = ints[2];
				parent.sourceselect[2] = ints[3];
				parent.sourceselect[3] = ints[4];
			}
			
			if (ints[0]==31) {
				parent.channelmute[0] = ints[1];
				parent.channelmute[1] = ints[2];
				parent.channelmute[2] = ints[3];
				parent.channelmute[3] = ints[4];
			}
			
			if (ints[0]==32) {
				parent.channelpolarity[0] = ints[1];
				parent.channelpolarity[1] = ints[2];
				parent.channelpolarity[2] = ints[3];
				parent.channelpolarity[3] = ints[4];
			}
			
			if (ints[0]==28) {
				parent.channelgains[0] = ints[1];
				parent.channelgains[1] = ints[2];
				parent.channelgains[2] = ints[3];
				parent.channelgains[3] = ints[4];
			}
			
			if (ints[0]==25) {
				parent.dsp_par_lp[ints[1],0]=ints[2];
				parent.dsp_par_lp[ints[1],1]=ints[3];
				parent.dsp_par_lp[ints[1],2]=ints[4];				
			}
			
			if (ints[0]==26) {
				parent.dsp_par_hp[ints[1],0]=ints[2];
				parent.dsp_par_hp[ints[1],1]=ints[3];
				parent.dsp_par_hp[ints[1],2]=ints[4];	
			}
			
			if (ints[0]==27) {
				parent.dsp_par_eq[ints[1],ints[2]*3+0]=ints[3];
				parent.dsp_par_eq[ints[1],ints[2]*3+1]=ints[4];
				parent.dsp_par_eq[ints[1],ints[2]*3+2]=ints[5];
			}
			
			if (ints[0]==29) {
				parent.limiterthresholds[0] = ints[1];
				parent.limiterthresholds[1] = ints[2];
				parent.limiterthresholds[2] = ints[3];
				parent.limiterthresholds[3] = ints[4];
				parent.limitereleases[0] = ints[5];
				parent.limitereleases[1] = ints[6];
				parent.limitereleases[2] = ints[7];
				parent.limitereleases[3] = ints[8];
				
			}
			
			if (ints[0]==33) {
				parent.channeldelay[0] = ints[1];
				parent.channeldelay[1] = ints[2];
				parent.channeldelay[2] = ints[3];
				parent.channeldelay[3] = ints[4];
			}
			
			if (ints[0]==36) {
				parent.vbsdata[0] = ints[1];
				parent.vbsdata[1] = ints[2];
			}
			
			
			
			if (ints[0]==39) {
				parent.dynbassdata[0] = ints[1];
				parent.dynbassdata[1] = ints[2];
				parent.dynbassdata[2] = ints[3];
				parent.dynbassdata[3] = ints[4];
				parent.dynbassdata[4] = ints[5];
				
			}
			
			if (ints[0] == 66) {
				parent.global_bypass[0]=ints[1];
				parent.global_bypass[1]=ints[2];
			}
			
			if (ints[0] == 65) {
				parent.channel_bypass[ints[1],0] = ints[2];
				parent.channel_bypass[ints[1],1] = ints[3];
				parent.channel_bypass[ints[1],2] = ints[4];
				parent.channel_bypass[ints[1],3] = ints[5];
				parent.channel_bypass[ints[1],4] = ints[6];
				parent.channel_bypass[ints[1],5] = ints[7];
				parent.channel_bypass[ints[1],6] = ints[8];
			}
			
			if (ints[0] == 37) {
				parent.irparams[0] = ints[1];
				parent.irparams[1] = ints[2];
				parent.irparams[2] = ints[3];
				parent.irparams[3] = ints[4];
				parent.irparams[4] = ints[5];
				parent.irparams[5] = ints[6];
				parent.irparams[6] = ints[7];
				parent.irparams[7] = ints[8];
				loaddatainprogress=false;
				cmdfifo.clear();
			}
			
			
			
		}
		
		void InterpretLevel(int[] input) {
			levels[0] = LinearToDB(input[1]);
			levels[1] = LinearToDB(input[2]);
			levels[2] = LinearToDB(input[3]);
			levels[3] = LinearToDB(input[4]);
			levels[4] = input[5];
			levels[5] = input[6];
			levels[6] = input[7];
			levels[7] = input[8];
			levels[8] = input[9];				
				
			if (input[0]==555) {
				ircode[0] = input[10];
				ircode[1] = input[11];
				wasir = true;
			}	
		}
		
		public bool IsLoadingData() {
			return loaddatainprogress;
		}
		
		public void StartLoadData() {
			loaddatainprogress = true;
			//source	
			cmdfifo.push("?,38");
			//mute
			cmdfifo.push("?,31");
			//polarity
			cmdfifo.push("?,32");
			//gain
			cmdfifo.push("?,28");
			
			for (int i=0; i<4; i++) {
				//bypasschannel
				cmdfifo.push("?,65,"+i.ToString());
				//lowpass
				cmdfifo.push("?,25,"+i.ToString());
				//highpass
				cmdfifo.push("?,26,"+i.ToString());
				
				for (int y=0;y<5;y++) {
					cmdfifo.push("?,27,"+i.ToString()+","+y.ToString());
				}
			}
			
			//bypass global
			cmdfifo.push("?,66");
			             
			//limiter
			cmdfifo.push("?,29");
			//delay
			cmdfifo.push("?,33");
			
			//vbs
			cmdfifo.push("?,36");
			
			//dynbass
			cmdfifo.push("?,39");
			
			
			//irparams
			cmdfifo.push("?,37");
			
			loadcmds = cmdfifo.size();
			
		}
		
		public void ExecuteCMDs(string[] cmds) {
			loaddatainprogress = true;
			cmdfifo.clear();
			for (int i=0; i<cmds.Length; i++) {
				cmdfifo.push(cmds[i]);
			}
			loadcmds = cmdfifo.size();
		}
		
		public int LoadingStatus() {
			float temp = 1.0f - (((float)cmdfifo.size())/(float)loadcmds);
			return (int) (temp*100.0f);
		}
		static double LinearToDB(int lin) {
			double maxvali = 2147483648.0f;
			double inputf = (double) lin;
			double val = 20.0f*Math.Log10(inputf/maxvali);
			return val;
		}
		
		
		public void GetLevelInformation (out double[] levelinfo, out int[] ircodeinfo, out bool iractive) {
			levelinfo = new double[9];
			ircodeinfo = new int[2];
			for (int i=0; i<9; i++) levelinfo[i] = levels[i];
			ircodeinfo[0] = ircode[0];
			ircodeinfo[1] = ircode[1];
			iractive = wasir;
			wasir = false;
		}
		
	}
}
