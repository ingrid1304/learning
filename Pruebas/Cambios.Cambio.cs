using Cambios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Pruebas.Cambios
{
    [TestClass]
    public class CambioTestClass
    {
        [TestMethod]
        public void CambiarCorrecto()
        {
            float costo = 1623.5f;
            Capital esperado = new Capital
            {
                Billete500 = 0,
                Billete200 = 1,
                Billete100 = 1,
                Billete50 = 1,
                Billete20 = 1,
                Moneda10 = 0,
                Moneda5 = 1,
                Moneda2 = 0,
                Moneda1 = 1,
                Moneda05 = 1
            };
            Capital resultado = Cambio.Cambiar(2000, costo);

            Assert.AreEqual(esperado.Billete500, resultado.Billete500);
            Assert.AreEqual(esperado.Billete200, resultado.Billete200);
            Assert.AreEqual(esperado.Billete100, resultado.Billete100);
            Assert.AreEqual(esperado.Billete50, resultado.Billete50);
            Assert.AreEqual(esperado.Billete20, resultado.Billete20);
            Assert.AreEqual(esperado.Moneda10, resultado.Moneda10);
            Assert.AreEqual(esperado.Moneda5, resultado.Moneda5);
            Assert.AreEqual(esperado.Moneda2, resultado.Moneda2);
            Assert.AreEqual(esperado.Moneda1, resultado.Moneda1);
            Assert.AreEqual(esperado.Moneda05, resultado.Moneda05);
        }

        [TestMethod]
        public void CambiarExcepcion()
        {
            float costo = 1623.5f;
            Capital esperado = new Capital
            {
                Billete500 = 0,
                Billete200 = 1,
                Billete100 = 1,
                Billete50 = 1,
                Billete20 = 1,
                Moneda10 = 0,
                Moneda5 = 1,
                Moneda2 = 0,
                Moneda1 = 1,
                Moneda05 = 1
            };

            try
            {
                Capital resultado = Cambio.Cambiar(500, costo);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));

                ArgumentException argumentException = (ArgumentException)e;
                Assert.AreEqual(argumentException.ParamName, "montoRecibido");
            }

        }
    }
}
