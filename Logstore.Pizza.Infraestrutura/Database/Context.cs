using Logstore.Pizza.Dominio.Endereco;
using Logstore.Pizza.Dominio.Model;
using Logstore.Pizza.Dominio.PedidoItem;
using Logstore.Pizza.Dominio.Pizza;
using Microsoft.EntityFrameworkCore;

namespace Logstore.Pizza.Infraestrutura.Database
{
   public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<PedidoItemModel> PedidoItem { get; set; }
    }
}
