using exApiCompras.Models;
using exApiCompras.Repositorio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace exApiCompras.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModels>> Create([FromBody] UsuarioModels usuarioModel)
        {
            UsuarioModels usuario = await _usuarioRepositorio.Create(usuarioModel);
            return Ok(usuario);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModels>> Read(int id)
        {
            UsuarioModels usuario = await _usuarioRepositorio.Read(id);

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModels>> Update(int id, [FromBody] UsuarioModels usuarioModel)
        {
            usuarioModel.Id = id;
            UsuarioModels usuario = await _usuarioRepositorio.Update(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModels>> Delete(int id)
        {
            bool apagado = await _usuarioRepositorio.Delete(id);
            return Ok(apagado);
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModels>>> ReadAll()
        {
            List<UsuarioModels> usuarios = await _usuarioRepositorio.ReadAll();
            return Ok(usuarios);
        }
    }
}
