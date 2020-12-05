using Logstore.Pizza.Dominio.Cliente;
using Logstore.Pizza.Dominio.Model;
using Logstore.Pizza.Dominio.Pizza;
using Logstore.Pizza.Infraestrutura.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Pizza.Infraestrutura.Repositorios
{
    public class ProdutoRepositorio : Repositorio<ProdutoModel>, IProdutoRepositorio
    {

        private Context _context;

        public ProdutoRepositorio(Context context) : base(context)
        {
            _context = context;
        }
    }

}
