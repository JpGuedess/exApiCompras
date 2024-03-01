using exApiCompras.Models;
using exApiCompras.Repositorio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace exApiCompras.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PedidosProdutosController : ControllerBase
    {
        private readonly IPedidosProdutosRepositorio _pedidosProdutosRepositorio;

        public PedidosProdutosController(IPedidosProdutosRepositorio pedidosProdutosRepositorio)
        {
            _pedidosProdutosRepositorio = pedidosProdutosRepositorio;
        }

        [HttpPost]
        public async Task<ActionResult<PedidosProdutosModels>> Create([FromBody] PedidosProdutosModels pedidosProdutosModel)
        {
            PedidosProdutosModels pedidosProdutos = await _pedidosProdutosRepositorio.Create(pedidosProdutosModel);
            return Ok(pedidosProdutos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidosProdutosModels>> Read(int id)
        {
            PedidosProdutosModels pedidosProdutos = await _pedidosProdutosRepositorio.Read(id);

            return Ok(pedidosProdutos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PedidosProdutosModels>> Update(int id, [FromBody] PedidosProdutosModels pedidosProdutosModel)
        {
            pedidosProdutosModel.Id = id;
            PedidosProdutosModels pedidosProdutos = await _pedidosProdutosRepositorio.Update(pedidosProdutosModel, id);
            return Ok(pedidosProdutos);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PedidosProdutosModels>> Delete(int id)
        {
            bool apagado = await _pedidosProdutosRepositorio.Delete(id);
            return Ok(apagado);
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidosProdutosModels>>> ReadAll()
        {
            List<PedidosProdutosModels> pedidosProdutos = await _pedidosProdutosRepositorio.ReadAll();
            return Ok(pedidosProdutos);
        }
    }
}
