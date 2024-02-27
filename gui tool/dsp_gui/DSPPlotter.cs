
using System;
using System.Drawing;
using System.Threading;
namespace dsp_gui
{
	/// <summary>
	/// Description of DSPPlotter.
	/// </summary>
	public class DSPPlotter
	{
		public DSPPlotter()
		{
			for (int channel=0; channel<4; channel++) {
				SetHighPass(channel,0,1000,7,0);
				SetLowPass(channel,0,1000,7,0);
				
				for (int i=0; i<5; i++) {
					SetEQ(channel,i,1000,0,7,0);
				}
			}
			gridimage = GetGridImage();
			//SetHighPass(3,2,100,7);
			//SetEQ(0,2,8000,+15,7);
			//SetEQ(0,0,8000,+15,7);
			//SetEQ(0,1,8000,+15,7);
			//SetEQ(0,0,100,-7,7);
			//SetLowPass(2,2,1000,1);
			//SetEQ(3,4,500,-4,7);
			//SetEQ(1,4,5000,-4,7);
			//SetEQ(1,4,130,+7,7);
			
			Thread plotterthread = new Thread(new ThreadStart(PlotterThread));
			plotterthread.Start();
		}
		
		double[,] iir_lp = new double[4,10];
		double[,] iir_hp = new double[4,10];
		double[,] iir_eq = new double[4,25];
		double[,] tf = new double[4,1000];
		double[,,] tfeq = new double[4,5,1000];
		double[,] tflp = new double[4,1000];
		double[,] tfhp = new Double[4,1000];
		double pi = 3.14159265359f;
		
		public int[,] channel_bypass = new int[4,7];
		
		static int penWidth = 2;
		static int alpha = 220;
		
		Pen maintfpen = new Pen(Color.FromArgb(255,255,255,255),2);
		                        
				
		
		static int penWidthbg = 1;
		static int alphabg = 160;		
		Pen[] bgpens = new Pen[7] {
			new Pen (Color.FromArgb(alphabg, 255,0,0),penWidthbg),
			
			new Pen (Color.FromArgb(alphabg, 102,250,250), penWidthbg),
			new Pen (Color.FromArgb(alphabg, 255,255,0), penWidthbg),
			new Pen (Color.FromArgb(alphabg, 0,255,0), penWidthbg),
			new Pen (Color.FromArgb(alphabg, 0,255,255), penWidthbg),
			new Pen (Color.FromArgb(alphabg, 255,0,255), penWidthbg),
			
			new Pen (Color.FromArgb(alphabg, 0,0,255), penWidthbg)
				
		};
		
		int step12 = 80;
		int xmax = 700;
		int ymax = 400;
		
		
		int drawch = 0;
		
		
		
		bool plotrequest = false;
		bool plotfinished = false;
		Bitmap tempimage = null;
		
		Bitmap gridimage = null;
		
		void PlotterThread() {
			
			while (true) {
				if (plotrequest) {
					Console.WriteLine("plotrequest");
					tempimage = DrawFilter();
					plotrequest = false;
					plotfinished = true;
				}
				System.Threading.Thread.Sleep(1);
			}
		}
		
		public void StartRenderPlot() {
			plotrequest = true;
		}
		
		public bool IsRenderFinished() {
			return plotfinished;
		}
		
		public Bitmap GetPlot() {
			plotfinished = false;
			return tempimage;
		}
		
