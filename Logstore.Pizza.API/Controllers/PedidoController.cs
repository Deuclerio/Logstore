using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logstore.Pizza.Aplicacao.Cliente;
using Logstore.Pizza.Aplicacao.Pedido;
using Logstore.Pizza.Aplicacao.ViewModel;
using Logstore.Pizza.Dominio.Model;
using Logstore.Pizza.Dominio.Pedido;
using Logstore.Pizza.Dominio.Pizza;
using Logstore.Pizza.Infraestrutura.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logstore.Pizza.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoServices _repor;



        public PedidoController(IPedidoServices repor)
        {
            _repor = repor;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetHistoricoPedido(int ClienteId)
        {
            try
            {
                Response.StatusCode = 200;
                return Ok(_repor.GetHistorico(ClienteId));
            }
            catch (Exception ex)
            {
                Response.StatusCode = 404;
                return BadRequest("Erro ao cadastrar");
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PedidoViewModel pedido)
        {
            try
            {
                await _repor.Incluir(pedido);

                Response.StatusCode = 200;
                return Ok($"{pedido.PedidoId} Produto Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex) { StatusCode = StatusCodes.Status500InternalServerError, Value = ex.Message };
            }
        }
    }
}