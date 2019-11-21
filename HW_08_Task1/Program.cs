using System;
using System.Globalization;

namespace HW_08_Task1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Messager message = new Messager();
            message.Welcome();
            message.GetSetDataPassenger();
            message.CheckIn();
            message.InspectionSequrity();
            message.PassportControl();
        }
    }
}
