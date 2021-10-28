using Newtonsoft.Json;
using Nexos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace Nexos.ViewWeb.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult Index()
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:61790/");
            var request = clienteHttp.GetAsync("api/Libro").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listaEmpleados = JsonConvert.DeserializeObject<List<LibroDTO>>(resultString);
                return View(listaEmpleados);
            }
            return View(new List<LibroDTO>());
        }
        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(LibroDTO libro)
        {  
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:61790/");
            var request = clienteHttp.PostAsync("api/Libro", libro, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var insertado = JsonConvert.DeserializeObject<bool>(resultString);
                if (insertado)
                {
                    return RedirectToAction("Index");
                }
                return View(libro);
            }
            return View(libro);

        }

        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:61790/");
            var request = clienteHttp.GetAsync("api/Libro?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var actualizado = JsonConvert.DeserializeObject<LibroDTO>(resultString);              
                return View(actualizado);
            }
            return View();

        }

        [HttpPost]
        public ActionResult Actualizar(LibroDTO libro)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:61790/");
            var request = clienteHttp.PutAsync("api/Libro", libro, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var insertado = JsonConvert.DeserializeObject<bool>(resultString);
                if (insertado)
                {
                    return RedirectToAction("Index");
                }
                return View(libro);
            }
            return View(libro);

        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:61790/");
            var request = clienteHttp.DeleteAsync("api/Libro?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var eliminado = JsonConvert.DeserializeObject<bool>(resultString);
                if (eliminado)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Detalle(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:61790/");
            var request = clienteHttp.GetAsync("api/Libro?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var actualizado = JsonConvert.DeserializeObject<LibroDTO>(resultString);
                return View(actualizado);
            }
            return View();
        }


    }
}