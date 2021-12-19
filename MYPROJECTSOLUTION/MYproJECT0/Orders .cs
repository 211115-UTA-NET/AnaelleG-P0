using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYproJECT0
{
    /// <summary>
    /// Orders class inherits both interfaces IFullName and ICustomerAddress.
    /// </summary>
    public class Orders : Address, IFullName 
    {
        /// <summary>
        /// don't use public fields
        /// </summary>
        private string _firstName = "";
        private string _lastName = "";
        public string FirstName 
        { 
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public string LastName
        { 
            get
            {
                return _lastName;
            }
            set
            {

            }
        }
    }
}
