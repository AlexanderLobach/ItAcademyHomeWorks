using System;

namespace OrderSushi
{
	public class Sushi : GetSetSqlData
	{

		public void GetSetSushilist()
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
	}
}
