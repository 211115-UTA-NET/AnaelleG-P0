using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Project0
{
    internal class Customer

    {

        private string FirstName;
        private string LastName;
        private string Address;
        private string City;
        private string Region;
        private int PostalCode;


    

        public Customer(string FirstName, string LastName, string Address, string City, string Region, int PostalCode)
        {

            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.City = City;
            this.Region = Region;
            this.PostalCode = PostalCode;
        }



    }

}

