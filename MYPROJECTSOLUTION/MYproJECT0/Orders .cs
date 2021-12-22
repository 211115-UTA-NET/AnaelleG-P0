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
    /// 
    public class Orders : StoreLocation, IFullName //AddressClass, IFullName 
    {
        //I want to inherit CustomerID but might just have to create it 
        public Orders()
        {
            //constructor
        }

        /// <summary>
        /// don't use public fields
        /// </summary>
        private int _orderID = 0;
        private string _firstName = "";
        private string _lastName = "";

        public int Id
        {
            get { return _orderID; }
            set { _orderID = value; }
        }
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
                _lastName = value;
            }
        }
    }

    public enum MenuItem
    {
        Apple,  //0
        Banana, //1
        Strawberry,//2
        Exit,    //3
        initialValue  //4
    }
}
