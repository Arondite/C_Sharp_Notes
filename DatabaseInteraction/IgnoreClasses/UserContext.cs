using DatabaseInteraction.Interfaces;
using System;
using System.Collections.Generic;

namespace DatabaseInteraction
{
    public class UserContext : IDisposable
    {
        public IEnumerable<Group> Groups { get; internal set; }
        public IEnumerable<User> Users { get; internal set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}