using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IGroup
    {
        Group Create(Group group);

        Group Update(int id,Group group);

        Group Delete(int id);

        Group GetGroup(string name);

        List<Group> GetAll();
        void AddStudent(Student stu);

    }
}
