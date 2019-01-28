using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.Abstractions
{
    public interface IGenericUnitOfWork<TDbContext> where TDbContext : DbContext 
    {
        TDbContext Context { get; }
        void Commit();
        Task CommitAsync();
    }
}
