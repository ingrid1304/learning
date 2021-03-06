﻿using Banco.Entidad;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BancoPruebas.Entidad
{
    [TestClass()]
    public class CuentaPruebas
    {
        [TestMethod()]
        public void SaldoInicialPrueba()
        {
            Cuenta cuenta = new Cuenta(1);
            Assert.AreEqual(cuenta.Saldo, 0);
        }

        [TestMethod()]
        public void AbonoCorrectoPrueba()
        {
            Cuenta cuenta = new Cuenta(1);
            decimal resultado = cuenta.Abonar(500m);
            Assert.AreEqual(cuenta.Saldo, 500m);
            Assert.AreEqual(resultado, 500m);
        }

        [TestMethod()]
        public void RetiroCorrectoPrueba()
        {
            Cuenta cuenta = new Cuenta(1);
            cuenta.Abonar(1000m);
            decimal resultado = cuenta.Retirar(500m);
            Assert.AreEqual(cuenta.Saldo, 500m);
            Assert.AreEqual(resultado, 500m);
        }

        [TestMethod()]
        public void RetiroIncorrectoPrueba()
        {
            Cuenta cuenta = new Cuenta(1);
            try
            {
                decimal resultado = cuenta.Retirar(500m);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(InvalidOperationException));
            }
        }
    }
}
