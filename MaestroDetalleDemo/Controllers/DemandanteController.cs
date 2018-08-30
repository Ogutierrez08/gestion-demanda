using MaestroDetalleDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaestroDetalleDemo.Controllers
{
    public class DemandanteController : Controller
    {
        // GET: Demandante
        PODER_JUDICIALEntities contexto = new PODER_JUDICIALEntities();
        // GET: Demanda
        public ActionResult Index(int id = 1)
        {

            return View(Buscar(id));
        }

        public ActionResult ListDemandante(int id = 1)
        {

            return PartialView(Buscar(id));
        }

        public List<TB_DEMANDANTE> Buscar(int pageIndex)
        {
            TB_DEMANDANTE order = new TB_DEMANDANTE();
            int pageCount = 0;
            List<TB_DEMANDANTE> orders = order.Listar(pageIndex, 5, out pageCount);
            ViewBag.PageCount = pageCount;
            ViewBag.PageIndex = pageIndex;
            return orders;
        }
        
        public ActionResult registrarDemandante()
        {

            TB_DEMANDANTE d = new TB_DEMANDANTE();
            d.COD_DANTE = d.generarCodigo();

            var data = contexto.TB_REPRESENTANTE.ToList();
            SelectList listaR = new SelectList(data, "COD_REPRE", "NOM_REPRE");
            ViewBag.Combo2 = listaR;
            return View(d);
        }

        [HttpPost]
        public JsonResult registrarDemandante(TB_DEMANDANTE collection)
        {
            try
            {
                contexto.TB_DEMANDANTE.Add(collection);
                contexto.SaveChanges();
                var mensaje = "Registro Correcto";
                return Json(mensaje);
            }
            catch (Exception)
            {
                var error = "Registro Incorrecto";
                return Json(error);
                throw;
            }
        }

    }
}