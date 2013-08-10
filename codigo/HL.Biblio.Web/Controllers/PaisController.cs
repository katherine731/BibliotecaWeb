using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HL.Biblio.BLL;
using HL.Biblio.POCO;

namespace HL.Biblio.Web.Controllers {
    public class PaisController : Controller {
        //
        // GET: /Pais/

        public ActionResult Index() {
            try {
                return View();
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        public ActionResult Lista() {
            try {
                return PartialView(PaisBLL.List());
            } catch(Exception ex) {
                return View("~/Views/Shared/ErrorSub.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // GET: /Pais/Details/5

        public ActionResult Details(int id) {
            try {
                Pais p = PaisBLL.Get(id);
                if(p != null)
                    return View(p);
                else
                    return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError("Nulo", "", "", "", ""));
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // GET: /Pais/Create

        public ActionResult Create() {
            return View();
        }

        //
        // POST: /Pais/Create

        [HttpPost]
        public ActionResult Create(Pais pais) {
            try {
                PaisBLL.Create(pais);
                return RedirectToAction("Index");
            } catch(Excepcion ec) {
                ViewBag.mensaje = new Models.Mensaje(ec.CreateMensaje(), Models.Mensaje.TipoMsg.error);
                return View("Create", pais);
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // GET: /Pais/Edit/5

        public ActionResult Edit(int id) {
            try {
                Pais p = PaisBLL.Get(id);
                if(p != null)
                    return View(p);
                else
                    return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError("Nulo", "", "", "", ""));
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // POST: /Pais/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Pais pais) {
            try {
                pais.Id = id;
                PaisBLL.Update(pais);
                return RedirectToAction("Index");
            } catch(Excepcion ec) {
                ViewBag.mensaje = new Models.Mensaje(ec.UpdateMensaje(), Models.Mensaje.TipoMsg.error);
                return View("Edit", pais);
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // POST: /Pais/Delete/5

        [HttpPost]
        public ActionResult Delete(int id) {
            try {
                BLL.PaisBLL.Delete(id);
                return View("Lista", BLL.PaisBLL.List());
            } catch(Excepcion ec) {
                ViewBag.mensaje = new Models.Mensaje(ec.DeleteMensaje(), Models.Mensaje.TipoMsg.error);
                return View("Lista", BLL.PaisBLL.List());
            } catch(Exception ex) {
                return View("~/Views/Shared/ErrorSub.cshtml", new Models.ManejadorError(ex));
            }
        }

        [HttpPost]
        public ActionResult CambiarEstado(int PaisID) {
            try {
                ViewBag.estado = BLL.PaisBLL.CambiarEstado(PaisID);
                return View("~/Views/Shared/Estado.cshtml");
            } catch {
                ViewBag.estado = -1;
                return View("~/Views/Shared/Estado.cshtml");
            }
        }
    }
}
