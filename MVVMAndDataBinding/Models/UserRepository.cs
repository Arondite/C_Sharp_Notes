using MVVMAndDataBinding.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAndDataBinding.Models
{
    class UserRepository : IUserRepository
    {
        public void SaveUser(User user)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<User> GetUser()
        {
            var users = new List<User>();
            for (int i = 0; i < 10; i++)
            {
                users.Add(new User()
                {
                    ID = i + 1,
                    Name = "User " + (i + 1),
                    Phone = new string(i.ToString()[0], 10),
                    Grade = 'A'
                });
            }
            return users;
        }
    }
}
