using Logstore.Pizza.Aplicacao.ServicesBasic;
using Logstore.Pizza.Aplicacao.ViewModel;
using Logstore.Pizza.Dominio.Cliente;
using Logstore.Pizza.Dominio.Endereco;
using Logstore.Pizza.Dominio.Model;
using Logstore.Pizza.Dominio.Pedido;
using Logstore.Pizza.Dominio.PedidoItem;
using Logstore.Pizza.Infraestrutura.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Pizza.Aplicacao.Pedido
{
    public class PedidoService : Services<PedidoModel>, IPedidoServices
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;


        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IEnderecoRepositorio _enderecoRepositorio;



        public PedidoService(IPedidoRepositorio pedidoRepositorio, IClienteRepositorio clienteRepositorio, IEnderecoRepositorio enderecoRepositorio) : base(pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _clienteRepositorio = clienteRepositorio;
            _enderecoRepositorio = enderecoRepositorio;
        }

        public async Task<HistoricoViewModel> GetHistorico(int clienteId)
        {
            var resultado = await _pedidoRepositorio.GetHistorico(clienteId);

            var HistoricoViewModel = new HistoricoViewModel();

            if (resultado.Count == 0)
                return HistoricoViewModel;

            HistoricoViewModel.NomeCliente = resultado[0].Cliente.NomeCliente;
            HistoricoViewModel.TelefoneCliente = resultado[0].Cliente.Telefone;

            HistoricoViewModel.Pedido = new List<PedidoViewModel>();

            foreach (var item in resultado)
            {

                PedidoViewModel pedidoView = new PedidoViewModel();

                pedidoView.Logradouro = item.Endereco.Logradouro;
                pedidoView.Numero = item.Endereco.Numero;
                pedidoView.Estado = item.Endereco.Estado;
                pedidoView.Complemento = item.Endereco.Complemento;
                pedidoView.Cep = item.Endereco.Cep;
                pedidoView.Bairro = item.Endereco.Bairro;
                pedidoView.Cidade = item.Endereco.Cidade;

                pedidoView.ValorTotalPedido = item.ValorTotalPedido;


                foreach (var itemPedido in item.PedidoItem)
                {
                    PedidoItemViewModel pedidoItemViewModel = new PedidoItemViewModel();

                    pedidoItemViewModel.ProdutoId = itemPedido.ProdutoId;
                    pedidoItemViewModel.DescricaoProduto = itemPedido.Produto.Descricao;

                    pedidoItemViewModel.Quantidade = itemPedido.Quantidade;
                    pedidoItemViewModel.ValorUnitario = itemPedido.ValorUnitario;

                    pedidoView.PedidoItem.Add(pedidoItemViewModel);

                }

                HistoricoViewModel.Pedido.Add(pedidoView);
            }

            return HistoricoViewModel;
        }

        public async Task<int> Incluir(PedidoViewModel pedidoView)
        {
            try
            {
                PedidoModel pedidox = new PedidoModel();


                pedidox.ClienteId = pedidoView.ClienteId;
                foreach (var item in pedidoView.PedidoItem)
                {
                    PedidoItemModel pedidoItem = new PedidoItemModel();

                    pedidoItem.ProdutoId = item.ProdutoId;
                    pedidoItem.Quantidade = item.Quantidade;
                    pedidoItem.Referencia = item.Referencia;
                    pedidoItem.ValorUnitario = item.ValorUnitario;

                    pedidox.PedidoItem.Add(pedidoItem);
                }



                if (!pedidox.PedidoValido())
                    throw new Exception("Pedido não contempla quantidade necessária ou máximo permitido");


                if (pedidox.ClienteId.HasValue)
                {
                    ClienteModel clienteExiste = await _clienteRepositorio.GetById(pedidox.ClienteId.Value);

                    pedidox.ClienteId = clienteExiste.ClienteId;
                    pedidox.EnderecoId = clienteExiste.EnderecoId;
                }

                else
                {

                    pedidox.Endereco = new EnderecoModel();
                    pedidox.Endereco.Logradouro = pedidoView.Logradouro;
                    pedidox.Endereco.Cep = pedidoView.Cep;
                    pedidox.Endereco.Numero = pedidoView.Numero;
                    pedidox.Endereco.Complemento = pedidoView.Complemento;
                    pedidox.Endereco.Bairro = pedidoView.Bairro;
                    pedidox.Endereco.Cidade = pedidoView.Cidade;
                    pedidox.Endereco.Estado = pedidoView.Estado;

                }





                await _pedidoRepositorio.Add(pedidox);

                return pedidox.PedidoId;
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
    }
}
