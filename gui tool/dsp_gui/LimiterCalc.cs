
using System;
using System.Drawing;
using System.Windows.Forms;

namespace dsp_gui
{
	/// <summary>
	/// Description of LimiterCalc.
	/// </summary>
	public partial class LimitCalc : Form
	{
		public LimitCalc()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Label1Click(object sender, EventArgs e)
		{
			
		}
		
		int LimiterdBtoFullScale(int val) {
			
			double valf = (double) val;
			valf = Math.Pow(10.0f,valf/20.0f)*2147000000.0f;			
			return (int) valf;
		}
		
		void LimiterCalcBarValueChanged(object sender, decimal value)
		{
			LimitCalcVal.Text = LimiterCalcBar.Value.ToString() + " dB";
			int val = LimiterdBtoFullScale (LimiterCalcBar.Value);
			
			float valf = (float) val;
			
			float linevoltage = valf*6.3618642e-10f;
			float linevoltagerms = linevoltage/1.4142f;
			float ampvoltage = 	valf*1.254575838479479e-8f;
			float ampvoltagerms = ampvoltage/1.4142f;
			
			float power8ohm = ampvoltagerms*ampvoltagerms/8.0f;
			float power4ohm = ampvoltagerms*ampvoltagerms/4.0f;
			if (power8ohm < 0.01f) ampout.Text = "Amp Output: " + Math.Round((double)ampvoltage,3) + "V (PEAK) | "+Math.Round((double)ampvoltagerms,3)+"V (RMS) | " + Math.Round((double)power4ohm,4)+ "W @ 4 Ohms | " + Math.Round((double)power8ohm,4)+ "W @ 8 Ohms";
			else ampout.Text = "Amp Output: " + Math.Round((double)ampvoltage,2) + "V (PEAK) | "+Math.Round((double)ampvoltagerms,2)+"V (RMS) | " + Math.Round((double)power4ohm,2)+ "W @ 4 Ohms | " + Math.Round((double)power8ohm,2)+ "W @ 8 Ohms";
			if (linevoltagerms < 0.01f) lineout.Text = "Line Output: "+Math.Round((double)linevoltage,4)+"V (PEAK) | "+Math.Round((double)linevoltagerms,4)+ "V (RMS)";
			else lineout.Text = "Line Output: "+Math.Round((double)linevoltage,2)+"V (PEAK) | "+Math.Round((double)linevoltagerms,2)+ "V (RMS)";
			
		}
	}
}
