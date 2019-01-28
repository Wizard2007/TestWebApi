using Microsoft.EntityFrameworkCore;
using Test.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.Entities
{
    [ExcludeFromCodeCoverage]
    public abstract class  GenericUnitOfWorkEF<TDbContext> : IGenericUnitOfWork<TDbContext> where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        [ExcludeFromCodeCoverage]
        public GenericUnitOfWorkEF(TDbContext context)
        {
            _context = context;
        }

        public TDbContext Context => _context;

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
