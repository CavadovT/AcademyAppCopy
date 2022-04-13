using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IStudent
    {
        Student Create(Student student);

        Student Update(int id, Student student);

        Student Delete(int id);

        Student GetStudentBYName(string name);
        Student GetStudentByID(int id);

        List<Student> GetAll();
    }
}
