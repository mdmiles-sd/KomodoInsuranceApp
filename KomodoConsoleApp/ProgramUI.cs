using KomodoInsuranceApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoConsoleApp
{
    class ProgramUI
    {
        private DeveloperRepository _DeveloperRepo = new DeveloperRepository();

        //Method that runs/starts the application
        public void Run()
        {
            SeedDeveloperList();
            Menu();
        }

        //Menu
        private void Menu()
        {

            bool keepRunning = true;
            while (keepRunning)
            {


                //Display our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1.Add Developer\n" +
                    "2.Display All Developers\n" +
                    "3.Display All BY ID\n" +
                    "4.Update List\n" +
                    "5.Terminate Developer\n" +
                    "6.Exit");

                //Get the user's input
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly

                switch (input)
                {
                    case "1":
                        // Create new Developer
                        AddNewDeveloper();
                        break;
                    case "2":
                        // view All Content
                        DisplayAllContent();
                        break;
                    case "3":
                        //
                        DisplayAllByID();
                        break;
                    case "4":
                        UpdateList();
                        break;
                    case "5":
                        //
                        DeleteDeveloper();
                        break;
                    case "6":
                        //exit
                        Console.WriteLine("GoodBye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }
        private void AddNewDeveloper()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            //Developer
            Console.WriteLine("Enter Developer Name:");
            newDeveloper.Name = Console.ReadLine();

            //ID
            Console.WriteLine("Enter ID:");
            newDeveloper.ID = Int32.Parse( Console.ReadLine());

            //Pluralsight
            Console.WriteLine("Pluralsight Access (y/n)");
            string pluralsightString = Console.ReadLine().ToLower();

            if (pluralsightString == "y")
            {
                newDeveloper.Pluralsight = true;
            }
            else
            {
                newDeveloper.Pluralsight = false;            }

                _DeveloperRepo.AddDeveloperToList(newDeveloper);
        }



        private void DisplayAllContent()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _DeveloperRepo.GetDeveloperList();

            foreach(Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"Name: {developer.Name}\n" +
                    $"ID: {developer.ID}\n" +
                    $"Pluralsight: {developer.Pluralsight}");
            }

        }

        private void DisplayAllByID()
        {
            Console.Clear();
            //Prompt the user to give an ID
            Console.WriteLine("Enter the ID of Developer");

            //get the user's input
            int ID = Int32.Parse (Console.ReadLine());

            //find the developer by Id
            Developer list = _DeveloperRepo.GetDeveloperById(ID);

            if (list != null)
            {
                Console.WriteLine($"Name: {list.Name}\n" +
                    $"ID: {list.ID}\n" +
                    $"Pluralsight: {list.Pluralsight}");
            }
            else
            {
                Console.WriteLine("No developer by ID");
            }


        }

        private void UpdateList()
        {
            //dispay all content
            DisplayAllContent();

            //Ask for the name of the dev to update 
            Console.WriteLine("Enter the ID of the Developer you'd like to update");

            // get that name 
            int oldDeveloper = Int32.Parse (Console.ReadLine());

            // we will build a new object
            Developer newDeveloper = new Developer();

            //Developer
            Console.WriteLine("Enter Developer Name:");
            newDeveloper.Name = Console.ReadLine();

            //ID
            Console.WriteLine("Enter ID:");
            newDeveloper.ID = Int32.Parse(Console.ReadLine());

            //Pluralsight
            Console.WriteLine("Pluralsight Access (y/n)");
            string pluralsightString = Console.ReadLine().ToLower();

            if (pluralsightString == "y")
            {
                newDeveloper.Pluralsight = true;
            }
            else
            {
                newDeveloper.Pluralsight = false;
            }

            _DeveloperRepo.UpdateExistinglist(oldDeveloper, newDeveloper);





        }

        private void DeleteDeveloper()
        {
            DisplayAllContent();
            //get the title dev they want to delete
            Console.WriteLine("Enter the ID of the Developer you'd like to remove");

            int input = Int32.Parse (Console.ReadLine());


            // call the delete method 
            bool wasDeleted = _DeveloperRepo.RemoveDeveloperFromList(input);

            // if the dev was deleted say so 
            // otherwise state it could not be deleted
            if (wasDeleted)
            {
                Console.WriteLine("The Developer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The Developer could not be deleted.");
            }

        }

        //see method
        private void SeedDeveloperList()
        {
            Developer michaelMiles = new Developer("Michael Miles", 123456, true);

            _DeveloperRepo.AddDeveloperToList(michaelMiles);
        }


    }
}
