using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Project.Models
{
    public class UsersList
    {
        private static List<Users> responses = new List<Users>();

        public static List<Users> Responses
        {
            get
            {
                return responses;
            }
        }
        public static void AddUser(Users response)
        {
            responses.Add(response);
        }
    }
}
