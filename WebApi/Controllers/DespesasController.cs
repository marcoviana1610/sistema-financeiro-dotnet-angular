using Domain.Interfaces.IDespesa;
using Domain.Interfaces.InterfaceServicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
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
    }
}
