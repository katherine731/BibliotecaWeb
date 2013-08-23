using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HL.Biblio.BLL;
using HL.Biblio.POCO;

namespace HL.Biblio.Test {
    [TestClass]
    public class UnitTest1 {

        [TestMethod]
        public void registrarPais() {
            Pais p = new Pais();
            p.Nombre = "Bolivia";
            p.Gentilicio = "Boliviana";
            p.Estado = 1;
            BLL.PaisBLL.Create(p);

            Assert.AreNotEqual(0, p.Id);
        }

        [TestMethod]
        public void listarPaises() {
            Assert.AreNotEqual(0, BLL.PaisBLL.ListActivos().Count());
        }

        [TestMethod]
        public void registrarEditorial() {
            Editorial e = new Editorial();
            e.Estado = 1;
            e.Nombre = "Editorial1";
            e.Pais = PaisBLL.Get(1);
            EditorialBLL.Create(e);
            Assert.AreNotEqual(0, e.Id);
        }

        [TestMethod]
        public void registrarAutor() {
            Autor a = new Autor();
            a.Apellidos = "ApAutor1";
            a.Estado = 1;
            a.Nombres = "autor1";
            a.Pais = PaisBLL.Get(1);
            AutorBLL.Create(a);
            Assert.AreNotEqual(0, a.Id);
        }

        [TestMethod]
        public void registrarLibro() {
            Libro l = new Libro();
            
        }
    }
}
