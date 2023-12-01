using Microsoft.AspNetCore.Mvc;
using MiPrimeraAplicacionProgressiva.Clases;
using MiPrimeraAplicacionProgressiva.Models;

namespace MiPrimeraAplicacionProgressiva.Controllers
{
    public class AutorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<AutorCLS> listarAutor()
        {
            var lista = new List<AutorCLS>();
            using (DbAa2316BdbibliotecaContext bd = new DbAa2316BdbibliotecaContext())
            {
                lista = (from autor in bd.Autors
                         where autor.Bhabilitado == 1
                         select new AutorCLS
                         {
                             iidautor = autor.Iidautor,
                             nombreautor = autor.Nombre + " " + autor.Appaterno + " " + autor.Apmaterno
                         }).ToList();
            }
            return lista;
        }

    }
}
