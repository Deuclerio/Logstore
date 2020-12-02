using Logstore.Pizza.Dominio.Model;
using Logstore.Pizza.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Pizza.Dominio.Pedido
{
    public interface IPedidoServices : IServices<PedidoModel>
    {
        Task<ICollection<PedidoModel>> GetHistorico(int idcliente);

        Task<int> Incluir(PedidoModel pedido);

        //Task<PedidoModel> GetByNumeroPedido(int numeroPedido);
    }
}
