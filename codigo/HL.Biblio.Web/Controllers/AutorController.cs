using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HL.Biblio.POCO;
using HL.Biblio.BLL;

namespace HL.Biblio.Web.Controllers {
    public class AutorController : Controller {
        //
        // GET: /Autor/

        public ActionResult Index() {
            try {
                return View();
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        public ActionResult Lista() {
            try {
                return PartialView(AutorBLL.List2());
            } catch(Exception ex) {
                return View("~/Views/Shared/ErrorSub.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // GET: /Autor/Details/5

        public ActionResult Details(int id) {
            try {
                Autor a = AutorBLL.Get(id);
                if(a != null)
                    return View(a);
                else
                    return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError("Nulo", "", "", "", ""));
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // GET: /Autor/Create

        public ActionResult Create() {
            ViewBag.Paises = BLL.PaisBLL.ListActivos();
            return View();
        }

        //
        // POST: /Autor/Create

        [HttpPost]
        public ActionResult Create(Autor autor) {
            try {
                AutorBLL.Create(autor);
                return RedirectToAction("Index");
            } catch(Excepcion ec) {
                ViewBag.mensaje = new Models.Mensaje(ec.CreateMensaje(), Models.Mensaje.TipoMsg.error);
                return View("Create", autor);
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // GET: /Autor/Edit/5

        public ActionResult Edit(int id) {
            try {
                ViewBag.Paises = BLL.PaisBLL.ListActivos();
                Autor a = AutorBLL.Get(id);
                if(a != null && ViewBag.Paises != null)
                    return View(a);
                else
                    return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError("Nulo", "", "", "", ""));
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // POST: /Autor/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Autor autor) {
            try {
                autor.Id = id;
                AutorBLL.Update(autor);
                return RedirectToAction("Index");
            } catch(Excepcion ec) {
                ViewBag.mensaje = new Models.Mensaje(ec.UpdateMensaje(), Models.Mensaje.TipoMsg.error);
                ViewBag.Paises = BLL.PaisBLL.ListActivos();
                return View("Edit", autor);
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // POST: /Autor/Delete/5

        [HttpPost]
        public ActionResult Delete(int id) {
            try {
                BLL.AutorBLL.Delete(id);
                return View("Lista", BLL.AutorBLL.List2());
            } catch(Excepcion ec) {
                ViewBag.mensaje = new Models.Mensaje(ec.DeleteMensaje(), Models.Mensaje.TipoMsg.error);
                return View("Lista", BLL.AutorBLL.List2());
            } catch(Exception ex) {
                return View("~/Views/Shared/ErrorSub.cshtml", new Models.ManejadorError(ex));
            }
        }

        [HttpPost]
        public ActionResult CambiarEstado(int AutorId) {
            try {
                ViewBag.estado = BLL.AutorBLL.CambiarEstado(AutorId);
                return View("~/Views/Shared/Estado.cshtml");
            } catch {
                ViewBag.estado = -1;
                return View("~/Views/Shared/Estado.cshtml");
            }
        }
    }
}
