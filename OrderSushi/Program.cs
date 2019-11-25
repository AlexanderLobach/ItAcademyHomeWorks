using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace OrderSushi
{
    class Program
    {
        static void Main(string[] args)
        {
            Messager messager = new Messager();
            messager.Welcome();
            messager.ReadName();
            
            //messager.OrderRequest();
            //Console.WriteLine(messager.FindingMatches("maki", messager.SushiList));
            Console.WriteLine(messager.OrderRequest());
        }
    }
}
