using System;

namespace AssemblyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Motorcycle minsk = new Motorcycle();
            minsk.StartEnginePublic();
            minsk.namePublic = "minsk";
            minsk.typeVehicleInternal = "tractor";
            //minsk.maxSpeedPrivate = 400; - is inaccessible due to its protection level
            //minsk.vinCodeProtected = "000 000000qwefqe 0a00afa"; - is inaccessible due to its protection level
            minsk.adometerProtectedInternal = 0001;
            //minsk.motoHoursPrivateProtected = 0934850; - is inaccessible due to its protection level
            minsk.StartEnginePublic();
            BikeSport BMW = new BikeSport();
            BMW.namePublic = "BMW";
            BMW.DisplayPublic(); 
            //BMW.DisplayProtected(); - is inaccessible due to its protection level
            BMW.DisplayProtectedInternal();
            //BMW.DisplayPrivateProtected(); - is inaccessible due to its protection level
        }
    }
}
