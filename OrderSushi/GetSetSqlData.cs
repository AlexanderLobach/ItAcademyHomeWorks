using System;
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
		const string connStr = "server=localhost;user=root;database=sushi_bot;password=mnenie;";
		public const string nameSqlGoodsList = "sushi_list";
		public const string nameSqlOrderList = "orders";
		public const string nameSqlOrderID = "order_id";
		public const string nameSqlOrderDate = "order_date";
		public const string nameSqlGoodsID = "sushi_id";
		public const string nameSqlGoodsViev = "sushi_view";
		public const string nameSqlGoodsOrders = "goods_orders";
		public const string nameSqlGoodsQuantity = "quantity_goods";
		public const string nameSqlShippingAddress = "shipping_address";
		public const string nameSqlСlientList = "clients";
		public const string nameSqlСlienName = "client_name";
		public const string nameSqlClientsData = "clients_data";
		public const string nameSqlClientID = "client_id";
		public const string nameSqlClientDataID = "client_data_id";
		public const string nameSqlClientTell = "client_tell";
		public const string nameSqlClientEmail = "client_email";
		public const string nameSqlClientAddress = "client_address";
		public const string nameSqlOrderAmount = "amount";
		public const string nameSqlOrderShippigAddress = "shipping_address";
		public const string nameSqlOrderStatus = "order_status";
		protected const string bodypuss = "huizqwrifvvgptsq";

		public int quantitySushi { get; set; }
		public double orderAmount { get; set; }
		public int CurrentIDOrder { get; set; }
		public int CurrentIDSushi { get; set; }
		public int CurrentIDClient { get; set; }
		public int CurrentClientDataID { get; set; }
		public int sqlLastID { get; set; }
		public string SushiName { get; set; }
		public string SushiInfo { get; set; }
		public string SushiList { get; set; }
		public string DeliveryAddress { get; set; }
		public string ClientEmail { get; set; }
		public string ClientNumberPhone { get; set; }
		public string ClientName { get; set; }
		public string sqlRequest { get; set; }
		public string stringSqlData  { get; set; }
		public string dataArrString { get; set; }
		public string dataOrder { get; set; }
		internal int presenceClientEmail{ get; set; }


		public void  GetSqlData()
		{
			MySqlConnection conn = new MySqlConnection(connStr);
			conn.Open();
			MySqlCommand command = new MySqlCommand(sqlRequest, conn);
			string data = command.ExecuteScalar().ToString();
			this.stringSqlData = data;
			conn.Close();
		}
		public void GetSqlArray()
		{
			MySqlConnection conn = new MySqlConnection(connStr);
			conn.Open();
			MySqlCommand sqlCommand = new MySqlCommand(sqlRequest, conn);
			MySqlDataReader reader = sqlCommand.ExecuteReader();
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
		public void SaveSqlPicture(int numPicture)
		{
			MySqlConnection conn = new MySqlConnection(connStr);
			conn.Open();
			MySqlCommand sqlCommand = new MySqlCommand(sqlRequest, conn);
			MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			
			if (sqlDataReader.HasRows)
			{
				MemoryStream memoryStream = new MemoryStream();
				foreach(DbDataRecord record in sqlDataReader)
				
				{
					int i = 0;
					memoryStream.Write((byte[])record[nameSqlGoodsViev], 0, ((byte[])record[nameSqlGoodsViev]).Length);
					Image image = Image.FromStream(memoryStream);
					image.Save(@$"{numPicture}.jpg");
					memoryStream.Dispose();
					image.Dispose();
					i++;
				}
				
			}
			else
				Console.WriteLine("A blank sample");
			conn.Close();
			sqlDataReader.Close();
		}
		public void InsertSqlData()
		{
				MySqlConnection conn = new MySqlConnection(connStr);
				conn.Open();
				MySqlCommand sqlCommand = new MySqlCommand(sqlRequest, conn);
				this.sqlLastID = Convert.ToInt16(sqlCommand.ExecuteScalar());
			conn.Close();
		}
		public void InsertSqlClientsData()
		{
				MySqlConnection conn = new MySqlConnection(connStr);
				conn.Open();
				MySqlCommand sqlCommand = new MySqlCommand(sqlRequest, conn);
				sqlCommand.Parameters.Add("?ClientNumberPhone", MySqlDbType.VarChar).Value = ClientNumberPhone;
				sqlCommand.Parameters.Add("?ClientEmail", MySqlDbType.VarChar).Value = ClientEmail;
				sqlCommand.Parameters.Add("?DeliveryAddress", MySqlDbType.VarChar).Value = DeliveryAddress;
				this.sqlLastID = Convert.ToInt16(sqlCommand.ExecuteScalar());
				conn.Close();
		}
		public void InsertSqlClientList()
		{
				MySqlConnection conn = new MySqlConnection(connStr);
				conn.Open();
				MySqlCommand sqlCommand = new MySqlCommand(sqlRequest, conn);
				sqlCommand.Parameters.Add("?ClientName", MySqlDbType.VarChar).Value = ClientName;
				this.sqlLastID = Convert.ToInt16(sqlCommand.ExecuteScalar());
				conn.Close();
		}
		public void UpdateSqlOrders()
		{
			MySqlConnection conn = new MySqlConnection(connStr);
			conn.Open();
			MySqlCommand sqlCommand = new MySqlCommand(sqlRequest, conn);
			sqlCommand.Parameters.Add("?orderAmount", MySqlDbType.Double).Value = orderAmount;
			sqlCommand.Parameters.Add("?DeliveryAddress", MySqlDbType.VarChar).Value = DeliveryAddress;
			sqlCommand.Parameters.Add("?Taken", MySqlDbType.VarChar).Value = "Taken";
			this.sqlLastID = Convert.ToInt16(sqlCommand.ExecuteScalar());
			conn.Close();
		}
	}
}