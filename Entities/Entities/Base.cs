﻿using Entities.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Base : Notifica
    {
        [Display(Name = "Codigo")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }    
    }
}
