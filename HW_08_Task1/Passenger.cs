using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace HW_08_Task1
{
    public class Passenger
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string patronumic { get; set; }
        public string passNumber { get; set; }

        public string GetFullName()
        {
            return firstName +$" {patronumic} {lastName}";
        }
        public string GetName(string firstName)
        {
            return firstName;
        }
        public string GetName(string firstName, string lastName)
        {
            return firstName + $" {lastName}";
        }
        

        public string GetName(string firstName, string lastName, string patronumic)
        {
            return firstName + $" {lastName} {patronumic}";
        }
        
        
    }
}
