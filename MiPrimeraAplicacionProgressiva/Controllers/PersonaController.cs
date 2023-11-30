using Microsoft.AspNetCore.Mvc;
using MiPrimeraAplicacionProgressiva.Clases;
using MiPrimeraAplicacionProgressiva.Models;


namespace MiPrimeraAplicacionProgressiva.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<PersonaCLS> listarPersonas(string nombreCompleto)
        {
            List<PersonaCLS> lista = new List<PersonaCLS>();
            using (DbAa2316BdbibliotecaContext bd = new DbAa2316BdbibliotecaContext())
            {
                if (nombreCompleto == null)
                    lista = (from persona in bd.Personas
                             where persona.Bhabilitado == 1
                             select new PersonaCLS
                             {
                                 iidpersona = persona.Iidpersona,
                                 nombreCompleto = persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno,
                                 correo = persona.Correo
                             }).ToList();
                else
                    lista = (from persona in bd.Personas
                             where persona.Bhabilitado == 1
                             && (persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno).Contains(nombreCompleto)
                             select new PersonaCLS
                             {
                                 iidpersona = persona.Iidpersona,
                                 nombreCompleto = persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno,
                                 correo = persona.Correo
                             }).ToList();
                return lista;
            }
        }
    }
}
