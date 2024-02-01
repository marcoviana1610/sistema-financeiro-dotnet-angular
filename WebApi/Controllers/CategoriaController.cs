using Domain.Interfaces.ICategoria;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CategoriaController : ControllerBase
    {
        private readonly InterfaceCategoria _interfaceCategoria;
        private readonly ICategoriaService _iCategoriaService;

        public CategoriaController(InterfaceCategoria interfaceCategoria, ICategoriaService iCategoriaService)
        {
            _iCategoriaService = iCategoriaService;
            _interfaceCategoria = interfaceCategoria;
        }

        [HttpGet("/api/ListarCategoriaUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarCategoriaUsuario(string emailUsuario)
        {
            return await _interfaceCategoria.ListarCategoriaUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarCategoria")]
        [Produces("application/json")]
        public async Task<object> AdicionarCategoria(Categoria categoria)
        {
            await _iCategoriaService.AdicionarCategoria(categoria);

            return categoria;
        }

        [HttpPut("/api/AtualizarCategoria")]
        [Produces("application/json")]
        public async Task<object> AtualizarCategoria(Categoria categoria)
        {
            await _iCategoriaService.AtualizarCategoria(categoria);

            return categoria;
        }

        [HttpGet("/api/ObterCategoria")]
        [Produces("application/json")]
        public async Task<object> ObterCategoria(int id)
        {
            return await _interfaceCategoria.GetEntityById(id);
        }


        [HttpDelete("/api/DeleteCategoria")]
        [Produces("application/json")]
        public async Task<object> DeleteCategoria(int id)
        {
            try
            {
                var categoria = await _interfaceCategoria.GetEntityById(id);
                await _interfaceCategoria.Delete(categoria);

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }



    }
}