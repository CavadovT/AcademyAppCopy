using AcademyApp.Controllers;
using System;
using Utilities.Helper;

namespace AcademyApp
{

    public class Program
    {
        static void Main(string[] args)
        {

            GroupController groupcontroller = new GroupController();
            StudentController studentController = new StudentController();
            Notifications.Print(ConsoleColor.Blue, "===Welcome===");
            do
            {
            Menu:
                Notifications.Print(ConsoleColor.Cyan, "1-Creat Group\n" +
                    "2-Update Group\n" +
                    "3-Remove Group\n" +
                    "4-Get Group by id\n" +
                    "5-Get Group by name\n" +
                    "6-Get All Groups\n" +
                    "7-Add Student\n" +
                    "8-Update Student\n" +
                    "9-Remove Student\n" +
                    "10-Get Student by id\n" +
                    "11-Get student by name\n"+
                    "12-Get All student\n" +
                    "0-Exit");
                string num = Console.ReadLine();
                int input;

                bool IsNum = int.TryParse(num, out input);
                if (IsNum && input >= 0 && input <= 13)
                {
                    switch (input)
                    {

                        case (int)Enumss.MenuBar.Creat_Group:
                            groupcontroller.CreatGroup();
                            break;
                        case (int)Enumss.MenuBar.Update_Group:
                            groupcontroller.UpdateGroup();
                            break;
                        case (int)Enumss.MenuBar.Remove_Group:
                            groupcontroller.DeletGroup();
                            break;
                        case (int)Enumss.MenuBar.Get_Group_By_Id:
                            groupcontroller.GetOneGroupbyId();
                            break;
                        case (int)Enumss.MenuBar.Get_Group_By_Name:
                            groupcontroller.GetOneGroupbyName();
                            break;
                        case (int)Enumss.MenuBar.Get_All_Groups:
                            groupcontroller.GetAllGroups();
                            break;
                        case (int)Enumss.MenuBar.Add_Student: 
                            studentController.AddStudent();
                            break;
                        case (int)Enumss.MenuBar.Update_Student_Info:
                            studentController.UpdateStudentInfo();
                            break;
                        case (int)Enumss.MenuBar.Remove_Student:
                            studentController.DeleteStudent();
                            break;
                        case (int)Enumss.MenuBar.Get_Student_By_Id:
                            studentController.GetOneStudentbyId();
                                break;
                        case (int)Enumss.MenuBar.Get_Student_By_Name:
                            studentController.GetOneStudentbyName();
                            break;
                            case (int)Enumss.MenuBar.Get_All_Students:
                                studentController.GetAllStudents();
                            break;
                        case 13:
                            //groupcontroller.GetAllGroups();
                            //Console.WriteLine("Hansi groupa elave etmek isteyirsini? enter the name of group:");
                            //string namegroup=Console.ReadLine();
                            //if(namegroup==)
                            //studentController.CreatStudent();  
                            break;
                        case (int)Enumss.MenuBar.Exit_Is_Program:
                            return;

                    }

                }
                else
                {
                    Console.Clear();
                    Notifications.Print(ConsoleColor.Red, $"Error: Plase change the correctly case for menyu");
                    goto Menu;
                }

            } while (true);
        }
    }
}