		Bitmap DrawFilter() {
			
			Bitmap bmp = (Bitmap)gridimage.Clone();
			Graphics graphic = Graphics.FromImage(bmp);
			
			
			
			double lastx = 0.0f; 
			double lasty = 0.0f;
			CalcTF();
							
			

			
			for (int x=0; x<700;x++) {					
					
					double newy = 0.0f;
					Pen temppen = (Pen)bgpens[0].Clone();						    	
					for (int i=0; i<5; i++) { 
					
						temppen = (Pen)bgpens[i+1].Clone();
						if (channel_bypass[drawch,2+i]==1) temppen = new Pen (Color.FromArgb(50, temppen.Color.R,temppen.Color.G,temppen.Color.B), penWidthbg);
						
						newy = (6.6666f*tfeq[drawch,i,x])+200;
						if ((float)newy > (float)GetYBydB(24,ymax,step12)-20 && (float)newy < (float)GetYBydB(-24,ymax,step12)+20) {
							if (newy>200) graphic.DrawLine(temppen,x,200,x,(float)newy);
							if (newy<200) graphic.DrawLine(temppen,x,200,x,(float)newy);
						}
						else {
							if (newy>200) graphic.DrawLine(temppen,x,200,x,(float)GetYBydB(-24,ymax,step12)+20);
							if (newy<200) graphic.DrawLine(temppen,x,200,x,(float)GetYBydB(+24,ymax,step12)-20);
						}
					}
				
					temppen = (Pen)bgpens[0].Clone();
					if (channel_bypass[drawch,0]==1) temppen = new Pen (Color.FromArgb(50, temppen.Color.R,temppen.Color.G,temppen.Color.B), penWidthbg);
					
					newy = (6.6666f*tflp[drawch,x])+200;
					if ((float)newy > (float)GetYBydB(24,ymax,step12)-20 && (float)newy < (float)GetYBydB(-24,ymax,step12)+20) {
						if (newy>200) graphic.DrawLine(temppen,x,200,x,(float)newy);
						if (newy<200) graphic.DrawLine(temppen,x,200,x,(float)newy);
					}
					else {
						if (newy>200) graphic.DrawLine(temppen,x,200,x,(float)GetYBydB(-24,ymax,step12)+20);
						if (newy<200) graphic.DrawLine(temppen,x,200,x,(float)GetYBydB(+24,ymax,step12)-20);
					}
				
					temppen = (Pen)bgpens[6].Clone();
					if (channel_bypass[drawch,1]==1) temppen = new Pen (Color.FromArgb(50, temppen.Color.R,temppen.Color.G,temppen.Color.B), penWidthbg);
					
					
					newy = (6.6666f*tfhp[drawch,x])+200;
					if ((float)newy > (float)GetYBydB(24,ymax,step12)-20 && (float)newy < (float)GetYBydB(-24,ymax,step12)+20) {
						if (newy>200) graphic.DrawLine(temppen,x,200,x,(float)newy);
						if (newy<200) graphic.DrawLine(temppen,x,200,x,(float)newy);
					}
					else {
						if (newy>200) graphic.DrawLine(temppen,x,200,x,(float)GetYBydB(-24,ymax,step12)+20);
						if (newy<200) graphic.DrawLine(temppen,x,200,x,(float)GetYBydB(+24,ymax,step12)-20);
					}
				
				
			}
				
			for (int i=0;i<700;i++) {
						       
        		
        		double newx = (double) i;
        		double newy = (6.6666f*tf[drawch,i])+200;
        		
        		if (i==0) {
    					lastx = newx;
    					lasty = newy;
        				}
        		
        		try {
        			if ((float)newy > (float)GetYBydB(24,ymax,step12)-20 && (float)newy < (float)GetYBydB(-24,ymax,step12)+20) {
        			if ((float)lasty > (float)GetYBydB(24,ymax,step12)-20 && (float)lasty < (float)GetYBydB(-24,ymax,step12)+20) {	
        			    
        					graphic.DrawLine(maintfpen,(float)lastx,(float)lasty,(float)newx,(float)newy);
		        		
		        		
		        		
        				}
        			}
        		}
        		
        		catch {
        			
        		}        		
        		lastx = newx;
				lasty = newy;
        		//graphic.DrawEllipse(redPen,i,(float),0.1f,0.1f);
        		
        		
			}
			
			
			graphic.FillRectangle(Brushes.Black,0,0,110,ymax);
			return bmp;
			
		}
		
