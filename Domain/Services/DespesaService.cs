using Domain.Interfaces.IDespesa;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class DespesaService : IDespesaService
    {
        private readonly InterfaceDespesa _interfaceDespesa;

        public DespesaService(InterfaceDespesa interfaceDespesa) 
        {
            _interfaceDespesa = interfaceDespesa;
        }

        public async Task AdicionarDespesa(Despesa despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataCadastro = data;
            despesa.Ano = data.Year;
            despesa.Mes = data.Month;

            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");
            if (valido)
                await _interfaceDespesa.Add(despesa);
        }

        public async Task AtualizarDespesa(Despesa despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataAlteracao = data;

            if (despesa.Pago)
            {
                despesa.DataPagamento = data;

            }

            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");



            if(valido)
                await _interfaceDespesa.Update(despesa);
        }

        public async Task<object> CarregaGraficos(string emailUsuario)
        {
            var despesasUsuario = await _interfaceDespesa.ListarDespesasUsuario(emailUsuario);

            var despesasAnterior = await _interfaceDespesa.ListarDespesasNaoPagasMesAnterior(emailUsuario);

            var despesasNaoPagasMesAnterior = despesasAnterior.Any() ? despesasAnterior.ToList().Sum(x => x.Valor) : 0;

            var despesasPagas = despesasUsuario.Where(d => d.Pago && d.TipoDespesa == Entities.Enums.EnumTipoDespesa.Contas).Sum(x => x.Valor);

            var despesasPendentes = despesasUsuario.Where(d => !d.Pago && d.TipoDespesa == Entities.Enums.EnumTipoDespesa.Contas).Sum(x => x.Valor);

            var investimentos = despesasUsuario.Where(d => d.TipoDespesa == Entities.Enums.EnumTipoDespesa.Investimento).Sum(x => x.Valor);

            return new
            {
                sucesso = "OK",
                despesas_pagas = despesasPagas,
                despesas_pendentes = despesasPendentes,
                despesas_naoPagasMesesAnteriores = despesasNaoPagasMesAnterior,
                investimentos = investimentos
            };
        }
    }
}
