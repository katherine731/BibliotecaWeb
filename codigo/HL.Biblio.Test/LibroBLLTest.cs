using HL.Biblio.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HL.Biblio.POCO;
using System.Collections.Generic;
using HL.Biblio.DAL;

namespace HL.Biblio.Test
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para LibroBLLTest y se pretende que
    ///contenga todas las pruebas unitarias LibroBLLTest.
    ///</summary>
    [TestClass()]
    public class LibroBLLTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de la prueba que proporciona
        ///la información y funcionalidad para la ejecución de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        // 
        //Puede utilizar los siguientes atributos adicionales mientras escribe sus pruebas:
        //
        //Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize para ejecutar código antes de ejecutar cada prueba
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup para ejecutar código después de que se hayan ejecutado todas las pruebas
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Una prueba de Constructor LibroBLL
        ///</summary>
        [TestMethod()]
        public void LibroBLLConstructorTest()
        {
            LibroBLL target = new LibroBLL();
            Assert.Inconclusive("TODO: Implementar código para comprobar el destino");
        }

        /// <summary>
        ///Una prueba de CambiarEstado
        ///</summary>
        [TestMethod()]
        public void CambiarEstadoTest()
        {
            int LibroId = 0; // TODO: Inicializar en un valor adecuado
            int estado = 0; // TODO: Inicializar en un valor adecuado
            LibroBLL.CambiarEstado(LibroId, estado);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de CambiarEstado
        ///</summary>
        [TestMethod()]
        public void CambiarEstadoTest1()
        {
            int LibroId = 0; // TODO: Inicializar en un valor adecuado
            int expected = 0; // TODO: Inicializar en un valor adecuado
            int actual;
            actual = LibroBLL.CambiarEstado(LibroId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de CambiarEstadoEjemplar
        ///</summary>
        [TestMethod()]
        public void CambiarEstadoEjemplarTest()
        {
            int EjemplarId = 0; // TODO: Inicializar en un valor adecuado
            int expected = 0; // TODO: Inicializar en un valor adecuado
            int actual;
            actual = LibroBLL.CambiarEstadoEjemplar(EjemplarId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de CambiarEstadoEjemplar
        ///</summary>
        [TestMethod()]
        public void CambiarEstadoEjemplarTest1()
        {
            int EjemplarId = 0; // TODO: Inicializar en un valor adecuado
            int estado = 0; // TODO: Inicializar en un valor adecuado
            LibroBLL.CambiarEstadoEjemplar(EjemplarId, estado);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de Create
        ///</summary>
        [TestMethod()]
        public void CreateTest()
        {
            Libro libro = null; // TODO: Inicializar en un valor adecuado
            LibroBLL.Create(libro);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de CreateEjemplar
        ///</summary>
        [TestMethod()]
        public void CreateEjemplarTest()
        {
            Ejemplar ejemplar = null; // TODO: Inicializar en un valor adecuado
            LibroBLL.CreateEjemplar(ejemplar);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            Libro libro = null; // TODO: Inicializar en un valor adecuado
            LibroBLL.Delete(libro);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest1()
        {
            int LibroId = 0; // TODO: Inicializar en un valor adecuado
            LibroBLL.Delete(LibroId);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de DeleteEjemplar
        ///</summary>
        [TestMethod()]
        public void DeleteEjemplarTest()
        {
            Ejemplar ejemplar = null; // TODO: Inicializar en un valor adecuado
            LibroBLL.DeleteEjemplar(ejemplar);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de DeleteEjemplar
        ///</summary>
        [TestMethod()]
        public void DeleteEjemplarTest1()
        {
            int EjemplarId = 0; // TODO: Inicializar en un valor adecuado
            LibroBLL.DeleteEjemplar(EjemplarId);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de Get
        ///</summary>
        [TestMethod()]
        public void GetTest()
        {
            int LibroId = 0; // TODO: Inicializar en un valor adecuado
            Libro expected = null; // TODO: Inicializar en un valor adecuado
            Libro actual;
            actual = LibroBLL.Get(LibroId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de GetEjemplar
        ///</summary>
        [TestMethod()]
        public void GetEjemplarTest()
        {
            int EjemplarId = 0; // TODO: Inicializar en un valor adecuado
            Ejemplar expected = null; // TODO: Inicializar en un valor adecuado
            Ejemplar actual;
            actual = LibroBLL.GetEjemplar(EjemplarId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de List
        ///</summary>
        [TestMethod()]
        public void ListTest()
        {
            List<Libro> expected = null; // TODO: Inicializar en un valor adecuado
            List<Libro> actual;
            actual = LibroBLL.List();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de List2
        ///</summary>
        [TestMethod()]
        public void List2Test()
        {
            List<LibroDet> expected = null; // TODO: Inicializar en un valor adecuado
            List<LibroDet> actual;
            actual = LibroBLL.List2();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de ListActivos
        ///</summary>
        [TestMethod()]
        public void ListActivosTest()
        {
            List<Libro> expected = null; // TODO: Inicializar en un valor adecuado
            List<Libro> actual;
            actual = LibroBLL.ListActivos();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de ListActivos2
        ///</summary>
        [TestMethod()]
        public void ListActivos2Test()
        {
            List<LibroDet> expected = null; // TODO: Inicializar en un valor adecuado
            List<LibroDet> actual;
            actual = LibroBLL.ListActivos2();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de ListActivosEjemplar
        ///</summary>
        [TestMethod()]
        public void ListActivosEjemplarTest()
        {
            int LibroId = 0; // TODO: Inicializar en un valor adecuado
            List<Ejemplar> expected = null; // TODO: Inicializar en un valor adecuado
            List<Ejemplar> actual;
            actual = LibroBLL.ListActivosEjemplar(LibroId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de ListEjemplar
        ///</summary>
        [TestMethod()]
        public void ListEjemplarTest()
        {
            int LibroId = 0; // TODO: Inicializar en un valor adecuado
            List<Ejemplar> expected = null; // TODO: Inicializar en un valor adecuado
            List<Ejemplar> actual;
            actual = LibroBLL.ListEjemplar(LibroId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            Libro libro = null; // TODO: Inicializar en un valor adecuado
            LibroBLL.Update(libro);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de UpdateEjemplar
        ///</summary>
        [TestMethod()]
        public void UpdateEjemplarTest()
        {
            Ejemplar ejemplar = null; // TODO: Inicializar en un valor adecuado
            LibroBLL.UpdateEjemplar(ejemplar);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de validarEjemplares
        ///</summary>
        [TestMethod()]
        [DeploymentItem("HL.Biblio.BLL.dll")]
        public void validarEjemplaresTest()
        {
            BibliotecaContext ctx = null; // TODO: Inicializar en un valor adecuado
            List<Ejemplar> listaEjemplar = null; // TODO: Inicializar en un valor adecuado
            LibroBLL_Accessor.validarEjemplares(ctx, listaEjemplar);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }
    }
}
