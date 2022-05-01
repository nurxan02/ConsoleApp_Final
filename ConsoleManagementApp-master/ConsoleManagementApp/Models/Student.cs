using ConsoleManagementApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleManagementApp.Models
{
    class Student
    {
        public string Fullname { get; set; }
        public StudentType Type { get; set; }
        public string GroupNo { get; set; }

        public Student(string fullname , string groupno , StudentType type)
        {
            Fullname = fullname;
            GroupNo = groupno;
            Type = type;
           

        }

        public override string ToString()
        {

            return $"{Fullname}   {Type}  {GroupNo} ";
        }
    }
}