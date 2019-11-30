using System;
using System.Globalization;
using System.Drawing;


namespace OrderSushi
{
	public class Messager :  Sushi
	{
		public string messageBot { get; set; }
		public string messageUser { get; set;}
		public string messageBotErr { get; set; }
		public string userName { get; set; }
		public int quantitySushi{ get; set; }
		const string botName = "Natalya";

		public const int maxSushiOrder = 50;

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
			//Console.BackgroundColor = backgroundColorDefault;
		}
		public void ReadMessageUser()
		{
			Console.ForegroundColor = colorUser;
			Console.WriteLine("You:");
			this.messageUser = Console.ReadLine().ToLower();
		}
		public void Welcome()
		{
			string solution = "";
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
			this.messageBot = "What's your name?";
			WriteMessageBot();
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
			string order;
			bool orderOk = false;
			do
			{
				GetSetSushilist();
				messageBot = $"{this.userName}, do you want to order sushi is: \n ";
				WriteMessageBot();
				PrintSushiList();
				ReadMessageUser();
				order = Searcher.FindingMatches(this.messageUser , this.SushiList);
				this.SushiName = order;
				GetSushiInfo();
				this.messageBot =$"You want order to {order} (yes or no)? ";
				WriteMessageBot ();
				PrintSushiInfo();
				while (messageUser != "yes" || messageUser != "no")
				{
					ReadMessageUser();
					if (messageUser == "yes")
					{
						this.messageBot = "please enter the quantity of selected sushi";
						WriteMessageBot();
						quantitySushi =  ReadNum();
						this.messageUser = "no";
					}
					if (messageUser == "no")
					{
						this.messageBot = "do you want to order more sushi (yes or no) ?";
						WriteMessageBot();
						while (messageUser != "yes" )
						{
							ReadMessageUser();
							if (messageUser == "yes")
							{ break; }
							if (messageUser == "no")
							{ System.Environment.Exit(1);}
							else { WriteErrAnswerYesNo(); }
						}
						if (messageUser == "yes") {break;}
					}
					else { WriteErrAnswerYesNo();}
				}
			}
			while (orderOk == false );
			return  order;
		}
		public int ReadNum()
		{
			string num;
			bool numOk = false;
			do
			{
				ReadMessageUser();
				num = messageUser;
				if (num.Trim( ) == "")
				{
					this.messageBotErr = $"You didn't enter anythin, {messageBot}";
					WriteMessageBotErr();
				}

				else
				{
					for (int i = 0; i < num.Length; i++ )
					{
						if (Char.IsDigit(num[i]) != true )
						{
							this.messageBotErr = $"Incorrect format of the specified number, { messageBot }";
							WriteMessageBotErr();
							break;
						}
						if (i == num.Length-1 ) {numOk = true;}
					}
				}
			}
			while (numOk == false);
			return Convert.ToInt32(num);
		}
		public void PrintSushiList()
		{
			string[] List = SushiList.TrimEnd(';').Split(new string[] { ";" }, StringSplitOptions.None);
			for (var i = 0; i < List.Length; i++) 
			{
				this.messageBot = $"{i+1} {List[i]}";
				Console.WriteLine(messageBot);
			}
		}
		public void PrintSushiInfo()
		{
			string[] List = SushiInfo.TrimEnd(';').Split(new string[] { ";" }, StringSplitOptions.None);
			int[] dote = new int[List.Length];
			string[] dotes = new string[List.Length];
			for (int i = 0; i < List.Length; i++) 
			{
				dote [i] = (30 - List[i].Length);
				for (var x = 0; x < dote[i]; x++)
				{
					dotes[i] += ".";
				}
				switch (i)
				{
				case 0:
					this.messageBot = $"Price {dotes[i]} {List[i]}";
					Console.WriteLine(messageBot);
					break;
				case 1:
					this.messageBot = $"Weight {dotes[i]} {List[i]}";
					Console.WriteLine(messageBot);
					break;
				case 2:
					this.messageBot = $"Description:\n {List[i]}";
					Console.WriteLine(messageBot);
					break;
				}
			}
		}
		public void WriteErrAnswerYesNo()
		{
			this.messageBotErr = "I'm sorry, but you have to give a clear answer: Yes or no!";
			WriteMessageBotErr();
		}
	} 
}
