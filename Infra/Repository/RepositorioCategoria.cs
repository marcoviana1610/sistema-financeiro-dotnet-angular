using Domain.Interfaces.ICategoria;
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
    public class RepositorioCategoria : RepositoryGenerics<Categoria>, InterfaceCategoria
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public RepositorioCategoria()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Categoria>> ListarCategoriaUsuario(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (
                    from s in banco.sistemaFinanceiro
                     join c in banco.categorias on s.Id equals c.IdSistema
                     join us in banco.usuarioSistemaFinanceiro on s.Id equals us.IdSistema
                    where us.EmailUsuario.Equals(emailUsuario) && us.SistemaAtual
                    select c).AsNoTracking().ToListAsync();
            }
        }
    }
}
