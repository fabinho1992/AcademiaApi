﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Models
{
    public sealed class Exercicio
    {
        public string Nome { get; set; }
        public int Serie { get; set; }
        public int Repeticao { get; set; }
        public string Musculo { get; set; }
    }
}
