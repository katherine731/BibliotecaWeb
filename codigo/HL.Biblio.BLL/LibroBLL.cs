using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HL.Biblio.DAL;
using HL.Biblio.POCO;

namespace HL.Biblio.BLL {
    public class LibroBLL {

        #region Libro
        public static Libro Get(int LibroId) {
            using(var ctx = new BibliotecaContext()) {
                Libro l1 = ctx.Libros.Include("Autor").Include("Editorial").Include("Clasificacion").Include("Ejemplares").Where(l => l.Id == LibroId).FirstOrDefault();
                return l1;
            }
        }

        private static void validarEjemplares(BibliotecaContext ctx, List<Ejemplar> listaEjemplar) {
            foreach(Ejemplar ejemplar in listaEjemplar)
                if(!string.IsNullOrEmpty(ejemplar.Codigo) && ctx.Ejemplares.Where(e => e.Id != ejemplar.Id && e.Codigo == ejemplar.Codigo).Count() > 0)
                    throw new Excepcion("Ya existe un ejemplar con código '" + ejemplar.Codigo + "'");
                else if(string.IsNullOrEmpty(ejemplar.CodBarras)) ejemplar.CodBarras = "";
            foreach(Ejemplar ejemplar in listaEjemplar)
                if(!string.IsNullOrEmpty(ejemplar.CodBarras) && ctx.Ejemplares.Where(e => e.Id != ejemplar.Id && e.CodBarras == ejemplar.CodBarras).Count() > 0)
                    throw new Excepcion("Ya existe un ejemplar con el código de barras '" + ejemplar.CodBarras + "'");
                else if(string.IsNullOrEmpty(ejemplar.CodBarras)) ejemplar.CodBarras = "";
            foreach(Ejemplar ejemplar in listaEjemplar)
                if(!string.IsNullOrEmpty(ejemplar.CodRFID) && ctx.Ejemplares.Where(e => e.Id != ejemplar.Id &&  e.CodRFID == ejemplar.CodRFID).Count() > 0)
                    throw new Excepcion("Ya existe un ejemplar con el código RFID '" + ejemplar.CodRFID + "'");
                else if(string.IsNullOrEmpty(ejemplar.CodRFID)) ejemplar.CodRFID = "";
            foreach(Ejemplar ejemplar in listaEjemplar)
                if(string.IsNullOrEmpty(ejemplar.Codigo))
                    ejemplar.Codigo = "";
            foreach(Ejemplar ejemplar in listaEjemplar)
                if(string.IsNullOrEmpty(ejemplar.Ubicacion))
                    ejemplar.Ubicacion = "";
        }

        public static void Create(Libro libro) {
            using(var ctx = new BibliotecaContext()) {
                if(ctx.Libros.Where(l => l.Codigo == libro.Codigo).Count() > 0)
                    throw new Excepcion("Ya existe un registro con el código '" + libro.Codigo + "'");
                if(string.IsNullOrEmpty(libro.Edicion))
                    libro.Edicion = "";
                if(string.IsNullOrEmpty(libro.Resumen))
                    libro.Resumen = "";
                if(string.IsNullOrEmpty(libro.Observacion))
                    libro.Observacion = "";
                if(string.IsNullOrEmpty(libro.ISBN))
                    libro.ISBN = "";
                if(string.IsNullOrEmpty(libro.Idioma))
                    libro.Idioma = "";
                List<Ejemplar> le = null;
                if(libro.Ejemplares != null) {
                    le = libro.Ejemplares.ToList();
                    validarEjemplares(ctx, le);
                    libro.Ejemplares = null;
                }
                Autor a1 = ctx.Autores.Where(a => a.Id == libro.Autor.Id).FirstOrDefault();
                Editorial e1 = ctx.Editoriales.Include("Pais").Where(e => e.Id == libro.Editorial.Id).FirstOrDefault();
                Clasificacion c1 = ctx.Clasificaciones.Where(c => c.Id == libro.Clasificacion.Id).FirstOrDefault();
                libro.Autor = null;
                libro.Clasificacion = null;
                libro.Editorial = null;
                ctx.Libros.AddObject(libro);
                ctx.SaveChanges();
                libro.Autor = a1;
                libro.Editorial = e1;
                libro.Clasificacion = c1;
                foreach(Ejemplar ejemplar in le) {
                    ejemplar.Libro = libro;
                    ctx.Ejemplares.AddObject(ejemplar);
                }
                ctx.SaveChanges();
            }
        }

