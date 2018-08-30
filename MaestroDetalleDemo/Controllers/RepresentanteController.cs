using MaestroDetalleDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaestroDetalleDemo.Controllers
{
    public class RepresentanteController : Controller
    {
        // GET: Representante
        PODER_JUDICIALEntities contexto = new PODER_JUDICIALEntities();
        // GET: Demanda
        public ActionResult Index(int id = 1)
        {

            return View(Buscar(id));
        }

        public ActionResult ListRepresentante(int id = 1)
        {

            return PartialView(Buscar(id));
        }

        public List<TB_REPRESENTANTE> Buscar(int pageIndex)
        {
            TB_REPRESENTANTE order = new TB_REPRESENTANTE();
            int pageCount = 0;
            List<TB_REPRESENTANTE> orders = order.Listar(pageIndex, 5, out pageCount);
            ViewBag.PageCount = pageCount;
            ViewBag.PageIndex = pageIndex;
            return orders;
        }

        public ActionResult registrarRepre()
        {
            TB_REPRESENTANTE r = new TB_REPRESENTANTE();
            r.COD_REPRE = r.generarCodigo();
            return View(r);
        }

        [HttpPost]
       public JsonResult registrarRepre(TB_REPRESENTANTE collection)
        {
            try
            {

                contexto.TB_REPRESENTANTE.Add(collection);
                contexto.SaveChanges();
                var mensaje = "Registro correcto";
                return Json(mensaje);
            }
            catch (Exception e)
            {
                var error = "Error en el Registro";
                return Json(error);
            }
        }

     

    

}
}