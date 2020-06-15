using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29_05_2020.Models
{
    class Customer
    {
        public String FirstName { get; set; } //property
        public String LastName { get; set; } //property
        public String Address { get; set; } //property
        public String City { get; set; } //property
        public String State { get; set; } //property
        public String Phone { get; set; } //property
        public int Zip { get; set; } //property

        public String FullName { 
            get {
                return $"{FirstName} {LastName}";
            } 
        }
        //fake data
        public static List<Customer> customers = new List<Customer>()
        {
            new Customer() { 
                FirstName = "Nguyen",
                LastName = "Duc Hoang",
                Address = "so nha xbc, phuong X",
                State = "nahqreer",
                Zip = 12345
            },
            new Customer() {
                FirstName = "Nguyen",
                LastName = "Van A",
                Address = "dia chi adbnsd",
                State = "sssdd"
            }
        };
        public override string ToString()
        {
            return $"First name = {FirstName}, " +
                $"Last name = {LastName}, " +
                $"Address = {Address}, " +
                $"City = {City}, " +
                $"State = {State}, " +
                $"Phone = {Phone}"+
                $"Zip = {Zip}";
        }
    }
}
