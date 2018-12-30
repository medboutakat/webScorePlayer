using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROP
{
    public class PROPUser
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; } 
         
        public PROPUser()
        {

        }

        public PROPUser(int id, string username, string email, string password)
        {
            Id = id;
            UserName = username;
            Email = email;
            Password = password; 
        }
    }
}
