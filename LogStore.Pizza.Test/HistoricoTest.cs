using Logstore.Pizza.Aplicacao.Pedido;
using Logstore.Pizza.Aplicacao.ViewModel;
using Logstore.Pizza.Dominio.PedidoItem;
using LogStore.Pizza.Test.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Logstore.Pizza.Aplicacao.Cliente;

namespace LogStore.Pizza.Test
{
    public class HistoricoTest : IClassFixture<DbFixture>
    {
        private readonly ITestOutputHelper _consoleWriteLine;
        private readonly IPedidoServices _pedidoServices;

        public HistoricoTest(DbFixture dbFixture)
        {
            var serviceProvider = dbFixture.ServiceProvider;
            _pedidoServices = serviceProvider.GetService<IPedidoServices>();
        }

        [Fact(DisplayName = "Carregar Pedidos Clientes Existentes")]
        public async Task CarregarHistoricoPedidosClientesExistentes()
        {
            //Arrange 
            var clienteId = 1;

            //Act
            var historico = await _pedidoServices.GetHistorico(clienteId);

            //Assert
            Assert.True(historico.Pedido.Count > 0);
        }

        [Fact(DisplayName = "Carregar Pedidos Clientes Inexistentes")]
        public async Task CarregarHistoricoPedidosClientesInexistentes()
        {
    
            //Act
            var historico = await _pedidoServices.GetHistorico(0);

            //Assert
            Assert.True(historico.Pedido.Count == 0);
        }
    }
}