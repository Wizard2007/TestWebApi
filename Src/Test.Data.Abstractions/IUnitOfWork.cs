using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Data.Abstractions
{
    public interface IUnitOfWork: IGenericUnitOfWork<DbContext>
    {
    }
}
