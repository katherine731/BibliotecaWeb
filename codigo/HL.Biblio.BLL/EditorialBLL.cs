using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HL.Biblio.POCO;
using HL.Biblio.DAL;

namespace HL.Biblio.BLL {
    public class EditorialBLL {

        public static Editorial Get(int EditorialId) {
            try {
                using(var ctx = new BibliotecaContext()) {
                    Editorial e1 = ctx.Editoriales.Include("Pais").Where(e => e.Id == EditorialId).FirstOrDefault();
                    return e1;
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static void Create(Editorial editorial) {
            try {
                using(var ctx = new BibliotecaContext()) {
                    editorial.Pais = ctx.Paises.Where(p => p.Id == editorial.Pais.Id).FirstOrDefault();
                    ctx.Editoriales.AddObject(editorial);
                    ctx.SaveChanges();
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static void Update(Editorial editorial) {
            try {
                using(var ctx = new BibliotecaContext()) {
                    Editorial e1 = ctx.Editoriales.Where(e => e.Id == editorial.Id).FirstOrDefault();
                    e1.Estado = editorial.Estado;
                    e1.Nombre = editorial.Nombre;
                    e1.Pais = ctx.Paises.Where(p => p.Id == editorial.Pais.Id).FirstOrDefault();
                    ctx.SaveChanges();
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static bool Delete(Editorial editorial) {
            return Delete(editorial.Id);
        }

        public static bool Delete(int EditorialId) {
            try {
                using(var ctx = new BibliotecaContext()) {
                    try {
                        ctx.Editoriales.DeleteObject(ctx.Editoriales.Where(e => e.Id == EditorialId).FirstOrDefault());
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

        public static List<Editorial> List() {
            try {
                using(var ctx = new BibliotecaContext()) {
                    return ctx.Editoriales.OrderBy(e => e.Nombre).ToList();
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static List<Editorial> ListActivos() {
            try {
                using(var ctx = new BibliotecaContext()) {
                    return ctx.Editoriales.Where(e => e.Estado == 1).OrderBy(e => e.Nombre).ToList();
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static List<Editorial> List2() {
            try {
                using(var ctx = new BibliotecaContext()) {
                    return ctx.Editoriales.Include("Pais").OrderBy(e => e.Nombre).ToList();
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static List<Editorial> ListActivos2() {
            try {
                using(var ctx = new BibliotecaContext()) {
                    return ctx.Editoriales.Include("Pais").Where(e => e.Estado == 1).OrderBy(e => e.Nombre).ToList();
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static void CambiarEstado(int EditorialId, int estado) {
            try {
                using(var ctx = new BibliotecaContext()) {
                    ctx.Editoriales.Where(e => e.Id == EditorialId).FirstOrDefault().Estado = estado;
                    ctx.SaveChanges();
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static int CambiarEstado(int EditorialId) {
            try {
                using(var ctx = new BibliotecaContext()) {
                    Editorial e1 = ctx.Editoriales.Where(e => e.Id == EditorialId).FirstOrDefault();
                    e1.Estado = (e1.Estado + 1) % 2;
                    ctx.SaveChanges();
                    return e1.Estado;
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }
    }
}
