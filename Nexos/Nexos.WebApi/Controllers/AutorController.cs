using Nexos.DB.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nexos.WebApi.Controllers
{
    public class AutorController : ApiController
    {
        NexosPruebaEntities DB = new NexosPruebaEntities();

        [HttpGet]
        public IEnumerable<Autor> Get()
        {
            var listado = DB.Autor.ToList();
            return listado;
        }
        [HttpGet]
        public Autor Get(int id)
        {
            var autor = DB.Autor.FirstOrDefault(x => x.IdAutor == id);
            return autor;
        }

        [HttpPost]
        public bool post(Autor autor)
        {
            DB.Autor.Add(autor);
            return DB.SaveChanges() > 0;
        }

        [HttpPut]
        public bool put(Autor autor)
        {
            var autorActualizar = DB.Autor.FirstOrDefault(x => x.IdAutor == autor.IdAutor);
            autorActualizar.Nombre = autor.Nombre;
            autorActualizar.FechaNacimiento = autor.FechaNacimiento;
            autorActualizar.Ciudad = autor.Ciudad;
            autorActualizar.CorreoElectronico = autor.CorreoElectronico;
            

            return DB.SaveChanges() > 0;
        }

        [HttpDelete]
        public bool delete(int id)
        {
            var autorEliminar = DB.Autor.FirstOrDefault(x => x.IdAutor == id);
            DB.Autor.Remove(autorEliminar);
            return DB.SaveChanges() > 0;
        }
    }
}
