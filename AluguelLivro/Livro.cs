﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelLivro
{
    public class Livro
    {
        public long NumeroTombo { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Autor { get; set; }

        public override string ToString()
        {
            return $"{NumeroTombo},{ISBN},{Titulo},{Genero},{DataPublicacao.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)},{Autor}";
        }
    }
}
