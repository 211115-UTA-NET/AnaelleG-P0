



namespace MYproJECT0
{
    public class Customer : AddressClass, IFullName
    {
        /// <summary>
        /// Customer Class - this class will have the contact info for the customer. There is an associated
        /// Customer table as well.
        /// </summary>
        /// <remarks>
        /// Overloaded Constructor for this class named Customer: two method signatures available when
        /// instantiating this class. If the customer info is not available, use the one with no arguments.
        /// </remarks>
        /// <remarks>
        /// These two parameters are native to this Customer class.
        /// <param name="First_Name"></param>
        /// <param name="Last_Name"></param>
        /// </remarks>
        /// These parameters are inherited from Address class.
        /// <param name="Address_"></param>
        /// <param name="City_"></param>
        /// <param name="Region_"></param>
        /// <param name="PostalCode_"></param>
        public Customer(string First_Name, string Last_Name, string Address_, string City_, string Region_, int PostalCode_)
        {
            ///<remarks>
            /// Set the public properties to their respective arguments passed into the constructor. 
            /// This way, when an object is created for this class upon its instatiation (when this constructor
            /// is run), the properties of the instance has these initial values.
            /// </remarks>

            FirstName = First_Name;
            LastName = Last_Name;

        }
        public Customer()
        {
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        //using private fields for project requirement
        private string _firstName = "";

        /// <summary>
        /// Customer class public properties
        /// </summary>
        /// <remarks>
        /// Using properties for interface for ifullname and IcustomerAddress 
        /// this is for the Program class through its methods to access the private storage fields.
        /// We are using Property to make it a public for the strings and etc
        /// </remarks>

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

        private int _customerID = 0;
        public int CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }

    }
}