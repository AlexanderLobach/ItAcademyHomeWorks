using System;

namespace OrderSushi
{
	public class Sushi : GetSetSqlData
	{
		internal bool getOrderPictureOk { get; set; } 
		
		public void GetSushiList()
		{
			this.sqlRequest = $"SELECT sushi_name FROM {nameSqlGoodsList} WHERE sushi_id is not NULL";
			GetSqlArray ();
			this.SushiList = dataArrString;
			logger.Info("GetSushiList - OK!");
		}
		internal void GetSushiInfo()
		{
			this.sqlRequest = $"SELECT sushi_id, sushi_price, sushi_weight, sushi_description FROM {nameSqlGoodsList} WHERE sushi_name = '{SushiName}'";
			GetSqlArray ();
			this.SushiInfo = dataArrString;
			logger.Info("GetSushiInfo - OK!");
		}
		public void CreateOrder()
		{
			this.sqlRequest = $"INSERT INTO `{nameSqlOrderList}`(`{nameSqlClientID}`, `{nameSqlOrderDate}`, `{nameSqlOrderAmount}`) VALUES ( 1 , UTC_TIMESTAMP(), 0);" +
				"SELECT LAST_INSERT_ID();";
			InsertSqlData();
			this.CurrentIDOrder = sqlLastID;
			logger.Info("CreateOrder - OK!");
		}
		public void InsertGoodsOrders()
		{
			this.sqlRequest = $"INSERT INTO `{nameSqlGoodsOrders}`(`{nameSqlOrderID}`, `{nameSqlGoodsID}`, `{nameSqlGoodsQuantity}`) VALUES ({CurrentIDOrder}, {CurrentIDSushi}, {quantitySushi});";
			InsertSqlData();
			logger.Info("InsertGoodsOrders - OK!");
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
			logger.Info("SqlAddClientData - OK!");
		}
		public void UpdateOrder()
		{
			this.sqlRequest = $"UPDATE `{nameSqlOrderList}` SET `{nameSqlClientID}` = '{CurrentIDClient}', `{nameSqlOrderAmount}` = ?orderAmount, `{nameSqlOrderShippigAddress}` = ?DeliveryAddress, `{nameSqlOrderStatus}` = ?Taken WHERE `{nameSqlOrderID}` = {CurrentIDOrder};";
			UpdateSqlOrders();
			logger.Info("UpdateOrder - OK!");
		}
		public void GetOrderCheck()
		{
			this.sqlRequest = $"SELECT sushi_name, sushi_weight, sushi_price, quantity_goods FROM sushi_list NATURAL JOIN goods_orders WHERE order_id = {CurrentIDOrder} ;";
			GetSqlArray();
			this.dataOrder = dataArrString;
			logger.Info("GetOrderCheck");
		}
		internal void GetPresenceClientEmail()
		{
			this.sqlRequest = $"SELECT COUNT(client_email) FROM clients_data WHERE client_email = \"{ClientEmail}\"";
			GetSqlData();
			this.presenceClientEmail = Convert.ToInt16(stringSqlData);
			logger.Info("GetPresenceClientEmail - OK!");
		}
		public void GetOrderPicture( int numPicture)
		{
			this.sqlRequest = $"SELECT sushi_view FROM sushi_list NATURAL JOIN goods_orders WHERE order_id = {CurrentIDOrder} LIMIT {numPicture},1";
			SaveSqlPicture(numPicture);
			this.getOrderPictureOk = true;
			logger.Info("GetOrderPicture - OK!");
		}
	}
}