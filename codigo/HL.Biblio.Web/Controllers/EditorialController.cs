using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HL.Biblio.BLL;
using HL.Biblio.POCO;

namespace HL.Biblio.Web.Controllers {
    public class EditorialController : Controller {
        //
        // GET: /Editorial/

        public ActionResult Index() {
            try {
                return View();
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        public ActionResult Lista() {
            try {
                return PartialView(EditorialBLL.List2());
            } catch {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        //
        // GET: /Editorial/Details/5

        public ActionResult Details(int id) {
            try {
                Editorial e = EditorialBLL.Get(id);
                if(e != null)
                    return View(EditorialBLL.Get(id));
                else
                    return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError("Nulo", "", "", "", ""));
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // GET: /Editorial/Create

        public ActionResult Create() {
            ViewBag.Paises = BLL.PaisBLL.ListActivos();
            return View();
        }

        //
        // POST: /Editorial/Create

        [HttpPost]
        public ActionResult Create(Editorial editorial) {
            try {
                EditorialBLL.Create(editorial);
                return RedirectToAction("Index");
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // GET: /Editorial/Edit/5

        public ActionResult Edit(int id) {
            try {
                ViewBag.Paises = BLL.PaisBLL.ListActivos();
                Editorial e = EditorialBLL.Get(id);
                if(e != null && ViewBag.Paises != null)
                    return View(e);
                else
                    return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError("Nulo", "", "", "", ""));
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // POST: /Editorial/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Editorial editorial) {
            try {
                editorial.Id = id;
                EditorialBLL.Update(editorial);
                return RedirectToAction("Index");
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // POST: /Editorial/Delete/5

        [HttpPost]
        public ActionResult Delete(int id) {
            try {
                if(!BLL.EditorialBLL.Delete(id))
                    ViewBag.mensaje = "No se pudo eliminar el registro, tiene participacion en alguna transaccion.";
                return View("Lista", BLL.EditorialBLL.List2());
            } catch(Exception ex) {
                return View("~/Views/Shared/ErrorSub.cshtml", new Models.ManejadorError(ex));
            }
        }

        [HttpPost]
        public ActionResult CambiarEstado(int EditorialID) {
            try {
                ViewBag.estado = BLL.EditorialBLL.CambiarEstado(EditorialID);
                return View("~/Views/Shared/Estado.cshtml");
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }
    }
}
