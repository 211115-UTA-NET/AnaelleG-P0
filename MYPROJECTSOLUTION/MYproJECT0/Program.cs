using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MYproJECT0
{
    public class Program
    {
        static void Main(string[] arg)
        {

            string connString = File.ReadAllText("C:/Users/15612/Revature-files/extra-code-stuff/string_CONNECTION.txt");
            string address = "";
            string city = "";
            string state = "";
            int zipCode = 0;
           
            Console.WriteLine("******** Welcome to Anna Framer's Market ***********");
            Console.Write("\n Please Enter your first name: ");
            string? Firstname = Console.ReadLine();
            Console.Write("\n Please Enter your last name: ");
            string? Lastname = Console.ReadLine();
            string Fullname = Firstname + " " + Lastname;
            Console.WriteLine(Fullname);
            Console.Clear();

            try
            {
                Customer customer;

                customer = new Customer();

                if ((Firstname != null) && (Lastname != null))
                {
                    //customer = null;
                    customer = new Customer(Firstname, Lastname, address, city, state, zipCode);
                }

                Orders orders = new Orders();
                if ((Firstname != null) && (Lastname != null))
                {
                    orders.FirstName = Firstname;
                    orders.LastName = Lastname;
                }

                int intLastID = 0;
                bool boolCustomerFound = CheckIfCustomerExists(out intLastID, connString, customer);

                if (boolCustomerFound == true)
                {
                    Console.WriteLine("\r\nThis customer exists.\r\n"); //used for Debug
                }
                else
                {
                    bool boolAddressUpdated = AskUserToEnterCustomerAddress(Fullname, connString);
                }

                bool result = false;

                while (result == false)
                {
                    Console.WriteLine("******** Anna Framer's Market ***********");
                    Console.WriteLine("\n Please select from the menu options ");
                    Console.WriteLine("[1]. Apple's   ");
                    Console.WriteLine("[2]. Banana's ");
                    Console.WriteLine("[3]. Strawberries ");
                    Console.WriteLine("[4]. Exit");
                    Console.Write("\n What would you like to add to your cart " + Fullname + "? ");// full name place here

                    string menuNumber = Console.ReadLine();
                    int resultMenu = 0; // the result for the menu option a user selected.
                    result = int.TryParse(menuNumber, out resultMenu); //out come for the menu result the user press.


                    if ((resultMenu == 1) || (resultMenu == 2) || (resultMenu == 3))
                    {
                        int fruitQTY = -1; // The result of fruits in your bag.
                        bool QTYresult = false;

                        while ((fruitQTY != 0) && (fruitQTY <= 100))
                        {
                            Console.Write($" \n How many fruits  would you like {Firstname} {Lastname}: ");
                            string? fruits = Console.ReadLine(); // The fruit that a customer would like to add.
                            QTYresult = int.TryParse(fruits, out fruitQTY);

                            if (fruitQTY <= 100)
                            {
                                Console.WriteLine($"You added {fruitQTY} to your cart. ");
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Thank you for your order but the quantity must be less than 100. Please try again.\r\n");
                            }
                        }
                    }
                    else if (resultMenu == 4)
                    {
                        Console.WriteLine("**************Have a Good Day!!!!!***********");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not a vaild Input please enter a number from 1 to 4 from the menu options.");

                    }
                }
            }
            catch (Exception)

            {
                Console.WriteLine("There's an error with your code");
            }
        }

        static bool CheckIfCustomerExists(out int intLastCustID, string connectionString, Customer thisCustomer)
        {
            bool boolFoundThisCustomer = false;
            int intLocalID = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM CustomerInfo;", conn);
                    SqlDataReader rdr = sqlCommand.ExecuteReader();
                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr.GetValue(0).ToString()); //.GetString(0));
                        Console.WriteLine(rdr.GetString(1));
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
                        //Console.WriteLine(rdr.GetString(2));
                        Console.WriteLine(rdr.GetString(3));
                        Console.WriteLine(rdr.GetString(4));
                        Console.WriteLine(rdr.GetString(5));
                        Console.WriteLine(rdr.GetValue(6).ToString());
                        Console.WriteLine(rdr.GetString(7));

                        intLastCustID = intLocalID = (int)rdr.GetValue(0);
                    }

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                intLastCustID = intLocalID;
            }
            return boolFoundThisCustomer;
        }

        static bool AskUserToEnterCustomerAddress(string fullname, string connectionString)
        {
            Console.Write("Please enter the shipping address: ");
            string? strAddress = Console.ReadLine();
            Console.Write("\r\nPlease enter the City where the product will be shipped: ");
            string? strCity = Console.ReadLine();
            Console.Write("\r\nPlease enter the State where the product will be shipped: ");
            string? strState = Console.ReadLine();
            Console.Write("\r\nPlease enter the ZipCode: ");
            string? strZipCode = Console.ReadLine();
            int intZipCode = 0;
            bool boolResult = int.TryParse(strZipCode, out intZipCode);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("Insert into [FramersMarket].[dbo].[tblCustomer] * VALUES (" +
                strAddress + "," + strCity + "," + strState + "," + strZipCode + ")", conn);

                //SqlDataReader rdr = sqlCommand.ExecuteReader();
                //while (rdr.Read())
                //{
                //    Console.WriteLine(rdr.GetValue(0).ToString()); //.GetString(0));
                //    Console.WriteLine(rdr.GetString(1));

                //    Console.WriteLine(rdr.GetString(2));
                //    Console.WriteLine(rdr.GetString(3));
                //    Console.WriteLine(rdr.GetString(4));
                //    Console.WriteLine(rdr.GetString(5));
                //    Console.WriteLine(rdr.GetValue(6).ToString());
                //    Console.WriteLine(rdr.GetString(7));

                //    //intLastCustID = intLocalID = (int)rdr.GetValue(0);
                //}

            }

            return false;
        }
    }
}

