using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Dominio
{
    public class LibroDTO
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Año { get; set; }
        public string Genero { get; set; }
        public string NumeroPaginas { get; set; }
        public int IdAutor { get; set; }
    }
}
