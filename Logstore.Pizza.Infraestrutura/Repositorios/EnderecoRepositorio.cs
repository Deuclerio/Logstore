using Logstore.Pizza.Dominio.Endereco;
using Logstore.Pizza.Infraestrutura.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logstore.Pizza.Infraestrutura.Repositorios
{
    public class EnderecoRepositorio : Repositorio<EnderecoModel>, IEnderecoRepositorio
    {
        private Context _context;


        public EnderecoRepositorio(Context context) : base(context)
        {
            _context = context;
        }
    }
}
