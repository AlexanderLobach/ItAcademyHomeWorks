using System;

namespace OrderSushi
{
	public class Searcher 
	{
		const double minThresholdSearch = 0.5;
		const bool searchByIndex = true;

		public static string FindingMatches(string wordSearch , string words)
		{
			int ws ;
			int maxLength = 0;
			int minLength = 0;
			int indexWords;
			int indexWordsMax;
			string[] wordsList = words.Trim(';').Split(new char[] { ';' });
			double[] similaratyPercent = new double[wordsList.Length];
			int[] similaraty = new int[wordsList.Length];
			indexWordsMax = wordsList.Length;
			bool isNum = int.TryParse(wordSearch, out indexWords);
			if (searchByIndex == true && isNum == true && indexWords <= indexWordsMax) 
			{
				return wordsList[indexWords-1];
			}
			else
			for (ws = 0; ws < wordsList.Length; )
			{
				int wss = 0;
				int wssS = 0;
				String[] wordsSplit = wordsList[ws].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				String[] wordSearchSplit = wordSearch.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				for ( wss = 0 ; wss < wordsSplit.Length ;)
				{
					for (wssS = 0; wssS < wordSearchSplit.Length; )
					{
						if ( wordsSplit[wss].Length > wordSearchSplit[wssS].Length ) 
						{ minLength = wordSearchSplit[wssS].Length;}
						else minLength = wordsSplit[wss].Length;

						if ( wordsSplit[wss].Length < wordSearchSplit[wssS].Length ) 
						{ maxLength = wordSearchSplit[wssS].Length;}
						else maxLength = wordsSplit[wss].Length;

						for (int i = 0; i < minLength; )
						{
							if (wordSearchSplit[wssS][i] == wordsSplit[wss][i])
							{
								similaraty[ws] = similaraty[ws] +1;
							}
							i ++;
						}
						wssS ++;
					}
					wss ++;
				}
				similaratyPercent[ws] = Convert.ToDouble(similaraty[ws]) / Convert.ToDouble(maxLength) ;
				Console.WriteLine(similaratyPercent[ws]);
				ws ++;
			}
			double maxVal = MaxValue(similaratyPercent);
			if (maxVal < minThresholdSearch) 
			{
				return "little coincidence";
			} 
			else 
			{
				int indexMax = Array.FindIndex (similaratyPercent, x => x == maxVal);
				return wordsList [indexMax];
			}
		}

		public static double MaxValue(double[] value)
		{
			double maxValue = 0;
			for (int i = 0; i < value.Length ;)
			{
				if ( maxValue < value[i] ) { maxValue = value[i]; }
				i++;
			}
			return maxValue;
		}
	} 
}

