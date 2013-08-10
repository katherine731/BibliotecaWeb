using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HL.Biblio.POCO;
using HL.Biblio.DAL;

namespace HL.Biblio.BLL {
    public class PaisBLL {

        public static Pais Get(int PaisId) {
            using(var ctx = new BibliotecaContext()) {
                Pais p1 = ctx.Paises.Where(p => p.Id == PaisId).FirstOrDefault();
                return p1;
            }
        }

        public static void Create(Pais pais) {
            using(var ctx = new BibliotecaContext()) {
                if(ctx.Paises.Where(p => p.Nombre == pais.Nombre).Count() > 0)
                    throw new Excepcion("Ya existe un País con el nombre '" + pais.Nombre + "'");
                ctx.Paises.AddObject(pais);
                ctx.SaveChanges();
            }
        }

        public static void Update(Pais pais) {
            using(var ctx = new BibliotecaContext()) {
                Pais p1 = ctx.Paises.Where(p => p.Nombre == pais.Nombre).FirstOrDefault();
                if(p1 != null && p1.Id != pais.Id)
                    throw new Excepcion("Ya existe un País con el nombre '" + pais.Nombre + "'");
                p1 = ctx.Paises.Where(p => p.Id == pais.Id).FirstOrDefault();
                p1.Estado = pais.Estado;
                p1.Gentilicio = pais.Gentilicio;
                p1.Nombre = pais.Nombre;
                ctx.SaveChanges();
            }
        }

        public static void Delete(Pais pais) {
            Delete(pais.Id);
        }

        public static void Delete(int PaisId) {
            using(var ctx = new BibliotecaContext()) {
                try {
                    ctx.Paises.DeleteObject(ctx.Paises.Where(p => p.Id == PaisId).FirstOrDefault());
                    ctx.SaveChanges();
                } catch {
                    throw new Excepcion("No se puede eliminar el registro, tiene participación en alguna transacción");
                }
            }
        }

        public static List<Pais> List() {
            using(var ctx = new BibliotecaContext()) {
                return ctx.Paises.OrderBy(p => p.Nombre).ToList();
            }
        }

        public static List<Pais> ListActivos() {
            using(var ctx = new BibliotecaContext()) {
                return ctx.Paises.Where(p => p.Estado == 1).OrderBy(p => p.Nombre).ToList();
            }
        }

        public static void CambiarEstado(int PaisId, int estado) {
            using(var ctx = new BibliotecaContext()) {
                ctx.Paises.Where(p => p.Id == PaisId).FirstOrDefault().Estado = estado;
                ctx.SaveChanges();
            }
        }

        public static int CambiarEstado(int PaisId) {
            using(var ctx = new BibliotecaContext()) {
                Pais p1 = ctx.Paises.Where(p => p.Id == PaisId).FirstOrDefault();
                p1.Estado = (p1.Estado + 1) % 2;
                ctx.SaveChanges();
                return p1.Estado;
            }
        }
    }
}
