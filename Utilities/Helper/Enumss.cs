using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Helper
{
    public class Enumss
    { /*"1-Creat Group\n" +
                    "2-Update Group\n" +
                    "3-Remove Group\n" +
                    "4-Get Group\n" +
                    "5-Get All Groups\n" +
                    "6-Add Student\n" +
                    "7-Update Student\n" +
                    "8-Remove Student\n" +
                    "9-Get Student\n" +
                    "10-Get All student\n");*/
       public enum MenuBar
        {
            Creat_Group = 1, Update_Group, Remove_Group, Get_Group_BY_ID,GET_GROUP_BY_NAME, Get_All_Groups,
            Add_Student, Update_Student, Remove_Student, Get_student, Get_All_student, Exit_Is_Program=0
        }

    }
}
