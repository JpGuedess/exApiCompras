using exApiCompras.Models;
using exApiCompras.Repositorio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace exApiCompras.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PedidoController(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        [HttpPost]
        public async Task<ActionResult<PedidoModels>> Create([FromBody] PedidoModels pedidoModels)
        {
            PedidoModels pedido = await _pedidoRepositorio.Create(pedidoModels);
            return Ok(pedido);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoModels>> Read(int id)
        {
            PedidoModels pedido = await _pedidoRepositorio.Read(id);

            return Ok(pedido);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PedidoModels>> Update(int id, [FromBody] PedidoModels pedidoModels)
        {
            pedidoModels.Id = id;
            PedidoModels pedido = await _pedidoRepositorio.Update(pedidoModels, id);
            return Ok(pedido);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PedidoModels>> Delete(int id)
        {
            bool apagado = await _pedidoRepositorio.Delete(id);
            return Ok(apagado);
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoModels>>> ReadAll()
        {
            List<PedidoModels> pedidos = await _pedidoRepositorio.ReadAll();
            return Ok(pedidos);
        }
    }
}
