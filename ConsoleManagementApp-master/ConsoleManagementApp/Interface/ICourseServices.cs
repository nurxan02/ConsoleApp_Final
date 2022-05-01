using ConsoleManagementApp.Enums;
using ConsoleManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleManagementApp
{
    interface ICourseServices
    {
        public List<Student> student { get;}
        public List<CGroup> CGroups { get; }

        



        string CreateGroup(GroupCategory groupCategory, string isonline);

        void ShowGroups();

        void EditGroup(string no, string newNo);

        void ShowGroupStudents(string no);

        void ShowAllStudents();

        bool CreateStudent(string fullname, string groupno, StudentType type);


    }
}
