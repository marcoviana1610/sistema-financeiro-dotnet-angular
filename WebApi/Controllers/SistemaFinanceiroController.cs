using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class SistemaFinanceiroController : ControllerBase
    {
        private readonly InterfaceSistemaFinanceiro _interfaceSistemaFinanceiro;
        private readonly ISistemaFinanceiroService _iSistemaFinanceiroService;

        public SistemaFinanceiroController(InterfaceSistemaFinanceiro interfaceSistemaFinanceiro,
            ISistemaFinanceiroService iSistemaFinanceiroService)
        {
            _interfaceSistemaFinanceiro = interfaceSistemaFinanceiro;
            _iSistemaFinanceiroService = iSistemaFinanceiroService;
        }

        [HttpGet("api/ListaSistemasUsuario")]
        [Produces("application/json")]  
        public async Task<object> ListaSistemasUsuario(string emailUsuario)
        {
            return await _interfaceSistemaFinanceiro.ListaSistemasUsuario(emailUsuario);
        }

        [HttpPost("api/AdicionarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _iSistemaFinanceiroService.AdicionarSistemaFinanceiro(sistemaFinanceiro);

            return Task.FromResult(sistemaFinanceiro);
        }
        
        [HttpPut("api/AtualizarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _iSistemaFinanceiroService.AtualizarSistemaFinanceiro(sistemaFinanceiro);

            return Task.FromResult(sistemaFinanceiro);
        }

        [HttpGet("api/ObterSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> ObterSistemaFinanceiro(int id)
        {
          return await _interfaceSistemaFinanceiro.GetEntityById(id);

        }

        [HttpDelete("api/DeleteSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteSistemaFinanceiro(int id)
        {
            var SistemaFinanceiro = await _interfaceSistemaFinanceiro.GetEntityById(id);

            try
            {
                await _interfaceSistemaFinanceiro.Delete(SistemaFinanceiro);
            } 
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
