﻿using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Helper;

namespace AcademyApp.Controllers
{
    public class StudentController//public etmiyede bilerem cunki oz asemblesindedi
    {
        public void CreatStudent()
        {
            
           
            Console.Write("Please enter the name of Student: ");
            string name = Console.ReadLine();
            Console.Write("Please enter the Surname of Student: ");
            string surname = Console.ReadLine();
            Student student = new Student()
            {
                Name = name,
                Surname = surname,
            };
            Console.WriteLine($"{student.Name}created");
       
        }

    }
}
