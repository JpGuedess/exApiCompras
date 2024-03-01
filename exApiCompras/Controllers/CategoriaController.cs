using exApiCompras.Models;
using exApiCompras.Repositorio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace exApiCompras.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaModels>> Create([FromBody] CategoriaModels categoriaModel)
        {
            CategoriaModels categoria = await _categoriaRepositorio.Create(categoriaModel);
            return Ok(categoria);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaModels>> Read(int id)
        {
            CategoriaModels categoria = await _categoriaRepositorio.Read(id);

            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriaModels>> Update(int id, [FromBody] CategoriaModels categoriaModel)
        {
            categoriaModel.Id = id;
            CategoriaModels categoria = await _categoriaRepositorio.Update(categoriaModel, id);
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriaModels>> Delete(int id)
        {
            bool apagado = await _categoriaRepositorio.Delete(id);
            return Ok(apagado);
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriaModels>>> ReadAll()
        {
            List<CategoriaModels> categorias = await _categoriaRepositorio.ReadAll();
            return Ok(categorias);
        }
    }
}
