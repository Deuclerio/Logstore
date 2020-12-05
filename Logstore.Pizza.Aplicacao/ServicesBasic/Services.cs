using Logstore.Pizza.Dominio.Shared;
using Logstore.Pizza.Infraestrutura.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Pizza.Aplicacao.ServicesBasic
{
    public class Services<T> : IServices<T> where T : class, new()
    {

        private IRepositorio<T> _repositorio;

        public Services(IRepositorio<T> repositorio)
        {
            _repositorio = repositorio;
        }

        public Task<T> Add(T entity)
        {
            return _repositorio.Add(entity);
        }

        public Task<T> Delete(int Id)
        {
            return _repositorio.Delete(Id);
        }

        public Task<ICollection<T>> GetAll()
        {
            return _repositorio.GetAll();
        }

        public Task<ICollection<T>> GetAllAsNoTracking()
        {
            return _repositorio.GetAllAsNoTracking();
        }

        public Task<T> GetById(int Id)
        {
            return _repositorio.GetById(Id);
        }

        public Task<T> Update(T entity)
        {
            return _repositorio.Update(entity);
        }
    }
}
