﻿using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Group:IEntity
    {
       
        public string  Name { get; set; }
        public int MaxSize { get; set; }
        public int Id { get; set; }

        public static List<Student> Students { get; set; }
        public Group()
        {
            Students = new List<Student>();
        }
    }
}
