using Logstore.Pizza.Dominio.Model;
using Logstore.Pizza.Dominio.Pedido;
using Logstore.Pizza.Infraestrutura.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Pizza.Infraestrutura.Repositorios
{
    public class PedidoRepositorio : Repositorio<PedidoModel>, IPedidoRepositorio
    {
        private Context _context;

        public PedidoRepositorio(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<PedidoModel>> GetHistorico(int ClienteId)
        {
            try
            {
                return await _context.Pedidos
                     .Include(x => x.Cliente)
                     .Include(x => x.Endereco)
                     .Include(x => x.PedidoItem).ThenInclude(x => x.Produto)
                     .Where(x => x.ClienteId.Equals(ClienteId))
                     .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
