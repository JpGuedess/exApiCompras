using exApiCompras.Models;
using exApiCompras.Repositorio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace exApiCompras.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModels>> Create([FromBody] ProdutoModels produtoModels)
        {
            ProdutoModels produto = await _produtoRepositorio.Create(produtoModels);
            return Ok(produto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModels>> Read(int id)
        {
            ProdutoModels produto = await _produtoRepositorio.Read(id);

            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoModels>> Update(int id, [FromBody] ProdutoModels produtoModels)
        {
            produtoModels.Id = id;
            ProdutoModels produto = await _produtoRepositorio.Update(produtoModels, id);
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoModels>> Delete(int id)
        {
            bool apagado = await _produtoRepositorio.Delete(id);
            return Ok(apagado);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoModels>>> ReadAll()
        {
            List<ProdutoModels> produtos = await _produtoRepositorio.ReadAll();
            return Ok(produtos);
        }
    }
}
