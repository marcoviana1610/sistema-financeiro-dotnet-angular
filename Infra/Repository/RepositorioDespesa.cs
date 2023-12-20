using Domain.Interfaces.IDespesa;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class RepositorioDespesa : RepositoryGenerics<Despesa>, InterfaceDespesa
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;


        public RepositorioDespesa()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }


        public async Task<IList<Despesa>> ListarDespesasNaoPagasMesAnterior(string emailUsuario)
        {

            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from s in banco.sistemaFinanceiro
                     join c in banco.categorias on s.Id equals c.IdSistema
                     join us in banco.usuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     join d in banco.despesas on c.Id equals d.IdCategoria
                     where us.EmailUsuario.Equals(emailUsuario) && d.Mes < DateTime.Now.Month && !d.Pago
                     select d).AsNoTracking().ToListAsync();
            }

        }

        public async Task<IList<Despesa>> ListarDespesasUsuario(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {   
                return await
                    (from s in banco.sistemaFinanceiro
                     join c in banco.categorias on s.Id equals c.IdSistema
                     join us in banco.usuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     join d in banco.despesas on c.Id equals d.IdCategoria
                     where us.EmailUsuario.Equals(emailUsuario) && s.Mes == d.Mes && s.Ano == d.Ano
                     select d).AsNoTracking().ToListAsync();
            }
        }
    }
}
