using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Dominio
{
    public class AutorDTO
    {
        public int IdAutor { get; set; }
        public string Nombre { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Ciudad { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
