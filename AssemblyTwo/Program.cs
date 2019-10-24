using System;
using AssemblyOne;



namespace AssemblyTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Motorcycle koljaska = new Motorcycle();
            //koljaska.typeVehicleInternal = "motokoljaska"; - is inaccessible due to its protection level
            //koljaska.maxSpeedPrivate = 400; - is inaccessible due to its protection level
            //koljaska.vinCodeProtected = "000 000000qwefqe 0a00afa"; - is inaccessible due to its protection level
            //koljaska.adometerProtectedInternal = 0001; - is inaccessible due to its protection level
            //koljaska.motoHoursPrivateProtected = 0934850; - is inaccessible due to its protection level
            koljaska.StartEnginePublic();
            //BikeSport kawasaki = new BikeSport(); - is inaccessible due to its protection level
        }
    }
}
