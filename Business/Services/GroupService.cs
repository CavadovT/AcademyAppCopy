using Business.Interfaces;
using DataAccess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Helper;

namespace Business.Services
{
    public class GroupService : IGroup
    {
        public static int Count { get; set; }
        private GroupRepository _groupRepository; 
        public GroupRepository GroupRepository 
        { 
            get 
            {
                return _groupRepository;
            }
            set
            {
                _groupRepository = value;
            }
        }

        public GroupService()
        {
            
            _groupRepository=new GroupRepository();

        }
        //public void AddStudent(Student student) 
        //{
        //_groupRepository.AddStudentToGroup(student);

        //    Console.WriteLine($"{student.Name}added to{_groupRepository.GetOne().Name}");
        //}
        public Group Create(Group group)
        {
            group.Id = Count;
            _groupRepository.Create(group);
            return group;
            
        }
        public Group Delete(int id)
        {
            Group isExist = _groupRepository.GetOne(g => g.Id == id);
            if (isExist == null)
            {
                return null;
            }
            _groupRepository.Delete(isExist);
            return isExist;
        }



        public Group GetGroup(string name)
        {
           Group isExit=_groupRepository.GetOne(g => g.Name == name);
           if (isExit==null)
            {
                return null;
            }
            _groupRepository.GetOne();
            return isExit;

        }

        public Group Update(int id, Group group)
        {
            Group isExist=_groupRepository.GetOne(g => g.Id == id);
            if (isExist==null) 
            {
                return null;
            }
            isExist.Name = group.Name;
            _groupRepository.Update(group);
            return group;
           
           
        }

        public List<Group> GetAll()
        {
          return _groupRepository.GetAll();
        }

        public Group GetGroupById(int id)
        {
            Group isExit = _groupRepository.GetOne(g => g.Id == id);
            if (isExit == null)
            {
                return null;
            }
            _groupRepository.GetOne();
            return isExit;
        }

    }
}
