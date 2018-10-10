using Banco;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Pruebas
{
    [TestClass]
    internal class BancoTest
    {
        [TestMethod]
        public void SaldoInicial()
        {
            Cuenta cuenta = new Cuenta(1);
            Assert.AreEqual(cuenta.Saldo, 0);
        }

        [TestMethod]
        public void AbonoCorrecto()
        {
            Cuenta cuenta = new Cuenta(1);
            cuenta.Abonar(500m);
            Assert.AreEqual(cuenta.Saldo, 500m);
        }

        [TestMethod]
        public void RetiroCorrecto()
        {
            Cuenta cuenta = new Cuenta(1);
            cuenta.Abonar(1000m);
            cuenta.Retirar(500m);
            Assert.AreEqual(cuenta.Saldo, 500m);
        }

        [TestMethod]
        public void RetiroIncorrecto()
        {
            Cuenta cuenta = new Cuenta(1);
            try
            {
                decimal resultado = cuenta.Retiro(500m);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
            }
        }
    }
}
