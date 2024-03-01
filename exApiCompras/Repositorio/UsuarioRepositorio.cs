using exApiCompras.Data;
using exApiCompras.Models;
using exApiCompras.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace exApiCompras.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemasComprasDBContext _dbContext;
        public UsuarioRepositorio(SistemasComprasDBContext SistemasComprasDBContext)
        {
            _dbContext = SistemasComprasDBContext;
        }
        public async Task<UsuarioModels> Create(UsuarioModels usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModels> Read(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UsuarioModels> Update(UsuarioModels usuario, int id)
        {
            UsuarioModels usuarioPorId = await Read(id);


            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário do ID: {id} não foi encontrado");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Delete(int id)
        {
            UsuarioModels usuarioporid = await Read(id);
            if (usuarioporid == null)
            {
                throw new Exception($"Usuario do Id: {id} não foi encontrado");
            }

            _dbContext.Usuarios.Remove(usuarioporid);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<UsuarioModels>> ReadAll()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

    }
}
