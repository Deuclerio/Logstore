using Logstore.Pizza.Dominio.Model;
using Logstore.Pizza.Dominio.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logstore.Pizza.Dominio.Pedido
{
    public interface IPedidoRepositorio : IRepositorio<PedidoModel>
    {
        //• O cliente deve ser capaz de ver seu histórico de pedidos, com os detalhes das pizzas, valor individual e valor total do pedido.

        Task<IList<PedidoModel>> GetHistorico(int ClienteId);
    }
}
