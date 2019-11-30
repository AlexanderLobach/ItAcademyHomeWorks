using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Drawing;
using System.IO;

namespace OrderSushi
{
	public class GetSetSqlData 
		{
		public string sqlRequest { get; set; }
		public string stringSqlData  { get; set; }
		public string dataArrString { get; set; }
		const string connStr = "server=localhost;user=root;database=sushi_bot;password=mnenie;";
		public const string nameSqlSushiList = "sushi_list";
		public const string nameSqlOrderList = "order_list";
		public const string nameSqlСlientList = "client_list";


		public void  GetSqlData()
		{
			// строка подключения к БД
			// создаём объект для подключения к БД
			MySqlConnection conn = new MySqlConnection(connStr);
			// устанавливаем соединение с БД
			conn.Open();
			// запрос
			// объект для выполнения SQL-запроса
			MySqlCommand command = new MySqlCommand(sqlRequest, conn);
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
			MySqlConnection conn = new MySqlConnection(connStr);
			conn.Open();
			MySqlCommand command = new MySqlCommand(sqlRequest, conn);
			MySqlDataReader reader = command.ExecuteReader();
			this.dataArrString = null;
			while (reader.Read())
			{
				for (var i = 0; i < reader.FieldCount; i++)
					{
					this.dataArrString += String.Format ("{0};", reader [i]);
					}
			}
			reader.Close();
			conn.Close();
		}
		public static void SavePicture()
		{
			MySqlConnection conn = new MySqlConnection(connStr);
			conn.Open();
			MySqlCommand sqlCommand = new MySqlCommand("SELECT sushi_view FROM sushi_list WHERE sushi_id = 1", conn);
			MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				MemoryStream memoryStream = new MemoryStream();
				foreach(DbDataRecord record in sqlDataReader)
					memoryStream.Write((byte[])record["sushi_view"], 0, ((byte[])record["sushi_view"]).Length);
				Image image = Image.FromStream(memoryStream);
				image.Save(@"1.jpg");
				memoryStream.Dispose();
				image.Dispose();
			}
			else
				Console.WriteLine("Пустая выборка");
			conn.Close();
		}
		public void CreateOrder()
		{

		}
	}
}

