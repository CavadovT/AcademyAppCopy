using DataAccess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class StudentService
    {
        public static int Count { get; set; }
        private StudentRepository _StudentRepository;
        public StudentRepository StudentRepository
        {
            get
            {
                return _StudentRepository;
            }
            set
            {
                _StudentRepository = value;
            }
        }

        public StudentService()
        {

            _StudentRepository = new StudentRepository();

        }
       
        public Student Create(Student student)
        {
            student.Id = Count;
            _StudentRepository.Create(student);
            return student;

        }

    }
}
