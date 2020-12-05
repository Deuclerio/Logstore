using Logstore.Pizza.Aplicacao.ServicesBasic;
using Logstore.Pizza.Dominio.Cliente;
using Logstore.Pizza.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Pizza.Aplicacao.Cliente
{
    public class ClienteService : Services<ClienteModel>, IClienteServices
    {
        private readonly IClienteRepositorio _repositorio;

        public ClienteService(IClienteRepositorio repositorio): base(repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
