using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HL.Biblio.POCO;
using HL.Biblio.BLL;

namespace HL.Biblio.Web.Controllers {
    public class ClasificacionController : Controller {
        //
        // GET: /Clasificacion/

        public ActionResult Index() {
            try {
                return View();
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        public ActionResult Lista() {
            try {
                return PartialView(ClasificacionBLL.List());
            } catch {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        //
        // GET: /Clasificacion/Details/5

        public ActionResult Details(int id) {
            try {
                Clasificacion c = ClasificacionBLL.Get(id);
                if(c != null)
                    return View(c);
                else
                    return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError("Nulo", "", "", "", ""));
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // GET: /Clasificacion/Create

        public ActionResult Create() {
            return View();
        }

        //
        // POST: /Clasificacion/Create

        [HttpPost]
        public ActionResult Create(Clasificacion clasificacion) {
            try {
                ClasificacionBLL.Create(clasificacion);
                return RedirectToAction("Index");
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // GET: /Clasificacion/Edit/5

        public ActionResult Edit(int id) {
            try {
                Clasificacion c = ClasificacionBLL.Get(id);
                if(c != null)
                    return View(c);
                else
                    return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError("Nulo", "", "", "", ""));
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // POST: /Clasificacion/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Clasificacion clasificacion) {
            try {
                clasificacion.Id = id;
                ClasificacionBLL.Update(clasificacion);
                return RedirectToAction("Index");
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // POST: /Clasificacion/Delete/5

        [HttpPost]
        public ActionResult Delete(int id) {
            try {
                if(!BLL.ClasificacionBLL.Delete(id))
                    ViewBag.mensaje = "No se pudo eliminar el registro, tiene participacion en alguna transaccion.";
                return View("Lista", BLL.ClasificacionBLL.List());
            } catch(Exception ex) {
                return View("~/Views/Shared/ErrorSub.cshtml", new Models.ManejadorError(ex));
            }
        }

        [HttpPost]
        public ActionResult CambiarEstado(int ClasificacionId) {
            try {
                ViewBag.estado = BLL.ClasificacionBLL.CambiarEstado(ClasificacionId);
                return View("~/Views/Shared/Estado.cshtml");
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }
    }
}
