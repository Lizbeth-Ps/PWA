using Microsoft.AspNetCore.Mvc;
using MiPrimeraAplicacionProgressiva.Clases;
using MiPrimeraAplicacionProgressiva.Models;

namespace MiPrimeraAplicacionProgressiva.Controllers
{
    public class NotificacionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string generarLlavePublica()
        {
            return Notificaciones.llavePublica;
        }

        public int guardarSubscripcion(SubscripcionCLS oSubscripcionCLS)
        {
            int rpta = 0;
            try
            {
                using (DbAa2316BdbibliotecaContext bd = new DbAa2316BdbibliotecaContext())
                {
                    Notificacione oNotificacione = new Notificacione();
                    oNotificacione.Endpointnotificacion = oSubscripcionCLS.endpoint;
                    oNotificacione.Authnotificacion = oSubscripcionCLS.auth;
                    oNotificacione.P256dhnotificacion = oSubscripcionCLS.p256dh;
                    oNotificacione.Bhabilitado = 1;
                    bd.Notificaciones.Add(oNotificacione);
                    bd.SaveChanges();
                    rpta = 1;

                }
            }
            catch (Exception ex)
            {
                rpta = 0;
            }

            return rpta;
        }


    }
}