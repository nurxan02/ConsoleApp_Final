using ConsoleManagementApp.Enums;
using ConsoleManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleManagementApp.Services
{
    class CourseServices : ICourseServices
    {

        private List<CGroup> _Cgroups = new List<CGroup>();
        public List<CGroup> CGroups => _Cgroups;

        private List<Student> _Student = new List<Student>();
        public List<Student> student => _Student;



        public string CreateGroup(GroupCategory groupCategory, string isonline)
        {
            CGroup cGroup = new CGroup(groupCategory, isonline);
            _Cgroups.Add(cGroup);
            return cGroup.No.ToUpper();
        }
        public void EditGroup(string no, string newNo)
        {
            CGroup existedCGroup = null;
            foreach (CGroup cgroup in _Cgroups)
            {
                if (cgroup.No.ToUpper().Trim() == no.ToUpper().Trim())
                {
                    existedCGroup = cgroup;
                    break;
                }
            }
            if (existedCGroup == null)
            {
                Console.WriteLine($"{no.ToUpper()} group doesnt exist");
                return;
            }
            foreach (CGroup cGroup in _Cgroups)
            {
                if (cGroup.No.ToUpper().Trim() == newNo.ToLower().Trim())
                {
                    Console.WriteLine($"{newNo.ToUpper()} group already exists");
                    return;
                }

            }
            existedCGroup.No = newNo.ToUpper().Trim();
            Console.WriteLine($"{no.ToUpper()} succesfully updated to {newNo.ToUpper()}");
        }

        public void ShowGroups()
        {
            if (CGroup.count == 0)
            {
                Console.WriteLine("There is no any group");
            }
            foreach (CGroup cGroup in _Cgroups)
            {

                Console.WriteLine(cGroup);
            }
        }

        public void ShowAllStudents()
        {
            if (_Student.Count == 0)
            {
                Console.WriteLine("There is no any student");
            }
            else
            {
                foreach (Student student in _Student)
                {
                    Console.WriteLine(student);

                }
            }

        }

        public void ShowGroupStudents(string no)
        {
            CGroup cGroup = _Cgroups.Find(c => c.No.ToUpper().Trim() == no.ToUpper().Trim());

            if (cGroup == null)
            {
                Console.WriteLine($"{no}group doesnt exist");
            }
            else
            {
                if (cGroup.Students.Count == 0)
                {
                    Console.WriteLine($"There is no any student in {cGroup.No} ");
                    return;
                }

                foreach (Student student in cGroup.Students)
                {
                    {
                        Console.WriteLine("----------------");
                        Console.WriteLine($"{student.Fullname}  {student.GroupNo} {student.Type}");
                        Console.WriteLine("----------------");
                    }
                }
            }
        }

        public bool CreateStudent(string fullname, string groupno, StudentType type)
        {
            Student student1 = new Student(fullname, groupno.ToUpper(), type);
            CGroup cGroup = _Cgroups.Find(c => c.No.ToUpper().Trim() == groupno.ToUpper().Trim());
            if (cGroup == null || cGroup.Limit <= cGroup.Students.Count)
            {
                if (cGroup == null)
                {
                    Console.WriteLine($"------------------------------");
                    Console.WriteLine($"{groupno} group does not exist");
                    Console.WriteLine($"------------------------------");
                }
                else
                {
                    Console.WriteLine("Your limit is full. You can not add any other students");
                }

                return false;
            }

            else
            {
                cGroup.Students.Add(student1);
                _Student.Add(student1);
                return true;
            }
        }
    }
}


