using DatabaseInteraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DatabaseInteraction
{
    /// <summary>
    /// Make sure Entity Framework is downloaded in the mapping class, data interactions, and the main project
    /// Put the implemetation of the data into Bootstrap
    /// Always confirm that your entity framwork reference the sql server you are using
    /// </summary>
    public class UserRepository : IUserRepository
    {
        //Got rid of because of the using statement
        //public UserContext DataContext { get; set; }

        public UserRepository()
        {
            //DataContext = new UserContext();
        }
        /// <summary>
        /// Linq pulls from the database an IQueryable. Just simply .ToList() it.
        /// </summary>
        /// <returns>Returns Groups</returns>
        public IEnumerable<Group> GetGroup()
        {
            using(var DataContext = new UserContext())
            {
                 return from u in DataContext.Groups
                        select u;
            }
            
        }

        //To Get the collections in the table
        //from u in DataContext.Groups.Include("UserRoles")
        //select u

        public IEnumerable<Role> GetRole()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUser()
        {
            using (var DataContext = new UserContext())
            {
                return from u in DataContext.Users
                       select u;
            }
                
        }

        public void SaveGroup(Group group)
        {
            throw new NotImplementedException();
        }

        public void SaveRole(Role role)
        {
            throw new NotImplementedException();
        }

        public void SaveUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
