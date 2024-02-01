using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UsuarioSistemaFinanceiroController : ControllerBase
    {
        private readonly InterfaceUsuarioSistemaFinanceiro _interfaceUsuarioSistemaFinanceiro;
        private readonly IUsuarioSistemaFinanceiroService _iusuarioSistemaFinanceiroService;

        public UsuarioSistemaFinanceiroController(InterfaceUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro, IUsuarioSistemaFinanceiroService iusuarioSistemaFinanceiroService)
        {
            _interfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
            _iusuarioSistemaFinanceiroService = iusuarioSistemaFinanceiroService;
        }

        [HttpGet("api/ListarUsuariosSistema")]
        [Produces("application/json")]
        public async Task<object> ListarUsuariosSistema(int idSistema)
        {
            return await _interfaceUsuarioSistemaFinanceiro.ListarUsuariosSistema(idSistema);
        }

        [HttpPost("api/CadastrarUsuarioNoSistema")]
        [Produces("application/json")]
        public async Task<object> CadastrarUsuarioNoSistema(int idSistema, string emailUsuario)
        {
            try
            {
                await _iusuarioSistemaFinanceiroService.CadastrarUsuarioNoSistema(new UsuarioSistemaFinanceiro
                {
                    IdSistema = idSistema,
                    EmailUsuario = emailUsuario,
                    Administrador = false,
                    SistemaAtual = true,
                });

            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }


            return Task.FromResult(true);
        }

        [HttpDelete("api/DeleteUsuarioSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteUsuarioSistemaFinanceiro(int id)
        {
            try
            {

                var usuarioSistemaFinanceiro = await _interfaceUsuarioSistemaFinanceiro.GetEntityById(id);

                await _interfaceUsuarioSistemaFinanceiro.Delete(usuarioSistemaFinanceiro);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }


            return Task.FromResult(true);
        }

    }
}
