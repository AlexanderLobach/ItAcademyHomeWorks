using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Globalization;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace OrderSushi
{
	public class Messager :  Sushi
	{
		public double currentPrice { get; set; }
		public string messageBot { get; set; }
		public string messageUser { get; set;}
		public string messageBotErr { get; set; }
		public string userName { get; set; }
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
			this.messageUser = Console.ReadLine();
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
			this.ClientName = userName;
		}

		public void OrderRequest()
		{
			string order;
			bool orderOk = false;
			int y = 0;
			do
			{
				GetSetSushilist();
				messageBot = $"{this.userName}, do you want to order sushi is: \n ";
				WriteMessageBot();
				PrintSushiList();
				ReadMessageUser();
				order = Searcher.FindingMatches( messageUser, SushiList );
				if (order == "little coincidence")
				{
					this.messageBotErr = "I'm sorry, but you entered a strange query";
					WriteMessageBotErr();
				}
				else
				{
				this.SushiName = order;
				GetSushiInfo();
				this.messageBot =$"You want order to {order} (yes or no)? ";
				WriteMessageBot ();
				PrintSushiInfo();
				while (messageUser.ToLower() != "yes" )
				{
					ReadMessageUser();
					if (messageUser.ToLower() == "yes")
					{
						this.messageBot = "please enter the quantity of selected sushi";
						WriteMessageBot();
						this.quantitySushi =  ReadNum();
						if (quantitySushi > 0 && y > 0)
						{
							this.orderAmount += quantitySushi * currentPrice ;
							InsertGoodsOrders();
						}
						if (quantitySushi > 0 && y == 0)
						{
							this.orderAmount = quantitySushi * currentPrice ;
							CreateOrder();
							InsertGoodsOrders();
							y++;
						}
						this.messageUser = "no";
						if (messageUser.ToLower() == "no")
						{
						this.messageBot = "do you want to order more sushi (yes or no) ?";
						WriteMessageBot();
						while (messageUser.ToLower() != "yes" )
						{
							ReadMessageUser();
							if (messageUser.ToLower() == "yes")
							{ break; }
								if (messageUser.ToLower() == "no" && y == 0 )
							{ System.Environment.Exit(1);}
								if (messageUser.ToLower() == "no" && y > 0 )
								{
									orderOk = true;
									break;
								}
							else { WriteErrAnswerYesNo(); }
						}
						if (messageUser.ToLower() == "yes") {break;}
							if ( orderOk == true ) { break; }
					}
					else { WriteErrAnswerYesNo();}
					}
						else if ( messageUser.ToLower() == "no" ){ break; }
						else { WriteErrAnswerYesNo(); break; }
				}
			}
		}
			while (orderOk == false );
			AddClientData();
			PrintOrderInfo();
			SendTheEmail ();
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

		public string ReadNumPhone()
		{
			string numPhone;
			bool numPhoneOk = false;
			do
			{
			ReadMessageUser ();
			numPhone = messageUser;
				if (numPhone.Trim( ) == "")
				{
					this.messageBotErr = $"You didn't enter anythin, {messageBot}";
					WriteMessageBotErr();
				}
				else if (numPhone[0] != '+' )
				{
					this.messageBotErr = $"Phone number entered incorrectly, {messageBot}";
					WriteMessageBotErr(); 
				}
				else if (numPhone.Length < 13)
				{
					this.messageBotErr = $"Phone number entered incorrectly, {messageBot}";
					WriteMessageBotErr();
				}

				else
				{
					{
						for (int i = 1; i < numPhone.Length; i++ )
						{
							if (Char.IsDigit(numPhone[i]) != true )
							{
								this.messageBotErr = $"Phone number entered incorrectly, { messageBot }";
								WriteMessageBotErr();
								break;
							}
							if (i == numPhone.Length-1 ) {numPhoneOk = true;}
						}
					}
				}
			}
			while( numPhoneOk == false );
			return numPhone;
		}
		public string ReadEmailAddress()
		{

			string emailAddress;
			bool emailAddressOk = false;
				do 
			{
				ReadMessageUser ();
				emailAddress = messageUser;
				int pozAt = emailAddress.IndexOf('@');
				if (emailAddress.Trim( ) == "")
				{
					this.messageBotErr = $"You didn't enter anythin, {messageBot}";
					WriteMessageBotErr();
				}
				else if (pozAt < 1 || pozAt == emailAddress.Length-1)
				{ 
					this.messageBotErr = $"{userName}, you entered an incorrect e-mail address.\nPlease enter the correct e-mail address.";
					WriteMessageBotErr();
				}
				else
				{ emailAddressOk = true; break; }
			} 
			while(emailAddressOk == false);
					return emailAddress;
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
			this.CurrentIDSushi = Convert.ToInt32(List[0]);
			this.currentPrice = Convert.ToDouble(List[1]);
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
				case 1:
					this.messageBot = $"Price. {dotes[i]} {List[i]}";
					Console.WriteLine(messageBot);
					break;
				case 2:
					this.messageBot = $"Weight {dotes[i]} {List[i]}";
					Console.WriteLine(messageBot);
					break;
				case 3:
					this.messageBot = $"Description:\n{List[i]}";
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

		public void AddClientData()
		{
			this.messageBot = $"{userName}, please provide shipping address or pickup";
			WriteMessageBot();
			ReadMessageUser();
			this.DeliveryAddress = messageUser;
			this.messageBot = $"{userName}, please enter your e-mail";
			WriteMessageBot();
			this.ClientEmail = ReadEmailAddress();
			this.messageBot = $"To complete the order, you must provide your phone number in the format +12345678910";
			WriteMessageBot();
			this.ClientNumberPhone = ReadNumPhone();
			SqlAddClientData();
			UpdateOrder();
		}

		public void PrintOrderInfo()
		{
			OrderCheck();
			this.messageBot = $"{userName}, please check your order...";
			WriteMessageBot();
			string[] List = dataOrder.TrimEnd(';').Split(new string[] { ";" }, StringSplitOptions.None);
			this.messageBot = String.Format("{0, 3} {1, 20} {2, 10} {3,10} {4, 10}\n", "№", "Goods", "Weight", "Price", "Quantity");
			Console.WriteLine(messageBot);
			int y = 0;
			int x = 0;
			double amounth = 0;
			for (var i = 0; i < List.Length/4; i++)
			{
				x = i + y;
				this.messageBot = String.Format("{0, 3} {1, 20} {2, 10} {3,10} {4, 10}", i+1,  List[x],  List[x+1],  List[x+2], List[x+3]);
				Console.WriteLine(messageBot);
				y = y+3;
				amounth += Convert.ToDouble (List [x + 2]) * Convert.ToDouble (List [x + 3]);
				if (i == List.Length/4 - 1)
				{
					this.messageBot = "\namounth" + String.Format ("{0, 50:C}", amounth);
					Console.WriteLine (messageBot);
				}
			}
		}

		public void SendTheEmail ()
		{
			var client = new SmtpClient("smtp.yandex.ru", 465);
			client.UseDefaultCredentials =false;
			MailAddress from = new MailAddress("ordersushi@ya.ru", "Alex");
			MailAddress to = new MailAddress("375296255246@ya.ru", "Pedro");
			MailMessage message = new MailMessage(from, to); 
			message.Subject = "Test";
			message.Body = "Email-test of the smtp client's work";
			message.IsBodyHtml = true;
			client.EnableSsl = true;
			client.DeliveryMethod = SmtpDeliveryMethod.Network;
			client.Credentials = new NetworkCredential("ordersushi", "huizqwrifvvgptsq");
			try
			{
				client.Send(message);
				Console.WriteLine("Message send");
				Console.ReadLine();
			}
			catch (Exception exc)
			{
				Console.WriteLine("Could not send e-mail. Exception caught: " + exc);
			}
			finally
			{
				client.Dispose();
			}
		}
	} 
}

