using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Pizza.Dominio.Shared
{
    public interface IRepositorio<T> : IDisposable where T : class
    {
        Task<ICollection<T>> GetAll();
        Task<ICollection<T>> GetAllAsNoTracking();
        Task<T> GetById(int Id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int Id);
    }
}
