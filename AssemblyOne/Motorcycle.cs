using System;
public class Motorcycle
{
   public string namePublic = "Honda";
   internal string typeVehicleInternal = "Motorcicle";
   private const ushort maxSpeedPrivate  = 300;
   protected string vinCodeProtected = "SD3434-44T98UV3NKJNS-A3SGJ3ASKDJ23";
   protected internal int adometerProtectedInternal = 200;
   private protected int motoHoursPrivateProtected = 100;
   public void StartEnginePublic()
   {
      Console.WriteLine($" max speed {namePublic} = {maxSpeedPrivate}\n type of vehicle {namePublic} = \"{typeVehicleInternal}\"\n vin code {namePublic} = {vinCodeProtected}\n adometer {namePublic} = {adometerProtectedInternal}\n motorhours {namePublic} = {motoHoursPrivateProtected}");
   }
}
internal class BikeSport : Motorcycle
{
    public void DisplayPublic() => Console.WriteLine($"name = {namePublic}");
    internal void DisplayInternal() => Console.WriteLine($"type vehicle = {typeVehicleInternal}");
    //internal void DisplayInternal() => Console.WriteLine($"max speed = {maxSpeedPrivate}"); - is inaccessible due to its protection level
    protected void DisplayProtected() => Console.WriteLine($"vin code = {vinCodeProtected}");
    protected internal void DisplayProtectedInternal() => Console.WriteLine($"adometer = {adometerProtectedInternal}");
    private protected void DisplayPrivateProtected() => Console.WriteLine($"motohours = {motoHoursPrivateProtected}");

}

