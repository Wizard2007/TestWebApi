using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.Abstractions
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        //Task<T> GetById(int id);
        void Add(T model);
        Task AddAsync(T model);
        //Task<bool> Update(int id, T model);
        //Task<bool> Delete(int id);
        //Task<bool> Delete(T model);
    }
}
