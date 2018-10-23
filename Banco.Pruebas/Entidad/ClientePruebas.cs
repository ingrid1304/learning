using Banco.Entidad;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BancoPruebas.Entidad
{
    [TestClass()]
    public class ClientePruebas
    {
        [TestMethod()]
        public void AgregarCuentaPrueba()
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

        [TestMethod()]
        public void AgregarCuentaRepetidaPrueba()
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

        [TestMethod()]
        public void QuitarUltimaCuentaPrueba()
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

        [TestMethod()]
        public void CerrarCuentaPrueba()
        {
            Persona ingrid = new Persona("Ingrid", "Luñá", "Taboada");
            Cuenta cuenta1 = new Cuenta(0),
                cuenta2 = new Cuenta(1),
                cuenta3 = new Cuenta(3);
            Cliente cliente = new Cliente(0, ingrid, cuenta1);

            cuenta3.Abonar(100);

            cliente.AgregarCuenta(cuenta2);
            cliente.AgregarCuenta(cuenta3);

            Assert.ThrowsException<InvalidOperationException>(
                () => cliente.CerrarCuenta());

            cliente.QuitarCuenta(cuenta1);
            cliente.QuitarCuenta(cuenta2);

            Assert.ThrowsException<InvalidOperationException>(
                () => cliente.CerrarCuenta());

            cuenta3.Retirar(100);

            cliente.CerrarCuenta();

            Assert.AreEqual(null, cliente.Propietario);
            Assert.AreEqual(null, cliente.Cuentas);
            //Assert.IsTrue(cliente == null);
        }
    }
}
