using System;

namespace Project
{
    public class Program
    {


        static void Main(string[] arg)

        {
            Console.WriteLine("******** Welcome to Anna Framer's Market ***********");
            Console.WriteLine("\n Please Enter your first name.");
            string Firstname = Console.ReadLine();
            Console.WriteLine("\n Please Enter your last name.");
            string? Lastname = Console.ReadLine();
            string? Fullname = Firstname + " " + Lastname;
            Console.WriteLine(Fullname);
            Console.Clear();


            try
            {

               

                Console.WriteLine("******** Anna Framer's Market ***********");
                Console.WriteLine("\n Please select from the menu options " + Fullname);
                Console.WriteLine("[1]. Apple's   ");
                Console.WriteLine("[2]. Banana's ");
                Console.WriteLine("[3]. Strawberries ");
                Console.WriteLine("[4]. Exit");
                Console.WriteLine("\n What would you like to add to your cart? " + Fullname);// full name place here



                bool menuLoop = false;

                while (true)
                {


                        string menuNumber = Console.ReadLine();
                        int resultMenu = 0; // the result for the menu option a user selected.
                        bool result = int.TryParse(menuNumber, out resultMenu); //out come for the menu result the user press.
                   

                    if ((resultMenu == 1) || (resultMenu == 2) || (resultMenu == 3))
                        {
                            Console.WriteLine($" \n How many fruits  would you like {Firstname} , {Lastname} ");
                            Console.ReadLine();

                            break;
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














    }
}
    
