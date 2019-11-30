using System;

namespace OrderSushi
{
	public class Sushi : GetSetSqlData
	{
		public string filodelfia = "filodelfia";
		public string gomosjakiMaki = "gomosjaki maki";
		public string SushiList { get; set;}
	
	public void GetSetSushilist()
	{
			GetSqlArray ();
			this.SushiList = this.dataArrString;
	}

	}
}
