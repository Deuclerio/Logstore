using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Logstore.Pizza.Dominio.Endereco
{
    [Table("Endereco")]
    public class EnderecoModel
    {
        public EnderecoModel()
        {

        }

        [Key]
        [Column("EnderecoId")]
        public int EnderecoId { get; set; }

        [Column("Logradouro")]
        public string Logradouro { get; set; }

        [Column("Cep")]
        public string Cep { get; set; }

        [Column("Numero")]
        public string Numero { get; set; }

        [Column("Complemento")]
        public string Complemento { get;  set; }

        [Column("Bairro")]
        public string Bairro { get;  set; }

        [Column("Cidade")]
        public string Cidade { get;  set; }

        [Column("Estado")]
        public string Estado { get;  set; }



    }
}