        public static void Update(Libro libro) {
            using(var ctx = new BibliotecaContext()) {
                Libro l1 = ctx.Libros.Where(l => l.Codigo == libro.Codigo).FirstOrDefault();
                if(l1 != null && l1.Id != libro.Id)
                    throw new Excepcion("Ya existe un registro con el código '" + libro.Codigo + "'");
                if(string.IsNullOrEmpty(libro.Edicion))
                    libro.Edicion = "";
                if(string.IsNullOrEmpty(libro.Resumen))
                    libro.Resumen = "";
                if(string.IsNullOrEmpty(libro.Observacion))
                    libro.Observacion = "";
                if(string.IsNullOrEmpty(libro.ISBN))
                    libro.ISBN = "";
                if(string.IsNullOrEmpty(libro.Idioma))
                    libro.Idioma = "";
                l1 = ctx.Libros.Include("Ejemplares").Where(l => l.Id == libro.Id).FirstOrDefault();
                //l1.Ejemplares = null;
                List<Ejemplar> le1 = null;
                if(libro.Ejemplares != null) le1 = l1.Ejemplares.ToList();
                List<Ejemplar> le2 = null;
                if(libro.Ejemplares != null) le2 = libro.Ejemplares.ToList();
                if(le1 != null)
                    foreach(Ejemplar e2 in le2) {
                        Ejemplar e1 = le1.Where(e => e.Codigo == e2.Codigo || e.Id == e2.Id).FirstOrDefault();
                        if(e1 != null)
                            e2.Id = e1.Id;
                    }
                validarEjemplares(ctx, le2);
                if(le1 != null)
                    foreach(Ejemplar e2 in le2) {
                        Ejemplar e1 = le1.Where(e => e.Codigo == e2.Codigo || e.Id == e2.Id).FirstOrDefault();
                        if(e1 != null) {
                            e2.Id = e1.Id;
                            e1.CodBarras = e2.CodBarras;
                            e1.Codigo = e2.Codigo;
                            e1.CodRFID = e2.CodRFID;
                            e1.Estado = e2.Estado;
                            e1.TipoPrestamo = e2.TipoPrestamo;
                            e1.Ubicacion = e2.Ubicacion;
                        }
                    }
                //validando registros eliminados
                List<Ejemplar> le3 = null;
                if(le1 != null) {
                    List<int> lId = (le2 == null) ? null : le2.Select(e => e.Id).ToList();
                    if(lId != null) {
                        le3 = le1.Where(e => e.Id > 0 && !lId.Contains(e.Id)).ToList();
                        //foreach(Ejemplar e1 in le3) {
                        //    if(ctx.Prestamos.Where(p => p.Ejemplares.Where(e => e.Id == e1.Id).FirstOrDefault() != null).FirstOrDefault() != null)
                        //        throw new Excepcion("No se puede eliminar el ejemplar '" + e1.Codigo + "', tiene participación en alguna transacción");
                        //}
                    }
                }
                if(le3 != null)
                    foreach(Ejemplar e in le3)
                        ctx.Ejemplares.DeleteObject(e);
                foreach(Ejemplar e in le2) {
                    if(e.Id < 1) {
                        e.Libro = l1;
                        ctx.Ejemplares.AddObject(e);
                    }
                }

                l1.Autor = ctx.Autores.Where(a => a.Id == libro.Autor.Id).FirstOrDefault();
                l1.Editorial = ctx.Editoriales.Where(e => e.Id == libro.Editorial.Id).FirstOrDefault();
                l1.Clasificacion = ctx.Clasificaciones.Where(c => c.Id == libro.Clasificacion.Id).FirstOrDefault();
                l1.Codigo = libro.Codigo;
                l1.Estado = libro.Estado;
                l1.ISBN = libro.ISBN;
                l1.Edicion = libro.Edicion;
                l1.FechaPublicacion = libro.FechaPublicacion;
                l1.Idioma = libro.Idioma;
                l1.Imagen = libro.Imagen;
                l1.Observacion = libro.Observacion;
                l1.Resumen = libro.Resumen;
                l1.Tipo = libro.Tipo;
                l1.Titulo = libro.Titulo;
                ctx.SaveChanges();
            }
        }

        public static void Delete(Libro libro) {
            Delete(libro.Id);
        }

        public static void Delete(int LibroId) {
            using(var ctx = new BibliotecaContext()) {
                IEnumerable<Ejemplar> le = ctx.Ejemplares.Where(e => e.Libro.Id == LibroId);
                //if(ctx.Prestamos.Where(p => p.Ejemplares.Intersect(le).Count() > 0).FirstOrDefault() != null)
                //    throw new Excepcion("No se puede eliminar el registro, tiene participación en alguna transacción");
                foreach(Ejemplar e in le)
                    ctx.Ejemplares.DeleteObject(e);
                ctx.Libros.DeleteObject(ctx.Libros.Where(l => l.Id == LibroId).FirstOrDefault());
                ctx.SaveChanges();
            }
        }

