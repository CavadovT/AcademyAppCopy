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

        #endregion


    }
}