		Bitmap GetGridImage() {
			int[] frequencies = new int[] {10,20,30,40,50,60,70,80,90,100,200,300,400,500,600,700,800,900,1000,2000,3000,4000,5000,6000,7000,8000,9000,10000,20000};
			int[] dbscale = new int[] {-24, -12,0,12,24};
			
			Bitmap bmp = new Bitmap(750,ymax);
			Graphics graphic = Graphics.FromImage(bmp);
			
			graphic.FillRectangle(Brushes.Black,0,0,750,ymax);
			
			int whiteintense = 150;
			Pen whitePen = new Pen(Color.FromArgb(whiteintense,whiteintense,whiteintense),1);
			for (int i=0;i<frequencies.Length;i++) {
				if (frequencies[i] != 10 && frequencies[i] != 100 && frequencies[i] != 1000 && frequencies[i] != 10000 && frequencies[i] != 20000) {
					graphic.DrawLine(whitePen,(float)GetXByFrequency(frequencies[i],xmax),30,(float)GetXByFrequency(frequencies[i],xmax),ymax-30);
				}
				else {
					graphic.DrawLine(whitePen,(float)GetXByFrequency(frequencies[i],xmax),20,(float)GetXByFrequency(frequencies[i],xmax),ymax-20);
				}
				
			}
			
			
			
			for (int i=0;i<dbscale.Length;i++) {
				graphic.DrawLine(whitePen,0,(float)GetYBydB(dbscale[i],ymax,step12),705,(float)GetYBydB(dbscale[i],ymax,step12));
			}
			graphic.DrawString("+24", new System.Drawing.Font("Arial", 10, FontStyle.Regular),whitePen.Brush,710,(float)GetYBydB(24,ymax,step12)-8);
			graphic.DrawString("+12", new System.Drawing.Font("Arial", 10, FontStyle.Regular),whitePen.Brush,710,(float)GetYBydB(12,ymax,step12)-8);
			graphic.DrawString("0", new System.Drawing.Font("Arial", 10, FontStyle.Regular),whitePen.Brush,710,(float)GetYBydB(0,ymax,step12)-8);
			graphic.DrawString("-12", new System.Drawing.Font("Arial", 10, FontStyle.Regular),whitePen.Brush,710,(float)GetYBydB(-12,ymax,step12)-8);
			graphic.DrawString("-24", new System.Drawing.Font("Arial", 10, FontStyle.Regular),whitePen.Brush,710,(float)GetYBydB(-24,ymax,step12)-8);
			
			graphic.DrawString("10", new System.Drawing.Font("Arial", 10, FontStyle.Regular),whitePen.Brush,(float)GetXByFrequency(10,xmax)-10,0);
			graphic.DrawString("100", new System.Drawing.Font("Arial", 10, FontStyle.Regular),whitePen.Brush,(float)GetXByFrequency(100,xmax)-10,0);
			graphic.DrawString("1k", new System.Drawing.Font("Arial", 10, FontStyle.Regular),whitePen.Brush,(float)GetXByFrequency(1000,xmax)-10,0);
			graphic.DrawString("10k", new System.Drawing.Font("Arial", 10, FontStyle.Regular),whitePen.Brush,(float)GetXByFrequency(10000,xmax)-10,0);
			graphic.DrawString("20k", new System.Drawing.Font("Arial", 10, FontStyle.Regular),whitePen.Brush,(float)GetXByFrequency(20000,xmax)-10,0);
			graphic.DrawString("10", new System.Drawing.Font("Arial", 10, FontStyle.Regular),whitePen.Brush,(float)GetXByFrequency(10,xmax)-10,ymax-15);
			graphic.DrawString("100", new System.Drawing.Font("Arial", 10, FontStyle.Regular),whitePen.Brush,(float)GetXByFrequency(100,xmax)-10,ymax-15);
			graphic.DrawString("1k", new System.Drawing.Font("Arial", 10, FontStyle.Regular),whitePen.Brush,(float)GetXByFrequency(1000,xmax)-10,ymax-15);
			graphic.DrawString("10k", new System.Drawing.Font("Arial", 10, FontStyle.Regular),whitePen.Brush,(float)GetXByFrequency(10000,xmax)-10,ymax-15);
			graphic.DrawString("20k", new System.Drawing.Font("Arial", 10, FontStyle.Regular),whitePen.Brush,(float)GetXByFrequency(20000,xmax)-10,ymax-15);
			
			
			return bmp;
		}
		
			
		public double GetYBydB(double db, int max, int step12) {
			
			double y0db = (double)max/2;
			return y0db - (db/12)*step12;
		}
		public double GetFrequencyByX(int x, int max) {
			double xf = (double) x;
			double mf = (double) max;
			return Math.Pow(10,xf*(4.301f/mf));
		}
		
