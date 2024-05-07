/*
 * 1st, program greets user
   Program also asks user to enter a number

   2nd, user enters number

   Validate user number- check if number that was entered is a valid number within the array.
         Use Loop to reject answer and ask again if the answer is invalid
   If answer is valid- find name from the number that the user entered and print it

   Than as the user what category of information to display: hometown or favorite food
        If the user answers invalid information to select a category, notify user that answer is invalid and loop back to ask again for the Hometown or Favorite Food.
    If Hometown is selected, display hometown for the student selected
    If Favorite Food is selected, display food for the student selected

  When this is complete, ask user if they would like to enter another student(learn about another student)
  If yes, continue
  If no, print a polite end program message

 * 
 * 
 */

using System.Threading.Channels;
using static System.Runtime.InteropServices.JavaScript.JSType;


internal class Program
{
    private static void Main(string[] args)
    {
        string[] names = {
            "Justin", "Victoria", "Ethan", "Ben",
            "Kyra", "Jack", "Ramses", "Clare", "Ramsey",
            "Ali", "Pedro", "Mellisa"
        };

        // Array to hold favorite foods
        string[] favoriteFoods = {
            "Baja Blast", "Pho", "Hot Wings", "Crab legs",
            "Sushi", "Hot Wings", "Lasagna", "Cheesy Potatoes", "Dim Sum",
            "Indian", "Italian", "Pizza"
        };

        // Array to hold hometowns
        string[] hometowns = {
            "Westerville", "Blacksburg", "Bolivar", "Birmingham",
            "Hazel Park", "Trenton", "Wyoming", "Lake Orion", "Brooklyn",
            "Dearborn Heights", "Chicago", "Detroit"
        };


        Console.WriteLine($"Hello, Welcome to the Student Database.");


        bool runProgram = true;
        int number = 0;
        //do while loop will hold program and than ask if user wants to continue at end. 
        do
        {
            Console.WriteLine($" Please enter a student number 1-{names.Length}:");

            while (true)
            {
                number = int.Parse(Console.ReadLine());
                if ((number <= 0) || (number > names.Length))
                {
                    Console.WriteLine("Unfortunately that number is outside of the possible choices, please select a new number:");
                }
                else
                {
                    GetNames(names, number);
                    break;
                }
            }







            Console.WriteLine("");
            Console.WriteLine("What information do you want to see? Hometown or Favorite food:\n");

            while (true)
            {
                string option = Console.ReadLine().ToLower().Trim();
                if (option != "hometown" && option != "favorite food" && option != "food" && option != "home")
                {

                    Console.WriteLine("That answer is not valid for this question, please try again:");
                }

                else if (option == "hometown" || option == "home")
                {
                    GetHometown(hometowns, number);
                    break;
                }

                else if (option == "favorite food" || option == "food")
                {
                    GetFood(favoriteFoods, number);
                    break;
                }


            }


            //main program ends here
            //user is asked if they want to continue to learn more, if yes, program will continue to loop.

            Console.WriteLine("\nWould you like to learn about another student? y/n");
            string choice = Console.ReadLine().ToLower();
            if (choice == "y")
            {
                runProgram = true;
            }
            else if (choice == "n")
            {
                runProgram = false;
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

        }
        while (runProgram == true);


        Console.WriteLine("Thank you, press any key to exit the program.");



        //methods
        //method to list out the names of the group


        static void listNames(string[] names)
        {
            for (int i = 0; i < names.Length; i++)
            {
                int arrayPosition = i + 1;
                string student = names[i - 1];
                Console.WriteLine($"{arrayPosition}.{student}");
            }
        }

        static void GetPosition(string[] names, int index)
        {
            //commenting out because validation statements are not working well inside the method
            //if (index >= 1 && index <= names.Length)
            {
                int arrayPosition = index;
                Console.WriteLine($"{arrayPosition}");
            }
            //else
            //{
            // Console.WriteLine("invalid number");
            //}

        }

        static void GetNames(string[] names, int index)
        {
            //if (index >= 1 && index <= names.Length)
            //{
            int arrayPosition = index;
            string student = names[index - 1];
            Console.WriteLine($"Student {arrayPosition} is {student}");
            //}

        }

        static void GetFood(string[] favoriteFoods, int index)
        {

            int arrayPosition = index;
            string food = favoriteFoods[index - 1];
            Console.WriteLine($"{food}");



        }

        static void GetHometown(string[] hometowns, int index)
        {

            int arrayPosition = index;
            string town = hometowns[index - 1];
            Console.WriteLine($"{town}");


        }


        //I really wanted to try validating through a method,
        //but it seemed like it made everything kind of convoluted and was unable to get the pieces in the correct places

        static void isInvalidText(string yesorno)
        {
            if (yesorno == null || yesorno != "yes" || yesorno != "no")
                Console.WriteLine("I'm sorry that input is invalid for this question, please try again");
        }

        static string IsValidInput(string userInput, string acceptableInput)
        {
            if (userInput != acceptableInput)
            {
                string errorMsg = "That input is invalid, please try again";
                return errorMsg;
            }
            else return "Thank you";



        }
    }
}