using ConsoleManagementApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleManagementApp.Models
{
    class CGroup 
    {
        public static int count = 0;
        
        public string No { get; set; }
        public GroupCategory groupCategory { get; set; }
        public string IsOnline { get; set; }
        public int Limit { get; }
        public List<Student> Students { get; set; }



        public CGroup(GroupCategory groupcategory ,string IsOnline)
        {
            this.IsOnline = IsOnline;
            
            groupCategory = groupcategory;
            
            count++;

            Students = new List<Student>();

            if(IsOnline.ToLower() == "online".ToLower())
            {
                Limit = 15;
            }
            else
            {
                if(IsOnline.ToLower() == "offline".ToLower())
                {
                    Limit = 10;
                }
            }

            

            switch (groupcategory)
            {
                case GroupCategory.programming:
                    No = "P" + count;
                    break;
                case GroupCategory.design:
                    No = "D" + count;
                    break;
                case GroupCategory.systemadministration:
                    No = "SA" + count;
                    break;
            }
        }
        public override string ToString()
        {
            return $"Group: {No} - Category: {groupCategory.ToString().ToUpper()} - Status :{IsOnline.ToUpper()} - StudentsCount: {Students.Count} - Student limit : {Limit} ";
        }
    }
}