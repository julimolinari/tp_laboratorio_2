using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;

namespace TestsUnitarios
{
    [TestClass]
    public class TestUnitario
    {
        [TestMethod]
        public void TestPaquetesCorreo()
        {
            Correo correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void PaquetesRepetidos()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Ejemplo", "11111");
            Paquete p2 = new Paquete("Ejemplo2", "11111");;

            correo += p1;
            correo += p2;           
        }
    }
}
