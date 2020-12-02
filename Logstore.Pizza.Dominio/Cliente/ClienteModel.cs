using Logstore.Pizza.Dominio.Endereco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logstore.Pizza.Dominio.Model
{
    public class ClienteModel
    {
        private EnderecoModel enderecoId;

        public ClienteModel()
        {

        }

        public ClienteModel(EnderecoModel enderecoId)
        {
            this.enderecoId = enderecoId;
        }

        public ClienteModel(int clienteid, string nomeCliente, string telefone, EnderecoModel enderecoId, bool ativo, DateTime dataRegistro)
        {
            ClienteId = clienteid;
            NomeCliente = nomeCliente;
            Telefone = telefone;
            EnderecoId = enderecoId;
            Ativo = ativo;
            DataRegistro = dataRegistro;
        }

        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public string Telefone { get; set; }
        public EnderecoModel EnderecoId { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataRegistro { get; set; } = DateTime.Now;

    }
}
