using System;
using System.Collections.Generic;

namespace Banco.Entities
{
    public class Cliente
    {
        public Cliente(int idCliente, Persona persona, Cuenta cuenta)
        {
            Cuentas.Add(cuenta);

            Id = idCliente;
            Individuo = persona;
        }

        public int Id { get; private set; }
        public Persona Individuo { get; private set; }
        public List<Cuenta> Cuentas { get; } = new List<Cuenta>();

        public void AgregarCuenta(Cuenta cuenta)
        {
            for (int i = 0; i < Cuentas.Count; i++)
                if (Cuentas[i].NumeroDeCuenta == cuenta.NumeroDeCuenta)
                    throw new InvalidOperationException("La cuenta que está " +
                        "intentando ingresar ya existe");

            Cuentas.Add(cuenta);
        }

        public void QuitarCuenta(Cuenta cuenta)
        {
            if (Cuentas.Count == 1)
                throw new InvalidOperationException("El cliente debe de " +
                    "mantener al menos una cuenta");

            Cuentas.Remove(cuenta);
        }
    }
}
