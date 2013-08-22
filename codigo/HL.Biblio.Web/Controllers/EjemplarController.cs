using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HL.Biblio.POCO;
using HL.Biblio.BLL;

namespace HL.Biblio.Web.Controllers {
    public class EjemplarController : Controller {
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
        // GET: /Ejemplar/

        public ActionResult Index(int LibroId) {
            try {
                ViewBag.LibroId = LibroId;
                return View();
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        public ActionResult Lista(int LibroId) {
            try {
                if(LibroId > 0) {
                    if(Session[S_LibEjem] == null) {
                        ListaLibEjem = LibroBLL.ListEjemplar(LibroId);
                        ListaLibEjemDel = null;
                    }
                } else {
                    if(Session[S_LibEjem] == null)
                        ListaLibEjemDel = null;
                }
                return PartialView(ListaLibEjem);
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        public ActionResult ListaDetails(int LibroId) {
            try {
                if(LibroId > 0) {
                    if(Session[S_LibEjem] == null) {
                        ListaLibEjem = LibroBLL.ListEjemplar(LibroId);
                        ListaLibEjemDel = null;
                    }
                } else {
                    if(Session[S_LibEjem] == null)
                        ListaLibEjemDel = null;
                }
                return PartialView(ListaLibEjem);
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        private int validar(Ejemplar ejemplar) {
            List<Ejemplar> le = ListaLibEjem;
            foreach(Ejemplar e in le) {
                if(!string.IsNullOrEmpty(e.Codigo) && !string.IsNullOrEmpty(ejemplar.Codigo) && e.Codigo == ejemplar.Codigo && e.Id != ejemplar.Id)
                    return 1;
                if(!string.IsNullOrEmpty(e.CodBarras) && !string.IsNullOrEmpty(ejemplar.CodBarras) && e.CodBarras == ejemplar.CodBarras && e.Id != ejemplar.Id)
                    return 2;
                if(!string.IsNullOrEmpty(e.CodRFID) && !string.IsNullOrEmpty(ejemplar.CodRFID) && e.CodRFID == ejemplar.CodRFID && e.Id != ejemplar.Id)
                    return 3;
            }
            return 0;
        }

        //
        // GET: /Ejemplar/Create

        public ActionResult Create(int LibroId) {
            ViewBag.LibroId = LibroId;
            return View();
        }

        //
        // POST: /Ejemplar/Create
        [HttpPost]
        public ActionResult Create(Ejemplar ejemplar) {
            try {
                int v = validar(ejemplar);
                if(v == 1)
                    throw new Excepcion("Código duplicado '" + ejemplar.Codigo + "'");
                if(v == 2)
                    throw new Excepcion("Código de barras duplicado '" + ejemplar.CodBarras + "'");
                if(v == 3)
                    throw new Excepcion("Código RFID duplicado '" + ejemplar.CodRFID + "'");
                List<Ejemplar> le = ListaLibEjem;
                int j = -1;
                foreach(Ejemplar e in le)
                    if(e.Id < 0) {
                        e.Id = j;
                        j--;
                    }
                ejemplar.Id = j;
                le.Add(ejemplar);
                return View("Lista", ListaLibEjem);
            } catch(Excepcion ec) {
                ViewBag.mensaje = new Models.Mensaje(ec.AddDetailMensaje(), Models.Mensaje.TipoMsg.error);
                ViewBag.LibroId = ejemplar.Libro.Id;
                return View("Create", ejemplar);
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // GET: /Ejemplar/Edit/5

        public ActionResult Edit(int id) {
            try {
                Ejemplar e = ListaLibEjem.Where(l => l.Id == id).FirstOrDefault();
                if(e != null) {
                    return View(e);
                } else
                    return View("~/Views/Shared/ErrorSub.cshtml", new Models.ManejadorError("Nulo", "", "", "", ""));
            } catch(Exception ex) {
                return View("~/Views/Shared/ErrorSub.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // POST: /Ejemplar/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Ejemplar ejemplar) {
            try {
                int v = validar(ejemplar);
                if(v == 1)
                    throw new Excepcion("Código duplicado '" + ejemplar.Codigo + "'");
                if(v == 2)
                    throw new Excepcion("Código de barras duplicado '" + ejemplar.CodBarras + "'");
                if(v == 3)
                    throw new Excepcion("Código RFID duplicado '" + ejemplar.CodRFID + "'");
                Ejemplar e1 = ListaLibEjem.Where(e => e.Id == id).FirstOrDefault();
                e1.CodBarras = ejemplar.CodBarras;
                e1.Codigo = ejemplar.Codigo;
                e1.CodRFID = ejemplar.CodRFID;
                e1.Estado = ejemplar.Estado;
                e1.TipoPrestamo = ejemplar.TipoPrestamo;
                e1.Ubicacion = ejemplar.Ubicacion;
                return View("Lista", ListaLibEjem);
            } catch(Excepcion ec) {
                ViewBag.mensaje = new Models.Mensaje(ec.UpdateDetailMensaje(), Models.Mensaje.TipoMsg.error);
                return View("Edit", ejemplar);
            } catch(Exception ex) {
                return View("~/Views/Shared/Error.cshtml", new Models.ManejadorError(ex));
            }
        }

        //
        // POST: /Ejemplar/Delete/5

        [HttpPost]
        public ActionResult Delete(int id) {
            try {
                List<Ejemplar> le = ListaLibEjem;
                Ejemplar e1 = le.Where(e => e.Id == id).FirstOrDefault();
                if(e1.Id > 0)
                    ListaLibEjemDel.Add(e1);
                le.Remove(e1);
                return View("Lista", ListaLibEjem);
            } catch(Excepcion ec) {
                ViewBag.mensaje = new Models.Mensaje(ec.DeleteMensaje(), Models.Mensaje.TipoMsg.error);
                return View("Lista", BLL.LibroBLL.List2());
            } catch(Exception ex) {
                return View("~/Views/Shared/ErrorSub.cshtml", new Models.ManejadorError(ex));
            }
        }

        [HttpPost]
        public ActionResult CambiarEstado(int EjemplarId) {
            try {
                Ejemplar e1 = ListaLibEjem.Where(e => e.Id == EjemplarId).FirstOrDefault();
                if(e1 != null)
                    e1.Estado = (e1.Estado + 1) % 2;
                ViewBag.estado = e1.Estado;
                return View("~/Views/Shared/Estado.cshtml");
            } catch {
                ViewBag.estado = -1;
                return View("~/Views/Shared/Estado.cshtml");
            }
        }
    }
}
