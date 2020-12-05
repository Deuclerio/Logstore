using System;
using System.Collections.Generic;
using System.Text;

namespace Logstore.Pizza.Aplicacao.ViewModel
{
    public class HistoricoViewModel
    {
        public HistoricoViewModel()
        {
            Pedido = new List<PedidoViewModel>();
        }
       
        public string NomeCliente { get; set; }
        public string TelefoneCliente { get; set; }
        public List<PedidoViewModel> Pedido { get; set; }
    }
}
