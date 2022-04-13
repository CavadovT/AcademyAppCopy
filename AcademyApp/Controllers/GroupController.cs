using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Helper;

namespace AcademyApp.Controllers
{
    public class GroupController//public etmiyede bilerem oz asemblesindedi sadece edirem...
    {
        GroupService groupService = new GroupService();


        #region Methods
        public void CreatGroup()
        {

            Console.Write("Please enter the name of Group: ");
            string name = Console.ReadLine();
        EnterName:
            Console.WriteLine("Please enter the MaxSize of group");
            string input = Console.ReadLine();
            int size;

            if (string.IsNullOrEmpty(input))
            {
                Notifications.Print(ConsoleColor.Red, $"Maxsize doesn't null or empty");
                goto EnterName;
            }
            else if (!int.TryParse(input, out size))
            {
                Notifications.Print(ConsoleColor.Red, "Enter Name");
                goto EnterName;
            }
            else
            {
                Group group = new Group
                {
                    Name = name,
                    MaxSize = size,
                };
                groupService.Create(group);
                Notifications.Print(ConsoleColor.Green, $"{group.Name} created");

            }


        }
        public void GetAllGroups()
        {

            foreach (var item in groupService.GetAll())
            {
                Notifications.Print(ConsoleColor.Yellow, $"{item.Name}");
            }
        }
        public void GetOneGroupbyName() 
        {
            M1:
            Console.WriteLine("Please enter the group name for Search:");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name)) 
            {
                Notifications.Print(ConsoleColor.Red, $"Group name deosn't null or empty");
                goto M1;
            }
            else
            {
                Notifications.Print(ConsoleColor.Yellow, $"{groupService.GetGroup(name).Name}");

            }
         
            
        }
        public void GetOneGroupbyId() 
        {
        M1:
            Console.WriteLine("Please enter the group id for Search:");
            string idinput = Console.ReadLine();
            int id;
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
                id=int.Parse(idinput);
                Notifications.Print(ConsoleColor.Yellow, $"{groupService.GetGroupById(id).Name}");

            }

        }
        public void UpdateGroup()
        {
            M1:
            Console.WriteLine("Please enter the group id for Search:");
            string idinput = Console.ReadLine();
            int id;
            Console.WriteLine("Please enter the Group's new name: ");
            string groupnewname=Console.ReadLine();
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
                Group grnew = new Group()
                {
                    Name = groupnewname,
                };
                Notifications.Print(ConsoleColor.Green, $"{groupService.Update(id, grnew).Name}updated");
            }



        }
        public void DeletGroup()
        {
            D1:
            Console.WriteLine("Please enter the group id for delete");
            string inputid=Console.ReadLine();
            int id;
            if (string.IsNullOrEmpty(inputid)) 
            {
                Notifications.Print(ConsoleColor.Red, $"Group id doesn't null or empty!!!");
                goto D1;
            }
            else if(!int.TryParse(inputid,out id))
            {
                Notifications.Print(ConsoleColor.Red, $"Group id should be digit!!!");
                goto D1;
            }
            else
            {
                id = int.Parse(inputid);
                Notifications.Print(ConsoleColor.Green, $"{groupService.Delete(id).Name}deleted");
            }
           

        }
        
        #endregion


    }
}
