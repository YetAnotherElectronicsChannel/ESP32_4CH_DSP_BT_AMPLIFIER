
using System;
using System.Windows.Forms;
using System.IO;
namespace dsp_gui
{
	/// <summary>
	/// Description of FileSaveLoad.
	/// </summary>
	public class FileSaveLoad
	{
		MainForm parent;
		Encrypt encrypt;
		
		public FileSaveLoad(MainForm input)
		{
			parent = input;
			encrypt = new Encrypt();
		}
		
		public void SaveFile() {
			parent.saveFileDialog1.Filter = "Samp File (*.samp)|*.samp"  ;
		    parent.saveFileDialog1.FilterIndex = 2 ;
		     parent.saveFileDialog1.RestoreDirectory = true ;
		 
		     if(parent.saveFileDialog1.ShowDialog() == DialogResult.OK)
		     {
		     	
		    		
		     
			     string nl = "\r\n";
			     
			     string cmds = "";
			     cmds += "?,6,1,1,1,1"+nl;
			     cmds += "?,13,"+parent.sourceselect[0].ToString()+","+parent.sourceselect[1].ToString()+","+parent.sourceselect[2].ToString()+","+parent.sourceselect[3].ToString() + nl;
				 cmds += "?,7,"+parent.channelpolarity[0].ToString()+","+parent.channelpolarity[1].ToString()+","+parent.channelpolarity[2].ToString()+","+parent.channelpolarity[3].ToString() +nl;
				 cmds += "?,3,"+parent.channelgains[0].ToString()+","+parent.channelgains[1].ToString()+","+parent.channelgains[2].ToString()+","+parent.channelgains[3].ToString()+nl;
								
				 for (int i=0; i<4; i++) {
				 	cmds += "?,40,"+parent.GetChannelBitMask(i).ToString()+","+parent.channel_bypass[i,0].ToString()+","+parent.channel_bypass[i,1].ToString()+","+parent.channel_bypass[i,2].ToString()
				 			+","+parent.channel_bypass[i,3].ToString()+","+parent.channel_bypass[i,4].ToString()+","+parent.channel_bypass[i,5].ToString()+","+parent.channel_bypass[i,6].ToString()+nl;
				 	cmds += "?,0,"+parent.GetChannelBitMask(i).ToString()+","+parent.dsp_par_lp[i,0].ToString()+","+parent.dsp_par_lp[i,1].ToString()+","+parent.dsp_par_lp[i,2].ToString()+nl;
				 	cmds += "?,1,"+parent.GetChannelBitMask(i).ToString()+","+parent.dsp_par_hp[i,0].ToString()+","+parent.dsp_par_hp[i,1].ToString()+","+parent.dsp_par_hp[i,2].ToString()+nl;
				 	
				 	for (int y=0; y<5; y++) {
				 		cmds += "?,2,"+parent.GetChannelBitMask(i).ToString()+","+y.ToString()+","+parent.dsp_par_eq[i,y*3+0].ToString()+","+parent.dsp_par_eq[i,y*3+1].ToString()+","+parent.dsp_par_eq[i,y*3+2].ToString()+nl;
				 	
				 	}
				 }
				 cmds += "?,41,"+parent.global_bypass[0].ToString()+","+parent.global_bypass[1].ToString()+nl;
				 cmds += "?,4,"+parent.limiterthresholds[0].ToString()+","+parent.limiterthresholds[1].ToString()+","+parent.limiterthresholds[2].ToString()+","+parent.limiterthresholds[3].ToString()+","+
				 	parent.limitereleases[0].ToString()+","+parent.limitereleases[1].ToString()+","+parent.limitereleases[2].ToString()+","+parent.limitereleases[3].ToString()+","+nl;
				 cmds += "?,8,"+parent.channeldelay[0].ToString()+","+parent.channeldelay[1].ToString()+","+parent.channeldelay[2].ToString()+","+parent.channeldelay[3].ToString()+nl;
				 cmds += "?,11,"+parent.vbsdata[0].ToString()+","+parent.vbsdata[1].ToString() + nl;
				 cmds += "?,14,"+parent.dynbassdata[0].ToString()+","+parent.dynbassdata[1].ToString()+","+parent.dynbassdata[2].ToString()+","+parent.dynbassdata[3].ToString()+","+parent.dynbassdata[4].ToString() + nl;
				 cmds += "?,12,"+parent.irparams[0].ToString()+","+parent.irparams[1].ToString()+","+parent.irparams[2].ToString()+","+parent.irparams[3].ToString()+","+parent.irparams[4].ToString()+","+parent.irparams[5].ToString()+","+parent.irparams[6].ToString()+","+parent.irparams[7].ToString() + nl;
				
				 //source	
				cmds += "?,38" + nl;
				
				//polarity
				cmds += "?,32" + nl;
				//gain
				cmds += "?,28" + nl;
			
				for (int i=0; i<4; i++) {
					//bypasschannel
					cmds += "?,65,"+i.ToString() + nl;
					//lowpass
					cmds += "?,25,"+i.ToString() + nl;
					//highpass
					cmds += "?,26,"+i.ToString() + nl;
				
					for (int y=0;y<5;y++) {
						cmds += "?,27,"+i.ToString()+","+y.ToString() + nl;
					}
				}
				
				cmds += "?,66" + nl;
				//limiter
				cmds += "?,29" + nl;
				//delay
				cmds += "?,33" + nl;
			
				//vbs
				cmds += "?,36" + nl;
			
				//dynbass
				cmds += "?,39" + nl;
				
			 	cmds += "?,6,"+parent.channelmute[0].ToString()+","+parent.channelmute[1].ToString()+","+parent.channelmute[2].ToString()+","+parent.channelmute[3].ToString() + nl;
				
				//mute
				cmds += "?,31" + nl;
				//irparams
				cmds += "?,37";
				
				//string outtext = Encrypt.EncryptDo(cmds,"meindspistderbeste");
				//string md5 = Encrypt.CreateMD5(outtext);
				//File.WriteAllText(parent.saveFileDialog1.FileName,md5+outtext);
				File.WriteAllText(parent.saveFileDialog1.FileName,cmds);	 
				
			  }
		}
		
		public bool LoadFile(out string[] data) {
			parent.openFileDialog1.Filter = "Samp File (*.samp)|*.samp";
			parent.openFileDialog1.FileName = "";
			parent.openFileDialog1.FilterIndex = 2;
			parent.openFileDialog1.RestoreDirectory = true;
			string text = "";
			
			if (parent.openFileDialog1.ShowDialog() == DialogResult.OK)
    		{
			
				data = System.Text.RegularExpressions.Regex.Split(File.ReadAllText(parent.openFileDialog1.FileName),"\r\n|\r|\n");
				return true;
				//text = File.ReadAllText(parent.openFileDialog1.FileName);
				//string md5 = text.Substring(0,32);
				//string encryptedtext = text.Substring(32,text.Length-32);
				//string md5check = Encrypt.CreateMD5(encryptedtext);
				
				
				//if (md5.Equals(md5check)) {
				//	string decrypted = Encrypt.DecryptDo(encryptedtext,"meindspistderbeste");
				//	data = System.Text.RegularExpressions.Regex.Split(decrypted,"\r\n|\r|\n");
				//	File.WriteAllText(parent.openFileDialog1.FileName+"asd",decrypted);
				//	return true;
				//}
				//else {
				//	MessageBox.Show("File is corrupted!");
					
				//}
				
			}
			string[] empty = new string[2];
			data = empty;
			return false;
			
		}
	}
}
