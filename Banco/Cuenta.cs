namespace Banco.Entities
{
    public class Cuenta
    {
        public Cuenta(int numeroDeCuenta)
        {
            NumeroDeCuenta = numeroDeCuenta;
            Saldo = 0;
        }

        public int NumeroDeCuenta { get; private set; }
        public decimal Saldo { get; private set; }

        public decimal Retirar(decimal retiro)
        {
            if (retiro > Saldo)
                throw new System.InvalidOperationException("Saldo insuficiente");

            return Saldo -= retiro;
        }

        public decimal Abonar(decimal abono)
        {
            return Saldo += abono;
        }
    }
}
