using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rohm.Common.Model;

namespace Rohm.DataAccess
{
    public class UserRepository
    {
        public User GetUserBy(string userCode)
        {
            return new User() 
            { 
                ID = 10,
                Code = userCode, 
                FirstName = "Tanapat", 
                LastName = "Sanitmoung" 
            };
        }

        public User GetUserBy(string userCode, string passsword)
        {
            return new User()
            {
                ID = 11,
                Code = userCode,
                FirstName = "Chirasit",
                LastName = "Sanitmoung"
            };
        }
    }
}
