using ConsoleManagementApp.Enums;
using ConsoleManagementApp.Models;
using ConsoleManagementApp.Services;
using System;

namespace ConsoleManagementApp
{
    static class MenuClass
    {
        public static CourseServices courseServices = new CourseServices();

        public static void CreateGroupMenu()


        {


            Console.WriteLine("Please select Online or Offline");
            string isonline = Console.ReadLine();
            if (isonline.ToLower() == "online".ToLower() || isonline.ToLower() == "offline".ToLower())
            {
                Console.WriteLine("Please select category");
                foreach (var c in Enum.GetValues(typeof(GroupCategory)))
                {
                    Console.WriteLine($"{(int)c}.{c}");
                }
                int category;
                string categoryStr = Console.ReadLine();
                bool categoryResult = int.TryParse(categoryStr, out category);
                if (categoryResult)
                {
                    switch (category)
                    {
                        case 1:
                            string No = courseServices.CreateGroup(GroupCategory.programming, isonline);
                            Console.WriteLine($"{No}. Group sucessfully created");
                            break;
                        case 2:
                            No = courseServices.CreateGroup(GroupCategory.design, isonline);
                            Console.WriteLine($"{No}. Group sucessfully created");
                            break;
                        case 3:
                            No = courseServices.CreateGroup(GroupCategory.systemadministration, isonline);
                            Console.WriteLine($"{No}. Group sucessfully created");
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Select valid group status please");
            }
        }

        public static void ShowGroupsMenu()
        {
            courseServices.ShowGroups();
        }

        public static void EditGroupMenu()
        {
            Console.WriteLine("Please enter Group No");
            string groupno = Console.ReadLine();
            Console.WriteLine("Pleae enter new group No");
            string newgroupno = Console.ReadLine();
            courseServices.EditGroup(groupno, newgroupno);
        }

        public static void GroupStudentsMenu()
        {
            Console.WriteLine("Please enter group no");
            string no = Console.ReadLine();

            courseServices.ShowGroupStudents(no.ToUpper());



        }

        public static void AllStudents()
        {
            courseServices.ShowAllStudents();
        }

        public static void CreateStudent()
        {
            Console.WriteLine("please insert Name");
            string name = Console.ReadLine();

            Console.WriteLine("please insert group no");
            string no = Console.ReadLine();


            Console.WriteLine("Please select student type");
            foreach (var s in Enum.GetValues(typeof(StudentType)))
            {
                Console.WriteLine($"{(int)s}.{s}");
            }
            int studenttype;
            string studenttypeStr = Console.ReadLine();
            bool typeResult = int.TryParse(studenttypeStr, out studenttype);
            if (typeResult)
            {

                switch (studenttype)
                {
                    case 1:
                        bool isTrue = courseServices.CreateStudent(name, no.ToUpper(), StudentType.Guaranteed);
                        if (isTrue)
                        {
                            Console.WriteLine($"{name} student created");
                        }

                        break;
                    case 2:
                        isTrue = courseServices.CreateStudent(name, no.ToUpper(), StudentType.NotGuaranteed);
                        if (isTrue)
                        {
                            Console.WriteLine($"{name} student created");
                        }

                        break;
                    default:
                        break;
                }
            }



        }

    }


}
