using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Domain.Interfaces
{
   
    public interface IUserRepository : IGenericRepository<User> { }
}

