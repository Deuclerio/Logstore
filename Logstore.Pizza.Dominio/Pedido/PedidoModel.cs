using Logstore.Pizza.Dominio.Endereco;
using Logstore.Pizza.Dominio.PedidoItem;
using Logstore.Pizza.Dominio.Pizza;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Pizza.Dominio.Model
{
    [Table("Pedido")]

    public class PedidoModel


    {
        public PedidoModel()
        {
            PedidoItem = new List<PedidoItemModel>();
        }

        [Key]
        public int PedidoId { get; set; }

        [Column("ValorTotalPedido")]
        public decimal ValorTotalPedido { get; set; } = 0;

        [Column("DataRegistro")]

        public DateTime DataRegistro = new DateTime();

        [Column("ClienteId")]
        public int? ClienteId { get; set; }

        public List<PedidoItemModel> PedidoItem { get; set; }

        [Column("EnderecoId")]
        public int? EnderecoId { get; set; }

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

        public EnderecoModel Endereco { get; set; }
    }
}