        public static List<Libro> List() {
            using(var ctx = new BibliotecaContext()) {
                return ctx.Libros.ToList();
            }
        }

        public static List<Libro> ListActivos() {
            using(var ctx = new BibliotecaContext()) {
                return ctx.Libros.Where(l => l.Estado == 1).ToList();
            }
        }

        public static List<LibroDet> List2() {
            using(var ctx = new BibliotecaContext()) {
                List<LibroDet> lld = new List<LibroDet>();
                IEnumerable<Libro> le = ctx.Libros.OrderBy(l => l.Codigo);
                foreach(Libro l in le) {
                    LibroDet ld = new LibroDet();
                    if(l.Autor != null)
                        ld.Autor = l.Autor.Apellidos + " " + l.Autor.Nombres;
                    else
                        ld.Autor = "";
                    if(l.Clasificacion != null)
                        ld.ClasifAbrev = l.Clasificacion.Abreviatura;
                    else
                        ld.ClasifAbrev = "";
                    ld.Codigo = l.Codigo;
                    if(l.Ejemplares != null)
                        ld.Copias = l.Ejemplares.Count;
                    ld.Edicion = "";
                    if (l.Edicion != null)
                        ld.Edicion = l.Edicion;
                    if(l.Editorial != null)
                        ld.Editorial = l.Editorial.Nombre;
                    else
                        ld.Editorial = "";
                    ld.Estado = l.Estado;
                    ld.Id = l.Id;
                    ld.Idioma = l.Idioma;
                    ld.Observacion = l.Observacion;
                    ld.Tipo = l.Tipo;
                    ld.Titulo = l.Titulo;
                    lld.Add(ld);
                }
                return lld;
            }
        }

        public static List<LibroDet> ListActivos2() {
            using(var ctx = new BibliotecaContext()) {
                List<LibroDet> lld = new List<LibroDet>();
                IEnumerable<Libro> le = ctx.Libros.Where(l => l.Estado == 1).OrderBy(l => l.Codigo);
                foreach(Libro l in le) {
                    LibroDet ld = new LibroDet();
                    ld.Autor = l.Autor.Apellidos + " " + l.Autor.Nombres;
                    ld.ClasifAbrev = l.Clasificacion.Abreviatura;
                    ld.Codigo = l.Codigo;
                    ld.Copias = l.Ejemplares.Count;
                    ld.Edicion = l.Edicion;
                    ld.Editorial = l.Editorial.Nombre;
                    ld.Estado = l.Estado;
                    ld.Id = l.Id;
                    ld.Idioma = l.Idioma;
                    ld.Observacion = l.Observacion;
                    ld.Tipo = l.Tipo;
                    ld.Titulo = l.Titulo;
                    lld.Add(ld);
                }
                return lld;
            }
        }

        public static void CambiarEstado(int LibroId, int estado) {
            using(var ctx = new BibliotecaContext()) {
                ctx.Libros.Where(l => l.Id == LibroId).FirstOrDefault().Estado = estado;
                ctx.SaveChanges();
            }
        }

        public static int CambiarEstado(int LibroId) {
            using(var ctx = new BibliotecaContext()) {
                Libro l1 = ctx.Libros.Where(l => l.Id == LibroId).FirstOrDefault();
                l1.Estado = (l1.Estado + 1) % 2;
                ctx.SaveChanges();
                return l1.Estado;
            }
        }
        #endregion

        #region Ejemplar
        public static Ejemplar GetEjemplar(int EjemplarId) {
            using(var ctx = new BibliotecaContext()) {
                Ejemplar e1 = ctx.Ejemplares.Where(e => e.Id == EjemplarId).FirstOrDefault();
                return e1;
            }
        }

