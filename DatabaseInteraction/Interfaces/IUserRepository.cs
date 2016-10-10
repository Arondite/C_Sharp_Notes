using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DatabaseInteraction.Interfaces
{
    public interface IUserRepository
    {
        void SaveUser(User user);
        IEnumerable<User> GetUser();
        void SaveGroup(Group group);
        IEnumerable<Group> GetGroup();
        void SaveRole(Role role);
        IEnumerable<Role> GetRole();
    }
}
