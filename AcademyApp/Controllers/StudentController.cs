using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Helper;

namespace AcademyApp.Controllers
{
    public class StudentController//public etmiyede bilerem cunki oz asemblesindedi
    {
        StudentService studentService=new StudentService();
        public void AddStudent()
        {

            Console.Write("Please enter the Name of Student: ");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter the Surname of Stuudent");
            string surname = Console.ReadLine();

                Student student = new Student()
                {
                    Name = name,
                    Surname = surname,
                };
                studentService.Create(student);
                Notifications.Print(ConsoleColor.Green, $"{student.Name} added");

        }
        public void GetAllStudents()
        {

            foreach (var item in studentService.GetAll())
            {
                Notifications.Print(ConsoleColor.Yellow, $"{item.Name}");
            }
        }
        public void GetOneStudentbyName()
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
                Notifications.Print(ConsoleColor.Yellow, $"{studentService.GetStudentBYName(name).Name}");

            }


        }
        public void GetOneStudentbyId()
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
        public void UpdateStudentInfo()
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
        public void DeleteStudent()
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
