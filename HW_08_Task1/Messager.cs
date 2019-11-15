using System;
using System.Globalization;

namespace HW_08_Task1
{
    public class Messager : Passenger
    {
        public string messageBot { get; set; }
        public string messageUser { get; set;}

        public string messageBotErr { get; set; }
         string passNumFormat = "SS12345678";

        const System.ConsoleColor colorBot = ConsoleColor.Green;
        const System.ConsoleColor colorUser = ConsoleColor.Red;
        const System.ConsoleColor colorErr = ConsoleColor.Red;
        const System.ConsoleColor backgroundColorDefault = ConsoleColor.White;

        public void WriteMessageBot()
        {
            Console.ForegroundColor = colorBot;
            Console.WriteLine(this.messageBot);
        }
        public void WriteMessageBotErr()
        {
            Console.ForegroundColor = colorBot;
            Console.BackgroundColor = colorErr;
            Console.WriteLine(this.messageBotErr);
            Console.BackgroundColor = backgroundColorDefault;
        }
        public void ReadMessageUser()
        {
            Console.ForegroundColor = colorUser;
            this.messageUser = Console.ReadLine();
        }
        public void Welcome()
        {
            string solution = "\nWelcome to Minsk international airport.\nPlease, introduce yourself!";
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
        public string  ReadName()
        {
            string name;
            bool nameOk = false;
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            do
            {
                Console.ForegroundColor = colorUser;
                name = ti.ToTitleCase(Console.ReadLine());

            if (name.Trim( ) == "")
            {
                this.messageBotErr = $"You didn't enter anythin, {this.messageBot}";
                WriteMessageBotErr();
            }
            if (name.Trim() != "")
            {
                for (int i = 0; i < name.Length; i++ )
                {
                    if (Char.IsLetter(name, i) == false) 
                    {
                        this.messageBotErr = $"You have entered forbidden characters, {this.messageBot}";
                        WriteMessageBotErr();
                        break;
                    }
                    if (i == name.Length -1) {nameOk = true;}
                }
            }
            }
            while (nameOk == false);
            return name;
        }

            public string ReadPassNum()
        {
            string passNum;
            bool nameOk = false;
            do
            {
                Console.ForegroundColor = colorUser;
                passNum = (Console.ReadLine()).ToUpper();

            if (passNum.Trim( ) == "")
            {
                this.messageBotErr = $"You didn't enter anythin, {this.messageBot}";
                WriteMessageBotErr();
            }
            else if (passNum.Length != passNumFormat.Length)
            {
                this.messageBotErr = $"You entered an invalid number format, {this.messageBot}";
                WriteMessageBotErr();
            }
            if (passNum.Length == passNumFormat.Length)
            {
                for (int i = 0; i < passNum.Length; i++ )
                {
                    if (CharUnicodeInfo.GetUnicodeCategory(passNum[i]) != CharUnicodeInfo.GetUnicodeCategory(passNumFormat[i]))
                    {
                        this.messageBotErr = $"Incorrect format of the specified number, {this.messageBot}";
                        WriteMessageBotErr();
                        break;
                    }
                    if (i == passNum.Length -1) {nameOk = true;}
                }
            }
            }
            while (nameOk == false);
            return passNum;
        }

            public  void GetSetDataPassenger()
        {
            //Passenger passenger = new Passenger();
            this.messageBot = "enter your firstname:";
            WriteMessageBot();
            this.firstName = ReadName();
            this.messageBot = "enter your patronumic:";
            WriteMessageBot();
            patronumic = ReadName();
            this.messageBot = "enter your lastname:";
            WriteMessageBot();
            this.lastName = ReadName();
            this.messageBot = $"{ firstName } { patronumic }, please enter your passport number in format: {passNumFormat}";
            WriteMessageBot();
            this.passNumber = ReadPassNum();
            this.messageBot = $"{ firstName } { patronumic } go to the front desk...";
            WriteMessageBot();
        }
        public  void CheckIn()
        {
            string messageUser;
            messageBot = $"{ firstName } { patronumic } you have registered via the Internet? (yes or no)";
            WriteMessageBot();
            Boolean registeredOk = false;
            do
            {
            ReadMessageUser();
            messageUser = this.messageUser;
            if ( messageUser == "yes" || messageUser == "Yes")
            {
                messageBot = $"{ firstName } { patronumic }, please present your online registration receipt";
                WriteMessageBot();
                registeredOk = true;
            }
            else if (messageUser == "no" || messageUser == "No")
            {
                messageBot = $"{ firstName } { patronumic }, please show your passport and ticket";
                WriteMessageBot();
                registeredOk = true;
            }
            else 
            {
                messageBotErr = "invalid response format, try again (yes or no)";
                WriteMessageBotErr();
            }
            }
            while (registeredOk == false);
            messageBot = "Please, go through security...";
            WriteMessageBot();
        }
        public void InspectionSequrity()
        {
            messageBot = $"{firstName} {patronumic}, do you have any prohibited items with you( yes or no )?";
            WriteMessageBot();
            bool inspectionSequrityOk = false;
            do
            {
                ReadMessageUser();
                if ( messageUser == "yes" || messageUser == "Yes")
            {
                messageBot = $"{ firstName } { patronumic }, please return all prohibited items to this cart...";
                WriteMessageBot();
                messageBot = $"{firstName} {patronumic}, do you have any other prohibited items left (yes or no)?";
                WriteMessageBot();
                inspectionSequrityOk = false;
            }
            else if (messageUser == "no" || messageUser == "No")
            {
                messageBot = $"{ firstName } { patronumic }, please proceed to the passport control area...";
                WriteMessageBot();
                inspectionSequrityOk = true;
            }
            else 
            {
                messageBotErr = "invalid response format, try again (yes or no)";
                WriteMessageBotErr();
            }
            
            }
            while (inspectionSequrityOk == false);
        }
        public void PassportControl()
        {
            messageBot = $" { firstName } { patronumic }, your passport and visa with you?";
            WriteMessageBot();
            bool passportControlOk = false;
            do
            {
                ReadMessageUser();
                if ( messageUser == "yes" || messageUser == "Yes")
            {
                messageBot = $"{ firstName } { patronumic }, provide your passport to the inspector for verification...";
                WriteMessageBot();
                messageBot = $"{ firstName } { patronumic },please go to the departure area. \n   Happy flight!";
                passportControlOk = true;
            }
            else if (messageUser == "no" || messageUser == "No")
            {
                messageBot = $"{ firstName } { patronumic }, you cannot be allowed to fly. For further assistance, contact the airport.";
                WriteMessageBot();
                passportControlOk = true;
            }
            else 
            {
                messageBotErr = "invalid response format, try again (yes or no)";
                WriteMessageBotErr();
            }
            }
            while (passportControlOk == false);

        }
    }
}
