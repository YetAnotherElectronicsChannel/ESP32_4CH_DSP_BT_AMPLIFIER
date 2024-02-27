
using System;

namespace dsp_gui
{
	/// <summary>
	/// Description of StringFIFO.
	/// </summary>
	public class StringFIFO
	{
		string[] buffer = new String[500];
		int rptr=0;
		int wptr=0;
		int max= 500;
		
		public StringFIFO()
		{
		}
		
		public void push(string input) {
			buffer[wptr] = input;
			wptr++;
			if (wptr==max) wptr=0;
		}
		public string pop() {
			string temp = buffer[rptr];
			rptr++;
			if (rptr==max) rptr=0;
			return temp;
		}
		
		public int size() {
			return wptr-rptr;
		}
		public void clear() {
			rptr=0;
			wptr=0;
		}
	}
}