		public double GetXByFrequency(int frequency, int max) {
			double ff = (double) frequency;
			double mf = (double) max;
			return (double) Math.Log10(frequency)/(4.301f/mf);
		}
		
	void CalcTF() {
						
		
			for (int x=0; x<700; x++) {
				double w02 = 2.0f*Math.PI*GetFrequencyByX(x, 700)/48000.0f;
				
				for (int channel=0; channel<4; channel++) {
				
					tf[channel,x] = 0.0f;
					tf[channel,x] += GainAtW0(iir_lp[channel,0], iir_lp[channel,1],iir_lp[channel,2],iir_lp[channel,3],iir_lp[channel,4] , w02);
					tf[channel,x] += GainAtW0(iir_lp[channel,5], iir_lp[channel,6],iir_lp[channel,7],iir_lp[channel,8],iir_lp[channel,9] , w02);
					tf[channel,x] += GainAtW0(iir_hp[channel,0], iir_hp[channel,1],iir_hp[channel,2],iir_hp[channel,3],iir_hp[channel,4] , w02);
					tf[channel,x] += GainAtW0(iir_hp[channel,5], iir_hp[channel,6],iir_hp[channel,7],iir_hp[channel,8],iir_hp[channel,9] , w02);
					
					tflp[channel,x] = GainAtW0(iir_lp[channel,0], iir_lp[channel,1],iir_lp[channel,2],iir_lp[channel,3],iir_lp[channel,4] , w02);
					tflp[channel,x] += GainAtW0(iir_lp[channel,5], iir_lp[channel,6],iir_lp[channel,7],iir_lp[channel,8],iir_lp[channel,9] , w02);
					tfhp[channel,x] = GainAtW0(iir_hp[channel,0], iir_hp[channel,1],iir_hp[channel,2],iir_hp[channel,3],iir_hp[channel,4] , w02);
					tfhp[channel,x] += GainAtW0(iir_hp[channel,5], iir_hp[channel,6],iir_hp[channel,7],iir_hp[channel,8],iir_hp[channel,9] , w02);
					
					for (int i=0; i<5; i++) {
						tf[channel,x] += GainAtW0(iir_eq[channel,i*5+0], iir_eq[channel,i*5+1],iir_eq[channel,i*5+2],iir_eq[channel,i*5+3],iir_eq[channel,i*5+4] , w02);
						tfeq[channel,i,x] = GainAtW0(iir_eq[channel,i*5+0], iir_eq[channel,i*5+1],iir_eq[channel,i*5+2],iir_eq[channel,i*5+3],iir_eq[channel,i*5+4] , w02);
					}
				}
			}
			
		}
	
		
	double GainAtW0 (double a0, double a1, double a2, double b1, double b2, double w0) {
			double numerator = a0*a0 + a1*a1 + a2*a2 + 2.0f*(a0*a1 + a1*a2)*Math.Cos(w0) + 2.0f*a0*a2*Math.Cos(2.0f*w0);
    		double denominator = 1.0f + b1*b1 + b2*b2 + 2.0f*(b1 + b1*b2)*Math.Cos(w0) + 2.0f*b2*Math.Cos(2.0f*w0);
    		double mag = Math.Sqrt(numerator/denominator);
    		return -20.0f*Math.Log10(mag);
	}
		
