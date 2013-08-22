using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HL.Biblio.POCO;
using HL.Biblio.BLL;

namespace HL.Biblio.Web.Controllers {
    public class LibroController : Controller {
        private const string S_LibEjem = "S_LibEjem";
        private const string S_LibEjemDel = "S_LibEjemDel";

        private List<Ejemplar> ListaLibEjem {
            get {
                if(Session[S_LibEjem] == null)
                    Session[S_LibEjem] = new List<Ejemplar>();
                return (List<Ejemplar>)Session[S_LibEjem];
            }
            set {
                Session[S_LibEjem] = value;
            }
        }

        private List<Ejemplar> ListaLibEjemDel {
            get {
                if(Session[S_LibEjemDel] == null)
                    Session[S_LibEjemDel] = new List<Ejemplar>();
                return (List<Ejemplar>)Session[S_LibEjemDel];
            }
            set {
                Session[S_LibEjemDel] = value;
            }
        }

        //
        // GET: /Libro/

        public ActionResult Index() {
            try {
                ListaLibEjem = null;
                ListaLibEjemDel = null;
                return View();
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        public ActionResult Lista() {
            try {
                return PartialView(LibroBLL.List2());
            } catch(Exception ex) {
                return View("~/Views/Shared/ErrorSub.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // GET: /Libro/Details/5

        public ActionResult Details(int id) {
            try {
                Libro l = LibroBLL.Get(id);
                if(l != null)
                    return View(l);
                else
                    return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError("Nulo", "", "", "", ""));
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // GET: /Libro/Create

        public ActionResult Create() {
            ViewBag.ffFecha = DateTime.Now.ToString("dd/MM/yyyy");
            ListaLibEjem = null;
            ListaLibEjemDel = null;
            ViewBag.Autores = AutorBLL.ListActivos();
            ViewBag.Editoriales = EditorialBLL.ListActivos();
            ViewBag.Clasificaciones = ClasificacionBLL.ListActivos();
            return View();
        }

        //
        // POST: /Libro/Create

        [HttpPost]
        public ActionResult Create(Libro libro) {
            try {
                libro.Ejemplares = ListaLibEjem;
                LibroBLL.Create(libro);
                return RedirectToAction("Index");
            } catch(Excepcion ec) {
                ViewBag.mensaje = new Models.Mensaje(ec.CreateMensaje(), Models.Mensaje.TipoMsg.error);
                ViewBag.Autores = AutorBLL.ListActivos();
                ViewBag.Editoriales = EditorialBLL.ListActivos();
                ViewBag.Clasificaciones = ClasificacionBLL.ListActivos();
                return View("Create", libro);
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // GET: /Libro/Edit/5

        public ActionResult Edit(int id) {
            ListaLibEjem = null;
            ListaLibEjemDel = null;
            try {
                Libro l = LibroBLL.Get(id);
                if(l != null) {
                    ViewBag.Autores = AutorBLL.ListActivos();
                    ViewBag.Editoriales = EditorialBLL.ListActivos();
                    ViewBag.Clasificaciones = ClasificacionBLL.ListActivos();
                    return View(l);
                } else
                    return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError("Nulo", "", "", "", ""));
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // POST: /Libro/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Libro libro) {
            try {
                libro.Id = id;
                libro.Ejemplares = ListaLibEjem;
                LibroBLL.Update(libro);
                ListaLibEjem = null;
                ListaLibEjemDel = null;
                return RedirectToAction("Index");
            } catch(Excepcion ec) {
                ViewBag.mensaje = new Models.Mensaje(ec.UpdateMensaje(), Models.Mensaje.TipoMsg.error);
                ViewBag.Autores = AutorBLL.ListActivos();
                ViewBag.Editoriales = EditorialBLL.ListActivos();
                ViewBag.Clasificaciones = ClasificacionBLL.ListActivos();
                return View("Edit", libro);
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // POST: /Libro/Delete/5

        [HttpPost]
        public ActionResult Delete(int id) {
            try {
                BLL.LibroBLL.Delete(id);
                return View("Lista", BLL.LibroBLL.List2());
            } catch(Excepcion ec) {
                ViewBag.mensaje = new Models.Mensaje(ec.DeleteMensaje(), Models.Mensaje.TipoMsg.error);
                return View("Lista", BLL.LibroBLL.List2());
            } catch(Exception ex) {
                return View("~/Views/Shared/ErrorSub.cshtml", new Models.ManejadorError(ex));
            }
        }

        [HttpPost]
        public ActionResult CambiarEstado(int LibroId) {
            try {
                ViewBag.estado = BLL.LibroBLL.CambiarEstado(LibroId);
                return View("~/Views/Shared/Estado.cshtml");
            } catch {
                ViewBag.estado = -1;
                return View("~/Views/Shared/Estado.cshtml");
            }
        }
    }
}
