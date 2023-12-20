using Domain.Interfaces.ICategoria;
using Entities.Entities;
using Infra.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class RepositorioCategoria : RepositoryGenerics<Categoria>, InterfaceCategoria
    {
        public Task<IList<Categoria>> ListarCategoriaUsuario(string emailUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
