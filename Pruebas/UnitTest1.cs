﻿using Banco;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Pruebas
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Persona ingrid = new Persona("Ingrid", "Luñá", "Taboada");
            Persona uli = new Persona("Jorge", "Ulises", "Briseño", "Chavez");

            Console.WriteLine(uli.SegundoNombre);
            Console.WriteLine(ingrid.SegundoNombre);

            Assert.AreEqual("Luñá Taboada Ingrid", ingrid.NombreCompleto);
            Assert.AreEqual("Briseño Chavez Jorge Ulises", uli.NombreCompleto);
        }
    }
}
