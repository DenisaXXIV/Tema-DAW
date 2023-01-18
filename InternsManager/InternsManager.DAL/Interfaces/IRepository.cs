using InternsManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManager.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Delete(int id);
        Task<T> FindById(int id);
        Task<List<T>> GetAll();
        Task<T> Update(T entity);
    }
}
