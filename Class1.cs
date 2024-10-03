//
//      ===  Demo LCDSmartie Plugin for c#  ===
//
// dot net plugins are supported in LCD Smartie 5.3 beta 3 and above.
//

// You may provide/use upto 20 functions (function1 to function20).


using System;
using System.Collections.Generic;
using System.Globalization;
namespace histogram
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class LCDSmartie
	{
		public LCDSmartie()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//$dll(histogram,1,4x15#8#0#100#value,name)
		//$dll(histogram,2,name,3)
		//$dll(histogram,2,name,2)
		//$dll(histogram,2,name,1)
		int strtoint(string input)
		{
			return (int) Convert.ToSingle(input, CultureInfo.InvariantCulture.NumberFormat);
		}
		string inttostr(int input)
		{
			return Convert.ToString(input);
		}


		int[] data;
		int columns = 1; //16
		int rows = 1; //4
		int min = 0;
		int max = 100;
		int sampleTime = 8;
		int currValue = 0;
		int currIndex = -1;
		long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
		public long lastmilliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
		string charDef = "$CustomChar(1,0,0,0,0,0,0,0,31)$CustomChar(2,0,0,0,0,0,0,31,31)$CustomChar(3,0,0,0,0,0,31,31,31)$CustomChar(4,0,0,0,0,31,31,31,31)$CustomChar(5,0,0,0,31,31,31,31,31)$CustomChar(6,0,0,31,31,31,31,31,31)$CustomChar(7,0,31,31,31,31,31,31,31)$CustomChar(8,31,31,31,31,31,31,31,31)";

		void updateArray(ref int[] data, int newValue)
        {
			for (int i=0;i<data.Length-1; i++)
            {
				data[i] = data[i + 1];
            }
			data[data.Length - 1] = newValue;
        }
		//string outputArray(int[] data)
  //      {
		//	string output = "";

		//	for(int i=0;i<data.Length;i++)
  //          {
		//		int value = (int)((data[i] - min) * 9.0f / (max - min));
		//		if (value > 8) value = 8;
		//		if (value < 0) value = 0;

		//		if (value == 0)
		//		{ 
		//			output += " "; 
		//		}
  //              else 
		//		{
		//			output += "$Chr(" + (value - 1) + ")"; 
		//		}
				
  //          }
		//	return output;
  //      }
		string[] outputArray(int[] data, int rows)
		{
			string[] output = new string[rows];
			if (rows == 1 || rows > 4)
			{
				for (int i = 0; i < data.Length; i++)
				{
					int value = (int)((data[i] - min) * 9.0f / (max - min));
					if (value > 8) value = 8;
					if (value < 0) value = 0;

					if (value == 0)
					{
						output[0] += " ";
					}
					else
					{
						output[0] += "$Chr(" + (value - 1) + ")";
					}
				}
			}

			if (rows == 2)
            {
				for (int i = 0; i < data.Length; i++)
				{
					int value = (int)((data[i] - min) * 17.0f / (max - min));
					if (value > 16) value = 16;
					if (value < 0) value = 0;
					if (value == 0)
					{
						output[0] += " ";
						output[1] += " ";
					}
					if (value > 0 && value < 9)
                    {
						output[0] += " ";
						output[1] += "$Chr(" + (value - 1) + ")";
					}
					if (value >= 9)
					{
						output[0] += "$Chr(" + (value - 9) + ")";
						output[1] += "$Chr(7)";
					}
				}
			}

			if (rows == 3)
			{
				for (int i = 0; i < data.Length; i++)
				{
					int value = (int)((data[i] - min) * 25.0f / (max - min));
					if (value > 24) value = 24;
					if (value < 0) value = 0;
					if (value == 0)
					{
						output[0] += " ";
						output[1] += " ";
						output[2] += " ";
					}
					if (value > 0 && value < 9)
					{
						output[0] += " ";
						output[1] += " ";
						output[2] += "$Chr(" + (value - 1) + ")";
					}
					if (value >= 9 && value < 17)
					{
						output[0] += " ";
						output[1] += "$Chr(" + (value - 9) + ")";
						output[2] += "$Chr(7)";
					}

					if (value >= 17)
					{
						output[0] += "$Chr(" + (value - 17) + ")";
						output[1] += "$Chr(7)";
						output[2] += "$Chr(7)";
					}
				}
			}

			if (rows == 4)
			{
				for (int i = 0; i < data.Length; i++)
				{
					int value = (int)((data[i] - min) * 33.0f / (max - min));
					if (value > 32) value = 32;
					if (value < 0) value = 0;
					if (value == 0)
					{
						output[0] += " ";
						output[1] += " ";
						output[2] += " ";
						output[3] += " ";
					}
					if (value > 0 && value < 9)
					{
						output[0] += " ";
						output[1] += " ";
						output[2] += " ";
						output[3] += "$Chr(" + (value - 1) + ")";
					}
					if (value >= 9 && value < 17)
					{
						output[0] += " ";
						output[1] += " ";
						output[2] += "$Chr(" + (value - 9) + ")";
						output[3] += "$Chr(7)";
					}

					if (value >= 17 && value < 25)
					{
						output[0] += " ";
						output[1] += "$Chr(" + (value - 17) + ")";
						output[2] += "$Chr(7)";
						output[3] += "$Chr(7)";
					}

					if (value >= 25)
					{
						output[0] += "$Chr(" + (value - 25) + ")";
						output[1] += "$Chr(7)";
						output[2] += "$Chr(7)";
						output[3] += "$Chr(7)";
					}
				}
			}

			return output;

		}

		int graphIndex(string name)
        {
			for (int i = 0; i < graphs.Count; i++)
            {
				if (graphs[i].name == name) return i;
            }
			return -1;
        }

		class graph
        {
			public graph()
            {
				columns = 1;
				rows = 1;
				min = 0;
				max = 100;
				sampleTime = 8;
				name = "";
				pendingUpdate = false;
			}
			public int[] data;
			public int columns; //16
			public int rows; //4
			public int min;
			public int max;
			public int sampleTime;
			public bool pendingUpdate;
			public string name;
		}

		List<graph> graphs = new List<graph>();
		graph currGraph;



		// This function is used in LCDSmartie by using the dll command as follows:
		//    $dll(vbdotnetplugin,1,hello,there)
		// Smartie will then display on the LCD: function called with (hello, there)
		public string function1(string param1, string param2)
		{
			milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

			string[] parameters = param1.Split('#');
			columns = strtoint(parameters[0].Split('x')[1]);
			rows = strtoint(parameters[0].Split('x')[0]);
			sampleTime = strtoint(parameters[1]);
			min = strtoint(parameters[2]);
			max = strtoint(parameters[3]);


			currValue = strtoint(parameters[4]);

			currIndex = graphIndex(param2);
			if(currIndex == -1)
            {
				currGraph = new graph();
				graphs.Add(currGraph);
            }
            else
            {
				currGraph = graphs[currIndex];
            }
			 

			if(columns != currGraph.columns || rows != currGraph.rows || sampleTime != currGraph.sampleTime || min!= currGraph.min || max!= currGraph.max)
            {
				currGraph.data = new int[columns];
				foreach(int i in currGraph.data) currGraph.data[i] = 0;
				currGraph.columns = columns;
				currGraph.rows = rows;
				currGraph.min = min;
				currGraph.max = max;
				currGraph.sampleTime = sampleTime;
				currGraph.name = param2;
			}




			if ((milliseconds - lastmilliseconds) > currGraph.sampleTime * 100)
            {
				lastmilliseconds = milliseconds;
				foreach (graph G in graphs) G.pendingUpdate = true;
            }

			if(currGraph.pendingUpdate)
            {
				updateArray(ref currGraph.data, currValue);
				currGraph.pendingUpdate = false;
			}

			return charDef + outputArray(currGraph.data, currGraph.rows)[0];

		}

		// This function is used in LCDSmartie by using the dll command as follows:
		//    $dll(vbdotnetplugin,2,hello,there)
		// Smartie will then display on the LCD: c#
		public string function2(string param1, string param2)
		{
			currIndex = graphIndex(param1);
			if (currIndex == -1)
			{
				return "";
			}
			else
			{
				currGraph = graphs[currIndex];
			}

			if (rows == 1) return "";
			if (rows == 2) return outputArray(currGraph.data, currGraph.rows)[1];
			if (rows == 3)
            {
				if (param2 == "2") return outputArray(currGraph.data, currGraph.rows)[1];
				if (param2 == "1") return outputArray(currGraph.data, currGraph.rows)[2];
			}
			if (rows == 4)
			{
				if (param2 == "3") return outputArray(currGraph.data, currGraph.rows)[1];
				if (param2 == "2") return outputArray(currGraph.data, currGraph.rows)[2];
				if (param2 == "1") return outputArray(currGraph.data, currGraph.rows)[3];
			}
			return "";
		}

		//
		// Define the minimum interval that a screen should get fresh data from our plugin.
		// The actual value used by Smartie will be the higher of this value and of the "dll check interval" setting
		// on the Misc tab.  [This function is optional, Smartie will assume 300ms if it is not provided.]
		// 
		public int GetMinRefreshInterval()
		{
			return 300; // 300 ms (around 3 times a second)
		}

	}





}
