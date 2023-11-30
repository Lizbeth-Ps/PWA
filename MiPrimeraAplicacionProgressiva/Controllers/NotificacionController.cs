using Microsoft.AspNetCore.Mvc;
using MiPrimeraAplicacionProgressiva.Clases;
using MiPrimeraAplicacionProgressiva.Models;
using WebPush;

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

        public async Task<int> enviarNotificaciones(string parametroPorContenido)
        {
            int rpta = 0;
            string subject = @"pwa2023pl@gmail.com";
            string clavePublica = Notificaciones.llavePublica;
            string clavePrivada = Notificaciones.llavePrivada;
            PushSubscription oPushSubscription;
            var vapidDetail = new VapidDetails(subject, clavePublica, clavePrivada);
            var webpushClient = new WebPushClient();
            try
            {
                using (DbAa2316BdbibliotecaContext bd = new DbAa2316BdbibliotecaContext())
                {
                    List<Notificacione> lista = bd.Notificaciones.ToList();
                    foreach (Notificacione oNotificacione in lista)
                    {
                        try
                        {
                            oPushSubscription = new PushSubscription(oNotificacione.Endpointnotificacion,
                                oNotificacione.P256dhnotificacion, oNotificacione.Authnotificacion);
                            await webpushClient.SendNotificationAsync(oPushSubscription, parametroPorContenido
                                , vapidDetail);

                            rpta = 1;


                        }
                        catch (WebPushException ex)
                        {
                            if (ex.StatusCode.ToString() == "Gone")
                            {
                                bd.Remove(oNotificacione);
                                bd.SaveChanges();
                                rpta = 1;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                rpta = 0;
            }



            return rpta;
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