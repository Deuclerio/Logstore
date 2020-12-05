using Logstore.Pizza.Aplicacao.ViewModel;
using Logstore.Pizza.Dominio.Model;
using Logstore.Pizza.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Pizza.Aplicacao.Pedido
{
    public interface IPedidoServices : IServices<PedidoModel>
    {
        Task<HistoricoViewModel> GetHistorico(int idcliente);

        Task<int> Incluir(PedidoViewModel pedido);
    }
}
