using ConsoleManagementApp.Enums;
using System;

namespace ConsoleManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
           

            int selection;

            do
            {

                Console.WriteLine("***************");
                Console.WriteLine("1.Create a group");
                Console.WriteLine("2.Show groups");
                Console.WriteLine("3.Edit group");
                Console.WriteLine("4.Show group students");
                Console.WriteLine("5.Show all students");
                Console.WriteLine("6.Create student");
                Console.WriteLine("***************");
                string selectStr = Console.ReadLine();
                bool result = int.TryParse(selectStr, out selection);

                if (result)
                {
                    switch (selection)
                    {
                        case 1:
                            MenuClass.CreateGroupMenu();
                            break;
                        case 2:
                            MenuClass.ShowGroupsMenu();
                            break;
                        case 3:
                            MenuClass.EditGroupMenu();
                            break;
                        case 4:
                            MenuClass.GroupStudentsMenu();
                            break;
                        case 5:
                            MenuClass.AllStudents();
                            break;
                        case 6:
                            MenuClass.CreateStudent();
                            break;
                        default:
                            break;
                    }
                }
            } while (selection != 0);
            
        }
    }
}
