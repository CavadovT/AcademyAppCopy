using Business.Interfaces;
using DataAccess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class StudentService:IStudent
    {
        public static int Count { get; set; }
        private StudentRepository _studentRepository;
        public StudentRepository StudentRepository
        {
            get
            {
                return _studentRepository;
            }
            set
            {
                _studentRepository = value;
            }
        }

        public StudentService()
        {

            _studentRepository = new StudentRepository();

        }


        public Student Create(Student student)
        {
            student.Id = Count;
            _studentRepository.Create(student);
            return student;

        }
        public Student Delete(int id)
        {
            Student isExist = _studentRepository.GetOne(g => g.Id == id);
            if (isExist == null)
            {
                return null;
            }
            _studentRepository.Delete(isExist);
            return isExist;
        }


        public Student Update(int id, Student student)
        {
            Student isExist = _studentRepository.GetOne(g => g.Id == id);
            if (isExist == null)
            {
                return null;
            }
            isExist.Name = student.Name;
            _studentRepository.Update(student);
            return student;


        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public Student GetStudentById(int id)
        {
            Student isExit = _studentRepository.GetOne(g => g.Id == id);
            if (isExit == null)
            {
                return null;
            }
            _studentRepository.GetOne();
            return isExit;
        }

        public Student GetStudentBYName(string name)
        {
            Student isExit = _studentRepository.GetOne(g => g.Name == name);
            if (isExit == null)
            {
                return null;
            }
            _studentRepository.GetOne();
            return isExit;
        }

        public Student GetStudentByID(int id)
        {
            Student isExit = _studentRepository.GetOne(g => g.Id == id);
            if (isExit == null)
            {
                return null;
            }
            _studentRepository.GetOne();
            return isExit;
        }
    }
}
