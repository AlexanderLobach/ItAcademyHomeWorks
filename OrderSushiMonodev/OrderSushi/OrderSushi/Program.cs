using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.Common;


namespace OrderSushi
{
	class Program
	{
		static void Main(string[] args)
		{
			Messager messager = new Messager();
			messager.Welcome();
			messager.ReadName();
			messager.OrderRequest();
		}
	}
}
