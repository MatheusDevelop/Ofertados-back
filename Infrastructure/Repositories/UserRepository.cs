using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
