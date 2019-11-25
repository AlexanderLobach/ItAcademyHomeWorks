using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace OrderSushi
{
	public class GetSetSqlData 
		{
		public string sql { get; set; }
		public string stringSqlData  { get; set; }
		public string dataArrString { get; set; }
		const string connStr = "server=localhost;user=root;database=sushi_bot;password=mnenie;";
		public const string nameSqlMenuList = "sushi_list";
		public const string nameSqlOrderList = "order_list";
		public const string nameSqlСlientList = "client_list";
		//public string nameSqlIDOrder = 

		public void  GetSqlData()
		{
			// строка подключения к БД
			// создаём объект для подключения к БД
			MySqlConnection conn = new MySqlConnection(connStr);
			// устанавливаем соединение с БД
			conn.Open();
			// запрос
			// объект для выполнения SQL-запроса
			MySqlCommand command = new MySqlCommand(sql, conn);
			// выполняем запрос и получаем ответ
			string name = command.ExecuteScalar().ToString();
			// выводим ответ в консоль
			Console.WriteLine(name); 
			this.stringSqlData = name;
			// закрываем соединение с БД
			conn.Close();
			//return name;
		}
		public void GetSqlArray()
		{
			// строка подключения к БД
			// создаём объект для подключения к БД
			MySqlConnection conn = new MySqlConnection(connStr);
			// устанавливаем соединение с БД
			conn.Open();
			// запрос
			// объект для выполнения SQL-запроса
			MySqlCommand command = new MySqlCommand(sql, conn);
			// объект для чтения ответа сервера
			MySqlDataReader reader = command.ExecuteReader();
			// читаем результат
			this.dataArrString = null;
			while (reader.Read())
			{
				// элементы массива [] - это значения столбцов из запроса SELECT
				this.dataArrString += String.Format ("{0},", reader [0]);
				//Console.WriteLine(dataArrString);
			}
			reader.Close(); // закрываем reader
			// закрываем соединение с БД
			conn.Close();
		}
	}
}

