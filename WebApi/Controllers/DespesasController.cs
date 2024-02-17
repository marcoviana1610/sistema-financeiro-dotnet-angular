using Domain.Interfaces.ICategoria;
using Domain.Interfaces.IDespesa;
using Domain.Interfaces.InterfaceServicos;
using Domain.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DespesasController : ControllerBase
    {
        private readonly InterfaceDespesa _interfaceDespesa;
        private readonly IDespesaService _despesaService;
        public DespesasController(IDespesaService despesaService, InterfaceDespesa interfaceDespesa)
        {
            _despesaService = despesaService;
            _interfaceDespesa = interfaceDespesa;
        }

        [HttpGet("/api/ListarDespesasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarDespesasUsuario(string emailUsuario)
        {
            return await _interfaceDespesa.ListarDespesasUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarDespesa")]
        [Produces("application/json")]
        public async Task<object> AdicionarDespesa(Despesa despesa)
        {
            await _despesaService.AdicionarDespesa(despesa);

            return despesa;
        }

        [HttpPut("/api/AtualizarDespesa")]
        [Produces("application/json")]
        public async Task<object> AtualizarDespesa(Despesa despesa)
        {
            await _despesaService.AtualizarDespesa(despesa);

            return despesa;
        }

        [HttpGet("/api/ObterDespesa")]
        [Produces("application/json")]
        public async Task<object> ObterDespesa(int id)
        {
            return await _interfaceDespesa.GetEntityById(id);
        }

        [HttpDelete("/api/DeleteDespesa")]
        [Produces("application/json")]
        public async Task<object> DeleteDespesa(int id)
        {
            try
            {
                var categoria = await _interfaceDespesa.GetEntityById(id);
                await _interfaceDespesa.Delete(categoria);

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        [HttpGet("/api/CarregaGraficos")]
        [Produces("application/json")]
        public async Task<object> CarregaGraficos(string emailUsuario)
        {
            return await _despesaService.CarregaGraficos(emailUsuario);
        }
    }
}
