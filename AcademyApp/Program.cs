using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using Utilities.Helper;

namespace AcademyApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            GroupService groupService = new GroupService(); 
            Notifications.Print(ConsoleColor.Green, "Welcome");

            do
            {
                Notifications.Print(ConsoleColor.Cyan, "1-Creat Group\n" +
                    "2-Update Group\n" +
                    "3-Remove Group\n" +
                    "4-Get Group" +
                    "5-Get All Groups");
                string num = Console.ReadLine();
                int input;

                bool IsNum = int.TryParse(num, out input);

                if (IsNum && input < 7 && input > 0)
                {
                    switch (input)
                    {

                        case 1:
                        EnterName:
                            Console.Write("Please enter the name of Group");
                            string name = Console.ReadLine();
                            Console.Write("Please enter the size of group");
                            string groupSize = Console.ReadLine();
                            int size;

                            bool isSize = int.TryParse(groupSize, out size);
                            if (isSize)
                            {
                                Group group = new Group
                                {
                                    Name = name,
                                    MaxSize = size,
                                };

                              groupService.Create(group);
                                Notifications.Print(ConsoleColor.Green, $"{group.Name} created");
                            }
                            else
                            {
                                Notifications.Print(ConsoleColor.Red, "Enter Name");
                                goto EnterName;
                            }

                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            List<Group> list = groupService.GetAll();
                            foreach (var item in list)
                            {
                                Notifications.Print(ConsoleColor.Yellow, $"{item.Name}");
                            }
                            break;
                        case 6:
                            break;
                    }

                }

            } while (true);
        }
    }
}
