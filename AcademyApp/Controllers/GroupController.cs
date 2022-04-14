using Business.Services;
using DataAccess;
using Entities.Models;
using System;
using Utilities.Helper;

namespace AcademyApp.Controllers
{
    public class GroupController//public etmiyede bilerem oz asemblesindedi sadece edirem...
    {
        GroupService groupService = new GroupService();


        #region Methods
        public void CreatGroup()
        {

        EnterName:
            Console.Write("Please enter the name of Group: ");
            string name = Console.ReadLine();

            Console.WriteLine("Please enter the MaxSize of group");
            string input = Console.ReadLine();
            int size;
            foreach (var item in DataContext.Groups)
            {
                if (item.Name == name)
                {
                    Notifications.Print(ConsoleColor.Red, "Error: This group name already in your base!!!");
                    goto EnterName;
                }
            }
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
            else if (size < 0)
            {
                Notifications.Print(ConsoleColor.Red, "Size doesn't minus!!!");
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
            if (DataContext.Groups.Count == 0)
            {
                Notifications.Print(ConsoleColor.Red, "Error: You have creat group the first!!!");
            }
            else
            {
                foreach (var item in groupService.GetAll())
                {
                    Notifications.Print(ConsoleColor.Yellow, $"{item.Id}--{item.Name}");
                }

            }

        }
        public void GetOneGroupbyName()
        {
            if (DataContext.Groups.Count == 0)
            {
                Notifications.Print(ConsoleColor.Red, "Error: You have creat group the first!!!");
            }
            else
            {
            M1:
                Notifications.Print(ConsoleColor.Cyan, "All groups");
                GetAllGroups();
                Console.WriteLine("Please enter the group name for Search:");
                string name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Notifications.Print(ConsoleColor.Red, $"Group name deosn't null or empty");
                    goto M1;
                }
                else
                {
                    groupService.GetGroupByName(name);

                }

            }
        }
        public void GetOneGroupbyId()
        {
            if (DataContext.Groups.Count == 0)
            {
                Notifications.Print(ConsoleColor.Red, "Error: You have creat group the first!!!");
            }
            else
            {
            M1:
                Notifications.Print(ConsoleColor.Cyan, "All groups");
                GetAllGroups();
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
                    id = int.Parse(idinput);

                    groupService.GetGroupById(id);

                }

            }

        }
        public void UpdateGroup()
        {
            if (DataContext.Groups.Count == 0)
            {
                Notifications.Print(ConsoleColor.Red, "Error: You have creat group the first!!!");
            }
            else
            {
            M1:
                Notifications.Print(ConsoleColor.Cyan, "All groups");
                GetAllGroups();
                Console.WriteLine("Please enter the group id for Search:");
                string idinput = Console.ReadLine();
                int id;
                Console.WriteLine("Please enter the Group's new name: ");
                string groupnewname = Console.ReadLine();
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
                    groupService.Update(id, grnew);
                }
            }

        }
        public void DeletGroup()
        {
            if (DataContext.Groups.Count == 0)
            {
                Notifications.Print(ConsoleColor.Red, "Error: You have creat group the first!!!");
            }
            else
            {
                
            D1:
                Notifications.Print(ConsoleColor.Cyan, "All groups");
                GetAllGroups();
                Console.WriteLine("Please enter the group id for delete");
                string inputid = Console.ReadLine();
                int id;
                if (string.IsNullOrEmpty(inputid))
                {
                    Notifications.Print(ConsoleColor.Red, $"Group id doesn't null or empty!!!");
                    goto D1;
                }
                else if (!int.TryParse(inputid, out id))
                {
                    Notifications.Print(ConsoleColor.Red, $"Group id should be digit!!!");
                    goto D1;
                }
                else
                {
                    id = int.Parse(inputid);
                    groupService.Delete(id);
                }
            }
        }

        #endregion
    }
}
