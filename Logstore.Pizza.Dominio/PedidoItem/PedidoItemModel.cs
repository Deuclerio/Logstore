using Logstore.Pizza.Dominio.Model;
using Logstore.Pizza.Dominio.Pizza;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Logstore.Pizza.Dominio.PedidoItem
{
    [Table("PedidoItem")]
    public class PedidoItemModel
    {

        [Key]
        [Column("PedidoItemId")]
        public int PedidoItemId { get; set; }

        [Column("Referencia")]
        public int? Referencia { get; set; }

        [NotMapped]
        public bool DividiSabor => Referencia.HasValue;

        [Column("ValorUnitario")]
        public decimal ValorUnitario { get; set; }

        [Column("Quantidade")]
        public int Quantidade { get; set; }


        [Column("ProdutoId")]
        public int ProdutoId { get; set; }
        public ProdutoModel Produto { get; set; }

        [Column("PedidoId")]
        public int PedidoId { get; set; }

        [ForeignKey("PedidoId")]
        public PedidoModel Pedido { get; set; }

    }
}
