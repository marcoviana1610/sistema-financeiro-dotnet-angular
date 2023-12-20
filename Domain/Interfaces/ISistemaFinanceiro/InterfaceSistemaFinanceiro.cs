﻿using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ISistemaFinanceiro
{
    public interface InterfaceSistemaFinanceiro : InterfaceGeneric<SistemaFinanceiro>
    {
        Task<IList<SistemaFinanceiro>> ListaSistemasUsuario();
    }
}
