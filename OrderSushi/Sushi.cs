using System;

namespace OrderSushi
{
	public class Sushi : GetSetSqlData
	{

		public void GetSushiList()
		{
			this.sqlRequest = $"SELECT sushi_name FROM {nameSqlGoodsList} WHERE sushi_id is not NULL";
			GetSqlArray ();
			this.SushiList = dataArrString;
		}
		public void GetSushiInfo()
		{
			this.sqlRequest = $"SELECT sushi_id, sushi_price, sushi_weight, sushi_description FROM {nameSqlGoodsList} WHERE sushi_name = '{SushiName}'";
			GetSqlArray ();
			this.SushiInfo = dataArrString;
		}
		public void CreateOrder()
		{
			this.sqlRequest = $"INSERT INTO `{nameSqlOrderList}`(`{nameSqlClientID}`, `{nameSqlOrderDate}`, `{nameSqlOrderAmount}`) VALUES ( 1 , UTC_TIMESTAMP(), 0);" +
				"SELECT LAST_INSERT_ID();";
			InsertSqlData();
			this.CurrentIDOrder = sqlLastID;
		}
		public void InsertGoodsOrders()
		{
			this.sqlRequest = $"INSERT INTO `{nameSqlGoodsOrders}`(`{nameSqlOrderID}`, `{nameSqlGoodsID}`, `{nameSqlGoodsQuantity}`) VALUES ({CurrentIDOrder}, {CurrentIDSushi}, {quantitySushi});";
			InsertSqlData();
		}
				public void SqlAddClientData()
		{
			this.sqlRequest = $"INSERT INTO `{nameSqlClientsData}` (`{nameSqlClientTell}`, `{nameSqlClientEmail}`, `{nameSqlClientAddress}`) VALUES (?ClientNumberPhone, ?ClientEmail, ?DeliveryAddress);" +
				"SELECT LAST_INSERT_ID();";
			InsertSqlClientsData();
			this.CurrentClientDataID = sqlLastID;
			this.sqlRequest = $"INSERT INTO `{nameSqlСlientList}` (`{nameSqlСlienName}`, `{nameSqlClientDataID}`) VALUES ( ?ClientName, {CurrentClientDataID});" +
				"SELECT LAST_INSERT_ID();";
			InsertSqlClientList();
			CurrentIDClient = sqlLastID;
		}
		public void UpdateOrder()
		{
			this.sqlRequest = $"UPDATE `{nameSqlOrderList}` SET `{nameSqlClientID}` = '{CurrentIDClient}', `{nameSqlOrderAmount}` = ?orderAmount, `{nameSqlOrderShippigAddress}` = ?DeliveryAddress, `{nameSqlOrderStatus}` = ?Taken WHERE `{nameSqlOrderID}` = {CurrentIDOrder};";
			UpdateSqlOrders();
		}
		public void OrderCheck()
		{
			this.sqlRequest = $"SELECT sushi_name, sushi_weight, sushi_price, quantity_goods FROM sushi_list NATURAL JOIN goods_orders WHERE order_id = {CurrentIDOrder} ;";
			GetSqlArray();
			this.dataOrder = dataArrString;
		}
		internal void GetPresenceClientEmail()
		{
			this.sqlRequest = $"SELECT COUNT(client_email) FROM clients_data WHERE client_email = \"{ClientEmail}\"";
			GetSqlData();
			this.presenceClientEmail = Convert.ToInt16(stringSqlData);
		}
	}
}