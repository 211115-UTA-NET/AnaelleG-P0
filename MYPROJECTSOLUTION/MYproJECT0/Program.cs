
using System.Data.SqlClient;


namespace MYproJECT0
{
    public class Program
    {
        static void Main(string[] arg)
        {
           
            string connectionString = File.ReadAllText("C:/Users/15612/Revature-files/extra-code-stuff/string_CONNECTION.txt");
           

            string CustomerAddress = "";
            string CustomerCity = "";
            string CustomerState = "";
            int CustomerZipCode = 0;
            //use in the SQLquery table for orders
            string StoreAddress = "";
            string StoreCity = "";
            string StoreState = "";
            int StoreZipCode = 0;
            int intStoreLocation = 0;

            Console.WriteLine("**************************************************************");
            Console.WriteLine("************* Welcome to Anna Farmer's Market ****************");
            Console.WriteLine("**************************************************************");


            StoreLocation strlocation = new StoreLocation(out intStoreLocation, out StoreAddress, out StoreCity, out StoreState, out StoreZipCode);
            
            strlocation.Address = StoreAddress;
            strlocation.City = StoreCity;
            strlocation.State = StoreState;
            strlocation.Zipcode = StoreZipCode;

            Console.Write("\n Please enter the customer's first name: ");
            string? strFirstname = Console.ReadLine();
            Console.Write("\n Please enter the customer's last name: ");
            string? strLastname = Console.ReadLine();
            string? Fullname = strFirstname + " " + strLastname;
            Console.WriteLine(Fullname);
            Console.Clear();
            int intCustomerID = 0;
            try
            {
                Customer customer = new Customer();

                if ((strFirstname != null) && (strLastname != null))
                {
                    customer = new Customer(strFirstname, strLastname, CustomerAddress, CustomerCity, CustomerState, CustomerZipCode);
                }

                Orders order = new Orders();

                if ((strFirstname != null) && (strLastname != null))
                {
                    order.FirstName = customer.FirstName;
                    order.LastName = customer.LastName;
                }

                int intLastID = 0;

                bool boolCustomerFound = CheckIfCustomerExists(out intLastID, connectionString, customer);
                // This bool is use for INCREMENTING and seeing if the customer  
                string? strYesNo = "";
                string strSQLqueryCustomerTable = "";

                if (boolCustomerFound == true)
                {
                    // Console.WriteLine("\r\nThis customer exists.\r\n"); //used for Debug
                    Console.WriteLine("Here is the customer address information on file for " + customer.FirstName + " " + customer.LastName + ": " + customer.Address + ", " + customer.City + ", " + customer.State + ", " + customer.Zipcode.ToString());
                    Console.WriteLine("Should we use the customer address information shown above for the Ship-to address? Enter 'y' for Yes or 'n' for No.");
                    strYesNo = Console.ReadLine().ToLower();

                    //call the method   bool AssignShipToInfo_toOrder(string strYesNo, Orders theOrder);
                    AssignShipToAddress_toOrderObj(strYesNo, order, customer);
                }
                else
                {
                    if (intLastID > 0)//
                    {
                        intCustomerID = (intLastID + 1);
                        AssignShipToAddress_toOrderObj(strYesNo, order, customer);
                        strSQLqueryCustomerTable = "insert into [Project0].[dbo].[Customers] (CustomerID, FirstName,LastName,Address,City,State,ZipCode) values('" + intCustomerID.ToString() + "','" + order.FirstName + "','" + order.LastName + "','" + order.Address + "','" + order.City + "','" + order.State + "','" + order.Zipcode + "')";

                        bool boolAddressUpdated = AskUser_InsertNewRecord(strSQLqueryCustomerTable, connectionString);
                        //...I can use AUTOINCREMENT for customerID in the Customer table so  don't
                        //need this integer intLastID to do it in C# code in this method.
                    }
                }
                Dictionary<int, int> dictMenuItemOrdered = new Dictionary<int, int>();
                int intQtyOfItemsOrdered = 0;
                bool result = false;
                MenuItem resultMenu = MenuItem.initialValue; // the result for the menu option a user selected.
                while (resultMenu != MenuItem.Exit)
                {
                    Console.WriteLine("******** Anna Framer's Market ***********");
                    Console.WriteLine("\n Please select from the menu options ");
                    Console.WriteLine("[0]. Apple's   ");
                    Console.WriteLine("[1]. Banana's ");
                    Console.WriteLine("[2]. Strawberries ");
                    Console.WriteLine("[3]. Exit");

                    Console.Write("\n Please select a menu option : " + Fullname + ". ");// full name place here
                    
                    string menuNumber = Console.ReadLine();

                    result = MenuItem.TryParse(menuNumber, out resultMenu); //out come for the menu result the user press.
                    Console.Write("\n Menu option : " + resultMenu + " was selected.");

                    if ((resultMenu == MenuItem.Apple) || (resultMenu == MenuItem.Banana) || (resultMenu == MenuItem.Strawberry))
                    {
                        int fruitQTY = -1; // The result of fruits in your bag.
                        bool QTYresult = false;

                        while ((fruitQTY != 0) && (fruitQTY <= 100))
                        {
                            Console.Write($" \n How many fruits  would you like {strFirstname} {strLastname}: ");
                            string? fruits = Console.ReadLine(); // The fruit that a customer would like to add.
                            QTYresult = int.TryParse(fruits, out fruitQTY);

                            if (fruitQTY <= 100)
                            {
                                Console.WriteLine($"You added {fruitQTY} to your cart. ");

                                switch (resultMenu)
                                {
                                    case MenuItem.Apple:
                                        dictMenuItemOrdered.Add(0, fruitQTY); //"Apple"
                                        intQtyOfItemsOrdered++;
                                        break;
                                    case MenuItem.Banana:
                                        dictMenuItemOrdered.Add(1, fruitQTY);//"Banana"
                                        intQtyOfItemsOrdered++;
                                        break;
                                    case MenuItem.Strawberry:
                                        dictMenuItemOrdered.Add(2, fruitQTY);//"Strawberry"
                                        intQtyOfItemsOrdered++;
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Thank you for your order but the quantity must be less than 100. Please try again.\r\n");
                            }
                        }
                    }
                    else if (resultMenu == MenuItem.Exit)
                    {
                        Console.WriteLine("**************Have a Good Day!!!!!***********");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not a vaild Input please enter a number from 0 to 3 from the menu options.");

                    }
                }

                bool boolSuccessful = false;
                int intLastOrderID = 0;
                boolSuccessful = GetOrderID(out intLastOrderID, connectionString);//this will return our biggest orderID so that I can increment by 1
                // so I can use that for the new record getting inserted into the table.

                //intQtyOfItemsOrdered
                int intProductID = -1;
                int intQtyOfItems = 0;
                foreach (var item in dictMenuItemOrdered)
                {
                    //example
                    //item.Key = 0 for Apple
                    //item.Pair = Quantity ordered by customer of Apples
                    intProductID = item.Key;
                    intQtyOfItems = item.Value;
                    string strSQLqueryOrderTable = "insert into [Project0].[dbo].[Orders] (OrderID, StoreLocationID,CustomerID,ProductID,QtyOfProduct,OrderDate,ShipFirstName,ShipLastName,ShipAddress,ShipCity,ShipState,ShipZipCode) values('"
                    + (intLastOrderID + 1).ToString() + "','" + intStoreLocation.ToString() + "','" + intCustomerID.ToString() + "','" + intProductID.ToString() + "','" + intQtyOfItems.ToString() + "','" + DateTime.Now + "','" + customer.FirstName + "','"
                    + customer.LastName + "','" + customer.Address + "','" + customer.City + "','" + customer.State + "','" + customer.Zipcode.ToString() + "')";
                    boolSuccessful = false; //everytime you use this, you must initialize it to false
                    Console.WriteLine(strSQLqueryOrderTable);
                    boolSuccessful = AskUser_InsertNewRecord(strSQLqueryOrderTable, connectionString);

                }

            }
            catch (Exception)

            {
                Console.WriteLine(/*"There's an error with your code"*/);
            }
        }

        static bool CheckIfCustomerExists(out int intLastCustID, string connectionString, Customer thisCustomer)
        {
            bool boolFoundThisCustomer = false;
            int intLocalID = 0;
            try
            {

               
                using (SqlConnection conn = new  SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [Project0].[dbo].[Customers]", conn);
                    SqlDataReader rdr = sqlCommand.ExecuteReader();
                    while (rdr.Read())
                    {
                        // Console.WriteLine(rdr.GetValue(0).ToString()); //.GetString(0));
                        //Console.WriteLine(rdr.GetString(1));

                        if (rdr.GetString(1).ToLower() == thisCustomer.FirstName.ToLower())
                        {
                            if (rdr.GetString(2).ToLower() == thisCustomer.LastName.ToLower())
                            {
                                boolFoundThisCustomer = true;
                            }
                            else
                            {
                                boolFoundThisCustomer = false;
                            }
                        }
                        if (boolFoundThisCustomer == true)
                        {
                            //reserved for customerID = rdr.GetValue(0).ToString();
                            // Console.WriteLine(rdr.GetString(3));
                            thisCustomer.Address = rdr.GetString(3);
                            //Console.WriteLine(rdr.GetString(4));
                            thisCustomer.City = rdr.GetString(4);
                            thisCustomer.State = rdr.GetString(5);
                            int theZip = 0;
                            bool success = false;
                            success = int.TryParse(rdr.GetValue(6).ToString(), out theZip);
                            if (success == true)
                            {
                                thisCustomer.Zipcode = theZip;
                            }

                            //Console.WriteLine(rdr.GetString(7)); //telephone removed from the table tblCustomer
                        }

                        intLastCustID = intLocalID = (int)rdr.GetValue(0);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception error occurred: " + ex.ToString());
            }
            finally
            {
                intLastCustID = intLocalID;
            }
            return boolFoundThisCustomer;
        }

        static bool AskUser_InsertNewRecord(string strSQLquery, string connectionString)
        {
            bool boolSuccessfulInsertingRowInTable = false;
            SqlConnection sqlconn = new SqlConnection(connectionString);
            sqlconn.Open();

            Console.WriteLine(strSQLquery);
            SqlCommand sqlcmd = new SqlCommand(strSQLquery, sqlconn);

            try
            {
                int intNumRowsAffected = sqlcmd.ExecuteNonQuery();
                if (intNumRowsAffected == 1)
                {
                    boolSuccessfulInsertingRowInTable = true;
                }
                //Console.WriteLine("Number of rows affected by Database comm: "+ intNumRowsAffected.ToString()); //for Debug
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }

            return boolSuccessfulInsertingRowInTable;
        }

        static bool AskUser_UpdateRecord(string firstname, string lastname, string connectionString, int intCustomerID)
        {

            SqlConnection sqlconn = new SqlConnection(connectionString);
            sqlconn.Open();
            string strSQLquery = "UPDATE [Project0].[dbo].[Customers] set FirstName =" + "'" + firstname + "'" + " where CustomerId = " + intCustomerID.ToString();
            Console.WriteLine(strSQLquery);  //Debug only
            SqlCommand sqlcmd = new SqlCommand(strSQLquery, sqlconn);

            try
            {
                int intNumRowsAffected = sqlcmd.ExecuteNonQuery();
                Console.WriteLine("Number of rows affected by Database comm: " + intNumRowsAffected.ToString());//debug only
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }

            return false;
        }
        
        // strYesNo is for wheter a customer has the same shipping address from the last time they wrote their name 
        static bool AssignShipToAddress_toOrderObj(string strYesNo, Orders order, Customer customer)
        {
            string? strZipCode = "";
            bool boolReturn = false;

            try
            {
                if (strYesNo == "y")
                {
                    // order.FirstName = customer.FirstName;
                    // order.LastName = customer.LastName;
                    order.Address = customer.Address;
                    order.City = customer.City;
                    order.State = customer.State;
                    order.Zipcode = customer.Zipcode;
                    boolReturn = true;
                }
                else if ((strYesNo == "n") || (strYesNo == ""))
                {
                    Console.Write("Please enter the shipping address: ");
                    order.Address = Console.ReadLine();
                    Console.Write("\r\nPlease enter the City where the product will be shipped: ");
                    order.City = Console.ReadLine();
                    Console.Write("\r\nPlease enter the State where the product will be shipped: ");
                    order.State = Console.ReadLine();
                    Console.Write("\r\nPlease enter the ZipCode: ");
                    strZipCode = Console.ReadLine();
                    int intZipCode = 0;
                    bool boolResult = int.TryParse(strZipCode, out intZipCode);
                    if (boolResult == true)
                    {
                        order.Zipcode = intZipCode;
                    }
                    boolReturn = true;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return boolReturn;
        }

        static bool GetOrderID(out int intLastOrderID, string connectionString)
        {
            ///<summary>
            /// The objective of this routine is to get the total quantity of rows in the Order table,
            /// so that when you subsequently call the Insert into the Order table method (InsertNewRecord() )
            /// you can assign the OrderID to this number + 1. (intLastOrderID + 1)
            /// </summary>


            int intTempID = 0; //temporary integer counter for While loop
            bool boolSuccessful = false;
            intLastOrderID = 0; //test for this number to make sure it is no longer zero

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [Project0].[dbo].[Orders]", conn);
                    SqlDataReader rdr = sqlCommand.ExecuteReader();
                    while (rdr.Read())
                    {
                        intTempID++;
                    }
                    intLastOrderID = intTempID;
                    boolSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception error occurred: " + ex.ToString());
            }
            return boolSuccessful;
        }
    }
}