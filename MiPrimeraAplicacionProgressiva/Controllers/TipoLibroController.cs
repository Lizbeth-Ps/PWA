using Microsoft.AspNetCore.Mvc;
using MiPrimeraAplicacionProgressiva.Clases;
using MiPrimeraAplicacionProgressiva.Models;
namespace MiPrimeraAplicacionProgressiva.Controllers
{
    public class TipoLibroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<TipoLibroCLS> listarTipoLibro(string nombretipolibrobusqueda)
        {
            List<TipoLibroCLS> lista = new List<TipoLibroCLS>();
            using (DbAa2316BdbibliotecaContext bd = new DbAa2316BdbibliotecaContext())
            {
                if (nombretipolibrobusqueda == null)
                    lista = (from tipolibro in bd.TipoLibros
                             where tipolibro.Bhabilitado == 1
                             select new TipoLibroCLS
                             {
                                 iidtipolibro = tipolibro.Iidtipolibro,
                                 nombre = tipolibro.Nombretipolibro,
                                 descripcion = tipolibro.Descripcion
                             }).ToList();
                else
                    lista = (from tipolibro in bd.TipoLibros
                             where tipolibro.Bhabilitado == 1 &&
                             tipolibro.Nombretipolibro.Contains(nombretipolibrobusqueda)
                             select new TipoLibroCLS
                             {
                                 iidtipolibro = tipolibro.Iidtipolibro,
                                 nombre = tipolibro.Nombretipolibro,
                                 descripcion = tipolibro.Descripcion
                             }).ToList();
                return lista;

            }


        }

        public TipoLibroCLS recuperarTipoLibro(int id)
        {
            using (DbAa2316BdbibliotecaContext bd = new DbAa2316BdbibliotecaContext())
            {
                TipoLibroCLS oTipoLibroCLS = new TipoLibroCLS();
                TipoLibro oTipoLibro =
                            bd.TipoLibros.Where(p => p.Iidtipolibro == id).First();
                oTipoLibroCLS.iidtipolibro = oTipoLibro.Iidtipolibro;
                oTipoLibroCLS.nombre = oTipoLibro.Nombretipolibro;
                oTipoLibroCLS.descripcion = oTipoLibro.Descripcion;
                return oTipoLibroCLS;
            }

        }

        public int guardarTipoLibro(TipoLibroCLS oTipoLibroCLS)
        {
            int rpta = 0;
            using (DbAa2316BdbibliotecaContext bd = new DbAa2316BdbibliotecaContext())
            {
                try
                {
                    if (oTipoLibroCLS.iidtipolibro == 0)
                    {
                        TipoLibro oTipoLibro = new TipoLibro();
                        oTipoLibro.Nombretipolibro = oTipoLibroCLS.nombre;
                        oTipoLibro.Descripcion = oTipoLibroCLS.descripcion;
                        oTipoLibro.Bhabilitado = 1;
                        bd.TipoLibros.Add(oTipoLibro);
                        bd.SaveChanges();
                        rpta = 1;
                    }
                    else
                    {
                        TipoLibro oTipoLibro =
                            bd.TipoLibros.Where(p => p.Iidtipolibro == oTipoLibroCLS.iidtipolibro).First();
                        oTipoLibro.Nombretipolibro = oTipoLibroCLS.nombre;
                        oTipoLibro.Descripcion = oTipoLibroCLS.descripcion;
                        bd.SaveChanges();
                        rpta = 1;
                    }
                }
                catch (Exception ex)
                {
                    rpta = 0;
                }



            }
            return rpta;
        }




    }
}