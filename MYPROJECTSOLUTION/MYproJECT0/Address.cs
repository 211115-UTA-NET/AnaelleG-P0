

namespace MYproJECT0
{
    public class AddressClass : IAddress
    {
        private string _address = "";
        public string Address
        {
            get { return _address; }
            set { _address = value; }

        }


        private string _city = "";
        public string City
        {
            get { return _city; }
            set { _city = value; }

        }

        private string _state = "";
        public string State
        {
            get { return _state; }
            set { _state = value; }

        }

        private int _zipCode = 0;
        public int Zipcode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

    }

}
