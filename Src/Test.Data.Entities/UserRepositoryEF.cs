using Microsoft.EntityFrameworkCore;
using Test.Data.Abstractions;
using Test.Data.Models;

namespace Test.Data.Entities
{
    public class UserRepositoryEF : GenericRepositoryEF<User>, IUserRepository
    {
        public UserRepositoryEF(IUnitOfWork unitOfWorkEF) : base(unitOfWorkEF.Context)  { }
    }
}
