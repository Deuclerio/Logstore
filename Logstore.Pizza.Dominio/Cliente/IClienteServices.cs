using Logstore.Pizza.Dominio.Model;
using Logstore.Pizza.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Pizza.Dominio.Cliente
{
    public interface IClienteServices : IServices<ClienteModel>
    {
        Task<ICollection<ClienteModel>> GetCardapio();
        Task<ClienteModel> Cadastrar(ClienteModel cliente);
    }
}
