using Business.Services;
using DataAccess;
using Entities.Models;
using System;
using Utilities.Helper;

namespace AcademyApp.Controllers
{
    public class StudentController//public etmiyede bilerem cunki oz asemblesindedi
    {
        StudentService studentService = new StudentService();
        GroupController groupController = new GroupController();
        public void AddStudent()
        {
            if (DataContext.Groups.Count == 0)
            {
                Notifications.Print(ConsoleColor.Red, "Error: You have creat group the first!!!");
            }
            else
            {
                Notifications.Print(ConsoleColor.Blue, $"Please enter the Name of Student: ");
                string name = Console.ReadLine();
                Notifications.Print(ConsoleColor.Blue, $"Please enter the Surname of Stuudent: ");
                string surname = Console.ReadLine();
                Notifications.Print(ConsoleColor.Blue, "Your all groups::::");
                groupController.GetAllGroups();
                Notifications.Print(ConsoleColor.Blue, $"Please enter the group name: ");
                string groupName = Console.ReadLine();
                bool IsExistName = false;
                int Count=0;
                foreach (var item in DataContext.Groups)
                {
                    Console.WriteLine(item.Name);
                    if (item.Name == groupName)
                    {
                        IsExistName = true;
                        Count = item.MaxSize;
                        break;
                    }
                    else
                    {
                        IsExistName = false;
                    }
                }
                if (!IsExistName) 
                {
                    Notifications.Print(ConsoleColor.Red, "Bu adda qrup yoxdur!!!");
                }
                else
                {
                    if (DataContext.Students.Count < Count) 
                    {
                        Student student = new Student()
                        {
                            Name = name,
                            Surname = surname,
                            GroupName = groupName,
                        };
                        studentService.Create(student);
                        Notifications.Print(ConsoleColor.Green, $"{student.Name} created and added to {groupName}");
                    }
                    else
                    {
                        Notifications.Print(ConsoleColor.Red, "Group maximumdur yeni qrup yaradin");
                    }

                }

            }

        }
        public void GetAllStudents()
        {
            if (DataContext.Groups.Count == 0)
            {
                Notifications.Print(ConsoleColor.Red, "Error: You have creat group the first!!!");
            }
            else
            {
                foreach (var item in studentService.GetAll())
                {
                    Notifications.Print(ConsoleColor.Yellow, $"{item.Id}--{item.Name}--{item.Surname}--{item.GroupName}");
                }
            }
           
        }
        public void GetOneStudentbyName()
        {
            if (DataContext.Groups.Count == 0)
            {
                Notifications.Print(ConsoleColor.Red, "Error: You have creat group the first!!!");
            }
            else
            {
            M1:
                Console.WriteLine("Please enter the student name for Search:");
                string name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Notifications.Print(ConsoleColor.Red, $"Studen name deosn't null or empty");
                    goto M1;
                }
                else
                {
                    Notifications.Print(ConsoleColor.Yellow, $"{studentService.GetStudentBYName(name).Id}--" +
                        $"{studentService.GetStudentBYName(name).Name}" +
                        $"{studentService.GetStudentBYName(name).Surname}" +
                        $"{studentService.GetStudentBYName(name).GroupName}");

                }

            }
        }
        public void GetOneStudentbyId()
        {
            if (DataContext.Groups.Count == 0)
            {
                Notifications.Print(ConsoleColor.Red, "Error: You have creat group the first!!!");
            }
            else
            {

            M1:
                Console.WriteLine("Please enter the student id for Search:");
                string idinput = Console.ReadLine();
                int id;
                if (string.IsNullOrEmpty(idinput))
                {
                    Notifications.Print(ConsoleColor.Red, $"Student id deosn't null or empty");
                    goto M1;
                }
                else if (!int.TryParse(idinput, out id))
                {
                    Notifications.Print(ConsoleColor.Red, $"Student id should be with digit");
                    goto M1;
                }
                else
                {
                    id = int.Parse(idinput);
                    Notifications.Print(ConsoleColor.Yellow, $"{studentService.GetStudentByID(id).Name}");

                }

            }


        }
        public void UpdateStudentInfo()
        {
            if (DataContext.Groups.Count == 0)
            {
                Notifications.Print(ConsoleColor.Red, "Error: You have creat group the first!!!");
            }
            else
            {
            M1:
                Console.WriteLine("Please enter the studen id for Search:");
                string idinput = Console.ReadLine();
                int id;
                Console.WriteLine("Please enter the student correctly Name: ");
                string studentname = Console.ReadLine();
                Console.WriteLine("Please enter the student correctly Surname: ");
                string studentsurname = Console.ReadLine();
                if (string.IsNullOrEmpty(idinput))
                {
                    Notifications.Print(ConsoleColor.Red, $"Group id deosn't null or empty");
                    goto M1;
                }
                else if (!int.TryParse(idinput, out id))
                {
                    Notifications.Print(ConsoleColor.Red, $"Group id should be digit");
                    goto M1;
                }
                else
                {
                    id = int.Parse(idinput);
                    Student stunewname = new Student()
                    {
                        Name = studentname,
                        Surname = studentsurname,
                    };
                    Notifications.Print(ConsoleColor.Green, $"{studentService.Update(id, stunewname).Name}success!!!");
                }

            }
        }
        public void DeleteStudent()
        {
            if (DataContext.Groups.Count == 0)
            {
                Notifications.Print(ConsoleColor.Red, "Error: You have creat group the first!!!");
            }
            else
            {

            D1:
                Console.WriteLine("Please enter the student id for delete");
                string inputid = Console.ReadLine();
                int id;
                if (string.IsNullOrEmpty(inputid))
                {
                    Notifications.Print(ConsoleColor.Red, $"Student id doesn't null or empty!!!");
                    goto D1;
                }
                else if (!int.TryParse(inputid, out id))
                {
                    Notifications.Print(ConsoleColor.Red, $"Student id should be with digit!!!");
                    goto D1;
                }
                else
                {
                    id = int.Parse(inputid);
                    Notifications.Print(ConsoleColor.Green, $"{studentService.Delete(id).Name} deleted");
                }


            }

        }


    }
}
