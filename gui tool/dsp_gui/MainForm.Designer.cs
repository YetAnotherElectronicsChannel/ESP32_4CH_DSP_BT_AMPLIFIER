/*
 * Created by SharpDevelop.
 * User: Noll
 * Date: 08.12.2020
 * Time: 12:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using XComponent.SliderBar;
using Ernzo.WinForms.Controls;
namespace dsp_gui
{
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.peakMeterCtrl2 = new Ernzo.WinForms.Controls.PeakMeterCtrl();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.GainCH3Bar = new XComponent.SliderBar.MACTrackBar();
			this.GainCH2Bar = new XComponent.SliderBar.MACTrackBar();
			this.GainCH1Bar = new XComponent.SliderBar.MACTrackBar();
			this.GainCH0Bar = new XComponent.SliderBar.MACTrackBar();
			this.GainCH3Text = new System.Windows.Forms.Label();
			this.GainCH2Text = new System.Windows.Forms.Label();
			this.GainCH1Text = new System.Windows.Forms.Label();
			this.GainCH0Text = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.PolCH3 = new System.Windows.Forms.CheckBox();
			this.PolCH2 = new System.Windows.Forms.CheckBox();
			this.PolCH1 = new System.Windows.Forms.CheckBox();
			this.PolCH0 = new System.Windows.Forms.CheckBox();
			this.Mute = new System.Windows.Forms.GroupBox();
			this.MuteCH3 = new System.Windows.Forms.CheckBox();
			this.MuteCH2 = new System.Windows.Forms.CheckBox();
			this.MuteCH1 = new System.Windows.Forms.CheckBox();
			this.MuteCH0 = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.Source3Select = new System.Windows.Forms.ComboBox();
			this.Source2Select = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.Source1Select = new System.Windows.Forms.ComboBox();
			this.Source0Select = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage9 = new System.Windows.Forms.TabPage();
			this.LPBypass = new System.Windows.Forms.Button();
			this.EQ4Bypass = new System.Windows.Forms.Button();
			this.EQ3Bypass = new System.Windows.Forms.Button();
			this.EQ2Bypass = new System.Windows.Forms.Button();
			this.EQ1Bypass = new System.Windows.Forms.Button();
			this.EQ0Bypass = new System.Windows.Forms.Button();
			this.HPBypass = new System.Windows.Forms.Button();
			this.label57 = new System.Windows.Forms.Label();
			this.label59 = new System.Windows.Forms.Label();
			this.label60 = new System.Windows.Forms.Label();
			this.label61 = new System.Windows.Forms.Label();
			this.LPOrder = new System.Windows.Forms.ComboBox();
			this.LPQ = new System.Windows.Forms.TextBox();
			this.LPFreq = new System.Windows.Forms.TextBox();
			this.label52 = new System.Windows.Forms.Label();
			this.label55 = new System.Windows.Forms.Label();
			this.label50 = new System.Windows.Forms.Label();
			this.HPOrder = new System.Windows.Forms.ComboBox();
			this.HPQ = new System.Windows.Forms.TextBox();
			this.EQ4Type = new System.Windows.Forms.ComboBox();
			this.EQ3Type = new System.Windows.Forms.ComboBox();
			this.label54 = new System.Windows.Forms.Label();
			this.EQ2Type = new System.Windows.Forms.ComboBox();
			this.EQ1Type = new System.Windows.Forms.ComboBox();
			this.label53 = new System.Windows.Forms.Label();
			this.EQ0Type = new System.Windows.Forms.ComboBox();
			this.label49 = new System.Windows.Forms.Label();
			this.HPFreq = new System.Windows.Forms.TextBox();
			this.EQ4Gain = new System.Windows.Forms.TextBox();
			this.EQ4Q = new System.Windows.Forms.TextBox();
			this.EQ4Freq = new System.Windows.Forms.TextBox();
			this.label48 = new System.Windows.Forms.Label();
			this.EQ3Gain = new System.Windows.Forms.TextBox();
			this.EQ3Q = new System.Windows.Forms.TextBox();
			this.EQ3Freq = new System.Windows.Forms.TextBox();
			this.label47 = new System.Windows.Forms.Label();
			this.EQ2Gain = new System.Windows.Forms.TextBox();
			this.EQ2Q = new System.Windows.Forms.TextBox();
			this.EQ2Freq = new System.Windows.Forms.TextBox();
			this.label46 = new System.Windows.Forms.Label();
			this.EQ1Gain = new System.Windows.Forms.TextBox();
			this.EQ1Q = new System.Windows.Forms.TextBox();
			this.EQ1Freq = new System.Windows.Forms.TextBox();
			this.label45 = new System.Windows.Forms.Label();
			this.EQ0Gain = new System.Windows.Forms.TextBox();
			this.lphpeqbar = new XComponent.SliderBar.MACTrackBar();
			this.EQ0Q = new System.Windows.Forms.TextBox();
			this.label44 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.EQ0Freq = new System.Windows.Forms.TextBox();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.ampoutvoltage = new System.Windows.Forms.Label();
			this.LimitRelVal = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.LimiterReleaseBar = new XComponent.SliderBar.MACTrackBar();
			this.LimitThresVal = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.LimiterTresholdBar = new XComponent.SliderBar.MACTrackBar();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.DelayVal3 = new System.Windows.Forms.Label();
			this.DelayVal2 = new System.Windows.Forms.Label();
			this.DelayVal1 = new System.Windows.Forms.Label();
			this.DelayVal0 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.DelayBar3 = new XComponent.SliderBar.MACTrackBar();
			this.DelayBar2 = new XComponent.SliderBar.MACTrackBar();
			this.DelayBar1 = new XComponent.SliderBar.MACTrackBar();
			this.DelayBar0 = new XComponent.SliderBar.MACTrackBar();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.VBS_Bypass = new System.Windows.Forms.Button();
			this.VBS_GainVal = new System.Windows.Forms.Label();
			this.VBS_FreqVal = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.VBS_GainBar = new XComponent.SliderBar.MACTrackBar();
			this.VBS_FreqBar = new XComponent.SliderBar.MACTrackBar();
			this.tabPage8 = new System.Windows.Forms.TabPage();
			this.DynBass_Bypass = new System.Windows.Forms.Button();
			this.DynBassLatestGain = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.DynBassWatchtime_Val = new System.Windows.Forms.Label();
			this.DynBassThres_Val = new System.Windows.Forms.Label();
			this.DynBassFreq_Val = new System.Windows.Forms.Label();
			this.DynBassGainSpeed_Val = new System.Windows.Forms.Label();
			this.DynBassMaxGain_Val = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.DynBassGainSpeed_Bar = new XComponent.SliderBar.MACTrackBar();
			this.DynBassMaxGain_Bar = new XComponent.SliderBar.MACTrackBar();
			this.DynBassFreq_Bar = new XComponent.SliderBar.MACTrackBar();
			this.DynBassThres_Bar = new XComponent.SliderBar.MACTrackBar();
			this.DynBassWatchtime_Bar = new XComponent.SliderBar.MACTrackBar();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.IR_VOLDOWN_PASTE = new System.Windows.Forms.Button();
			this.IR_VOLDOWN_CMD = new System.Windows.Forms.Label();
			this.IR_VOLDOWN_ADDR = new System.Windows.Forms.Label();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.IR_VOLUP_PASTE = new System.Windows.Forms.Button();
			this.IR_VOLUP_CMD = new System.Windows.Forms.Label();
			this.IR_VOLUP_ADDR = new System.Windows.Forms.Label();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.IR_MUTE_PASTE = new System.Windows.Forms.Button();
			this.IR_MUTE_CMD = new System.Windows.Forms.Label();
			this.IR_MUTE_ADDR = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.IR_ONOFF_PASTE = new System.Windows.Forms.Button();
			this.IR_ONOFF_CMD = new System.Windows.Forms.Label();
			this.IR_ONOFF_ADDR = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.IR_RX_CMD = new System.Windows.Forms.Label();
			this.IR_RX_ADDR = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.iractivityled = new System.Windows.Forms.Label();
			this.Limiter3Show = new System.Windows.Forms.Label();
			this.Limiter2Show = new System.Windows.Forms.Label();
			this.Limiter1Show = new System.Windows.Forms.Label();
			this.Limiter0Show = new System.Windows.Forms.Label();
			this.FormsTimer = new System.Windows.Forms.Timer(this.components);
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.Link3 = new System.Windows.Forms.CheckBox();
			this.Link2 = new System.Windows.Forms.CheckBox();
			this.Link1 = new System.Windows.Forms.CheckBox();
			this.Link0 = new System.Windows.Forms.CheckBox();
			this.LoadProgress = new System.Windows.Forms.ProgressBar();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.label35 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.label39 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.label41 = new System.Windows.Forms.Label();
			this.label42 = new System.Windows.Forms.Label();
			this.Out1Draw = new System.Windows.Forms.RadioButton();
			this.Out2Draw = new System.Windows.Forms.RadioButton();
			this.Out3Draw = new System.Windows.Forms.RadioButton();
			this.Out4Draw = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.Mute.SuspendLayout();
			this.tabPage9.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage8.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(-100, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(750, 400);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.PictureBox1Click);
			// 
			// button5
			// 
			this.button5.ForeColor = System.Drawing.Color.Black;
			this.button5.Location = new System.Drawing.Point(789, 162);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(150, 40);
			this.button5.TabIndex = 7;
			this.button5.Text = "Save Settings to Device";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// button6
			// 
			this.button6.ForeColor = System.Drawing.Color.Black;
			this.button6.Location = new System.Drawing.Point(789, 208);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(150, 40);
			this.button6.TabIndex = 8;
			this.button6.Text = "Load Settings from Device";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.Button6Click);
			// 
			// button7
			// 
			this.button7.ForeColor = System.Drawing.Color.Black;
			this.button7.Location = new System.Drawing.Point(789, 116);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(150, 40);
			this.button7.TabIndex = 9;
			this.button7.Text = "Reset all";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.Button7Click);
			// 
			// peakMeterCtrl2
			// 
			this.peakMeterCtrl2.BackColor = System.Drawing.Color.Black;
			this.peakMeterCtrl2.BandsCount = 4;
			this.peakMeterCtrl2.ColorHigh = System.Drawing.Color.Red;
			this.peakMeterCtrl2.ColorHighBack = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.peakMeterCtrl2.ColorMedium = System.Drawing.Color.Yellow;
			this.peakMeterCtrl2.ColorMediumBack = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.peakMeterCtrl2.ColorNormal = System.Drawing.Color.LawnGreen;
			this.peakMeterCtrl2.ColorNormalBack = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.peakMeterCtrl2.FalloffColor = System.Drawing.Color.Gray;
			this.peakMeterCtrl2.FalloffEffect = false;
			this.peakMeterCtrl2.FalloffSpeed = 100;
			this.peakMeterCtrl2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.peakMeterCtrl2.LEDCount = 30;
			this.peakMeterCtrl2.Location = new System.Drawing.Point(706, 8);
			this.peakMeterCtrl2.Name = "peakMeterCtrl2";
			this.peakMeterCtrl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.peakMeterCtrl2.Size = new System.Drawing.Size(67, 381);
			this.peakMeterCtrl2.TabIndex = 5;
			this.peakMeterCtrl2.Text = "peakMeterCtrl2";
			this.peakMeterCtrl2.Click += new System.EventHandler(this.PeakMeterCtrl2Click);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(706, 392);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 23);
			this.label1.TabIndex = 15;
			this.label1.Text = "1    2    3    4";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage9);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Controls.Add(this.tabPage7);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage8);
			this.tabControl1.Controls.Add(this.tabPage6);
			this.tabControl1.Location = new System.Drawing.Point(12, 445);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(845, 239);
			this.tabControl1.TabIndex = 16;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabChangedEventHandler);
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.Black;
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.Mute);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.Source3Select);
			this.tabPage1.Controls.Add(this.Source2Select);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.Source1Select);
			this.tabPage1.Controls.Add(this.Source0Select);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(837, 213);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Source / Mute / Phase / Gain";
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.Black;
			this.groupBox2.Controls.Add(this.GainCH3Bar);
			this.groupBox2.Controls.Add(this.GainCH2Bar);
			this.groupBox2.Controls.Add(this.GainCH1Bar);
			this.groupBox2.Controls.Add(this.GainCH0Bar);
			this.groupBox2.Controls.Add(this.GainCH3Text);
			this.groupBox2.Controls.Add(this.GainCH2Text);
			this.groupBox2.Controls.Add(this.GainCH1Text);
			this.groupBox2.Controls.Add(this.GainCH0Text);
			this.groupBox2.ForeColor = System.Drawing.Color.White;
			this.groupBox2.Location = new System.Drawing.Point(454, 20);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(369, 164);
			this.groupBox2.TabIndex = 29;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Gain";
			// 
			// GainCH3Bar
			// 
			this.GainCH3Bar.BackColor = System.Drawing.Color.Transparent;
			this.GainCH3Bar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.GainCH3Bar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GainCH3Bar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
			this.GainCH3Bar.IndentHeight = 6;
			this.GainCH3Bar.Location = new System.Drawing.Point(19, 109);
			this.GainCH3Bar.Maximum = 20;
			this.GainCH3Bar.Minimum = -20;
			this.GainCH3Bar.Name = "GainCH3Bar";
			this.GainCH3Bar.Size = new System.Drawing.Size(276, 28);
			this.GainCH3Bar.TabIndex = 37;
			this.GainCH3Bar.TextTickStyle = System.Windows.Forms.TickStyle.None;
			this.GainCH3Bar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
			this.GainCH3Bar.TickFrequency = 1000;
			this.GainCH3Bar.TickHeight = 4;
			this.GainCH3Bar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.GainCH3Bar.TrackerColor = System.Drawing.Color.White;
			this.GainCH3Bar.TrackerSize = new System.Drawing.Size(16, 16);
			this.GainCH3Bar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
			this.GainCH3Bar.TrackLineHeight = 3;
			this.GainCH3Bar.Value = 0;
			this.GainCH3Bar.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.GainCH3BarValueChanged);
			// 
			// GainCH2Bar
			// 
			this.GainCH2Bar.BackColor = System.Drawing.Color.Transparent;
			this.GainCH2Bar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.GainCH2Bar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GainCH2Bar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
			this.GainCH2Bar.IndentHeight = 6;
			this.GainCH2Bar.Location = new System.Drawing.Point(19, 79);
			this.GainCH2Bar.Maximum = 20;
			this.GainCH2Bar.Minimum = -20;
			this.GainCH2Bar.Name = "GainCH2Bar";
			this.GainCH2Bar.Size = new System.Drawing.Size(276, 28);
			this.GainCH2Bar.TabIndex = 36;
			this.GainCH2Bar.TextTickStyle = System.Windows.Forms.TickStyle.None;
			this.GainCH2Bar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
			this.GainCH2Bar.TickFrequency = 1000;
			this.GainCH2Bar.TickHeight = 4;
			this.GainCH2Bar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.GainCH2Bar.TrackerColor = System.Drawing.Color.White;
			this.GainCH2Bar.TrackerSize = new System.Drawing.Size(16, 16);
			this.GainCH2Bar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
			this.GainCH2Bar.TrackLineHeight = 3;
			this.GainCH2Bar.Value = 0;
			this.GainCH2Bar.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.GainCH2BarValueChanged);
			// 
			// GainCH1Bar
			// 
			this.GainCH1Bar.BackColor = System.Drawing.Color.Transparent;
			this.GainCH1Bar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.GainCH1Bar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GainCH1Bar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
			this.GainCH1Bar.IndentHeight = 6;
			this.GainCH1Bar.Location = new System.Drawing.Point(19, 49);
			this.GainCH1Bar.Maximum = 20;
			this.GainCH1Bar.Minimum = -20;
			this.GainCH1Bar.Name = "GainCH1Bar";
			this.GainCH1Bar.Size = new System.Drawing.Size(276, 28);
			this.GainCH1Bar.TabIndex = 35;
			this.GainCH1Bar.TextTickStyle = System.Windows.Forms.TickStyle.None;
			this.GainCH1Bar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
			this.GainCH1Bar.TickFrequency = 1000;
			this.GainCH1Bar.TickHeight = 4;
			this.GainCH1Bar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.GainCH1Bar.TrackerColor = System.Drawing.Color.White;
			this.GainCH1Bar.TrackerSize = new System.Drawing.Size(16, 16);
			this.GainCH1Bar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
			this.GainCH1Bar.TrackLineHeight = 3;
			this.GainCH1Bar.Value = 0;
			this.GainCH1Bar.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.GainCH1BarValueChanged);
			// 
			// GainCH0Bar
			// 
			this.GainCH0Bar.BackColor = System.Drawing.Color.Transparent;
			this.GainCH0Bar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.GainCH0Bar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GainCH0Bar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
			this.GainCH0Bar.IndentHeight = 6;
			this.GainCH0Bar.Location = new System.Drawing.Point(19, 17);
			this.GainCH0Bar.Maximum = 20;
			this.GainCH0Bar.Minimum = -20;
			this.GainCH0Bar.Name = "GainCH0Bar";
			this.GainCH0Bar.Size = new System.Drawing.Size(276, 28);
			this.GainCH0Bar.TabIndex = 34;
			this.GainCH0Bar.TextTickStyle = System.Windows.Forms.TickStyle.None;
			this.GainCH0Bar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
			this.GainCH0Bar.TickFrequency = 1000;
			this.GainCH0Bar.TickHeight = 4;
			this.GainCH0Bar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.GainCH0Bar.TrackerColor = System.Drawing.Color.White;
			this.GainCH0Bar.TrackerSize = new System.Drawing.Size(16, 16);
			this.GainCH0Bar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
			this.GainCH0Bar.TrackLineHeight = 3;
			this.GainCH0Bar.Value = 0;
			this.GainCH0Bar.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.GainCH0BarValueChanged);
			// 
			// GainCH3Text
			// 
			this.GainCH3Text.Location = new System.Drawing.Point(301, 114);
			this.GainCH3Text.Name = "GainCH3Text";
			this.GainCH3Text.Size = new System.Drawing.Size(59, 16);
			this.GainCH3Text.TabIndex = 33;
			this.GainCH3Text.Text = "0 dB";
			// 
			// GainCH2Text
			// 
			this.GainCH2Text.Location = new System.Drawing.Point(301, 84);
			this.GainCH2Text.Name = "GainCH2Text";
			this.GainCH2Text.Size = new System.Drawing.Size(59, 16);
			this.GainCH2Text.TabIndex = 32;
			this.GainCH2Text.Text = "0 dB";
			// 
			// GainCH1Text
			// 
			this.GainCH1Text.Location = new System.Drawing.Point(301, 54);
			this.GainCH1Text.Name = "GainCH1Text";
			this.GainCH1Text.Size = new System.Drawing.Size(59, 16);
			this.GainCH1Text.TabIndex = 31;
			this.GainCH1Text.Text = "0 dB";
			// 
			// GainCH0Text
			// 
			this.GainCH0Text.Location = new System.Drawing.Point(301, 24);
			this.GainCH0Text.Name = "GainCH0Text";
			this.GainCH0Text.Size = new System.Drawing.Size(59, 16);
			this.GainCH0Text.TabIndex = 30;
			this.GainCH0Text.Text = "0 dB";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.PolCH3);
			this.groupBox1.Controls.Add(this.PolCH2);
			this.groupBox1.Controls.Add(this.PolCH1);
			this.groupBox1.Controls.Add(this.PolCH0);
			this.groupBox1.ForeColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(334, 20);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(102, 164);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "180°";
			// 
			// PolCH3
			// 
			this.PolCH3.Location = new System.Drawing.Point(6, 109);
			this.PolCH3.Name = "PolCH3";
			this.PolCH3.Size = new System.Drawing.Size(76, 24);
			this.PolCH3.TabIndex = 24;
			this.PolCH3.Text = "OUT 4";
			this.PolCH3.UseVisualStyleBackColor = true;
			this.PolCH3.CheckedChanged += new System.EventHandler(this.PolCH3CheckedChanged);
			// 
			// PolCH2
			// 
			this.PolCH2.Location = new System.Drawing.Point(6, 79);
			this.PolCH2.Name = "PolCH2";
			this.PolCH2.Size = new System.Drawing.Size(76, 24);
			this.PolCH2.TabIndex = 2;
			this.PolCH2.Text = "OUT 3";
			this.PolCH2.UseVisualStyleBackColor = true;
			this.PolCH2.CheckedChanged += new System.EventHandler(this.PolCH2CheckedChanged);
			// 
			// PolCH1
			// 
			this.PolCH1.Location = new System.Drawing.Point(6, 49);
			this.PolCH1.Name = "PolCH1";
			this.PolCH1.Size = new System.Drawing.Size(76, 24);
			this.PolCH1.TabIndex = 1;
			this.PolCH1.Text = "OUT 2";
			this.PolCH1.UseVisualStyleBackColor = true;
			this.PolCH1.CheckedChanged += new System.EventHandler(this.PolCH1CheckedChanged);
			// 
			// PolCH0
			// 
			this.PolCH0.Location = new System.Drawing.Point(6, 19);
			this.PolCH0.Name = "PolCH0";
			this.PolCH0.Size = new System.Drawing.Size(76, 24);
			this.PolCH0.TabIndex = 0;
			this.PolCH0.Text = "OUT 1";
			this.PolCH0.UseVisualStyleBackColor = true;
			this.PolCH0.CheckedChanged += new System.EventHandler(this.PolCH0CheckedChanged);
			// 
			// Mute
			// 
			this.Mute.Controls.Add(this.MuteCH3);
			this.Mute.Controls.Add(this.MuteCH2);
			this.Mute.Controls.Add(this.MuteCH1);
			this.Mute.Controls.Add(this.MuteCH0);
			this.Mute.ForeColor = System.Drawing.Color.White;
			this.Mute.Location = new System.Drawing.Point(217, 20);
			this.Mute.Name = "Mute";
			this.Mute.Size = new System.Drawing.Size(102, 164);
			this.Mute.TabIndex = 23;
			this.Mute.TabStop = false;
			this.Mute.Text = "Mute";
			// 
			// MuteCH3
			// 
			this.MuteCH3.Location = new System.Drawing.Point(6, 109);
			this.MuteCH3.Name = "MuteCH3";
			this.MuteCH3.Size = new System.Drawing.Size(76, 24);
			this.MuteCH3.TabIndex = 24;
			this.MuteCH3.Text = "OUT 4";
			this.MuteCH3.UseVisualStyleBackColor = true;
			this.MuteCH3.CheckedChanged += new System.EventHandler(this.MuteCH3CheckedChanged);
			// 
			// MuteCH2
			// 
			this.MuteCH2.Location = new System.Drawing.Point(6, 79);
			this.MuteCH2.Name = "MuteCH2";
			this.MuteCH2.Size = new System.Drawing.Size(76, 24);
			this.MuteCH2.TabIndex = 2;
			this.MuteCH2.Text = "OUT 3";
			this.MuteCH2.UseVisualStyleBackColor = true;
			this.MuteCH2.CheckedChanged += new System.EventHandler(this.MuteCH2CheckedChanged);
			// 
			// MuteCH1
			// 
			this.MuteCH1.Location = new System.Drawing.Point(6, 49);
			this.MuteCH1.Name = "MuteCH1";
			this.MuteCH1.Size = new System.Drawing.Size(76, 24);
			this.MuteCH1.TabIndex = 1;
			this.MuteCH1.Text = "OUT 2";
			this.MuteCH1.UseVisualStyleBackColor = true;
			this.MuteCH1.CheckedChanged += new System.EventHandler(this.MuteCH1CheckedChanged);
			// 
			// MuteCH0
			// 
			this.MuteCH0.Location = new System.Drawing.Point(6, 19);
			this.MuteCH0.Name = "MuteCH0";
			this.MuteCH0.Size = new System.Drawing.Size(76, 24);
			this.MuteCH0.TabIndex = 0;
			this.MuteCH0.Text = "OUT 1";
			this.MuteCH0.UseVisualStyleBackColor = true;
			this.MuteCH0.CheckedChanged += new System.EventHandler(this.MuteCH0CheckedChanged);
			// 
			// label5
			// 
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(7, 134);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "Out 4";
			// 
			// Source3Select
			// 
			this.Source3Select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Source3Select.FormattingEnabled = true;
			this.Source3Select.Items.AddRange(new object[] {
									"Left",
									"Right",
									"Left+Right"});
			this.Source3Select.Location = new System.Drawing.Point(72, 131);
			this.Source3Select.Name = "Source3Select";
			this.Source3Select.Size = new System.Drawing.Size(121, 21);
			this.Source3Select.TabIndex = 7;
			this.Source3Select.SelectedIndexChanged += new System.EventHandler(this.Source3SelectSelectedIndexChanged);
			// 
			// Source2Select
			// 
			this.Source2Select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Source2Select.FormattingEnabled = true;
			this.Source2Select.Items.AddRange(new object[] {
									"Left",
									"Right",
									"Left+Right"});
			this.Source2Select.Location = new System.Drawing.Point(72, 101);
			this.Source2Select.Name = "Source2Select";
			this.Source2Select.Size = new System.Drawing.Size(121, 21);
			this.Source2Select.TabIndex = 6;
			this.Source2Select.SelectedIndexChanged += new System.EventHandler(this.Source2SelectSelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(7, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 23);
			this.label4.TabIndex = 5;
			this.label4.Text = "Out 3";
			// 
			// Source1Select
			// 
			this.Source1Select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Source1Select.FormattingEnabled = true;
			this.Source1Select.Items.AddRange(new object[] {
									"Left",
									"Right",
									"Left+Right"});
			this.Source1Select.Location = new System.Drawing.Point(72, 69);
			this.Source1Select.Name = "Source1Select";
			this.Source1Select.Size = new System.Drawing.Size(121, 21);
			this.Source1Select.TabIndex = 4;
			this.Source1Select.SelectedIndexChanged += new System.EventHandler(this.Source1SelectSelectedIndexChanged);
			// 
			// Source0Select
			// 
			this.Source0Select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Source0Select.FormattingEnabled = true;
			this.Source0Select.Items.AddRange(new object[] {
									"Left",
									"Right",
									"Left+Right"});
			this.Source0Select.Location = new System.Drawing.Point(72, 39);
			this.Source0Select.Name = "Source0Select";
			this.Source0Select.Size = new System.Drawing.Size(121, 21);
			this.Source0Select.TabIndex = 3;
			this.Source0Select.SelectedIndexChanged += new System.EventHandler(this.Source0SelectSelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(6, 74);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Out 2";
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(6, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Out 1";
			// 
			// tabPage9
			// 
			this.tabPage9.BackColor = System.Drawing.Color.Black;
			this.tabPage9.Controls.Add(this.LPBypass);
			this.tabPage9.Controls.Add(this.EQ4Bypass);
			this.tabPage9.Controls.Add(this.EQ3Bypass);
			this.tabPage9.Controls.Add(this.EQ2Bypass);
			this.tabPage9.Controls.Add(this.EQ1Bypass);
			this.tabPage9.Controls.Add(this.EQ0Bypass);
			this.tabPage9.Controls.Add(this.HPBypass);
			this.tabPage9.Controls.Add(this.label57);
			this.tabPage9.Controls.Add(this.label59);
			this.tabPage9.Controls.Add(this.label60);
			this.tabPage9.Controls.Add(this.label61);
			this.tabPage9.Controls.Add(this.LPOrder);
			this.tabPage9.Controls.Add(this.LPQ);
			this.tabPage9.Controls.Add(this.LPFreq);
			this.tabPage9.Controls.Add(this.label52);
			this.tabPage9.Controls.Add(this.label55);
			this.tabPage9.Controls.Add(this.label50);
			this.tabPage9.Controls.Add(this.HPOrder);
			this.tabPage9.Controls.Add(this.HPQ);
			this.tabPage9.Controls.Add(this.EQ4Type);
			this.tabPage9.Controls.Add(this.EQ3Type);
			this.tabPage9.Controls.Add(this.label54);
			this.tabPage9.Controls.Add(this.EQ2Type);
			this.tabPage9.Controls.Add(this.EQ1Type);
			this.tabPage9.Controls.Add(this.label53);
			this.tabPage9.Controls.Add(this.EQ0Type);
			this.tabPage9.Controls.Add(this.label49);
			this.tabPage9.Controls.Add(this.HPFreq);
			this.tabPage9.Controls.Add(this.EQ4Gain);
			this.tabPage9.Controls.Add(this.EQ4Q);
			this.tabPage9.Controls.Add(this.EQ4Freq);
			this.tabPage9.Controls.Add(this.label48);
			this.tabPage9.Controls.Add(this.EQ3Gain);
			this.tabPage9.Controls.Add(this.EQ3Q);
			this.tabPage9.Controls.Add(this.EQ3Freq);
			this.tabPage9.Controls.Add(this.label47);
			this.tabPage9.Controls.Add(this.EQ2Gain);
			this.tabPage9.Controls.Add(this.EQ2Q);
			this.tabPage9.Controls.Add(this.EQ2Freq);
			this.tabPage9.Controls.Add(this.label46);
			this.tabPage9.Controls.Add(this.EQ1Gain);
			this.tabPage9.Controls.Add(this.EQ1Q);
			this.tabPage9.Controls.Add(this.EQ1Freq);
			this.tabPage9.Controls.Add(this.label45);
			this.tabPage9.Controls.Add(this.EQ0Gain);
			this.tabPage9.Controls.Add(this.lphpeqbar);
			this.tabPage9.Controls.Add(this.EQ0Q);
			this.tabPage9.Controls.Add(this.label44);
			this.tabPage9.Controls.Add(this.label43);
			this.tabPage9.Controls.Add(this.label12);
			this.tabPage9.Controls.Add(this.EQ0Freq);
			this.tabPage9.Location = new System.Drawing.Point(4, 22);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Size = new System.Drawing.Size(837, 213);
			this.tabPage9.TabIndex = 9;
			this.tabPage9.Text = "HP / LP / EQ";
			// 
			// LPBypass
			// 
			this.LPBypass.BackColor = System.Drawing.Color.Red;
			this.LPBypass.Location = new System.Drawing.Point(747, 115);
			this.LPBypass.Name = "LPBypass";
			this.LPBypass.Size = new System.Drawing.Size(53, 23);
			this.LPBypass.TabIndex = 81;
			this.LPBypass.Text = "OFF";
			this.LPBypass.UseVisualStyleBackColor = false;
			this.LPBypass.Click += new System.EventHandler(this.LPBypassClick);
			// 
			// EQ4Bypass
			// 
			this.EQ4Bypass.BackColor = System.Drawing.Color.Red;
			this.EQ4Bypass.Location = new System.Drawing.Point(571, 145);
			this.EQ4Bypass.Name = "EQ4Bypass";
			this.EQ4Bypass.Size = new System.Drawing.Size(53, 23);
			this.EQ4Bypass.TabIndex = 80;
			this.EQ4Bypass.Text = "OFF";
			this.EQ4Bypass.UseVisualStyleBackColor = false;
			this.EQ4Bypass.Click += new System.EventHandler(this.EQ4BypassClick);
			// 
			// EQ3Bypass
			// 
			this.EQ3Bypass.BackColor = System.Drawing.Color.Red;
			this.EQ3Bypass.Location = new System.Drawing.Point(499, 145);
			this.EQ3Bypass.Name = "EQ3Bypass";
			this.EQ3Bypass.Size = new System.Drawing.Size(53, 23);
			this.EQ3Bypass.TabIndex = 79;
			this.EQ3Bypass.Text = "OFF";
			this.EQ3Bypass.UseVisualStyleBackColor = false;
			this.EQ3Bypass.Click += new System.EventHandler(this.EQ3BypassClick);
			// 
			// EQ2Bypass
			// 
			this.EQ2Bypass.BackColor = System.Drawing.Color.Red;
			this.EQ2Bypass.Location = new System.Drawing.Point(427, 145);
			this.EQ2Bypass.Name = "EQ2Bypass";
			this.EQ2Bypass.Size = new System.Drawing.Size(53, 23);
			this.EQ2Bypass.TabIndex = 78;
			this.EQ2Bypass.Text = "OFF";
			this.EQ2Bypass.UseVisualStyleBackColor = false;
			this.EQ2Bypass.Click += new System.EventHandler(this.EQ2BypassClick);
			// 
			// EQ1Bypass
			// 
			this.EQ1Bypass.BackColor = System.Drawing.Color.Red;
			this.EQ1Bypass.Location = new System.Drawing.Point(357, 145);
			this.EQ1Bypass.Name = "EQ1Bypass";
			this.EQ1Bypass.Size = new System.Drawing.Size(53, 23);
			this.EQ1Bypass.TabIndex = 77;
			this.EQ1Bypass.Text = "OFF";
			this.EQ1Bypass.UseVisualStyleBackColor = false;
			this.EQ1Bypass.Click += new System.EventHandler(this.EQ1BypassClick);
			// 
			// EQ0Bypass
			// 
			this.EQ0Bypass.BackColor = System.Drawing.Color.Red;
			this.EQ0Bypass.Location = new System.Drawing.Point(287, 145);
			this.EQ0Bypass.Name = "EQ0Bypass";
			this.EQ0Bypass.Size = new System.Drawing.Size(53, 23);
			this.EQ0Bypass.TabIndex = 76;
			this.EQ0Bypass.Text = "OFF";
			this.EQ0Bypass.UseVisualStyleBackColor = false;
			this.EQ0Bypass.Click += new System.EventHandler(this.EQ0BypassClick);
			// 
			// HPBypass
			// 
			this.HPBypass.BackColor = System.Drawing.Color.Red;
			this.HPBypass.Location = new System.Drawing.Point(88, 115);
			this.HPBypass.Name = "HPBypass";
			this.HPBypass.Size = new System.Drawing.Size(57, 23);
			this.HPBypass.TabIndex = 75;
			this.HPBypass.Text = "OFF";
			this.HPBypass.UseVisualStyleBackColor = false;
			this.HPBypass.Click += new System.EventHandler(this.HPBypassClick);
			// 
			// label57
			// 
			this.label57.ForeColor = System.Drawing.Color.White;
			this.label57.Location = new System.Drawing.Point(88, 13);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(68, 23);
			this.label57.TabIndex = 74;
			this.label57.Text = "HighPass";
			// 
			// label59
			// 
			this.label59.ForeColor = System.Drawing.Color.White;
			this.label59.Location = new System.Drawing.Point(676, 91);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(55, 23);
			this.label59.TabIndex = 73;
			this.label59.Text = "Order";
			// 
			// label60
			// 
			this.label60.ForeColor = System.Drawing.Color.White;
			this.label60.Location = new System.Drawing.Point(676, 65);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(55, 23);
			this.label60.TabIndex = 72;
			this.label60.Text = "Q";
			// 
			// label61
			// 
			this.label61.ForeColor = System.Drawing.Color.White;
			this.label61.Location = new System.Drawing.Point(676, 39);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(68, 23);
			this.label61.TabIndex = 71;
			this.label61.Text = "Frequency";
			// 
			// LPOrder
			// 
			this.LPOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.LPOrder.FormattingEnabled = true;
			this.LPOrder.Items.AddRange(new object[] {
									"0 dB/oct",
									"12 dB/oct",
									"24 dB/oct"});
			this.LPOrder.Location = new System.Drawing.Point(747, 88);
			this.LPOrder.Name = "LPOrder";
			this.LPOrder.Size = new System.Drawing.Size(57, 21);
			this.LPOrder.TabIndex = 68;
			this.LPOrder.SelectedIndexChanged += new System.EventHandler(this.LPOrderSelectedIndexChanged);
			// 
			// LPQ
			// 
			this.LPQ.BackColor = System.Drawing.Color.Black;
			this.LPQ.ForeColor = System.Drawing.Color.White;
			this.LPQ.Location = new System.Drawing.Point(747, 62);
			this.LPQ.Name = "LPQ";
			this.LPQ.Size = new System.Drawing.Size(57, 20);
			this.LPQ.TabIndex = 67;
			this.LPQ.Text = "0,7";
			this.LPQ.Click += new System.EventHandler(this.LPQClicked);
			this.LPQ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQKeyDown);
			// 
			// LPFreq
			// 
			this.LPFreq.BackColor = System.Drawing.Color.Black;
			this.LPFreq.ForeColor = System.Drawing.Color.White;
			this.LPFreq.Location = new System.Drawing.Point(747, 36);
			this.LPFreq.Name = "LPFreq";
			this.LPFreq.Size = new System.Drawing.Size(57, 20);
			this.LPFreq.TabIndex = 66;
			this.LPFreq.Text = "1000";
			this.LPFreq.Click += new System.EventHandler(this.LPFreqClicked);
			this.LPFreq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQKeyDown);
			// 
			// label52
			// 
			this.label52.ForeColor = System.Drawing.Color.White;
			this.label52.Location = new System.Drawing.Point(747, 10);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(68, 23);
			this.label52.TabIndex = 57;
			this.label52.Text = "LowPass";
			// 
			// label55
			// 
			this.label55.ForeColor = System.Drawing.Color.White;
			this.label55.Location = new System.Drawing.Point(14, 92);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(55, 23);
			this.label55.TabIndex = 63;
			this.label55.Text = "Order";
			// 
			// label50
			// 
			this.label50.ForeColor = System.Drawing.Color.White;
			this.label50.Location = new System.Drawing.Point(213, 120);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(55, 23);
			this.label50.TabIndex = 50;
			this.label50.Text = "Type";
			this.label50.Click += new System.EventHandler(this.Label50Click);
			// 
			// HPOrder
			// 
			this.HPOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.HPOrder.FormattingEnabled = true;
			this.HPOrder.Items.AddRange(new object[] {
									"0 dB/oct",
									"12 dB/oct",
									"24 dB/oct"});
			this.HPOrder.Location = new System.Drawing.Point(88, 89);
			this.HPOrder.Name = "HPOrder";
			this.HPOrder.Size = new System.Drawing.Size(57, 21);
			this.HPOrder.TabIndex = 62;
			this.HPOrder.SelectedIndexChanged += new System.EventHandler(this.HPOrderSelectedIndexChanged);
			// 
			// HPQ
			// 
			this.HPQ.BackColor = System.Drawing.Color.Black;
			this.HPQ.ForeColor = System.Drawing.Color.White;
			this.HPQ.Location = new System.Drawing.Point(88, 63);
			this.HPQ.Name = "HPQ";
			this.HPQ.Size = new System.Drawing.Size(57, 20);
			this.HPQ.TabIndex = 61;
			this.HPQ.Text = "0,7";
			this.HPQ.Click += new System.EventHandler(this.HPQClicked);
			this.HPQ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQKeyDown);
			// 
			// EQ4Type
			// 
			this.EQ4Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.EQ4Type.FormattingEnabled = true;
			this.EQ4Type.Items.AddRange(new object[] {
									"Bell",
									"HighShelf",
									"LowShelf"});
			this.EQ4Type.Location = new System.Drawing.Point(571, 118);
			this.EQ4Type.Name = "EQ4Type";
			this.EQ4Type.Size = new System.Drawing.Size(53, 21);
			this.EQ4Type.TabIndex = 49;
			this.EQ4Type.SelectedIndexChanged += new System.EventHandler(this.EQ4TypeSelectedIndexChanged);
			// 
			// EQ3Type
			// 
			this.EQ3Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.EQ3Type.FormattingEnabled = true;
			this.EQ3Type.Items.AddRange(new object[] {
									"Bell",
									"HighShelf",
									"LowShelf"});
			this.EQ3Type.Location = new System.Drawing.Point(499, 118);
			this.EQ3Type.Name = "EQ3Type";
			this.EQ3Type.Size = new System.Drawing.Size(53, 21);
			this.EQ3Type.TabIndex = 48;
			this.EQ3Type.SelectedIndexChanged += new System.EventHandler(this.EQ3TypeSelectedIndexChanged);
			// 
			// label54
			// 
			this.label54.ForeColor = System.Drawing.Color.White;
			this.label54.Location = new System.Drawing.Point(14, 66);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(55, 23);
			this.label54.TabIndex = 60;
			this.label54.Text = "Q";
			// 
			// EQ2Type
			// 
			this.EQ2Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.EQ2Type.FormattingEnabled = true;
			this.EQ2Type.Items.AddRange(new object[] {
									"Bell",
									"HighShelf",
									"LowShelf"});
			this.EQ2Type.Location = new System.Drawing.Point(427, 118);
			this.EQ2Type.Name = "EQ2Type";
			this.EQ2Type.Size = new System.Drawing.Size(53, 21);
			this.EQ2Type.TabIndex = 47;
			this.EQ2Type.SelectedIndexChanged += new System.EventHandler(this.EQ2TypeSelectedIndexChanged);
			// 
			// EQ1Type
			// 
			this.EQ1Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.EQ1Type.FormattingEnabled = true;
			this.EQ1Type.Items.AddRange(new object[] {
									"Bell",
									"HighShelf",
									"LowShelf"});
			this.EQ1Type.Location = new System.Drawing.Point(357, 118);
			this.EQ1Type.Name = "EQ1Type";
			this.EQ1Type.Size = new System.Drawing.Size(53, 21);
			this.EQ1Type.TabIndex = 46;
			this.EQ1Type.SelectedIndexChanged += new System.EventHandler(this.EQ1TypeSelectedIndexChanged);
			// 
			// label53
			// 
			this.label53.ForeColor = System.Drawing.Color.White;
			this.label53.Location = new System.Drawing.Point(14, 40);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(68, 23);
			this.label53.TabIndex = 59;
			this.label53.Text = "Frequency";
			// 
			// EQ0Type
			// 
			this.EQ0Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.EQ0Type.FormattingEnabled = true;
			this.EQ0Type.Items.AddRange(new object[] {
									"Bell",
									"HighShelf",
									"LowShelf"});
			this.EQ0Type.Location = new System.Drawing.Point(287, 118);
			this.EQ0Type.Name = "EQ0Type";
			this.EQ0Type.Size = new System.Drawing.Size(53, 21);
			this.EQ0Type.TabIndex = 45;
			this.EQ0Type.SelectedIndexChanged += new System.EventHandler(this.EQ0TypeSelectedIndexChanged);
			// 
			// label49
			// 
			this.label49.ForeColor = System.Drawing.Color.White;
			this.label49.Location = new System.Drawing.Point(571, 13);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(68, 23);
			this.label49.TabIndex = 44;
			this.label49.Text = "EQ 5";
			// 
			// HPFreq
			// 
			this.HPFreq.BackColor = System.Drawing.Color.Gray;
			this.HPFreq.ForeColor = System.Drawing.Color.White;
			this.HPFreq.Location = new System.Drawing.Point(88, 37);
			this.HPFreq.Name = "HPFreq";
			this.HPFreq.Size = new System.Drawing.Size(57, 20);
			this.HPFreq.TabIndex = 58;
			this.HPFreq.Text = "1000";
			this.HPFreq.Click += new System.EventHandler(this.HPFreqClicked);
			this.HPFreq.TextChanged += new System.EventHandler(this.HPFreqTextChanged);
			this.HPFreq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQKeyDown);
			// 
			// EQ4Gain
			// 
			this.EQ4Gain.BackColor = System.Drawing.Color.Black;
			this.EQ4Gain.ForeColor = System.Drawing.Color.White;
			this.EQ4Gain.Location = new System.Drawing.Point(571, 66);
			this.EQ4Gain.Name = "EQ4Gain";
			this.EQ4Gain.Size = new System.Drawing.Size(53, 20);
			this.EQ4Gain.TabIndex = 43;
			this.EQ4Gain.Text = "0";
			this.EQ4Gain.Click += new System.EventHandler(this.EQ4GainClicked);
			this.EQ4Gain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQKeyDown);
			// 
			// EQ4Q
			// 
			this.EQ4Q.BackColor = System.Drawing.Color.Black;
			this.EQ4Q.ForeColor = System.Drawing.Color.White;
			this.EQ4Q.Location = new System.Drawing.Point(571, 92);
			this.EQ4Q.Name = "EQ4Q";
			this.EQ4Q.Size = new System.Drawing.Size(53, 20);
			this.EQ4Q.TabIndex = 42;
			this.EQ4Q.Text = "0.7";
			this.EQ4Q.Click += new System.EventHandler(this.EQ4QClicked);
			this.EQ4Q.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQKeyDown);
			// 
			// EQ4Freq
			// 
			this.EQ4Freq.BackColor = System.Drawing.Color.Black;
			this.EQ4Freq.ForeColor = System.Drawing.Color.White;
			this.EQ4Freq.Location = new System.Drawing.Point(571, 40);
			this.EQ4Freq.Name = "EQ4Freq";
			this.EQ4Freq.Size = new System.Drawing.Size(53, 20);
			this.EQ4Freq.TabIndex = 41;
			this.EQ4Freq.Text = "1000";
			this.EQ4Freq.Click += new System.EventHandler(this.EQ4FreqClicked);
			this.EQ4Freq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQKeyDown);
			// 
			// label48
			// 
			this.label48.ForeColor = System.Drawing.Color.White;
			this.label48.Location = new System.Drawing.Point(499, 13);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(68, 23);
			this.label48.TabIndex = 40;
			this.label48.Text = "EQ 4";
			// 
			// EQ3Gain
			// 
			this.EQ3Gain.BackColor = System.Drawing.Color.Black;
			this.EQ3Gain.ForeColor = System.Drawing.Color.White;
			this.EQ3Gain.Location = new System.Drawing.Point(499, 66);
			this.EQ3Gain.Name = "EQ3Gain";
			this.EQ3Gain.Size = new System.Drawing.Size(53, 20);
			this.EQ3Gain.TabIndex = 39;
			this.EQ3Gain.Text = "0";
			this.EQ3Gain.Click += new System.EventHandler(this.EQ3GainClicked);
			this.EQ3Gain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQKeyDown);
			// 
			// EQ3Q
			// 
			this.EQ3Q.BackColor = System.Drawing.Color.Black;
			this.EQ3Q.ForeColor = System.Drawing.Color.White;
			this.EQ3Q.Location = new System.Drawing.Point(499, 92);
			this.EQ3Q.Name = "EQ3Q";
			this.EQ3Q.Size = new System.Drawing.Size(53, 20);
			this.EQ3Q.TabIndex = 38;
			this.EQ3Q.Text = "0.7";
			this.EQ3Q.Click += new System.EventHandler(this.EQ3QClicked);
			this.EQ3Q.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQKeyDown);
			// 
			// EQ3Freq
			// 
			this.EQ3Freq.BackColor = System.Drawing.Color.Black;
			this.EQ3Freq.ForeColor = System.Drawing.Color.White;
			this.EQ3Freq.Location = new System.Drawing.Point(499, 40);
			this.EQ3Freq.Name = "EQ3Freq";
			this.EQ3Freq.Size = new System.Drawing.Size(53, 20);
			this.EQ3Freq.TabIndex = 37;
			this.EQ3Freq.Text = "1000";
			this.EQ3Freq.Click += new System.EventHandler(this.EQ3FreqClicked);
			this.EQ3Freq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQKeyDown);
			// 
			// label47
			// 
			this.label47.ForeColor = System.Drawing.Color.White;
			this.label47.Location = new System.Drawing.Point(427, 13);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(68, 23);
			this.label47.TabIndex = 36;
			this.label47.Text = "EQ 3";
			// 
			// EQ2Gain
			// 
			this.EQ2Gain.BackColor = System.Drawing.Color.Black;
			this.EQ2Gain.ForeColor = System.Drawing.Color.White;
			this.EQ2Gain.Location = new System.Drawing.Point(427, 66);
			this.EQ2Gain.Name = "EQ2Gain";
			this.EQ2Gain.Size = new System.Drawing.Size(53, 20);
			this.EQ2Gain.TabIndex = 35;
			this.EQ2Gain.Text = "0";
			this.EQ2Gain.Click += new System.EventHandler(this.EQ2GainClicked);
			this.EQ2Gain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQKeyDown);
			// 
			// EQ2Q
			// 
			this.EQ2Q.BackColor = System.Drawing.Color.Black;
			this.EQ2Q.ForeColor = System.Drawing.Color.White;
			this.EQ2Q.Location = new System.Drawing.Point(427, 92);
			this.EQ2Q.Name = "EQ2Q";
			this.EQ2Q.Size = new System.Drawing.Size(53, 20);
			this.EQ2Q.TabIndex = 34;
			this.EQ2Q.Text = "0.7";
			this.EQ2Q.Click += new System.EventHandler(this.EQ2QClicked);
			this.EQ2Q.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQKeyDown);
			// 
			// EQ2Freq
			// 
			this.EQ2Freq.BackColor = System.Drawing.Color.Black;
			this.EQ2Freq.ForeColor = System.Drawing.Color.White;
			this.EQ2Freq.Location = new System.Drawing.Point(427, 40);
			this.EQ2Freq.Name = "EQ2Freq";
			this.EQ2Freq.Size = new System.Drawing.Size(53, 20);
			this.EQ2Freq.TabIndex = 33;
			this.EQ2Freq.Text = "1000";
			this.EQ2Freq.Click += new System.EventHandler(this.EQ2FreqClicked);
			this.EQ2Freq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQKeyDown);
			// 
			// label46
			// 
			this.label46.ForeColor = System.Drawing.Color.White;
			this.label46.Location = new System.Drawing.Point(357, 13);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(68, 23);
			this.label46.TabIndex = 32;
			this.label46.Text = "EQ 2";
			// 
			// EQ1Gain
			// 
			this.EQ1Gain.BackColor = System.Drawing.Color.Black;
			this.EQ1Gain.ForeColor = System.Drawing.Color.White;
			this.EQ1Gain.Location = new System.Drawing.Point(357, 66);
			this.EQ1Gain.Name = "EQ1Gain";
			this.EQ1Gain.Size = new System.Drawing.Size(53, 20);
			this.EQ1Gain.TabIndex = 31;
			this.EQ1Gain.Text = "0";
			this.EQ1Gain.Click += new System.EventHandler(this.EQ1GainClicked);
			this.EQ1Gain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQKeyDown);
			// 
			// EQ1Q
			// 
			this.EQ1Q.BackColor = System.Drawing.Color.Black;
			this.EQ1Q.ForeColor = System.Drawing.Color.White;
			this.EQ1Q.Location = new System.Drawing.Point(357, 92);
			this.EQ1Q.Name = "EQ1Q";
			this.EQ1Q.Size = new System.Drawing.Size(53, 20);
			this.EQ1Q.TabIndex = 30;
			this.EQ1Q.Text = "0.7";
			this.EQ1Q.Click += new System.EventHandler(this.EQ1QClicked);
			this.EQ1Q.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQKeyDown);
			// 
			// EQ1Freq
			// 
			this.EQ1Freq.BackColor = System.Drawing.Color.Black;
			this.EQ1Freq.ForeColor = System.Drawing.Color.White;
			this.EQ1Freq.Location = new System.Drawing.Point(357, 40);
			this.EQ1Freq.Name = "EQ1Freq";
			this.EQ1Freq.Size = new System.Drawing.Size(53, 20);
			this.EQ1Freq.TabIndex = 29;
			this.EQ1Freq.Text = "1000";
			this.EQ1Freq.Click += new System.EventHandler(this.EQ1FreqClicked);
			this.EQ1Freq.TextChanged += new System.EventHandler(this.TextBox6TextChanged);
			this.EQ1Freq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQKeyDown);
			// 
			// label45
			// 
			this.label45.ForeColor = System.Drawing.Color.White;
			this.label45.Location = new System.Drawing.Point(287, 13);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(68, 23);
			this.label45.TabIndex = 28;
			this.label45.Text = "EQ 1";
			this.label45.Click += new System.EventHandler(this.Label45Click);
			// 
			// EQ0Gain
			// 
			this.EQ0Gain.BackColor = System.Drawing.Color.Black;
			this.EQ0Gain.ForeColor = System.Drawing.Color.White;
			this.EQ0Gain.Location = new System.Drawing.Point(287, 66);
			this.EQ0Gain.Name = "EQ0Gain";
			this.EQ0Gain.Size = new System.Drawing.Size(53, 20);
			this.EQ0Gain.TabIndex = 27;
			this.EQ0Gain.Text = "0";
			this.EQ0Gain.Click += new System.EventHandler(this.EQ0GainClicked);
			this.EQ0Gain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQKeyDown);
			// 
			// lphpeqbar
			// 
			this.lphpeqbar.BackColor = System.Drawing.Color.Transparent;
			this.lphpeqbar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.lphpeqbar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lphpeqbar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
			this.lphpeqbar.IndentHeight = 6;
			this.lphpeqbar.Location = new System.Drawing.Point(14, 176);
			this.lphpeqbar.Maximum = 30;
			this.lphpeqbar.Minimum = 5;
			this.lphpeqbar.Name = "lphpeqbar";
			this.lphpeqbar.Size = new System.Drawing.Size(820, 28);
			this.lphpeqbar.TabIndex = 26;
			this.lphpeqbar.TextTickStyle = System.Windows.Forms.TickStyle.None;
			this.lphpeqbar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
			this.lphpeqbar.TickFrequency = 3;
			this.lphpeqbar.TickHeight = 4;
			this.lphpeqbar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.lphpeqbar.TrackerColor = System.Drawing.Color.White;
			this.lphpeqbar.TrackerSize = new System.Drawing.Size(16, 16);
			this.lphpeqbar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
			this.lphpeqbar.TrackLineHeight = 3;
			this.lphpeqbar.Value = 7;
			this.lphpeqbar.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.LphpeqbarValueChanged);
			// 
			// EQ0Q
			// 
			this.EQ0Q.BackColor = System.Drawing.Color.Black;
			this.EQ0Q.ForeColor = System.Drawing.Color.White;
			this.EQ0Q.Location = new System.Drawing.Point(287, 92);
			this.EQ0Q.Name = "EQ0Q";
			this.EQ0Q.Size = new System.Drawing.Size(53, 20);
			this.EQ0Q.TabIndex = 24;
			this.EQ0Q.Text = "0.7";
			this.EQ0Q.Click += new System.EventHandler(this.EQ0QClicked);
			this.EQ0Q.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQKeyDown);
			// 
			// label44
			// 
			this.label44.ForeColor = System.Drawing.Color.White;
			this.label44.Location = new System.Drawing.Point(213, 95);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(55, 23);
			this.label44.TabIndex = 25;
			this.label44.Text = "Q";
			// 
			// label43
			// 
			this.label43.ForeColor = System.Drawing.Color.White;
			this.label43.Location = new System.Drawing.Point(213, 69);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(55, 23);
			this.label43.TabIndex = 23;
			this.label43.Text = "Gain";
			// 
			// label12
			// 
			this.label12.ForeColor = System.Drawing.Color.White;
			this.label12.Location = new System.Drawing.Point(213, 42);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(68, 23);
			this.label12.TabIndex = 22;
			this.label12.Text = "Frequency";
			// 
			// EQ0Freq
			// 
			this.EQ0Freq.BackColor = System.Drawing.Color.Black;
			this.EQ0Freq.ForeColor = System.Drawing.Color.White;
			this.EQ0Freq.Location = new System.Drawing.Point(287, 39);
			this.EQ0Freq.Name = "EQ0Freq";
			this.EQ0Freq.Size = new System.Drawing.Size(53, 20);
			this.EQ0Freq.TabIndex = 19;
			this.EQ0Freq.Text = "1000";
			this.EQ0Freq.Click += new System.EventHandler(this.EQ0FreqClicked);
			this.EQ0Freq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQKeyDown);
			// 
			// tabPage5
			// 
			this.tabPage5.BackColor = System.Drawing.Color.Black;
			this.tabPage5.Controls.Add(this.ampoutvoltage);
			this.tabPage5.Controls.Add(this.LimitRelVal);
			this.tabPage5.Controls.Add(this.label6);
			this.tabPage5.Controls.Add(this.LimiterReleaseBar);
			this.tabPage5.Controls.Add(this.LimitThresVal);
			this.tabPage5.Controls.Add(this.label22);
			this.tabPage5.Controls.Add(this.LimiterTresholdBar);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(837, 213);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Limiter";
			// 
			// ampoutvoltage
			// 
			this.ampoutvoltage.ForeColor = System.Drawing.Color.White;
			this.ampoutvoltage.Location = new System.Drawing.Point(116, 156);
			this.ampoutvoltage.Name = "ampoutvoltage";
			this.ampoutvoltage.Size = new System.Drawing.Size(512, 23);
			this.ampoutvoltage.TabIndex = 48;
			this.ampoutvoltage.Text = "Amp Output: 26,94V (PEAK) | 19,05V (RMS) | 90,69W @ 4 Ohms | 45,35W @ 8 Ohms";
			// 
			// LimitRelVal
			// 
			this.LimitRelVal.ForeColor = System.Drawing.Color.White;
			this.LimitRelVal.Location = new System.Drawing.Point(603, 74);
			this.LimitRelVal.Name = "LimitRelVal";
			this.LimitRelVal.Size = new System.Drawing.Size(59, 23);
			this.LimitRelVal.TabIndex = 47;
			this.LimitRelVal.Text = "1390 ms";
			// 
			// label6
			// 
			this.label6.ForeColor = System.Drawing.Color.White;
			this.label6.Location = new System.Drawing.Point(22, 74);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 23);
			this.label6.TabIndex = 46;
			this.label6.Text = "Hold / Release";
			// 
			// LimiterReleaseBar
			// 
			this.LimiterReleaseBar.BackColor = System.Drawing.Color.Transparent;
			this.LimiterReleaseBar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.LimiterReleaseBar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LimiterReleaseBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
			this.LimiterReleaseBar.IndentHeight = 6;
			this.LimiterReleaseBar.Location = new System.Drawing.Point(116, 69);
			this.LimiterReleaseBar.Maximum = 1500;
			this.LimiterReleaseBar.Minimum = 10;
			this.LimiterReleaseBar.Name = "LimiterReleaseBar";
			this.LimiterReleaseBar.Size = new System.Drawing.Size(444, 28);
			this.LimiterReleaseBar.TabIndex = 45;
			this.LimiterReleaseBar.TextTickStyle = System.Windows.Forms.TickStyle.None;
			this.LimiterReleaseBar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
			this.LimiterReleaseBar.TickFrequency = 1000;
			this.LimiterReleaseBar.TickHeight = 4;
			this.LimiterReleaseBar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.LimiterReleaseBar.TrackerColor = System.Drawing.Color.White;
			this.LimiterReleaseBar.TrackerSize = new System.Drawing.Size(16, 16);
			this.LimiterReleaseBar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
			this.LimiterReleaseBar.TrackLineHeight = 3;
			this.LimiterReleaseBar.Value = 1000;
			this.LimiterReleaseBar.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.LimiterReleaseBarValueChanged);
			// 
			// LimitThresVal
			// 
			this.LimitThresVal.ForeColor = System.Drawing.Color.White;
			this.LimitThresVal.Location = new System.Drawing.Point(603, 29);
			this.LimitThresVal.Name = "LimitThresVal";
			this.LimitThresVal.Size = new System.Drawing.Size(59, 23);
			this.LimitThresVal.TabIndex = 40;
			this.LimitThresVal.Text = "0 dB";
			// 
			// label22
			// 
			this.label22.ForeColor = System.Drawing.Color.White;
			this.label22.Location = new System.Drawing.Point(22, 29);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(59, 23);
			this.label22.TabIndex = 36;
			this.label22.Text = "Threshold";
			// 
			// LimiterTresholdBar
			// 
			this.LimiterTresholdBar.BackColor = System.Drawing.Color.Transparent;
			this.LimiterTresholdBar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.LimiterTresholdBar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LimiterTresholdBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
			this.LimiterTresholdBar.IndentHeight = 6;
			this.LimiterTresholdBar.Location = new System.Drawing.Point(116, 24);
			this.LimiterTresholdBar.Maximum = 0;
			this.LimiterTresholdBar.Minimum = -70;
			this.LimiterTresholdBar.Name = "LimiterTresholdBar";
			this.LimiterTresholdBar.Size = new System.Drawing.Size(444, 28);
			this.LimiterTresholdBar.TabIndex = 32;
			this.LimiterTresholdBar.TextTickStyle = System.Windows.Forms.TickStyle.None;
			this.LimiterTresholdBar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
			this.LimiterTresholdBar.TickFrequency = 1000;
			this.LimiterTresholdBar.TickHeight = 4;
			this.LimiterTresholdBar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.LimiterTresholdBar.TrackerColor = System.Drawing.Color.White;
			this.LimiterTresholdBar.TrackerSize = new System.Drawing.Size(16, 16);
			this.LimiterTresholdBar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
			this.LimiterTresholdBar.TrackLineHeight = 3;
			this.LimiterTresholdBar.Value = 0;
			this.LimiterTresholdBar.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.LimiterBar0ValueChanged);
			// 
			// tabPage7
			// 
			this.tabPage7.BackColor = System.Drawing.Color.Black;
			this.tabPage7.Controls.Add(this.DelayVal3);
			this.tabPage7.Controls.Add(this.DelayVal2);
			this.tabPage7.Controls.Add(this.DelayVal1);
			this.tabPage7.Controls.Add(this.DelayVal0);
			this.tabPage7.Controls.Add(this.label27);
			this.tabPage7.Controls.Add(this.label28);
			this.tabPage7.Controls.Add(this.label29);
			this.tabPage7.Controls.Add(this.label30);
			this.tabPage7.Controls.Add(this.DelayBar3);
			this.tabPage7.Controls.Add(this.DelayBar2);
			this.tabPage7.Controls.Add(this.DelayBar1);
			this.tabPage7.Controls.Add(this.DelayBar0);
			this.tabPage7.Location = new System.Drawing.Point(4, 22);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Size = new System.Drawing.Size(837, 213);
			this.tabPage7.TabIndex = 6;
			this.tabPage7.Text = "Delay";
			// 
			// DelayVal3
			// 
			this.DelayVal3.ForeColor = System.Drawing.Color.White;
			this.DelayVal3.Location = new System.Drawing.Point(579, 121);
			this.DelayVal3.Name = "DelayVal3";
			this.DelayVal3.Size = new System.Drawing.Size(59, 23);
			this.DelayVal3.TabIndex = 55;
			this.DelayVal3.Text = "0 ms";
			// 
			// DelayVal2
			// 
			this.DelayVal2.ForeColor = System.Drawing.Color.White;
			this.DelayVal2.Location = new System.Drawing.Point(579, 91);
			this.DelayVal2.Name = "DelayVal2";
			this.DelayVal2.Size = new System.Drawing.Size(59, 23);
			this.DelayVal2.TabIndex = 54;
			this.DelayVal2.Text = "0 ms";
			// 
			// DelayVal1
			// 
			this.DelayVal1.ForeColor = System.Drawing.Color.White;
			this.DelayVal1.Location = new System.Drawing.Point(579, 61);
			this.DelayVal1.Name = "DelayVal1";
			this.DelayVal1.Size = new System.Drawing.Size(59, 23);
			this.DelayVal1.TabIndex = 53;
			this.DelayVal1.Text = "0 ms";
			// 
			// DelayVal0
			// 
			this.DelayVal0.ForeColor = System.Drawing.Color.White;
			this.DelayVal0.Location = new System.Drawing.Point(579, 29);
			this.DelayVal0.Name = "DelayVal0";
			this.DelayVal0.Size = new System.Drawing.Size(59, 23);
			this.DelayVal0.TabIndex = 52;
			this.DelayVal0.Text = "0 ms";
			// 
			// label27
			// 
			this.label27.ForeColor = System.Drawing.Color.White;
			this.label27.Location = new System.Drawing.Point(3, 121);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(59, 23);
			this.label27.TabIndex = 51;
			this.label27.Text = "Out 4";
			// 
			// label28
			// 
			this.label28.ForeColor = System.Drawing.Color.White;
			this.label28.Location = new System.Drawing.Point(3, 91);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(59, 23);
			this.label28.TabIndex = 50;
			this.label28.Text = "Out 3";
			// 
			// label29
			// 
			this.label29.ForeColor = System.Drawing.Color.White;
			this.label29.Location = new System.Drawing.Point(2, 61);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(59, 23);
			this.label29.TabIndex = 49;
			this.label29.Text = "Out 2";
			// 
			// label30
			// 
			this.label30.ForeColor = System.Drawing.Color.White;
			this.label30.Location = new System.Drawing.Point(2, 29);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(59, 23);
			this.label30.TabIndex = 48;
			this.label30.Text = "Out 1";
			// 
			// DelayBar3
			// 
			this.DelayBar3.BackColor = System.Drawing.Color.Transparent;
			this.DelayBar3.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.DelayBar3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DelayBar3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
			this.DelayBar3.IndentHeight = 6;
			this.DelayBar3.Location = new System.Drawing.Point(61, 116);
			this.DelayBar3.Maximum = 3000;
			this.DelayBar3.Minimum = 0;
			this.DelayBar3.Name = "DelayBar3";
			this.DelayBar3.Size = new System.Drawing.Size(444, 28);
			this.DelayBar3.TabIndex = 47;
			this.DelayBar3.TextTickStyle = System.Windows.Forms.TickStyle.None;
			this.DelayBar3.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
			this.DelayBar3.TickFrequency = 1000;
			this.DelayBar3.TickHeight = 4;
			this.DelayBar3.TickStyle = System.Windows.Forms.TickStyle.None;
			this.DelayBar3.TrackerColor = System.Drawing.Color.White;
			this.DelayBar3.TrackerSize = new System.Drawing.Size(16, 16);
			this.DelayBar3.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
			this.DelayBar3.TrackLineHeight = 3;
			this.DelayBar3.Value = 0;
			this.DelayBar3.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.DelayBar3ValueChanged);
			// 
			// DelayBar2
			// 
			this.DelayBar2.BackColor = System.Drawing.Color.Transparent;
			this.DelayBar2.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.DelayBar2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DelayBar2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
			this.DelayBar2.IndentHeight = 6;
			this.DelayBar2.Location = new System.Drawing.Point(61, 86);
			this.DelayBar2.Maximum = 3000;
			this.DelayBar2.Minimum = 0;
			this.DelayBar2.Name = "DelayBar2";
			this.DelayBar2.Size = new System.Drawing.Size(444, 28);
			this.DelayBar2.TabIndex = 46;
			this.DelayBar2.TextTickStyle = System.Windows.Forms.TickStyle.None;
			this.DelayBar2.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
			this.DelayBar2.TickFrequency = 1000;
			this.DelayBar2.TickHeight = 4;
			this.DelayBar2.TickStyle = System.Windows.Forms.TickStyle.None;
			this.DelayBar2.TrackerColor = System.Drawing.Color.White;
			this.DelayBar2.TrackerSize = new System.Drawing.Size(16, 16);
			this.DelayBar2.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
			this.DelayBar2.TrackLineHeight = 3;
			this.DelayBar2.Value = 0;
			this.DelayBar2.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.DelayBar2ValueChanged);
			// 
			// DelayBar1
			// 
			this.DelayBar1.BackColor = System.Drawing.Color.Transparent;
			this.DelayBar1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.DelayBar1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DelayBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
			this.DelayBar1.IndentHeight = 6;
			this.DelayBar1.Location = new System.Drawing.Point(61, 56);
			this.DelayBar1.Maximum = 3000;
			this.DelayBar1.Minimum = 0;
			this.DelayBar1.Name = "DelayBar1";
			this.DelayBar1.Size = new System.Drawing.Size(444, 28);
			this.DelayBar1.TabIndex = 45;
			this.DelayBar1.TextTickStyle = System.Windows.Forms.TickStyle.None;
			this.DelayBar1.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
			this.DelayBar1.TickFrequency = 1000;
			this.DelayBar1.TickHeight = 4;
			this.DelayBar1.TickStyle = System.Windows.Forms.TickStyle.None;
			this.DelayBar1.TrackerColor = System.Drawing.Color.White;
			this.DelayBar1.TrackerSize = new System.Drawing.Size(16, 16);
			this.DelayBar1.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
			this.DelayBar1.TrackLineHeight = 3;
			this.DelayBar1.Value = 0;
			this.DelayBar1.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.DelayBar1ValueChanged);
			// 
			// DelayBar0
			// 
			this.DelayBar0.BackColor = System.Drawing.Color.Transparent;
			this.DelayBar0.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.DelayBar0.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DelayBar0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
			this.DelayBar0.IndentHeight = 6;
			this.DelayBar0.Location = new System.Drawing.Point(61, 24);
			this.DelayBar0.Maximum = 3000;
			this.DelayBar0.Minimum = 0;
			this.DelayBar0.Name = "DelayBar0";
			this.DelayBar0.Size = new System.Drawing.Size(444, 28);
			this.DelayBar0.TabIndex = 44;
			this.DelayBar0.TextTickStyle = System.Windows.Forms.TickStyle.None;
			this.DelayBar0.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
			this.DelayBar0.TickFrequency = 1000;
			this.DelayBar0.TickHeight = 4;
			this.DelayBar0.TickStyle = System.Windows.Forms.TickStyle.None;
			this.DelayBar0.TrackerColor = System.Drawing.Color.White;
			this.DelayBar0.TrackerSize = new System.Drawing.Size(16, 16);
			this.DelayBar0.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
			this.DelayBar0.TrackLineHeight = 3;
			this.DelayBar0.Value = 0;
			this.DelayBar0.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.DelayBar0ValueChanged);
			// 
			// tabPage4
			// 
			this.tabPage4.BackColor = System.Drawing.Color.Black;
			this.tabPage4.Controls.Add(this.VBS_Bypass);
			this.tabPage4.Controls.Add(this.VBS_GainVal);
			this.tabPage4.Controls.Add(this.VBS_FreqVal);
			this.tabPage4.Controls.Add(this.label24);
			this.tabPage4.Controls.Add(this.label23);
			this.tabPage4.Controls.Add(this.VBS_GainBar);
			this.tabPage4.Controls.Add(this.VBS_FreqBar);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(837, 213);
			this.tabPage4.TabIndex = 7;
			this.tabPage4.Text = "Virtual Bass System";
			// 
			// VBS_Bypass
			// 
			this.VBS_Bypass.BackColor = System.Drawing.Color.Red;
			this.VBS_Bypass.Location = new System.Drawing.Point(14, 151);
			this.VBS_Bypass.Name = "VBS_Bypass";
			this.VBS_Bypass.Size = new System.Drawing.Size(57, 23);
			this.VBS_Bypass.TabIndex = 76;
			this.VBS_Bypass.Text = "OFF";
			this.VBS_Bypass.UseVisualStyleBackColor = false;
			this.VBS_Bypass.Click += new System.EventHandler(this.VBS_BypassClick);
			// 
			// VBS_GainVal
			// 
			this.VBS_GainVal.ForeColor = System.Drawing.Color.White;
			this.VBS_GainVal.Location = new System.Drawing.Point(586, 100);
			this.VBS_GainVal.Name = "VBS_GainVal";
			this.VBS_GainVal.Size = new System.Drawing.Size(94, 23);
			this.VBS_GainVal.TabIndex = 52;
			this.VBS_GainVal.Text = "0 %";
			// 
			// VBS_FreqVal
			// 
			this.VBS_FreqVal.ForeColor = System.Drawing.Color.White;
			this.VBS_FreqVal.Location = new System.Drawing.Point(586, 45);
			this.VBS_FreqVal.Name = "VBS_FreqVal";
			this.VBS_FreqVal.Size = new System.Drawing.Size(94, 23);
			this.VBS_FreqVal.TabIndex = 51;
			this.VBS_FreqVal.Text = "80 Hz";
			// 
			// label24
			// 
			this.label24.ForeColor = System.Drawing.Color.White;
			this.label24.Location = new System.Drawing.Point(14, 100);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(94, 23);
			this.label24.TabIndex = 50;
			this.label24.Text = "Level";
			this.label24.Click += new System.EventHandler(this.Label24Click);
			// 
			// label23
			// 
			this.label23.ForeColor = System.Drawing.Color.White;
			this.label23.Location = new System.Drawing.Point(14, 45);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(94, 23);
			this.label23.TabIndex = 49;
			this.label23.Text = "Bass Frequency";
			// 
			// VBS_GainBar
			// 
			this.VBS_GainBar.BackColor = System.Drawing.Color.Transparent;
			this.VBS_GainBar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.VBS_GainBar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.VBS_GainBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
			this.VBS_GainBar.IndentHeight = 6;
			this.VBS_GainBar.Location = new System.Drawing.Point(114, 95);
			this.VBS_GainBar.Maximum = 500;
			this.VBS_GainBar.Minimum = 0;
			this.VBS_GainBar.Name = "VBS_GainBar";
			this.VBS_GainBar.Size = new System.Drawing.Size(444, 28);
			this.VBS_GainBar.TabIndex = 48;
			this.VBS_GainBar.TextTickStyle = System.Windows.Forms.TickStyle.None;
			this.VBS_GainBar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
			this.VBS_GainBar.TickFrequency = 1000;
			this.VBS_GainBar.TickHeight = 4;
			this.VBS_GainBar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.VBS_GainBar.TrackerColor = System.Drawing.Color.White;
			this.VBS_GainBar.TrackerSize = new System.Drawing.Size(16, 16);
			this.VBS_GainBar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
			this.VBS_GainBar.TrackLineHeight = 3;
			this.VBS_GainBar.Value = 0;
			this.VBS_GainBar.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.VBS_GainBarValueChanged);
			// 
			// VBS_FreqBar
			// 
			this.VBS_FreqBar.BackColor = System.Drawing.Color.Transparent;
			this.VBS_FreqBar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.VBS_FreqBar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.VBS_FreqBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
			this.VBS_FreqBar.IndentHeight = 6;
			this.VBS_FreqBar.Location = new System.Drawing.Point(114, 40);
			this.VBS_FreqBar.Maximum = 200;
			this.VBS_FreqBar.Minimum = 30;
			this.VBS_FreqBar.Name = "VBS_FreqBar";
			this.VBS_FreqBar.Size = new System.Drawing.Size(444, 28);
			this.VBS_FreqBar.TabIndex = 47;
			this.VBS_FreqBar.TextTickStyle = System.Windows.Forms.TickStyle.None;
			this.VBS_FreqBar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
			this.VBS_FreqBar.TickFrequency = 1000;
			this.VBS_FreqBar.TickHeight = 4;
			this.VBS_FreqBar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.VBS_FreqBar.TrackerColor = System.Drawing.Color.White;
			this.VBS_FreqBar.TrackerSize = new System.Drawing.Size(16, 16);
			this.VBS_FreqBar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
			this.VBS_FreqBar.TrackLineHeight = 3;
			this.VBS_FreqBar.Value = 80;
			this.VBS_FreqBar.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.VBS_FreqBarValueChanged);
			// 
			// tabPage8
			// 
			this.tabPage8.BackColor = System.Drawing.Color.Black;
			this.tabPage8.Controls.Add(this.DynBass_Bypass);
			this.tabPage8.Controls.Add(this.DynBassLatestGain);
			this.tabPage8.Controls.Add(this.label34);
			this.tabPage8.Controls.Add(this.DynBassWatchtime_Val);
			this.tabPage8.Controls.Add(this.DynBassThres_Val);
			this.tabPage8.Controls.Add(this.DynBassFreq_Val);
			this.tabPage8.Controls.Add(this.DynBassGainSpeed_Val);
			this.tabPage8.Controls.Add(this.DynBassMaxGain_Val);
			this.tabPage8.Controls.Add(this.label33);
			this.tabPage8.Controls.Add(this.label32);
			this.tabPage8.Controls.Add(this.label31);
			this.tabPage8.Controls.Add(this.label26);
			this.tabPage8.Controls.Add(this.label25);
			this.tabPage8.Controls.Add(this.DynBassGainSpeed_Bar);
			this.tabPage8.Controls.Add(this.DynBassMaxGain_Bar);
			this.tabPage8.Controls.Add(this.DynBassFreq_Bar);
			this.tabPage8.Controls.Add(this.DynBassThres_Bar);
			this.tabPage8.Controls.Add(this.DynBassWatchtime_Bar);
			this.tabPage8.Location = new System.Drawing.Point(4, 22);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Size = new System.Drawing.Size(837, 213);
			this.tabPage8.TabIndex = 8;
			this.tabPage8.Text = "Dynamic Bass Boost";
			// 
			// DynBass_Bypass
			// 
			this.DynBass_Bypass.BackColor = System.Drawing.Color.Red;
			this.DynBass_Bypass.Location = new System.Drawing.Point(3, 187);
			this.DynBass_Bypass.Name = "DynBass_Bypass";
			this.DynBass_Bypass.Size = new System.Drawing.Size(57, 23);
			this.DynBass_Bypass.TabIndex = 76;
			this.DynBass_Bypass.Text = "OFF";
			this.DynBass_Bypass.UseVisualStyleBackColor = false;
			this.DynBass_Bypass.Click += new System.EventHandler(this.DynBass_BypassClick);
			// 
			// DynBassLatestGain
			// 
			this.DynBassLatestGain.ForeColor = System.Drawing.Color.White;
			this.DynBassLatestGain.Location = new System.Drawing.Point(710, 43);
			this.DynBassLatestGain.Name = "DynBassLatestGain";
			this.DynBassLatestGain.Size = new System.Drawing.Size(94, 23);
			this.DynBassLatestGain.TabIndex = 64;
			this.DynBassLatestGain.Text = "0 dB";
			// 
			// label34
			// 
			this.label34.ForeColor = System.Drawing.Color.White;
			this.label34.Location = new System.Drawing.Point(710, 20);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(94, 23);
			this.label34.TabIndex = 63;
			this.label34.Text = "Current Bass Gain";
			// 
			// DynBassWatchtime_Val
			// 
			this.DynBassWatchtime_Val.ForeColor = System.Drawing.Color.White;
			this.DynBassWatchtime_Val.Location = new System.Drawing.Point(589, 20);
			this.DynBassWatchtime_Val.Name = "DynBassWatchtime_Val";
			this.DynBassWatchtime_Val.Size = new System.Drawing.Size(94, 23);
			this.DynBassWatchtime_Val.TabIndex = 62;
			this.DynBassWatchtime_Val.Text = "200 ms";
			// 
			// DynBassThres_Val
			// 
			this.DynBassThres_Val.ForeColor = System.Drawing.Color.White;
			this.DynBassThres_Val.Location = new System.Drawing.Point(589, 52);
			this.DynBassThres_Val.Name = "DynBassThres_Val";
			this.DynBassThres_Val.Size = new System.Drawing.Size(94, 23);
			this.DynBassThres_Val.TabIndex = 61;
			this.DynBassThres_Val.Text = "-70 dB";
			// 
			// DynBassFreq_Val
			// 
			this.DynBassFreq_Val.ForeColor = System.Drawing.Color.White;
			this.DynBassFreq_Val.Location = new System.Drawing.Point(589, 87);
			this.DynBassFreq_Val.Name = "DynBassFreq_Val";
			this.DynBassFreq_Val.Size = new System.Drawing.Size(94, 23);
			this.DynBassFreq_Val.TabIndex = 60;
			this.DynBassFreq_Val.Text = "90 Hz";
			// 
			// DynBassGainSpeed_Val
			// 
			this.DynBassGainSpeed_Val.ForeColor = System.Drawing.Color.White;
			this.DynBassGainSpeed_Val.Location = new System.Drawing.Point(589, 155);
			this.DynBassGainSpeed_Val.Name = "DynBassGainSpeed_Val";
			this.DynBassGainSpeed_Val.Size = new System.Drawing.Size(94, 23);
			this.DynBassGainSpeed_Val.TabIndex = 59;
			this.DynBassGainSpeed_Val.Text = "6 dB/sec";
			// 
			// DynBassMaxGain_Val
			// 
			this.DynBassMaxGain_Val.ForeColor = System.Drawing.Color.White;
			this.DynBassMaxGain_Val.Location = new System.Drawing.Point(589, 121);
			this.DynBassMaxGain_Val.Name = "DynBassMaxGain_Val";
			this.DynBassMaxGain_Val.Size = new System.Drawing.Size(94, 23);
			this.DynBassMaxGain_Val.TabIndex = 58;
			this.DynBassMaxGain_Val.Text = "Off";
			// 
			// label33
			// 
			this.label33.ForeColor = System.Drawing.Color.White;
			this.label33.Location = new System.Drawing.Point(3, 155);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(94, 23);
			this.label33.TabIndex = 57;
			this.label33.Text = "Gain Speed";
			// 
			// label32
			// 
			this.label32.ForeColor = System.Drawing.Color.White;
			this.label32.Location = new System.Drawing.Point(3, 121);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(94, 23);
			this.label32.TabIndex = 56;
			this.label32.Text = "Max. Gain";
			// 
			// label31
			// 
			this.label31.ForeColor = System.Drawing.Color.White;
			this.label31.Location = new System.Drawing.Point(1, 87);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(94, 23);
			this.label31.TabIndex = 55;
			this.label31.Text = "Bass Frequency";
			// 
			// label26
			// 
			this.label26.ForeColor = System.Drawing.Color.White;
			this.label26.Location = new System.Drawing.Point(3, 52);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(94, 23);
			this.label26.TabIndex = 54;
			this.label26.Text = "Threshold";
			// 
			// label25
			// 
			this.label25.ForeColor = System.Drawing.Color.White;
			this.label25.Location = new System.Drawing.Point(3, 20);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(94, 23);
			this.label25.TabIndex = 53;
			this.label25.Text = "Watchtime";
			// 
			// DynBassGainSpeed_Bar
			// 
			this.DynBassGainSpeed_Bar.BackColor = System.Drawing.Color.Transparent;
			this.DynBassGainSpeed_Bar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.DynBassGainSpeed_Bar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DynBassGainSpeed_Bar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
			this.DynBassGainSpeed_Bar.IndentHeight = 6;
			this.DynBassGainSpeed_Bar.Location = new System.Drawing.Point(101, 150);
			this.DynBassGainSpeed_Bar.Maximum = 90;
			this.DynBassGainSpeed_Bar.Minimum = 1;
			this.DynBassGainSpeed_Bar.Name = "DynBassGainSpeed_Bar";
			this.DynBassGainSpeed_Bar.Size = new System.Drawing.Size(444, 28);
			this.DynBassGainSpeed_Bar.TabIndex = 52;
			this.DynBassGainSpeed_Bar.TextTickStyle = System.Windows.Forms.TickStyle.None;
			this.DynBassGainSpeed_Bar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
			this.DynBassGainSpeed_Bar.TickFrequency = 1000;
			this.DynBassGainSpeed_Bar.TickHeight = 4;
			this.DynBassGainSpeed_Bar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.DynBassGainSpeed_Bar.TrackerColor = System.Drawing.Color.White;
			this.DynBassGainSpeed_Bar.TrackerSize = new System.Drawing.Size(16, 16);
			this.DynBassGainSpeed_Bar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
			this.DynBassGainSpeed_Bar.TrackLineHeight = 3;
			this.DynBassGainSpeed_Bar.Value = 10;
			this.DynBassGainSpeed_Bar.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.DynBassGainSpeed_BarValueChanged);
			// 
			// DynBassMaxGain_Bar
			// 
			this.DynBassMaxGain_Bar.BackColor = System.Drawing.Color.Transparent;
			this.DynBassMaxGain_Bar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.DynBassMaxGain_Bar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DynBassMaxGain_Bar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
			this.DynBassMaxGain_Bar.IndentHeight = 6;
			this.DynBassMaxGain_Bar.Location = new System.Drawing.Point(101, 116);
			this.DynBassMaxGain_Bar.Maximum = 90;
			this.DynBassMaxGain_Bar.Minimum = 0;
			this.DynBassMaxGain_Bar.Name = "DynBassMaxGain_Bar";
			this.DynBassMaxGain_Bar.Size = new System.Drawing.Size(444, 28);
			this.DynBassMaxGain_Bar.TabIndex = 51;
			this.DynBassMaxGain_Bar.TextTickStyle = System.Windows.Forms.TickStyle.None;
			this.DynBassMaxGain_Bar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
			this.DynBassMaxGain_Bar.TickFrequency = 1000;
			this.DynBassMaxGain_Bar.TickHeight = 4;
			this.DynBassMaxGain_Bar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.DynBassMaxGain_Bar.TrackerColor = System.Drawing.Color.White;
			this.DynBassMaxGain_Bar.TrackerSize = new System.Drawing.Size(16, 16);
			this.DynBassMaxGain_Bar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
			this.DynBassMaxGain_Bar.TrackLineHeight = 3;
			this.DynBassMaxGain_Bar.Value = 0;
			this.DynBassMaxGain_Bar.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.DynBassMaxGain_BarValueChanged);
			// 
			// DynBassFreq_Bar
			// 
			this.DynBassFreq_Bar.BackColor = System.Drawing.Color.Transparent;
			this.DynBassFreq_Bar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.DynBassFreq_Bar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DynBassFreq_Bar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
			this.DynBassFreq_Bar.IndentHeight = 6;
			this.DynBassFreq_Bar.Location = new System.Drawing.Point(101, 82);
			this.DynBassFreq_Bar.Maximum = 200;
			this.DynBassFreq_Bar.Minimum = 30;
			this.DynBassFreq_Bar.Name = "DynBassFreq_Bar";
			this.DynBassFreq_Bar.Size = new System.Drawing.Size(444, 28);
			this.DynBassFreq_Bar.TabIndex = 50;
			this.DynBassFreq_Bar.TextTickStyle = System.Windows.Forms.TickStyle.None;
			this.DynBassFreq_Bar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
			this.DynBassFreq_Bar.TickFrequency = 1000;
			this.DynBassFreq_Bar.TickHeight = 4;
			this.DynBassFreq_Bar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.DynBassFreq_Bar.TrackerColor = System.Drawing.Color.White;
			this.DynBassFreq_Bar.TrackerSize = new System.Drawing.Size(16, 16);
			this.DynBassFreq_Bar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
			this.DynBassFreq_Bar.TrackLineHeight = 3;
			this.DynBassFreq_Bar.Value = 90;
			this.DynBassFreq_Bar.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.DynBassFreq_BarValueChanged);
			// 
			// DynBassThres_Bar
			// 
			this.DynBassThres_Bar.BackColor = System.Drawing.Color.Transparent;
			this.DynBassThres_Bar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.DynBassThres_Bar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DynBassThres_Bar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
			this.DynBassThres_Bar.IndentHeight = 6;
			this.DynBassThres_Bar.Location = new System.Drawing.Point(101, 48);
			this.DynBassThres_Bar.Maximum = 0;
			this.DynBassThres_Bar.Minimum = -80;
			this.DynBassThres_Bar.Name = "DynBassThres_Bar";
			this.DynBassThres_Bar.Size = new System.Drawing.Size(444, 28);
			this.DynBassThres_Bar.TabIndex = 49;
			this.DynBassThres_Bar.TextTickStyle = System.Windows.Forms.TickStyle.None;
			this.DynBassThres_Bar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
			this.DynBassThres_Bar.TickFrequency = 1000;
			this.DynBassThres_Bar.TickHeight = 4;
			this.DynBassThres_Bar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.DynBassThres_Bar.TrackerColor = System.Drawing.Color.White;
			this.DynBassThres_Bar.TrackerSize = new System.Drawing.Size(16, 16);
			this.DynBassThres_Bar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
			this.DynBassThres_Bar.TrackLineHeight = 3;
			this.DynBassThres_Bar.Value = -70;
			this.DynBassThres_Bar.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.DynBassThres_BarValueChanged);
			// 
			// DynBassWatchtime_Bar
			// 
			this.DynBassWatchtime_Bar.BackColor = System.Drawing.Color.Transparent;
			this.DynBassWatchtime_Bar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.DynBassWatchtime_Bar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DynBassWatchtime_Bar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
			this.DynBassWatchtime_Bar.IndentHeight = 6;
			this.DynBassWatchtime_Bar.Location = new System.Drawing.Point(101, 14);
			this.DynBassWatchtime_Bar.Maximum = 5000;
			this.DynBassWatchtime_Bar.Minimum = 10;
			this.DynBassWatchtime_Bar.Name = "DynBassWatchtime_Bar";
			this.DynBassWatchtime_Bar.Size = new System.Drawing.Size(444, 28);
			this.DynBassWatchtime_Bar.TabIndex = 48;
			this.DynBassWatchtime_Bar.TextTickStyle = System.Windows.Forms.TickStyle.None;
			this.DynBassWatchtime_Bar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
			this.DynBassWatchtime_Bar.TickFrequency = 1000;
			this.DynBassWatchtime_Bar.TickHeight = 4;
			this.DynBassWatchtime_Bar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.DynBassWatchtime_Bar.TrackerColor = System.Drawing.Color.White;
			this.DynBassWatchtime_Bar.TrackerSize = new System.Drawing.Size(16, 16);
			this.DynBassWatchtime_Bar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
			this.DynBassWatchtime_Bar.TrackLineHeight = 3;
			this.DynBassWatchtime_Bar.Value = 200;
			this.DynBassWatchtime_Bar.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.DynBassWatchtime_BarValueChanged);
			// 
			// tabPage6
			// 
			this.tabPage6.BackColor = System.Drawing.Color.Black;
			this.tabPage6.Controls.Add(this.groupBox8);
			this.tabPage6.Controls.Add(this.groupBox7);
			this.tabPage6.Controls.Add(this.groupBox6);
			this.tabPage6.Controls.Add(this.groupBox5);
			this.tabPage6.Controls.Add(this.groupBox4);
			this.tabPage6.Controls.Add(this.label36);
			this.tabPage6.Controls.Add(this.iractivityled);
			this.tabPage6.Location = new System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(837, 213);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "IR Control";
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.IR_VOLDOWN_PASTE);
			this.groupBox8.Controls.Add(this.IR_VOLDOWN_CMD);
			this.groupBox8.Controls.Add(this.IR_VOLDOWN_ADDR);
			this.groupBox8.ForeColor = System.Drawing.Color.White;
			this.groupBox8.Location = new System.Drawing.Point(670, 54);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(125, 96);
			this.groupBox8.TabIndex = 6;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Volume Down";
			// 
			// IR_VOLDOWN_PASTE
			// 
			this.IR_VOLDOWN_PASTE.ForeColor = System.Drawing.Color.Black;
			this.IR_VOLDOWN_PASTE.Location = new System.Drawing.Point(7, 62);
			this.IR_VOLDOWN_PASTE.Name = "IR_VOLDOWN_PASTE";
			this.IR_VOLDOWN_PASTE.Size = new System.Drawing.Size(81, 24);
			this.IR_VOLDOWN_PASTE.TabIndex = 10;
			this.IR_VOLDOWN_PASTE.Text = "paste";
			this.IR_VOLDOWN_PASTE.UseVisualStyleBackColor = true;
			this.IR_VOLDOWN_PASTE.Click += new System.EventHandler(this.IR_VOLDOWN_PASTEClick);
			// 
			// IR_VOLDOWN_CMD
			// 
			this.IR_VOLDOWN_CMD.Location = new System.Drawing.Point(7, 43);
			this.IR_VOLDOWN_CMD.Name = "IR_VOLDOWN_CMD";
			this.IR_VOLDOWN_CMD.Size = new System.Drawing.Size(100, 23);
			this.IR_VOLDOWN_CMD.TabIndex = 1;
			this.IR_VOLDOWN_CMD.Text = "0";
			// 
			// IR_VOLDOWN_ADDR
			// 
			this.IR_VOLDOWN_ADDR.Location = new System.Drawing.Point(7, 20);
			this.IR_VOLDOWN_ADDR.Name = "IR_VOLDOWN_ADDR";
			this.IR_VOLDOWN_ADDR.Size = new System.Drawing.Size(100, 23);
			this.IR_VOLDOWN_ADDR.TabIndex = 0;
			this.IR_VOLDOWN_ADDR.Text = "0";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.IR_VOLUP_PASTE);
			this.groupBox7.Controls.Add(this.IR_VOLUP_CMD);
			this.groupBox7.Controls.Add(this.IR_VOLUP_ADDR);
			this.groupBox7.ForeColor = System.Drawing.Color.White;
			this.groupBox7.Location = new System.Drawing.Point(524, 54);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(125, 96);
			this.groupBox7.TabIndex = 5;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Volume UP";
			// 
			// IR_VOLUP_PASTE
			// 
			this.IR_VOLUP_PASTE.ForeColor = System.Drawing.Color.Black;
			this.IR_VOLUP_PASTE.Location = new System.Drawing.Point(7, 62);
			this.IR_VOLUP_PASTE.Name = "IR_VOLUP_PASTE";
			this.IR_VOLUP_PASTE.Size = new System.Drawing.Size(81, 24);
			this.IR_VOLUP_PASTE.TabIndex = 10;
			this.IR_VOLUP_PASTE.Text = "paste";
			this.IR_VOLUP_PASTE.UseVisualStyleBackColor = true;
			this.IR_VOLUP_PASTE.Click += new System.EventHandler(this.IR_VOLUP_PASTEClick);
			// 
			// IR_VOLUP_CMD
			// 
			this.IR_VOLUP_CMD.Location = new System.Drawing.Point(7, 43);
			this.IR_VOLUP_CMD.Name = "IR_VOLUP_CMD";
			this.IR_VOLUP_CMD.Size = new System.Drawing.Size(100, 23);
			this.IR_VOLUP_CMD.TabIndex = 1;
			this.IR_VOLUP_CMD.Text = "0";
			// 
			// IR_VOLUP_ADDR
			// 
			this.IR_VOLUP_ADDR.Location = new System.Drawing.Point(7, 20);
			this.IR_VOLUP_ADDR.Name = "IR_VOLUP_ADDR";
			this.IR_VOLUP_ADDR.Size = new System.Drawing.Size(100, 23);
			this.IR_VOLUP_ADDR.TabIndex = 0;
			this.IR_VOLUP_ADDR.Text = "0";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.IR_MUTE_PASTE);
			this.groupBox6.Controls.Add(this.IR_MUTE_CMD);
			this.groupBox6.Controls.Add(this.IR_MUTE_ADDR);
			this.groupBox6.ForeColor = System.Drawing.Color.White;
			this.groupBox6.Location = new System.Drawing.Point(370, 54);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(125, 96);
			this.groupBox6.TabIndex = 4;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Mute";
			// 
			// IR_MUTE_PASTE
			// 
			this.IR_MUTE_PASTE.ForeColor = System.Drawing.Color.Black;
			this.IR_MUTE_PASTE.Location = new System.Drawing.Point(7, 62);
			this.IR_MUTE_PASTE.Name = "IR_MUTE_PASTE";
			this.IR_MUTE_PASTE.Size = new System.Drawing.Size(81, 24);
			this.IR_MUTE_PASTE.TabIndex = 10;
			this.IR_MUTE_PASTE.Text = "paste";
			this.IR_MUTE_PASTE.UseVisualStyleBackColor = true;
			this.IR_MUTE_PASTE.Click += new System.EventHandler(this.IR_MUTE_PASTEClick);
			// 
			// IR_MUTE_CMD
			// 
			this.IR_MUTE_CMD.Location = new System.Drawing.Point(7, 43);
			this.IR_MUTE_CMD.Name = "IR_MUTE_CMD";
			this.IR_MUTE_CMD.Size = new System.Drawing.Size(100, 23);
			this.IR_MUTE_CMD.TabIndex = 1;
			this.IR_MUTE_CMD.Text = "0";
			// 
			// IR_MUTE_ADDR
			// 
			this.IR_MUTE_ADDR.Location = new System.Drawing.Point(7, 20);
			this.IR_MUTE_ADDR.Name = "IR_MUTE_ADDR";
			this.IR_MUTE_ADDR.Size = new System.Drawing.Size(100, 23);
			this.IR_MUTE_ADDR.TabIndex = 0;
			this.IR_MUTE_ADDR.Text = "0";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.IR_ONOFF_PASTE);
			this.groupBox5.Controls.Add(this.IR_ONOFF_CMD);
			this.groupBox5.Controls.Add(this.IR_ONOFF_ADDR);
			this.groupBox5.ForeColor = System.Drawing.Color.White;
			this.groupBox5.Location = new System.Drawing.Point(225, 54);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(125, 96);
			this.groupBox5.TabIndex = 3;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "On/Off";
			this.groupBox5.Enter += new System.EventHandler(this.GroupBox5Enter);
			// 
			// IR_ONOFF_PASTE
			// 
			this.IR_ONOFF_PASTE.ForeColor = System.Drawing.Color.Black;
			this.IR_ONOFF_PASTE.Location = new System.Drawing.Point(7, 62);
			this.IR_ONOFF_PASTE.Name = "IR_ONOFF_PASTE";
			this.IR_ONOFF_PASTE.Size = new System.Drawing.Size(81, 24);
			this.IR_ONOFF_PASTE.TabIndex = 10;
			this.IR_ONOFF_PASTE.Text = "paste";
			this.IR_ONOFF_PASTE.UseVisualStyleBackColor = true;
			this.IR_ONOFF_PASTE.Click += new System.EventHandler(this.IR_ONOFF_PASTEClick);
			// 
			// IR_ONOFF_CMD
			// 
			this.IR_ONOFF_CMD.Location = new System.Drawing.Point(7, 43);
			this.IR_ONOFF_CMD.Name = "IR_ONOFF_CMD";
			this.IR_ONOFF_CMD.Size = new System.Drawing.Size(100, 23);
			this.IR_ONOFF_CMD.TabIndex = 1;
			this.IR_ONOFF_CMD.Text = "0";
			// 
			// IR_ONOFF_ADDR
			// 
			this.IR_ONOFF_ADDR.Location = new System.Drawing.Point(7, 20);
			this.IR_ONOFF_ADDR.Name = "IR_ONOFF_ADDR";
			this.IR_ONOFF_ADDR.Size = new System.Drawing.Size(100, 23);
			this.IR_ONOFF_ADDR.TabIndex = 0;
			this.IR_ONOFF_ADDR.Text = "0";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.IR_RX_CMD);
			this.groupBox4.Controls.Add(this.IR_RX_ADDR);
			this.groupBox4.ForeColor = System.Drawing.Color.White;
			this.groupBox4.Location = new System.Drawing.Point(16, 54);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(133, 96);
			this.groupBox4.TabIndex = 2;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Received";
			// 
			// IR_RX_CMD
			// 
			this.IR_RX_CMD.Location = new System.Drawing.Point(7, 43);
			this.IR_RX_CMD.Name = "IR_RX_CMD";
			this.IR_RX_CMD.Size = new System.Drawing.Size(100, 23);
			this.IR_RX_CMD.TabIndex = 1;
			this.IR_RX_CMD.Text = "0";
			// 
			// IR_RX_ADDR
			// 
			this.IR_RX_ADDR.Location = new System.Drawing.Point(7, 20);
			this.IR_RX_ADDR.Name = "IR_RX_ADDR";
			this.IR_RX_ADDR.Size = new System.Drawing.Size(100, 23);
			this.IR_RX_ADDR.TabIndex = 0;
			this.IR_RX_ADDR.Text = "0";
			// 
			// label36
			// 
			this.label36.ForeColor = System.Drawing.Color.White;
			this.label36.Location = new System.Drawing.Point(16, 14);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(62, 17);
			this.label36.TabIndex = 1;
			this.label36.Text = "IR activity";
			// 
			// iractivityled
			// 
			this.iractivityled.BackColor = System.Drawing.Color.Lime;
			this.iractivityled.ForeColor = System.Drawing.Color.White;
			this.iractivityled.Location = new System.Drawing.Point(81, 12);
			this.iractivityled.Name = "iractivityled";
			this.iractivityled.Size = new System.Drawing.Size(38, 20);
			this.iractivityled.TabIndex = 0;
			// 
			// Limiter3Show
			// 
			this.Limiter3Show.BackColor = System.Drawing.Color.Lime;
			this.Limiter3Show.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Limiter3Show.ForeColor = System.Drawing.Color.Black;
			this.Limiter3Show.Location = new System.Drawing.Point(789, 81);
			this.Limiter3Show.Name = "Limiter3Show";
			this.Limiter3Show.Size = new System.Drawing.Size(90, 17);
			this.Limiter3Show.TabIndex = 27;
			this.Limiter3Show.Text = "Limiter 3";
			// 
			// Limiter2Show
			// 
			this.Limiter2Show.BackColor = System.Drawing.Color.Lime;
			this.Limiter2Show.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Limiter2Show.ForeColor = System.Drawing.Color.Black;
			this.Limiter2Show.Location = new System.Drawing.Point(789, 64);
			this.Limiter2Show.Name = "Limiter2Show";
			this.Limiter2Show.Size = new System.Drawing.Size(90, 17);
			this.Limiter2Show.TabIndex = 26;
			this.Limiter2Show.Text = "Limiter 2";
			// 
			// Limiter1Show
			// 
			this.Limiter1Show.BackColor = System.Drawing.Color.Lime;
			this.Limiter1Show.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Limiter1Show.ForeColor = System.Drawing.Color.Black;
			this.Limiter1Show.Location = new System.Drawing.Point(789, 47);
			this.Limiter1Show.Name = "Limiter1Show";
			this.Limiter1Show.Size = new System.Drawing.Size(90, 17);
			this.Limiter1Show.TabIndex = 25;
			this.Limiter1Show.Text = "Limiter 1";
			// 
			// Limiter0Show
			// 
			this.Limiter0Show.BackColor = System.Drawing.Color.Lime;
			this.Limiter0Show.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Limiter0Show.ForeColor = System.Drawing.Color.Black;
			this.Limiter0Show.Location = new System.Drawing.Point(789, 30);
			this.Limiter0Show.Name = "Limiter0Show";
			this.Limiter0Show.Size = new System.Drawing.Size(90, 17);
			this.Limiter0Show.TabIndex = 24;
			this.Limiter0Show.Text = "Limiter 0";
			// 
			// FormsTimer
			// 
			this.FormsTimer.Enabled = true;
			this.FormsTimer.Interval = 10;
			this.FormsTimer.Tick += new System.EventHandler(this.ConnectionTimerTick);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.Link3);
			this.groupBox3.Controls.Add(this.Link2);
			this.groupBox3.Controls.Add(this.Link1);
			this.groupBox3.Controls.Add(this.Link0);
			this.groupBox3.ForeColor = System.Drawing.Color.White;
			this.groupBox3.Location = new System.Drawing.Point(863, 467);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(78, 137);
			this.groupBox3.TabIndex = 23;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Control Link";
			// 
			// Link3
			// 
			this.Link3.ForeColor = System.Drawing.Color.White;
			this.Link3.Location = new System.Drawing.Point(6, 104);
			this.Link3.Name = "Link3";
			this.Link3.Size = new System.Drawing.Size(58, 24);
			this.Link3.TabIndex = 27;
			this.Link3.Text = "Out 4";
			this.Link3.UseVisualStyleBackColor = true;
			this.Link3.CheckedChanged += new System.EventHandler(this.Link3CheckedChanged);
			// 
			// Link2
			// 
			this.Link2.ForeColor = System.Drawing.Color.White;
			this.Link2.Location = new System.Drawing.Point(6, 74);
			this.Link2.Name = "Link2";
			this.Link2.Size = new System.Drawing.Size(58, 24);
			this.Link2.TabIndex = 26;
			this.Link2.Text = "Out 3";
			this.Link2.UseVisualStyleBackColor = true;
			this.Link2.CheckedChanged += new System.EventHandler(this.Link2CheckedChanged);
			// 
			// Link1
			// 
			this.Link1.ForeColor = System.Drawing.Color.White;
			this.Link1.Location = new System.Drawing.Point(6, 44);
			this.Link1.Name = "Link1";
			this.Link1.Size = new System.Drawing.Size(58, 24);
			this.Link1.TabIndex = 25;
			this.Link1.Text = "Out 2";
			this.Link1.UseVisualStyleBackColor = true;
			this.Link1.CheckedChanged += new System.EventHandler(this.Link1CheckedChanged);
			// 
			// Link0
			// 
			this.Link0.ForeColor = System.Drawing.Color.White;
			this.Link0.Location = new System.Drawing.Point(6, 14);
			this.Link0.Name = "Link0";
			this.Link0.Size = new System.Drawing.Size(58, 24);
			this.Link0.TabIndex = 24;
			this.Link0.Text = "Out 1";
			this.Link0.UseVisualStyleBackColor = true;
			this.Link0.CheckedChanged += new System.EventHandler(this.Link0CheckedChanged);
			// 
			// LoadProgress
			// 
			this.LoadProgress.Location = new System.Drawing.Point(789, 346);
			this.LoadProgress.Name = "LoadProgress";
			this.LoadProgress.Size = new System.Drawing.Size(150, 23);
			this.LoadProgress.TabIndex = 24;
			this.LoadProgress.Visible = false;
			// 
			// checkBox1
			// 
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.ForeColor = System.Drawing.Color.White;
			this.checkBox1.Location = new System.Drawing.Point(789, 387);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(138, 24);
			this.checkBox1.TabIndex = 25;
			this.checkBox1.Text = "Enable Live Metering";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
			// 
			// button1
			// 
			this.button1.ForeColor = System.Drawing.Color.Black;
			this.button1.Location = new System.Drawing.Point(789, 254);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(150, 40);
			this.button1.TabIndex = 26;
			this.button1.Text = "Save Settings to File";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.ForeColor = System.Drawing.Color.Black;
			this.button2.Location = new System.Drawing.Point(789, 300);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(150, 40);
			this.button2.TabIndex = 27;
			this.button2.Text = "Load Settings from File";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// label35
			// 
			this.label35.BackColor = System.Drawing.Color.Transparent;
			this.label35.Font = new System.Drawing.Font("Arial", 8F);
			this.label35.ForeColor = System.Drawing.Color.White;
			this.label35.Location = new System.Drawing.Point(671, 63);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(69, 23);
			this.label35.TabIndex = 29;
			this.label35.Text = "- 6 dB";
			this.label35.Click += new System.EventHandler(this.Label35Click);
			// 
			// label37
			// 
			this.label37.BackColor = System.Drawing.Color.Transparent;
			this.label37.Font = new System.Drawing.Font("Arial", 8F);
			this.label37.ForeColor = System.Drawing.Color.White;
			this.label37.Location = new System.Drawing.Point(678, 28);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(69, 23);
			this.label37.TabIndex = 30;
			this.label37.Text = "0 dB";
			// 
			// label38
			// 
			this.label38.BackColor = System.Drawing.Color.Transparent;
			this.label38.Font = new System.Drawing.Font("Arial", 8F);
			this.label38.ForeColor = System.Drawing.Color.White;
			this.label38.Location = new System.Drawing.Point(666, 100);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(69, 23);
			this.label38.TabIndex = 31;
			this.label38.Text = "- 12 dB";
			// 
			// label39
			// 
			this.label39.BackColor = System.Drawing.Color.Transparent;
			this.label39.Font = new System.Drawing.Font("Arial", 8F);
			this.label39.ForeColor = System.Drawing.Color.White;
			this.label39.Location = new System.Drawing.Point(666, 135);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(69, 23);
			this.label39.TabIndex = 32;
			this.label39.Text = "- 18 dB";
			// 
			// label40
			// 
			this.label40.BackColor = System.Drawing.Color.Transparent;
			this.label40.Font = new System.Drawing.Font("Arial", 8F);
			this.label40.ForeColor = System.Drawing.Color.White;
			this.label40.Location = new System.Drawing.Point(666, 182);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(69, 23);
			this.label40.TabIndex = 33;
			this.label40.Text = "- 24 dB";
			// 
			// label41
			// 
			this.label41.BackColor = System.Drawing.Color.Transparent;
			this.label41.Font = new System.Drawing.Font("Arial", 8F);
			this.label41.ForeColor = System.Drawing.Color.White;
			this.label41.Location = new System.Drawing.Point(666, 280);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(69, 23);
			this.label41.TabIndex = 34;
			this.label41.Text = "- 40 dB";
			// 
			// label42
			// 
			this.label42.BackColor = System.Drawing.Color.Transparent;
			this.label42.Font = new System.Drawing.Font("Arial", 8F);
			this.label42.ForeColor = System.Drawing.Color.White;
			this.label42.Location = new System.Drawing.Point(666, 376);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(69, 23);
			this.label42.TabIndex = 35;
			this.label42.Text = "- 55 dB";
			// 
			// Out1Draw
			// 
			this.Out1Draw.Checked = true;
			this.Out1Draw.ForeColor = System.Drawing.Color.White;
			this.Out1Draw.Location = new System.Drawing.Point(12, 415);
			this.Out1Draw.Name = "Out1Draw";
			this.Out1Draw.Size = new System.Drawing.Size(69, 24);
			this.Out1Draw.TabIndex = 0;
			this.Out1Draw.TabStop = true;
			this.Out1Draw.Text = "Out 1";
			this.Out1Draw.UseVisualStyleBackColor = true;
			this.Out1Draw.CheckedChanged += new System.EventHandler(this.Out1DrawCheckedChanged);
			// 
			// Out2Draw
			// 
			this.Out2Draw.ForeColor = System.Drawing.Color.White;
			this.Out2Draw.Location = new System.Drawing.Point(72, 415);
			this.Out2Draw.Name = "Out2Draw";
			this.Out2Draw.Size = new System.Drawing.Size(69, 24);
			this.Out2Draw.TabIndex = 36;
			this.Out2Draw.Text = "Out 2";
			this.Out2Draw.UseVisualStyleBackColor = true;
			this.Out2Draw.CheckedChanged += new System.EventHandler(this.Out2DrawCheckedChanged);
			// 
			// Out3Draw
			// 
			this.Out3Draw.ForeColor = System.Drawing.Color.White;
			this.Out3Draw.Location = new System.Drawing.Point(132, 415);
			this.Out3Draw.Name = "Out3Draw";
			this.Out3Draw.Size = new System.Drawing.Size(69, 24);
			this.Out3Draw.TabIndex = 37;
			this.Out3Draw.Text = "Out 3";
			this.Out3Draw.UseVisualStyleBackColor = true;
			this.Out3Draw.CheckedChanged += new System.EventHandler(this.Out3DrawCheckedChanged);
			// 
			// Out4Draw
			// 
			this.Out4Draw.ForeColor = System.Drawing.Color.White;
			this.Out4Draw.Location = new System.Drawing.Point(192, 415);
			this.Out4Draw.Name = "Out4Draw";
			this.Out4Draw.Size = new System.Drawing.Size(69, 24);
			this.Out4Draw.TabIndex = 38;
			this.Out4Draw.Text = "Out 4";
			this.Out4Draw.UseVisualStyleBackColor = true;
			this.Out4Draw.CheckedChanged += new System.EventHandler(this.Out4DrawCheckedChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(951, 696);
			this.Controls.Add(this.Out4Draw);
			this.Controls.Add(this.Limiter3Show);
			this.Controls.Add(this.Out3Draw);
			this.Controls.Add(this.Limiter2Show);
			this.Controls.Add(this.Out2Draw);
			this.Controls.Add(this.Out1Draw);
			this.Controls.Add(this.Limiter1Show);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.Limiter0Show);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.peakMeterCtrl2);
			this.Controls.Add(this.LoadProgress);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label35);
			this.Controls.Add(this.label37);
			this.Controls.Add(this.label38);
			this.Controls.Add(this.label39);
			this.Controls.Add(this.label40);
			this.Controls.Add(this.label41);
			this.Controls.Add(this.label42);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "MainForm";
			this.Text = "SAmp forte - Control ";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainFormClose);
			this.Load += new System.EventHandler(this.MainFormLoad);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.Mute.ResumeLayout(false);
			this.tabPage9.ResumeLayout(false);
			this.tabPage9.PerformLayout();
			this.tabPage5.ResumeLayout(false);
			this.tabPage7.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage8.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label ampoutvoltage;
		private System.Windows.Forms.Label LimitRelVal;
		private XComponent.SliderBar.MACTrackBar LimiterReleaseBar;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button DynBass_Bypass;
		private System.Windows.Forms.Button VBS_Bypass;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.Button HPBypass;
		private System.Windows.Forms.Button EQ0Bypass;
		private System.Windows.Forms.Button EQ1Bypass;
		private System.Windows.Forms.Button EQ2Bypass;
		private System.Windows.Forms.Button EQ3Bypass;
		private System.Windows.Forms.Button EQ4Bypass;
		private System.Windows.Forms.Button LPBypass;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.TextBox HPFreq;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.TextBox HPQ;
		private System.Windows.Forms.ComboBox HPOrder;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.TextBox LPFreq;
		private System.Windows.Forms.TextBox LPQ;
		private System.Windows.Forms.ComboBox LPOrder;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.ComboBox EQ1Type;
		private System.Windows.Forms.ComboBox EQ2Type;
		private System.Windows.Forms.ComboBox EQ3Type;
		private System.Windows.Forms.ComboBox EQ4Type;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.ComboBox EQ0Type;
		private System.Windows.Forms.TextBox EQ1Freq;
		private System.Windows.Forms.TextBox EQ1Q;
		private System.Windows.Forms.TextBox EQ1Gain;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.TextBox EQ2Freq;
		private System.Windows.Forms.TextBox EQ2Q;
		private System.Windows.Forms.TextBox EQ2Gain;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.TextBox EQ3Freq;
		private  System.Windows.Forms.TextBox EQ3Q;
		private  System.Windows.Forms.TextBox EQ3Gain;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.TextBox EQ4Freq;
		private  System.Windows.Forms.TextBox EQ4Q;
		private   System.Windows.Forms.TextBox EQ4Gain;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.TextBox EQ0Freq;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label44;
		private   System.Windows.Forms.TextBox EQ0Q;
		private XComponent.SliderBar.MACTrackBar lphpeqbar;
		private  System.Windows.Forms.TextBox EQ0Gain;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.TabPage tabPage9;
		private System.Windows.Forms.RadioButton Out4Draw;
		private System.Windows.Forms.RadioButton Out3Draw;
		private System.Windows.Forms.RadioButton Out2Draw;
		private System.Windows.Forms.RadioButton Out1Draw;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label35;
		public System.Windows.Forms.OpenFileDialog openFileDialog1;
		public System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button IR_ONOFF_PASTE;
		private System.Windows.Forms.Label IR_MUTE_ADDR;
		private System.Windows.Forms.Label IR_MUTE_CMD;
		private System.Windows.Forms.Button IR_MUTE_PASTE;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label IR_VOLUP_ADDR;
		private System.Windows.Forms.Label IR_VOLUP_CMD;
		private System.Windows.Forms.Button IR_VOLUP_PASTE;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Label IR_VOLDOWN_ADDR;
		private System.Windows.Forms.Label IR_VOLDOWN_CMD;
		private System.Windows.Forms.Button IR_VOLDOWN_PASTE;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Label IR_ONOFF_ADDR;
		private System.Windows.Forms.Label IR_ONOFF_CMD;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label iractivityled;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label IR_RX_ADDR;
		private System.Windows.Forms.Label IR_RX_CMD;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ProgressBar LoadProgress;
		private System.Windows.Forms.Label DynBassLatestGain;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label DynBassMaxGain_Val;
		private System.Windows.Forms.Label DynBassGainSpeed_Val;
		private System.Windows.Forms.Label DynBassFreq_Val;
		private System.Windows.Forms.Label DynBassThres_Val;
		private System.Windows.Forms.Label DynBassWatchtime_Val;
		private XComponent.SliderBar.MACTrackBar DynBassWatchtime_Bar;
		private XComponent.SliderBar.MACTrackBar DynBassThres_Bar;
		private XComponent.SliderBar.MACTrackBar DynBassFreq_Bar;
		private XComponent.SliderBar.MACTrackBar DynBassMaxGain_Bar;
		private XComponent.SliderBar.MACTrackBar DynBassGainSpeed_Bar;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label VBS_FreqVal;
		private System.Windows.Forms.Label VBS_GainVal;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TabPage tabPage8;
		private XComponent.SliderBar.MACTrackBar VBS_FreqBar;
		private XComponent.SliderBar.MACTrackBar VBS_GainBar;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Label LimitThresVal;
		private XComponent.SliderBar.MACTrackBar DelayBar0;
		private XComponent.SliderBar.MACTrackBar DelayBar1;
		private XComponent.SliderBar.MACTrackBar DelayBar2;
		private XComponent.SliderBar.MACTrackBar DelayBar3;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label DelayVal0;
		private System.Windows.Forms.Label DelayVal1;
		private System.Windows.Forms.Label DelayVal2;
		private System.Windows.Forms.Label DelayVal3;
		private System.Windows.Forms.Label Limiter3Show;
		private System.Windows.Forms.Label Limiter2Show;
		private System.Windows.Forms.Label Limiter1Show;
		private System.Windows.Forms.Label Limiter0Show;
		private XComponent.SliderBar.MACTrackBar LimiterTresholdBar;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.CheckBox Link0;
		private System.Windows.Forms.CheckBox Link1;
		private System.Windows.Forms.CheckBox Link2;
		private System.Windows.Forms.CheckBox Link3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label GainCH0Text;
		private System.Windows.Forms.Label GainCH1Text;
		private System.Windows.Forms.Label GainCH2Text;
		private System.Windows.Forms.Label GainCH3Text;
		private XComponent.SliderBar.MACTrackBar GainCH0Bar;
		private XComponent.SliderBar.MACTrackBar GainCH1Bar;
		private XComponent.SliderBar.MACTrackBar GainCH2Bar;
		private XComponent.SliderBar.MACTrackBar GainCH3Bar;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox MuteCH1;
		private System.Windows.Forms.CheckBox MuteCH2;
		private System.Windows.Forms.CheckBox MuteCH3;
		private System.Windows.Forms.CheckBox PolCH0;
		private System.Windows.Forms.CheckBox PolCH1;
		private System.Windows.Forms.CheckBox PolCH2;
		private System.Windows.Forms.CheckBox PolCH3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox MuteCH0;
		private System.Windows.Forms.GroupBox Mute;
		private System.Windows.Forms.TabPage tabPage7;
		private System.Windows.Forms.Timer FormsTimer;
		private System.Windows.Forms.ComboBox Source1Select;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox Source2Select;
		private System.Windows.Forms.ComboBox Source3Select;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox Source0Select;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private Ernzo.WinForms.Controls.PeakMeterCtrl peakMeterCtrl2;
		private System.Windows.Forms.PictureBox pictureBox1;
		
		void MacTrackBar1ValueChanged(object sender, decimal value)
		{
			
			
		}
		
		void PeakMeterCtrl2Click(object sender, System.EventArgs e)
		{
		}
		
		void Label10Click(object sender, System.EventArgs e)
		{
			
		}
		
		
		
		void EQFreqFieldTextChanged(object sender, System.EventArgs e)
		{
			
		}
		
		void EQQFieldTextChanged(object sender, System.EventArgs e)
		{
			
		}
		
		void Label17Click(object sender, System.EventArgs e)
		{
			
		}
		

		
		void LPQFieldTextChanged(object sender, System.EventArgs e)
		{
			
		}
		
		void HPFreqFieldTextChanged(object sender, System.EventArgs e)
		{
			
		}
		
		void EQGainFieldTextChanged(object sender, System.EventArgs e)
		{
			
		}
		
		void TextBox3TextChanged(object sender, System.EventArgs e)
		{
			
		}
		
		
		
		
		
		
		
		
		

	
		
	
		
		
		
	
		
		
		
		void LPFreqFieldTextChanged(object sender, System.EventArgs e)
		{
			
		}
	}
}
