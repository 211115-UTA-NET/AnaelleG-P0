using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MYproJECT0
{
    public class Customer : Address, IFullName

    {//using a private fields for project requirement

         //constructor 
        public Customer(string First_Name, string Last_Name, string Address_, string City_, string Region_, int PostalCode_)
        {
          

            FirstName = First_Name;
            LastName = Last_Name;

        }
        public Customer()
        {

        }





        //property for interface for ifullname and IcustomerAddress 
        private string _firstName = "";
        public string FirstName 
        {
            get { return _firstName; }
            set { _firstName = value; }

        }

        private string _lastName = "";
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }

        }
    }

  

}
