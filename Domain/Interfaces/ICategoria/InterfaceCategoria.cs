﻿using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ICategoria
{
    public interface InterfaceCategoria : InterfaceGeneric<Categoria>
    {
        Task<IList<Categoria>> ListarCategoriaUsuario(string emailUsuario);
    }
}
