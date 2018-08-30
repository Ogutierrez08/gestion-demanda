using MaestroDetalleDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaestroDetalleDemo.Controllers
{
    public class DemandadoController : Controller
    {
        PODER_JUDICIALEntities contexto = new PODER_JUDICIALEntities();
        // GET: Demanda
        public ActionResult Index(int id = 1)
        {

            return View(Buscar(id));
        }

        public ActionResult ContenedorRegistro()
        {
            return View();
        }
        public ActionResult ListDemandado(int id = 1)
        {

            return PartialView(Buscar(id));
        }

        public List<TB_DEMANDADO> Buscar(int pageIndex)
        {
            TB_DEMANDADO order = new TB_DEMANDADO();
            int pageCount = 0;
            List<TB_DEMANDADO> orders = order.Listar(pageIndex, 5, out pageCount);
            ViewBag.PageCount = pageCount;
            ViewBag.PageIndex = pageIndex;
            return orders;
        }


        public ActionResult Detalle(String id)
        {
            var data = contexto.TB_DEMANDADO_EMPRESA.Where(x => x.COD_DADO == id);
            
            
                return PartialView(data); 
        }

        public ActionResult Detalle2(String id)
        {
            var data = contexto.TB_DEMANDADO_PERSONA.Where(x => x.COD_DADO == id);


            return PartialView(data);
        }

        public ActionResult registrarCabezera()
        {
            TB_DEMANDADO d = new TB_DEMANDADO();
            d.COD_DADO = d.generarCodigo();

            var data = contexto.TB_REPRESENTANTE.ToList();
            SelectList lista = new SelectList(data,"COD_REPRE", "NOM_REPRE");
            ViewBag.Combo = lista;

            return View(d);
        }

        [HttpPost]
        public JsonResult registrarCabezera(TB_DEMANDADO collection)
        {
            try
            {
                var data = contexto.TB_REPRESENTANTE.ToList();
                SelectList lista = new SelectList(data, "COD_REPRE", "NOM_REPRE");
                ViewBag.Combo = lista;
                // TODO: Add insert logic here
                contexto.TB_DEMANDADO.Add(collection);
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




        public ActionResult registrarDetalle1()
        {
            TB_DEMANDADO_EMPRESA de = new TB_DEMANDADO_EMPRESA();
            TB_DEMANDADO d = new TB_DEMANDADO();
            de.COD_DADO = d.generarCodigoDetalle();
            return View(de);
        }

        [HttpPost]
        public JsonResult registrarDetalle1(TB_DEMANDADO_EMPRESA collection)
        {
            try
            {
                
                // TODO: Add insert logic here
                contexto.TB_DEMANDADO_EMPRESA.Add(collection);
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

        
        public ActionResult registrarDetalle2()
        {
            TB_DEMANDADO_PERSONA de = new TB_DEMANDADO_PERSONA();
            TB_DEMANDADO d = new TB_DEMANDADO();
            de.COD_DADO = d.generarCodigoDetalle();
            return View(de);
        }

        [HttpPost]
        public JsonResult registrarDetalle2(TB_DEMANDADO_PERSONA collection)
        {
            try
            {

                // TODO: Add insert logic here
                contexto.TB_DEMANDADO_PERSONA.Add(collection);
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
    }
}