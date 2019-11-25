using System;
using System.Globalization;
//using MySql.Data.MySqlClient;

namespace OrderSushi
{
    public class Messager : Sushi
    {
        public string messageBot { get; set; }
        public string messageUser { get; set;}

        public string messageBotErr { get; set; }
        public string userName { get; set; }

        const string botName = "Natalya";
        
        const System.ConsoleColor colorBot = ConsoleColor.Green;
        const System.ConsoleColor colorUser = ConsoleColor.Red;
        const System.ConsoleColor colorErr = ConsoleColor.Red;
        const System.ConsoleColor backgroundColorDefault = ConsoleColor.White;

        public void WriteMessageBot()
        {
            Console.ForegroundColor = colorBot;
            Console.WriteLine($"{ botName }: \n {this.messageBot}");
        }
        public void WriteMessageBotErr()
        {
            Console.ForegroundColor = colorBot;
            Console.WriteLine($"{botName}:");
            //Console.BackgroundColor = colorErr;
            Console.WriteLine(this.messageBotErr);
            Console.BackgroundColor = backgroundColorDefault;
        }
        public void ReadMessageUser()
        {
            Console.ForegroundColor = colorUser;
            Console.WriteLine("You:");
            this.messageUser = Console.ReadLine();
        }
        public void Welcome()
        {
            string solution = "What's your name?";
            this.messageBot = solution;
            int currentHour = DateTime.Now.Hour ;
            string solutionTime;
            if (currentHour >= 5 && currentHour < 12) solutionTime = "Good morning!"+ solution;
            else if (currentHour >= 12 && currentHour < 18) solutionTime =  "Good afternoon!"+ solution; 
            else if (currentHour >= 18 && currentHour < 22) solutionTime = "Good evenig!"+ solution; 
            else  
            solutionTime = $"Good night! {solution}";
            this.messageBot = solutionTime;
            WriteMessageBot();
        }
        public void ReadName()
        {
            string name;
            bool nameOk = false;
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            do
            {
                Console.ForegroundColor = colorUser;
                Console.WriteLine("You:");
                name = ti.ToTitleCase(Console.ReadLine());
                name = name.Trim();

            if (name == "" || name.Length < 2)
            {
                this.messageBotErr = $"Sorry, but you didn’t introduce yourself. What's your name?";
                WriteMessageBotErr();
            }
            if (name != "" && name.Length >= 2)
            {
                for (int i = 0; i < name.Length; i++ )
                {
                    if (Char.IsLetter(name, i) == false) 
                    {
                        this.messageBotErr = $"I'm sorry, but you misrepresented yourself. What's your name?";
                        WriteMessageBotErr();
                        break;
                    }
                    if (i == name.Length -1) {nameOk = true;}
                }
            }
            }
            while (nameOk == false);
            this.userName = name;
        }

        public string OrderRequest()
        {
            messageBot = $"{this.userName}, do you want to order sushi is {this.SushiList}?";
            WriteMessageBot();
            ReadMessageUser();
            string order = FindingMatches(this.messageUser , this.SushiList);

            return  order;
        }
            public string FindingMatches(string wordSearch, string[] words)
            {
                int ws ;
                int maxLength = 0;
                int minLength = 0;
                double[] similaratyPercent = new double[words.Length];
                int[] similaraty = new int[words.Length];
                
                for (ws = 0; ws < words.Length; )
                {
                    int wss = 0;
                    int wssS = 0;
                    String[] wordsSplit = words[ws].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
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
                    similaratyPercent[ws] =Convert.ToDouble(similaraty[ws]) / Convert.ToDouble(maxLength) ;
                    Console.WriteLine(similaratyPercent[ws]);
                    ws ++;
                }
                double maxVal = MaxValue(similaratyPercent);
                int indexMax = Array.FindIndex(similaratyPercent, x => x == maxVal);
                return words[indexMax];
            }
           public double MaxValue(double[] value)
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
