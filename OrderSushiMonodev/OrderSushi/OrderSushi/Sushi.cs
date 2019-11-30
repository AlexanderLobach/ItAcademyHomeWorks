using System;

namespace OrderSushi
{
	public class Sushi : GetSetSqlData
	{
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
			this.sqlRequest = $"SELECT  sushi_price, sushi_weight, sushi_description FROM {nameSqlSushiList} WHERE sushi_name = '{SushiName}'";
			GetSqlArray ();
			this.SushiInfo = dataArrString;

		}


	}
}
