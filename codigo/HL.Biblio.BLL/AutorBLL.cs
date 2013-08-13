using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HL.Biblio.POCO;
using HL.Biblio.DAL;

namespace HL.Biblio.BLL {
    public class AutorBLL {

        public static Autor Get(int AutorId) {
            try {
                using(var ctx = new BibliotecaContext()) {
                    Autor a1 = ctx.Autores.Include("Pais").Where(a => a.Id == AutorId).FirstOrDefault();
                    return a1;
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static void Create(Autor autor) {
            try {
                using(var ctx = new BibliotecaContext()) {
                    if(string.IsNullOrEmpty(autor.Nombres))
                        autor.Nombres = "";
                    autor.Pais = ctx.Paises.Where(p => p.Id == autor.Pais.Id).FirstOrDefault();
                    ctx.Autores.AddObject(autor);
                    ctx.SaveChanges();
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static void Update(Autor autor) {
            try {
                using(var ctx = new BibliotecaContext()) {
                    Autor a1 = ctx.Autores.Where(a => a.Id == autor.Id).FirstOrDefault();
                    a1.Apellidos = autor.Apellidos;
                    a1.Estado = autor.Estado;
                    if(string.IsNullOrEmpty(autor.Nombres))
                        autor.Nombres = "";
                    a1.Nombres = autor.Nombres;
                    a1.Pais = ctx.Paises.Where(p => p.Id == autor.Pais.Id).FirstOrDefault();
                    ctx.SaveChanges();
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static void Delete(Autor autor) {
            Delete(autor.Id);
        }

        public static void Delete(int AutorId) {
            using(var ctx = new BibliotecaContext()) {
                try {
                    ctx.Autores.DeleteObject(ctx.Autores.Where(a => a.Id == AutorId).FirstOrDefault());
                    ctx.SaveChanges();
                } catch {
                    throw new Excepcion("No se puede eliminar el registro, tiene participación en alguna transacción");
                }
            }
            //try {
            //    using(var ctx = new BibliotecaContext()) {
            //        try {
            //            ctx.Autores.DeleteObject(ctx.Autores.Where(a => a.Id == AutorId).FirstOrDefault());
            //            ctx.SaveChanges();
            //            return true;
            //        } catch {
            //            return false;
            //        }
            //    }
            //} catch(Exception ex) {
            //    throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            //}
        }

        public static List<Autor> List() {
            try {
                using(var ctx = new BibliotecaContext()) {
                    return ctx.Autores.OrderBy(a => a.Apellidos).ToList();
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static List<Autor> ListActivos() {
            try {
                using(var ctx = new BibliotecaContext()) {
                    return ctx.Autores.Where(a => a.Estado == 1).OrderBy(a => a.Apellidos).ToList();
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static List<Autor> List2() {
            try {
                using(var ctx = new BibliotecaContext()) {
                    return ctx.Autores.Include("Pais").OrderBy(a => a.Apellidos).ToList();
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static List<Autor> ListActivos2() {
            try {
                using(var ctx = new BibliotecaContext()) {
                    return ctx.Autores.Include("Pais").Where(a => a.Estado == 1).OrderBy(a => a.Apellidos).ToList();
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static void CambiarEstado(int AutorId, int estado) {
            try {
                using(var ctx = new BibliotecaContext()) {
                    ctx.Autores.Where(a => a.Id == AutorId).FirstOrDefault().Estado = estado;
                    ctx.SaveChanges();
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }

        public static int CambiarEstado(int AutorId) {
            try {
                using(var ctx = new BibliotecaContext()) {
                    Autor a1 = ctx.Autores.Where(a => a.Id == AutorId).FirstOrDefault();
                    a1.Estado = (a1.Estado + 1) % 2;
                    ctx.SaveChanges();
                    return a1.Estado;
                }
            } catch(Exception ex) {
                throw new Exception("Ocurrio un error al obtener los datos, verifique la conexion con el servidor", ex);
            }
        }
    }
}
