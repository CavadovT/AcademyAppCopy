using AcademyApp.Controllers;
using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using Utilities.Helper;

namespace AcademyApp
{
    
    public class Program
    {
        static void Main(string[] args)
        {
           
            GroupController groupcontroller = new GroupController();
            StudentController studentController = new StudentController();  
            do
            {
                Notifications.Print(ConsoleColor.Cyan, "1-Creat Group\n" +
                    "2-Update Group\n" +
                    "3-Remove Group\n" +
                    "4-Get Group\n" +
                    "5-Get All Groups\n" +
                    "6-Add Student\n" +
                    "7-Update Student\n" +
                    "8-Remove Student\n" +
                    "9-Get Student\n" +
                    "10-Get All student\n");
                string num = Console.ReadLine();
                int input;

                bool IsNum = int.TryParse(num, out input);

                if (IsNum && input < 7 && input > 0)
                {
                    switch (input)
                    {

                        case (int)Enumss.MenuBar.Creat_Group:
                              groupcontroller.CreatGroup();
                            break;
                        case 2:

                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                           groupcontroller.GetAllGroups();
                            break;
                        case 6:

                            studentController.CreatStudent();   

                            break;
                    }

                }

            } while (true);
        }
    }
}
