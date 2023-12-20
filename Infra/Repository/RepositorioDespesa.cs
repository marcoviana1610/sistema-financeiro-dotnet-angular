using Domain.Interfaces.IDespesa;
using Entities.Entities;
using Infra.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class RepositorioDespesa : RepositoryGenerics<Despesa>, InterfaceDespesa
    {
        public Task<IList<Despesa>> ListarDespesasNaoPagasMesAnterior(string emailUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Despesa>> ListarDespesasUsuario(string emailUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
