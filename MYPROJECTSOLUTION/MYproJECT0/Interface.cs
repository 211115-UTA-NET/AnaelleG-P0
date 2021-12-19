using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYproJECT0
{


    //Base 
    interface IAddress
    {
        public string Addresses { get; set; }
        string City { get; set; }
        string State { get; set; }
        int Zipcode { get; set; }

    }

    //Derived 
    interface IFullName 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }



    }


}
