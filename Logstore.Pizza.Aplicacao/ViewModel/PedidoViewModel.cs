using Logstore.Pizza.Dominio.PedidoItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logstore.Pizza.Aplicacao.ViewModel
{
    public class PedidoViewModel
    {
        public PedidoViewModel()
        {
            PedidoItem = new List<PedidoItemViewModel>();
        }

        public int PedidoId { get; set; }

        public int? ClienteId { get; set; }

        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Complemento { get;  set; }
        public string Bairro { get;  set; }
        public string Cidade { get;  set; }
        public string Estado { get;  set; }
        public decimal ValorTotalPedido { get; set; }

        public List<PedidoItemViewModel> PedidoItem { get; set; }

    }
}
