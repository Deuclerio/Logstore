using Logstore.Pizza.Dominio.Cliente;
using Logstore.Pizza.Dominio.Model;
using Logstore.Pizza.Infraestrutura.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Pizza.Infraestrutura.Repositorios
{
    public class ClienteRepositorio : Repositorio<ClienteModel>, IClienteRepositorio
    {

        private Context _context;

        public ClienteRepositorio(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ClienteExiste(int ClienteId)
        {
            return await _context.Clientes
                           .AsNoTracking()
                           .Where(x => x.ClienteId.Equals(ClienteId))
                           .AnyAsync();
        }     
    }
}
