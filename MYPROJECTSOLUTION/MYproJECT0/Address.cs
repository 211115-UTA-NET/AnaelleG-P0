using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYproJECT0
{
    public class Address : IAddress
    {

        private string _address = "";
        private string _city = "";
        private string _state = "";
        private int _zipCode = 0;

        string IAddress.Addresses
        {
            get { return _address; }
            set { _address = value; }

        }

       
        string IAddress.City
        {
            get { return _city; }
            set { _city = value; }

        }

        
        string IAddress.State
        {
            get { return _state; }
            set { _state = value; }

        }

       
        int IAddress.Zipcode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }
    }
}
