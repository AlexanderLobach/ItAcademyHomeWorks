using System;

namespace OrderSushi
{
	public class Sushi : GetSetSqlData
	{
		public string userName { get; set; }
		public int quantitySushi{ get; set; }
		public int CurrentIDOrder{ get; set; }
		public int CurrentIDSushi{ get; set; }
		public string SushiName { get; set; }
		public string SushiInfo { get; set; }
		public string SushiList { get; set; }


		public void GetSetSushilist()
		{
			this.sqlRequest = $"SELECT sushi_name FROM {nameSqlSushiList} WHERE sushi_id is not NULL";
			GetSqlArray ();
			this.SushiList = dataArrString;
		}

		public void GetSushiInfo()
		{
			this.sqlRequest = $"SELECT sushi_id, sushi_price, sushi_weight, sushi_description FROM {nameSqlSushiList} WHERE sushi_name = '{SushiName}'";
			GetSqlArray ();
			this.SushiInfo = dataArrString;
		}

		public void CreateOrders()
		{
			this.sqlRequest = $"INSERT INTO `orders`(`client_id`, `order_date`, `amount`, `order_status`) VALUES (1,UTC_TIMESTAMP(), 0 ,'Open');" +
				"SELECT LAST_INSERT_ID();";
			this.CurrentIDOrder = InsertSqlData();
		}
		public void AddGoods()
		{
			this.sqlRequest = $"INSERT INTO `goods_orders`(`order_id`, `sushi_id`, `quantity_goods`) VALUES ({CurrentIDOrder}, {CurrentIDSushi}, {quantitySushi});";
			InsertSqlData();
		}
	}
}
