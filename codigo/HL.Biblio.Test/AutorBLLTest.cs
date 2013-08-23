using HL.Biblio.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HL.Biblio.POCO;
using System.Collections.Generic;

namespace HL.Biblio.Test
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para AutorBLLTest y se pretende que
    ///contenga todas las pruebas unitarias AutorBLLTest.
    ///</summary>
    [TestClass()]
    public class AutorBLLTest
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
        ///Una prueba de Get
        ///</summary>
        [TestMethod()]
        public void GetTest()
        {
            int AutorId = 1; // TODO: Inicializar en un valor adecuado
            Autor expected = null; // TODO: Inicializar en un valor adecuado
            Autor actual;
            actual = AutorBLL.Get(AutorId);
            Assert.AreNotEqual(expected, actual);
            //Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

       
        /// <summary>
        ///Una prueba de CambiarEstado
        ///</summary>
        [TestMethod()]
        public void CambiarEstadoTest()
        {
            int AutorId = 1; // TODO: Inicializar en un valor adecuado
            int estado = 0; // TODO: Inicializar en un valor adecuado
            AutorBLL.CambiarEstado(AutorId, estado);
        //    Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de CambiarEstado
        ///</summary>
        [TestMethod()]
        public void CambiarEstadoTest1()
        {
            int AutorId = 1; // TODO: Inicializar en un valor adecuado
            int expected = 0; // TODO: Inicializar en un valor adecuado
            int actual;
            actual = AutorBLL.CambiarEstado(AutorId);
            Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de Create
        ///</summary>
        [TestMethod()]
        public void CreateTest()
        {
          //  Autor autor = null; // TODO: Inicializar en un valor adecuado
            Autor a = new Autor();
            a.Nombres="pablo";
            a.Apellidos= "pablo";
                Pais p = new Pais();
                p.Nombre = "Bolivia";
                p.Gentilicio = "Boliviana";
                p.Estado = 1;
                a.Pais = p;
            a.Estado = 1;
            AutorBLL.Create(a);
           // Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest1()
        {
            int AutorId = 1; // TODO: Inicializar en un valor adecuado
            AutorBLL.Delete(AutorId);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de List
        ///</summary>
        [TestMethod()]
        public void ListTest()
        {
            List<Autor> expected = null; // TODO: Inicializar en un valor adecuado
            List<Autor> actual;
            actual = AutorBLL.List();
            Assert.AreNotEqual(expected, actual);
          //  Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de List2
        ///</summary>
        [TestMethod()]
        public void List2Test()
        {
            List<Autor> expected = null; // TODO: Inicializar en un valor adecuado
            List<Autor> actual;
            actual = AutorBLL.List2();
            Assert.AreNotEqual(expected, actual);
            //Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de ListActivos
        ///</summary>
        [TestMethod()]
        public void ListActivosTest()
        {
            List<Autor> expected = null; // TODO: Inicializar en un valor adecuado
            List<Autor> actual;
            actual = AutorBLL.ListActivos();
            Assert.AreNotEqual(expected, actual);
         //   Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de ListActivos2
        ///</summary>
        [TestMethod()]
        public void ListActivos2Test()
        {
            List<Autor> expected = null; // TODO: Inicializar en un valor adecuado
            List<Autor> actual;
            actual = AutorBLL.ListActivos2();
            Assert.AreNotEqual(expected, actual);
        //    Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            Autor a= AutorBLL.Get(2);
           // a.Id = a.Id;
            a.Nombres = "pablo";
            a.Apellidos = "perez";
            a.Pais = PaisBLL.Get(1);
            a.Estado = 1;
            
            AutorBLL.Update(a);

            a = AutorBLL.Get(2);

            Assert.AreEqual("pablo", a.Nombres);
            Assert.AreEqual("perez", a.Apellidos);
            //Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }
    }
}
