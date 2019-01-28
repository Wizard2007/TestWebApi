using Microsoft.EntityFrameworkCore;
using Test.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.Entities
{
    public class UnitOfWorkEF : GenericUnitOfWorkEF<DbContext>, IUnitOfWork
    {
        [ExcludeFromCodeCoverage]
        public UnitOfWorkEF(EntityFrameWorkDbContext context): base(context) { }
    }
}
