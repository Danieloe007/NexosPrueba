using Nexos.DB.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nexos.WebApi.Controllers
{
    public class LibroController : ApiController
    {
        NexosPruebaEntities DB = new NexosPruebaEntities();
        
        [HttpGet]
        public IEnumerable<Libro> Get() 
        {
            var listado = DB.Libro.ToList();
            return listado;
        }
        [HttpGet]
        public Libro Get(int id)
        {
            var libro = DB.Libro.FirstOrDefault(x => x.IdLibro == id);
            return libro;
        }

        [HttpPost]
        public bool post(Libro libro)
        {
           DB.Libro.Add(libro);            
            return DB.SaveChanges() > 0;
        }

        [HttpPut]
        public bool put(Libro libro)
        {
            var libroActualizar = DB.Libro.FirstOrDefault(x => x.IdLibro == libro.IdLibro);
            libroActualizar.Titulo = libro.Titulo;
            libroActualizar.Año = libro.Año;
            libroActualizar.Genero = libro.Genero;
            libroActualizar.NumeroPaginas = libro.NumeroPaginas;
            libroActualizar.IdAutor = libro.IdAutor;

            return DB.SaveChanges() > 0;
        }

        [HttpDelete]
        public bool delete(int id)
        {
            var empleadoEliminar = DB.Libro.FirstOrDefault(x => x.IdLibro == id);
            DB.Libro.Remove(empleadoEliminar);
            return DB.SaveChanges() > 0;
        }
    }
}