        public static void CreateEjemplar(Ejemplar ejemplar) {
            using(var ctx = new BibliotecaContext()) {
                if(string.IsNullOrEmpty(ejemplar.Codigo))
                    ejemplar.Codigo = "";
                if(string.IsNullOrEmpty(ejemplar.CodBarras))
                    ejemplar.CodBarras = "";
                if(string.IsNullOrEmpty(ejemplar.CodRFID))
                    ejemplar.CodRFID = "";
                if(string.IsNullOrEmpty(ejemplar.Ubicacion))
                    ejemplar.Ubicacion = "";
                if(!string.IsNullOrEmpty(ejemplar.CodBarras) && ctx.Ejemplares.Where(e => e.CodBarras == ejemplar.CodBarras) != null)
                    throw new Excepcion("Ya existe un registro con el código de barras '" + ejemplar.CodBarras + "'");
                if(!string.IsNullOrEmpty(ejemplar.CodRFID) && ctx.Ejemplares.Where(e => e.CodRFID == ejemplar.CodRFID) != null)
                    throw new Excepcion("Ya existe un registro con el código RFID '" + ejemplar.CodRFID + "'");
                ejemplar.Libro = ctx.Libros.Where(l => l.Id == ejemplar.Libro.Id).FirstOrDefault();
                ctx.Ejemplares.AddObject(ejemplar);
                ctx.SaveChanges();
            }
        }

        public static void UpdateEjemplar(Ejemplar ejemplar) {
            using(var ctx = new BibliotecaContext()) {
                Ejemplar e1;
                if(string.IsNullOrEmpty(ejemplar.Codigo))
                    ejemplar.Codigo = "";
                if(string.IsNullOrEmpty(ejemplar.CodBarras))
                    ejemplar.CodBarras = "";
                if(string.IsNullOrEmpty(ejemplar.CodRFID))
                    ejemplar.CodRFID = "";
                if(string.IsNullOrEmpty(ejemplar.Ubicacion))
                    ejemplar.Ubicacion = "";
                if(!string.IsNullOrEmpty(ejemplar.CodBarras)) {
                    e1 = ctx.Ejemplares.Where(e => e.CodBarras == ejemplar.CodBarras).FirstOrDefault();
                    if(e1 != null && e1.Id != ejemplar.Id)
                        throw new Excepcion("Ya existe un registro con el código de barras '" + ejemplar.CodBarras + "'");
                }
                if(!string.IsNullOrEmpty(ejemplar.CodRFID)) {
                    e1 = ctx.Ejemplares.Where(e => e.CodRFID == ejemplar.CodRFID).FirstOrDefault();
                    if(e1 != null && e1.Id != ejemplar.Id)
                        throw new Excepcion("Ya existe un registro con el código RFID '" + ejemplar.CodRFID + "'");
                }
                e1 = ctx.Ejemplares.Where(e => e.Id == ejemplar.Id).FirstOrDefault();
                e1.CodBarras = ejemplar.CodBarras;
                e1.CodRFID = ejemplar.CodRFID;
                e1.Estado = ejemplar.Estado;
                e1.Codigo = ejemplar.Codigo;
                ejemplar.Libro = ctx.Libros.Where(l => l.Id == ejemplar.Libro.Id).FirstOrDefault();
                e1.TipoPrestamo = ejemplar.TipoPrestamo;
                e1.Ubicacion = ejemplar.Ubicacion;
                ctx.SaveChanges();
            }
        }

        public static void DeleteEjemplar(Ejemplar ejemplar) {
            DeleteEjemplar(ejemplar.Id);
        }

        public static void DeleteEjemplar(int EjemplarId) {
            using(var ctx = new BibliotecaContext()) {
                try {
                    ctx.Ejemplares.DeleteObject(ctx.Ejemplares.Where(e => e.Id == EjemplarId).FirstOrDefault());
                    ctx.SaveChanges();
                } catch {
                    throw new Excepcion("No se puede eliminar el registro, tiene participación en alguna transacción");
                }
            }
        }

        public static List<Ejemplar> ListEjemplar(int LibroId) {
            using(var ctx = new BibliotecaContext()) {
                return ctx.Ejemplares.Where(e => e.Libro.Id == LibroId).OrderBy(e => e.Codigo).ToList();
            }
        }

        public static List<Ejemplar> ListActivosEjemplar(int LibroId) {
            using(var ctx = new BibliotecaContext()) {
                return ctx.Ejemplares.Where(e => e.Libro.Id == LibroId && e.Estado == 1).OrderBy(e => e.Codigo).ToList();
            }
        }

        public static void CambiarEstadoEjemplar(int EjemplarId, int estado) {
            using(var ctx = new BibliotecaContext()) {
                ctx.Ejemplares.Where(e => e.Id == EjemplarId).FirstOrDefault().Estado = estado;
                ctx.SaveChanges();
            }
        }

        public static int CambiarEstadoEjemplar(int EjemplarId) {
            using(var ctx = new BibliotecaContext()) {
                Ejemplar e1 = ctx.Ejemplares.Where(e => e.Id == EjemplarId).FirstOrDefault();
                e1.Estado = (e1.Estado + 1) % 2;
                ctx.SaveChanges();
                return e1.Estado;
            }
        }
        #endregion
    }
}
