using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Instanciables;
using Archivos;
using System.Collections.Generic;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitarios
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalidoTest()
        {
            Alumno alumno = new Alumno(123, "Test", "Unitario", "9999999a", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void ArchivoTextoTest()
        {
            string aux;
            Texto archivoLeer = new Texto();
            archivoLeer.Leer("C://JornadaFalso.txt", out aux);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void ArchivoXmlTest()
        {
            Universidad aux;
            Xml<Universidad> archivoLeer = new Xml<Universidad>();
            archivoLeer.Leer("C://UniversidadFalso.xml", out aux);

        }

        [TestMethod]        
        public void InstanciaColeccionTest()
        {
            Universidad universidad = new Universidad();            

            Assert.IsInstanceOfType(universidad.Alumnos, typeof(List<Alumno>));

        }

    }
}
