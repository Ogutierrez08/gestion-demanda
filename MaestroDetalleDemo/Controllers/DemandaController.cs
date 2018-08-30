using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaestroDetalleDemo.Models;

namespace MaestroDetalleDemo.Controllers
{
    public class DemandaController : Controller
    {
        PODER_JUDICIALEntities contexto = new PODER_JUDICIALEntities();
        // GET: Demanda
        public ActionResult Index(int id = 1)
        {

            return View(Buscar(id));
        }

        public ActionResult ListDemanda(int id = 1)
        {

            return PartialView(Buscar(id));
        }

        public List<TB_DEMANDA> Buscar(int pageIndex)
        {
            TB_DEMANDA order = new TB_DEMANDA();
            int pageCount = 0;
            List<TB_DEMANDA> orders = order.Listar(pageIndex, 5, out pageCount);
            ViewBag.PageCount = pageCount;
            ViewBag.PageIndex = pageIndex;
            return orders;
        }
    

    public ActionResult Detalle(String id)
        {
            var data = contexto.TB_DETALLE_DEMANDA.Where(x => x.NUM_DEMANDA == id);
            return PartialView(data);
        }

    public ActionResult registrar()
        {
            TB_DEMANDA d = new TB_DEMANDA();
            d.NUM_DEMANDA = d.generarCodigo();
            TB_DEMANDADO o = new TB_DEMANDADO();
            d.COD_DADO = o.generarCodigoDetalle();
            TB_DEMANDANTE de= new TB_DEMANDANTE();
            d.COD_DANTE = de.generarCodigoDetalle();
            
            return View(d); 
        }

        [HttpPost]
        public JsonResult registrar(TB_DEMANDA collection)
        {
            try
            {

                // TODO: Add insert logic here
                contexto.TB_DEMANDA.Add(collection);
                contexto.SaveChanges();


                var mensaje = "Registro Correcto";
                return Json(mensaje);
            }
            catch
            {
                var error = "Error en el registro";
                return Json(error);
            }
        }

        public ActionResult registrarDetalle()
        {
            TB_DETALLE_DEMANDA de = new TB_DETALLE_DEMANDA();
            TB_DEMANDA d = new TB_DEMANDA();
            de.NUM_DEMANDA = d.generarCodigoDetalle();
            return View(de);
        }

        [HttpPost]
        public ActionResult registrarDetalle(TB_DETALLE_DEMANDA collection)
        {
            try
            {

                // TODO: Add insert logic here
                contexto.TB_DETALLE_DEMANDA.Add(collection);
                contexto.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                var error = "Error en el registro";
                return Json(error);
            }
        }

    }

}