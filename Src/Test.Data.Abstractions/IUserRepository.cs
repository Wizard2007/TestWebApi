using Test.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Data.Abstractions
{
    public interface IUserRepository: IGenericRepository<User>
    {
    }
}
