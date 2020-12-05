using Logstore.Pizza.Aplicacao.Pedido;
using Logstore.Pizza.Aplicacao.ViewModel;
using Logstore.Pizza.Dominio.Pedido;
using Logstore.Pizza.Dominio.Pizza;
using Logstore.Pizza.Dominio.Shared;
using LogStore.Pizza.Test.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Logstore.Pizza.Dominio.PedidoItem;
using Logstore.Pizza.Dominio.Model;

namespace LogStore.Pizza.Test
{
    public class PedidoTest : IClassFixture<DbFixture>
    {
        private readonly ITestOutputHelper _consoleWriteLine;
        private readonly IProdutoRepositorio _repository;
        private readonly IPedidoServices _pedidoAppService;

        public PedidoTest(DbFixture dbFixture, ITestOutputHelper consoleWriteLine)
        {
            _consoleWriteLine = consoleWriteLine;
            var serviceProvider = dbFixture.ServiceProvider;
            _repository = serviceProvider.GetService<IProdutoRepositorio>();
            _pedidoAppService = serviceProvider.GetService<IPedidoServices>();
        }

        [Fact(DisplayName = "Novo Pedido Cliente Cadastrado")]
        public async Task NovoPedido_ClienteJaCadastrado()
        {
            //Arrange
            var clienteId = 1;
            var produto = await _repository.GetById(1);
            var pedido = new PedidoViewModel
            {
                PedidoItem = new List<PedidoItemViewModel> { new PedidoItemViewModel(produto.ProdutoId, 1, produto.ValorUnitario, null) }
            };

            pedido.ClienteId = clienteId;

            pedido.Logradouro = "Logradouro";
            pedido.Numero = "10";
            pedido.Estado = "ES";
            pedido.Complemento = "Complemento";
            pedido.Cep = "29149408";
            pedido.Bairro = "Bairro";
            pedido.Cidade = "Cidade";

            //Act
            var result = await _pedidoAppService.Incluir(pedido);

            //Assert
            Assert.True(result > 0);
        }

        [Fact(DisplayName = "Novo Pedido Cliente Sem Cadastro")]
        public async Task NovoPedido_ClienteSemCadastro()
        {
            //Arrange

            var produto = await _repository.GetById(1);
            var pedido = new PedidoViewModel
            {
                PedidoItem = new List<PedidoItemViewModel> { new PedidoItemViewModel(produto.ProdutoId, 1, produto.ValorUnitario, null) }
            };

            pedido.Logradouro = "Logradouro";
            pedido.Numero = "10";
            pedido.Estado = "ES";
            pedido.Complemento = "Complemento";
            pedido.Cep = "29149408";
            pedido.Bairro = "Bairro";
            pedido.Cidade = "Cidade";

            //Act
            var result = await _pedidoAppService.Incluir(pedido);

            //Assert
            Assert.True(result > 0);
        }



        [Fact(DisplayName = "Validar Mínimo de Itens")]
        public void ValidaQuantidadeMinimaDeItens()
        {
            //Arrange
            var novoPedido = new PedidoModel();

            //Act
            var validation = novoPedido.PedidoValido();

            //Assert
            Assert.True(!validation);
        }

        [Fact(DisplayName = "Validar Máximo de Itens")]
        public void ValidaQuantidadeMaximaDeItens()
        {
            //Arrange
            var novoPedido = new PedidoModel();
            for (int i = 0; i < 11; i++)
            {
                novoPedido.PedidoItem.Add(new PedidoItemModel());
            }


            //Act
            var validation = novoPedido.PedidoValido();

            //Assert
            Assert.True(!validation);
        }
    }
}
