using Logstore.Pizza.Dominio.Endereco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Logstore.Pizza.Dominio.Model
{
    [Table("Cliente")]
    public class ClienteModel
    {
        public ClienteModel()
        {

        }

        [Key]
        [Column("ClienteId")]
        public int ClienteId { get; set; }

        [Column("NomeCliente")]
        public string NomeCliente { get; set; }

        [Column("Telefone")]
        public string Telefone { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Column("EnderecoId")]
        public int EnderecoId { get; set; }

        [ForeignKey("EnderecoId")]
        public EnderecoModel Endereco { get; set; }
    }
}
