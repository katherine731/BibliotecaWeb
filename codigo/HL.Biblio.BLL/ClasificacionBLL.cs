using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HL.Biblio.DAL;
using HL.Biblio.POCO;

namespace HL.Biblio.BLL {
    public class ClasificacionBLL {

        public static Clasificacion Get(int ClasificacionId) {
            try {
                using(var ctx = new BibliotecaContext()) {
                    Clasificacion c1 = ctx.Clasificaciones.Where(c => c.Id == ClasificacionId).FirstOrDefault();
                    return c1;
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static void Create(Clasificacion clasificacion) {
            try {
                using(var ctx = new BibliotecaContext()) {
                    if(string.IsNullOrEmpty(clasificacion.Descripcion))
                        clasificacion.Descripcion = "";
                    ctx.Clasificaciones.AddObject(clasificacion);
                    ctx.SaveChanges();
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static void Update(Clasificacion clasificacion) {
            try {
                using(var ctx = new BibliotecaContext()) {
                    Clasificacion c1 = ctx.Clasificaciones.Where(c => c.Id == clasificacion.Id).FirstOrDefault();
                    c1.Abreviatura = clasificacion.Abreviatura;
                    if(string.IsNullOrEmpty(clasificacion.Descripcion))
                        clasificacion.Descripcion = "";
                    c1.Descripcion = clasificacion.Descripcion;
                    c1.Estado = clasificacion.Estado;
                    c1.Nombre = clasificacion.Nombre;
                    ctx.SaveChanges();
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static bool Delete(Clasificacion clasificacion) {
            return Delete(clasificacion.Id);
        }

        public static bool Delete(int ClasificacionId) {
            try {
                using(var ctx = new BibliotecaContext()) {
                    try {
                        ctx.Clasificaciones.DeleteObject(ctx.Clasificaciones.Where(c => c.Id == ClasificacionId).FirstOrDefault());
                        ctx.SaveChanges();
                        return true;
                    } catch {
                        return false;
                    }
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static List<Clasificacion> List() {
            try {
                using(var ctx = new BibliotecaContext()) {
                    return ctx.Clasificaciones.OrderBy(c => c.Nombre).ToList();
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static List<Clasificacion> ListActivos() {
            try {
                using(var ctx = new BibliotecaContext()) {
                    return ctx.Clasificaciones.Where(c => c.Estado == 1).OrderBy(c => c.Nombre).ToList();
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static void CambiarEstado(int ClasificacionId, int estado) {
            using(var ctx = new BibliotecaContext()) {
                ctx.Clasificaciones.Where(c => c.Id == ClasificacionId).FirstOrDefault().Estado = estado;
                ctx.SaveChanges();
            }
        }

        public static int CambiarEstado(int ClasificacionId) {
            try {
                using(var ctx = new BibliotecaContext()) {
                    Clasificacion c1 = ctx.Clasificaciones.Where(c => c.Id == ClasificacionId).FirstOrDefault();
                    c1.Estado = (c1.Estado + 1) % 2;
                    ctx.SaveChanges();
                    return c1.Estado;
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }
    }
}
