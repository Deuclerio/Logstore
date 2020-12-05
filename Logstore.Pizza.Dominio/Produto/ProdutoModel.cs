
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logstore.Pizza.Dominio.Pizza
{
    [Table("Produto")]

    public class ProdutoModel
    {
        [Key]
        [Column("ProdutoId")]
        public int ProdutoId { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("ValorUnitario")]
        public decimal ValorUnitario { get; set; }

    }
}
