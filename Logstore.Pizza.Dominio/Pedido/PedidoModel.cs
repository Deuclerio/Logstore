using Logstore.Pizza.Dominio.Endereco;
using Logstore.Pizza.Dominio.PedidoItem;
using Logstore.Pizza.Dominio.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Pizza.Dominio.Model
{
    public class PedidoModel
    {
        public PedidoModel()
        {
            PedidoItem = new List<PedidoItemModel>();
        }

        public int PedidoId { get; set; }

        public ClienteModel ClienteId { get; set; }

        public List<PedidoItemModel> PedidoItem { get; set; }

        public decimal ValorTotalPedido { get; set; } = 0;

        public DateTime DataRegistro = new DateTime();
        public EnderecoModel EnderecoId { get; set; }

        public bool PedidoValido() => this.PedidoItem.Count > 0 && this.PedidoItem.Count <= 10;

        public decimal ValorTotal
        {
            get
            {
                var valorMeiaPizza = CalcularMeiaPizza();

                valorMeiaPizza += PedidoItem.Where(x => !x.DividiSabor).Sum(x => x.ValorUnitario * x.Quantidade);

                return valorMeiaPizza;
            }
        }

        private decimal CalcularMeiaPizza()
        {
            decimal valorMeiaPizza = 0;
            if (PedidoItem.Any(x => x.DividiSabor))
            {
                foreach (var referencia in PedidoItem.Where(x => x.DividiSabor && x.Referencia.HasValue).GroupBy(y => y.Referencia))
                {
                    valorMeiaPizza += PedidoItem.Where(x => x.Referencia.HasValue && x.Referencia.Value.Equals(referencia.Key)).Sum(itemPedido => itemPedido.ValorUnitario / 2);
                }
            }

            return valorMeiaPizza;
        }
    }
}
