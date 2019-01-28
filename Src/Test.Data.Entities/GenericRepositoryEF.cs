using Microsoft.EntityFrameworkCore;
using Test.Data.Abstractions;
using Test.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://garywoodfine.com/generic-repository-pattern-net-core/
namespace Test.Data.Entities
{
    [ExcludeFromCodeCoverage]
    public abstract class GenericRepositoryEF<T> : IGenericRepository<T> where T : class
    {
        private DbSet<T> _items;
        private readonly DbContext _dbContext;

        [ExcludeFromCodeCoverage]
        public GenericRepositoryEF(DbContext dbContext)
        {
            _dbContext = dbContext;
            _items = _dbContext.Set<T>();
        }

        public void Add(T model) => _items.Add(model);

        /*
        public async void Delete(int id)
        {
            _items.Remove(_items.Where(x => x.Id == id).SingleOrDefault());
            await _entityFrameWorkDbContext.SaveChangesAsync();
        }

        public async bool Delete(T model)
        {
            _items.Remove(model);
            await _entityFrameWorkDbContext.SaveChangesAsync();
            return true;
        }
        */
        public IEnumerable<T> GetAll() => _items.ToList();

        public async Task<IEnumerable<T>> GetAllAsync() => await _items.ToListAsync();

        public async Task AddAsync(T model) => await _items.AddAsync(model);

        /* 
public Task<T> GetById(int id)
{
   throw new NotImplementedException();
}

public <bool> Update(int id, T model)
{
   throw new NotImplementedException();
}
*/
    }
}
