using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entities;
using Infra.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class RepositorioSistemaFinanceiro : RepositoryGenerics<SistemaFinanceiro>, InterfaceSistemaFinanceiro
    {
        public Task<IList<SistemaFinanceiro>> ListaSistemasUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
