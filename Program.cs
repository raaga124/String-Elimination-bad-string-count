
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Q3
{

	public class Program
	{
		public static void Main()
		{
			#region Reading input strings from file and storing them in an array
			//If you get a system.security exception for reading the input file in the mentioned path. Change your web config as mentioned here:
			// https://forums.asp.net/t/1422162.aspx

			List<string> inputItems = new List<string>();
			//replace 'fakepath' with the original path for the input file
			try
			{
				using (StreamReader file = new StreamReader(@"C:\Users\Sricharan\Desktop\Clevest\question03_input.txt"))
				{
					string line;
					while ((line = file.ReadLine()) != null)
					{
						string[] arr = line.Trim().Split(',');
						foreach (var item in arr)
						{
							inputItems.Add(item);
						}
					}
					
				}
				string[] fin_arr = inputItems.ToArray();

				#endregion

				int total = 0;
				bool repeat = false, final = false;
				Dictionary<string, int> dict = new Dictionary<string, int>();

				#region Iterate through the array with input strings

				foreach (string input in fin_arr)
				{
					int count = 0;

					//counting total number of vowels in the string.
					for (int i = 0; i < input.Length; i++)
					{
						if (input[i] == 'a' || input[i] == 'e' || input[i] == 'i' || input[i] == 'o' || input[i] == 'u')
						{
							count++;

						}
					}

					//vowel count should be atleast 3
					if (count >= 3)
					{
						//repeat is set to true if any repeated character exists(like dd, aa, cc)
						for (int i = 1; i < input.Length; i++)
						{
							if (input[i] == input[i - 1])
							{
								repeat = true;
							}
						}
					}

					//if a repeated character exists check for below strings in input.
					if (repeat)
					{
						var values = new[] { "ab", "cd", "pq", "xy" };
						final = values.Any(input.Contains);
						if (!final)
						{
							//Console.WriteLine("'"+input+"' is a good string");
							total++;
						}
					}
				}
				Console.WriteLine("Total number of good strings are:{0}", total);
				#endregion
			}
			catch (Exception e)
			{
				Console.WriteLine("{0} Exception caught.", e);
			}

		}
	}
}
