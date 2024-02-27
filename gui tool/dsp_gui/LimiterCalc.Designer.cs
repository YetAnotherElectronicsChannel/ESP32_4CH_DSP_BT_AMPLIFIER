/*
 * Created by SharpDevelop.
 * User: Markus
 * Date: 02.02.2021
 * Time: 23:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace dsp_gui
{
	partial class LimitCalc
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.LimiterCalcBar = new XComponent.SliderBar.MACTrackBar();
			this.LimitCalcVal = new System.Windows.Forms.Label();
			this.ampout = new System.Windows.Forms.Label();
			this.lineout = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// LimiterCalcBar
			// 
			this.LimiterCalcBar.BackColor = System.Drawing.Color.Transparent;
			this.LimiterCalcBar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.LimiterCalcBar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LimiterCalcBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
			this.LimiterCalcBar.IndentHeight = 6;
			this.LimiterCalcBar.Location = new System.Drawing.Point(12, 35);
			this.LimiterCalcBar.Maximum = 0;
			this.LimiterCalcBar.Minimum = -70;
			this.LimiterCalcBar.Name = "LimiterCalcBar";
			this.LimiterCalcBar.Size = new System.Drawing.Size(444, 28);
			this.LimiterCalcBar.TabIndex = 33;
			this.LimiterCalcBar.TextTickStyle = System.Windows.Forms.TickStyle.None;
			this.LimiterCalcBar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
			this.LimiterCalcBar.TickFrequency = 1000;
			this.LimiterCalcBar.TickHeight = 4;
			this.LimiterCalcBar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.LimiterCalcBar.TrackerColor = System.Drawing.Color.White;
			this.LimiterCalcBar.TrackerSize = new System.Drawing.Size(16, 16);
			this.LimiterCalcBar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
			this.LimiterCalcBar.TrackLineHeight = 3;
			this.LimiterCalcBar.Value = 0;
			this.LimiterCalcBar.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.LimiterCalcBarValueChanged);
			// 
			// LimitCalcVal
			// 
			this.LimitCalcVal.ForeColor = System.Drawing.Color.White;
			this.LimitCalcVal.Location = new System.Drawing.Point(479, 40);
			this.LimitCalcVal.Name = "LimitCalcVal";
			this.LimitCalcVal.Size = new System.Drawing.Size(59, 23);
			this.LimitCalcVal.TabIndex = 41;
			this.LimitCalcVal.Text = "0 dB";
			// 
			// ampout
			// 
			this.ampout.ForeColor = System.Drawing.Color.White;
			this.ampout.Location = new System.Drawing.Point(12, 97);
			this.ampout.Name = "ampout";
			this.ampout.Size = new System.Drawing.Size(512, 23);
			this.ampout.TabIndex = 42;
			this.ampout.Text = "Amp Output: 26,94V (PEAK) | 19,05V (RMS) | 90,69W @ 4 Ohms | 45,35W @ 8 Ohms";
			this.ampout.Click += new System.EventHandler(this.Label1Click);
			// 
			// lineout
			// 
			this.lineout.ForeColor = System.Drawing.Color.White;
			this.lineout.Location = new System.Drawing.Point(12, 137);
			this.lineout.Name = "lineout";
			this.lineout.Size = new System.Drawing.Size(512, 23);
			this.lineout.TabIndex = 43;
			this.lineout.Text = "Line Output: 1,37V (PEAK) | 0,97V (RMS)";
			// 
			// LimitCalc
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(517, 168);
			this.Controls.Add(this.lineout);
			this.Controls.Add(this.ampout);
			this.Controls.Add(this.LimitCalcVal);
			this.Controls.Add(this.LimiterCalcBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "LimitCalc";
			this.Text = "Limiter Calculator";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lineout;
		private System.Windows.Forms.Label ampout;
		private System.Windows.Forms.Label LimitCalcVal;
		private XComponent.SliderBar.MACTrackBar LimiterCalcBar;
	}
}