	public void SetHighPass(int channel, int order, int frequency, int q, int bypass) {
			if (channel<0 || channel>3) return;
			if (order<0 || order>2) return;
			if (frequency <0 || frequency>20000) return;
			if (q<1 || q>30) return;
			
			channel_bypass[channel,1]=bypass;
			if (order==0) {	
				
					for (int i=0; i<10;i++) {
					
						iir_hp[channel, i]=0.0f;				
						
						if (i%5==0) {
							iir_hp[channel, i]=1.0f;
						}
					}			
					
				
				return;
			}

			double fc = (double) frequency;
			double fs = 48000.0f;
			double k = Math.Tan(pi*(fc/fs));
			double qf=((double)q)/10.0f;
			double norm = 1.0f/(1.0f+k/qf+k*k);
			double a0 = norm;
			double a1 = -2.0f*a0;
			double a2 = a0;
			double b1 = 2.0f * (k*k-1.0f)*norm;
			double b2 = (1.0f-k/qf+k*k)*norm;
	
	
			if (order==1) {	
				iir_hp[channel,0] = a0;
				iir_hp[channel,1] = a1;
				iir_hp[channel,2] = a2;
				iir_hp[channel,3] = b1;
				iir_hp[channel,4] = b2;
				iir_hp[channel,5] = 1.0f;
				iir_hp[channel,6] = 0.0f;
				iir_hp[channel,7] = 0.0f;
				iir_hp[channel,8] = 0.0f;
				iir_hp[channel,9] = 0.0f;
			}
			else {
				iir_hp[channel,0] = a0;
				iir_hp[channel,1] = a1;
				iir_hp[channel,2] = a2;
				iir_hp[channel,3] = b1;
				iir_hp[channel,4] = b2;
				iir_hp[channel,5] = a0;
				iir_hp[channel,6] = a1;
				iir_hp[channel,7] = a2;
				iir_hp[channel,8] = b1;
				iir_hp[channel,9] = b2;
			
			}
	
	

	}
		
	
	public void EnabledDraw(int inputno) {
			drawch = inputno;
			
	}
	public void SetLowPass(int channel, int order, int frequency, int q, int bypass) {
		if (channel<0 || channel>3) return;
		if (order<0 || order>2) return;
		if (frequency <0 || frequency>20000) return;
		if (q<1 || q>30) return;
	
		channel_bypass[channel,0]=bypass;
		if (order==0) {
		
			
			for (int i=0; i<10;i++) {
			
				iir_lp[channel,i]=0.0f;				
				
				if (i%5==0) {
					iir_lp[channel,i]=1.0f;
				}
			}
			
				
			return;
		}

		double fc = (double) frequency;
		double fs = 48000.0f;
		
		double k = Math.Tan(pi*(fc/fs));
		double qf=((double)q)/10.0f;
		double norm = 1.0f/(1.0f+k/qf+k*k);
		double a0 = k*k*norm;
		double a1 = 2.0f*a0;
		double a2 = a0;
		double b1 = 2.0f * (k*k-1.0f)*norm;
		double b2 = (1.0f-k/qf+k*k)*norm;
	
	
		if (order==1) {	
			iir_lp[channel,0] = a0;
			iir_lp[channel,1] = a1;
			iir_lp[channel,2] = a2;
			iir_lp[channel,3] = b1;
			iir_lp[channel,4] = b2;
			iir_lp[channel,5] = 1.0f;
			iir_lp[channel,6] = 0.0f;
			iir_lp[channel,7] = 0.0f;
			iir_lp[channel,8] = 0.0f;
			iir_lp[channel,9] = 0.0f;
		}
		else {
			iir_lp[channel,0] = a0;
			iir_lp[channel,1] = a1;
			iir_lp[channel,2] = a2;
			iir_lp[channel,3] = b1;
			iir_lp[channel,4] = b2;
			iir_lp[channel,5] = a0;
			iir_lp[channel,6] = a1;
			iir_lp[channel,7] = a2;
			iir_lp[channel,8] = b1;
			iir_lp[channel,9] = b2;
	
	}
	
	

	}
		
		
	public void SetEQ (int channel, int no, int frequency, int gain, int q, int bypass) {
		if (channel<0 || channel>3) return;
		if (frequency <0 || frequency>20000) return;
		if (q< -2 || q>100) return;
		if (q>=0&&q<1) return;
		if (no<0 || no>4) return;
		if (gain< -15 || gain > 15) return;
	
		channel_bypass[channel,2+no]=bypass;
	
	
	
		if (gain==0) {
		
			
			iir_eq[channel, no*5+0] = 1.0f;
			iir_eq[channel, no*5+1] = 0.0f;
			iir_eq[channel, no*5+2] = 0.0f;
			iir_eq[channel, no*5+3] = 0.0f;
			iir_eq[channel, no*5+4] = 0.0f;
			
			return;
		
		}
	
		double fc = (double) frequency;
		double fs = 48000.0f;
		double sqrt2 = 1.41421356f;
		double k = Math.Tan(pi*(fc/fs));
		double norm=0.0f, a0=0.0f, a1=0.0f, a2=0.0f, b1=0.0f, b2=0.0f;
		double qf=((double)q)/10.0f;
		double gainf = (double) gain;
		double v = Math.Pow(10.0f, Math.Abs(gainf)/20.0f);
	
	
		//standard peak eq
		if (q>1) {
		
			if (gain>=0) {
				
				norm = 1.0f/(1.0f+1.0f/qf*k+k*k);
				a0 = (1.0f+v/qf*k+k*k)*norm;
				a1 = 2.0f*(k*k-1.0f)*norm;
				a2 = (1.0f-v/qf*k+k*k)*norm;
				b1 = a1;
				b2 = (1.0f-1.0f/qf*k+k*k)*norm;
			}
			else {
			
				norm = 1.0f/(1.0f+v/qf*k+k*k);
				a0 = (1.0f+1.0f/qf*k+k*k)*norm;
				a1 = 2.0f*(k*k-1.0f)*norm;
				a2 = (1.0f-1.0f/qf*k+k*k)*norm;
				b1=a1;
				b2 = (1.0f-v/qf*k+k*k)*norm;
			}
		
		}
	
	//highshelf
	   	if (q==-1) {
		
			if (gain>=0) {
			
				norm = 1.0f/(1.0f+sqrt2*k+k*k);
				a0 = (v+Math.Sqrt(2.0f*v)*k+k*k)*norm;
				a1 = 2.0f*(k*k-v)*norm;
				a2 = (v-Math.Sqrt(2*v)*k+k*k)*norm;
				b1 = 2.0f*(k*k-1.0f)*norm;
				b2 = (1.0f-sqrt2*k+k*k)*norm;
			}
			else {
			
				norm = 1.0f/(v+Math.Sqrt(2*v)*k+k*k);
				a0 = (1.0f+sqrt2*k+k*k)*norm;
				a1 = 2.0f*(k*k-1.0f)*norm;
				a2 = (1.0f-sqrt2*k+k*k)*norm;
				b1 = 2.0f*(k*k-v)*norm;
				b2 = (v-Math.Sqrt(2.0f*v)*k+k*k)*norm;
			}
		
		}
	
		//lowshelf
	   	if (q==-2) {
		
			if (gain>=0) {
			
				norm = 1.0f/(1.0f+sqrt2*k+k*k);
				a0 = (1.0f+Math.Sqrt(2.0f*v)*k+v*k*k)*norm;
				a1 = 2.0f*(v*k*k-1.0f)*norm;
				a2 = (1.0f-Math.Sqrt(2.0f*v)*k+v*k*k)*norm;
				b1 = 2.0f*(k*k-1.0f)*norm;
				b2 = (1.0f-sqrt2*k+k*k)*norm;
			}
			else {
			
				norm = 1.0f/(1.0f+Math.Sqrt(2.0f*v)*k+v*k*k);
				a0 = (1.0f+sqrt2*k+k*k)*norm;
				a1 = 2.0f*(k*k-1.0f)*norm;
				a2 = (1.0f-sqrt2*k+k*k)*norm;
				b1 = 2.0f*(v*k*k-1.0f)*norm;
				b2 = (1.0f-Math.Sqrt(2.0f*v)*k+v*k*k)*norm;
			}
		
		}
	
	
	
	iir_eq[channel, no*5+0] = a0;
	iir_eq[channel, no*5+1] = a1;
	iir_eq[channel, no*5+2] = a2;
	iir_eq[channel, no*5+3] = b1;
	iir_eq[channel, no*5+4] = b2;
	
	
	
}

		
		
	}
}
