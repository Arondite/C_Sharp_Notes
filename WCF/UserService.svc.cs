using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Caliburn.Models;

namespace WCF
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class UserService : IUserService
	{
		public IEnumerable<User> GetUser()
		{
			return new List<User>()
			{
				new User() { Id = "1", Name = "User 1"},
				new User() { Id = "2", Name = "User 2"},
				new User() { Id = "3", Name = "User 3"},
				new User() { Id = "4", Name = "User 4"}
			};
		}
	}
}
