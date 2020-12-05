using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logstore.Pizza.Aplicacao.ViewModel
{
    public class PedidoItemViewModel
    {

        public PedidoItemViewModel(int produtoId, int quantidade, decimal valorUnitario, int? referencia)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            Referencia = referencia;
        }

        public PedidoItemViewModel()
        {

        }

        public int? Referencia { get; set; }

        public decimal ValorUnitario { get; set; }

        public int Quantidade { get; set; }

        public int ProdutoId { get; set; }

        public string DescricaoProduto { get; set; }
    }
}
