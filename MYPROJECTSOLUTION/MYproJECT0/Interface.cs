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
        /// <summary>
        /// This is the Interface IAddress that will be inherited by both Customer Class (for its
        /// address info) and also
        /// </summary>
        /// 
        public string Address { get; set; }
        string City { get; set; }
        string State { get; set; }
        int Zipcode { get; set; }

    }

    //Derived 
    interface IFullName 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }




    }


}
