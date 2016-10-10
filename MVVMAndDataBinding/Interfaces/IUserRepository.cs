using MVVMAndDataBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAndDataBinding.Interfaces
{
    public interface IUserRepository
    {
        void SaveUser(User user);
        IEnumerable<User> GetUser();
    }
}
