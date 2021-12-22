namespace MYproJECT0
{
 
    public class StoreLocation : AddressClass
    {
        private string StoreLocationMessage = "Please identify the Store Location. \r\n" +
        " [1] for Azalea Park Default Store \r\n" +
        " [2] for Winter Park \r\n" + 
        " [3] for Altamonte Springs  \r\n" +
        " [4] for Downtown Orlando \r\n"+ 
        " [5] for Lake Buena Vista \r\n" + 
        " [6] for International Drive area \r\n" +
        "Press an option between 1 to 5: " ;

        private string _storeLocationName = "";
        private int _storeLocationId = 0;

        public StoreLocation(out int intStoreLocation, out string strStoreAddress, out string strStoreCity, out string strStoreState, out int intStoreZipCode)
        {
            strStoreAddress = "";
            strStoreCity = "";
            intStoreZipCode = 0;
            strStoreState = "";
            intStoreLocation = -1;


            string strAdd = "";
            string strCity = "";
            string strState = "";
            int intZip = 0;
            try
            {
                string? strConsoleRead = "";
                int intStoreLoc = -1;
                bool boolParseSuccess = false;

                while (intStoreLoc == -1)
                {
                    Console.Write(StoreLocationMessage);

                    strConsoleRead = Console.ReadLine(); //convert this string NUMBER to an integer

                    boolParseSuccess = int.TryParse(strConsoleRead, out intStoreLoc);

                    if (boolParseSuccess)
                    {
                        if (strConsoleRead != null)
                        {
                            if (intStoreLoc != -1)
                            {
                                AskForStoreLocation(intStoreLoc, out strAdd, out strCity, out strState, out intZip);
                                intStoreLocation = intStoreLoc;
                                strStoreAddress = strAdd;
                                strStoreCity = strCity;
                                strStoreState = strState;
                                intStoreZipCode = intZip;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public StoreLocation() { }

        public string StoreLocationName
        {
            get
            {
                return _storeLocationName;
            }
            set
            {
                _storeLocationName = value;
            }
        }

        public int StoreLocationID
        {
            get
            {
                return _storeLocationId;
            }
            set
            {
                if ((value > 0) && (_storeLocationId == 0))
                {
                    _storeLocationId = value;
                }
            }
        }

        bool AskForStoreLocation(int intStoreLoc, out string StoreAddress, out string StoreCity, out string StoreState, out int StoreZipCode)
        {
            bool boolResult = true;

            switch (intStoreLoc)
            {
                case 1: //Azalea Park
                    StoreAddress = "100 Kasey Drive";
                    StoreCity = "Orlando";
                    StoreState = "FL";
                    StoreZipCode = 32807;
                    break;
                case 2: //Winter Park
                    StoreAddress = "234 N. Park Avenue";
                    StoreCity = "Winter Park";
                    StoreState = "FL";
                    StoreZipCode = 32789;
                    break;
                case 3: //Altamonte Springs
                    StoreAddress = "8579 E. Altamonte Drive";
                    StoreCity = "Altamonte Springs";
                    StoreState = "FL";
                    StoreZipCode = 32701;
                    break;
                case 4: //Downtown Orlando
                    StoreAddress = "123 E. Robinson Street";
                    StoreCity = "Orlando";
                    StoreState = "FL";
                    StoreZipCode = 32801;
                    break;
                case 5: //Lake Buena Vista
                    StoreAddress = "2445 S. Apopka Vineland";
                    StoreCity = "Orlando";
                    StoreState = "FL";
                    StoreZipCode = 32821;
                    break;
                case 6: //International Drive area
                    StoreAddress = "5204 International Drive";
                    StoreCity = "Orlando";
                    StoreState = "FL";
                    StoreZipCode = 32819;
                    break;
                default:
                    StoreAddress = "100 Kasey Drive";
                    StoreCity = "Orlando";
                    StoreState = "FL";
                    StoreZipCode = 32807;
                    boolResult = false;
                    break;
            }
            if (boolResult == true)
            {
                Console.WriteLine("\r\nStore Location is: " + StoreAddress + ", " + StoreCity + ", " + StoreState + " " + StoreZipCode.ToString());
            }
            else
            {
                Console.WriteLine("An invalid store location was selected so the default Store Location was assigned.\r\n");
            }
            return boolResult;
        }
    }
}


