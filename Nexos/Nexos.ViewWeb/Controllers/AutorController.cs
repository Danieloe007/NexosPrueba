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
    public class AutorController : Controller
    {
        // GET: Autor
        public ActionResult Index()
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:61790/");
            var request = clienteHttp.GetAsync("api/Autor").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listaEmpleados = JsonConvert.DeserializeObject<List<AutorDTO>>(resultString);
                return View(listaEmpleados);
            }
            return View(new List<AutorDTO>());
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(AutorDTO autor)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:61790/");
            var request = clienteHttp.PostAsync("api/Autor", autor, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var insertado = JsonConvert.DeserializeObject<bool>(resultString);
                if (insertado)
                {
                    return RedirectToAction("Index");
                }
                return View(autor);
            }
            return View(autor);

        }

        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:61790/");
            var request = clienteHttp.GetAsync("api/Autor?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var actualizado = JsonConvert.DeserializeObject<AutorDTO>(resultString);
                return View(actualizado);
            }
            return View();

        }

        [HttpPost]
        public ActionResult Actualizar(AutorDTO autor)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:61790/");
            var request = clienteHttp.PutAsync("api/Autor", autor, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var insertado = JsonConvert.DeserializeObject<bool>(resultString);
                if (insertado)
                {
                    return RedirectToAction("Index");
                }
                return View(autor);
            }
            return View(autor);

        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:61790/");
            var request = clienteHttp.DeleteAsync("api/Autor?id=" + id).Result;

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
            var request = clienteHttp.GetAsync("api/Autor?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var actualizado = JsonConvert.DeserializeObject<AutorDTO>(resultString);
                return View(actualizado);
            }
            return View();
        }
    }
}