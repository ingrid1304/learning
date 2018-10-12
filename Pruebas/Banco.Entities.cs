using Banco.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Pruebas.Banco
{
    [TestClass]
    public class PersonaTest
    {
        [TestMethod]
        public void SegundoNombrePropertyTest()
        {
            Persona ingrid = new Persona("Ingrid", "Luñá", "Taboada");
            Persona uli = new Persona("Jorge", "Ulises", "Briseño", "Chavez");

            Console.WriteLine(uli.SegundoNombre);
            Console.WriteLine(ingrid.SegundoNombre);

            Assert.AreEqual("Luñá Taboada Ingrid", ingrid.NombreCompleto);
            Assert.AreEqual("Briseño Chavez Jorge Ulises", uli.NombreCompleto);
        }
    }

    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        public void AgregarCuenta()
        {
            Cliente cliente = new Cliente(1,
                new Persona("Ingrid", "Luñá", "Taboada"),
                new Cuenta(1));

            cliente.AgregarCuenta(new Cuenta(2));
            cliente.AgregarCuenta(new Cuenta(3));

            int i = 0;
            foreach (Cuenta cuenta in cliente.Cuentas)
                Assert.AreEqual(++i, cuenta.NumeroDeCuenta);
        }

        [TestMethod]
        public void AgregarCuentaRepetida()
        {
            Cliente cliente = new Cliente(1,
                new Persona("Ingrid", "Luñá", "Taboada"),
                new Cuenta(1));

            try
            {
                cliente.AgregarCuenta(new Cuenta(1));
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(InvalidOperationException));
            }
        }

        [TestMethod]
        public void QuitarUltimaCuenta()
        {
            Cuenta cuenta = new Cuenta(1);
            Cliente cliente = new Cliente(1,
                new Persona("Ingrid", "Luñá", "Taboada"),
                cuenta);

            try
            {
                cliente.QuitarCuenta(cuenta);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(Exception));
            }


        }
    }

    [TestClass]
    public class CuentaTest
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
            decimal resultado = cuenta.Abonar(500m);
            Assert.AreEqual(cuenta.Saldo, 500m);
            Assert.AreEqual(resultado, 500m);
        }

        [TestMethod]
        public void RetiroCorrecto()
        {
            Cuenta cuenta = new Cuenta(1);
            cuenta.Abonar(1000m);
            decimal resultado = cuenta.Retirar(500m);
            Assert.AreEqual(cuenta.Saldo, 500m);
            Assert.AreEqual(resultado, 500m);
        }

        [TestMethod]
        public void RetiroIncorrecto()
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
