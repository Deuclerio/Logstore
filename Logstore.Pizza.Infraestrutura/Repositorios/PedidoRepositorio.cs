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

        //public async Task<PedidoModel> GetByNumeroPedido(int numeroPedido)
        //{
        //    return await _context.Pedidos
        //                     .AsNoTracking()
        //                     .Include(x => x.PedidoItem).ThenInclude(x => x.Sabor1)
        //                     //.Include(x => x.Produtos).ThenInclude(x => x.Sabor2)
        //                     .Where(x => x.IdCliente.Equals(idCliente))
        //                     .ToListAsync();
        //}

        public async Task<ICollection<PedidoModel>> GetHistorico(int ClienteId)
        {
            return await _context.Pedidos
                         .AsNoTracking()
                         .Include(x => x.PedidoItem).ThenInclude(x => x.Produto)
                         .Where(x => x.ClienteId.Equals(ClienteId))
                         .ToListAsync();
        }
    }
}
