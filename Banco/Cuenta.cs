namespace Banco
{
    public class Cuenta
    {
        public Cuenta(int id)
        {
            Id = id;
            Saldo = 0;
        }

        public int Id { get; private set; }
        public decimal Saldo { get; private set; }

        public decimal Retirar(decimal retiro)
        {
            if (retiro > Saldo)
            {
                throw new System.ArgumentException("Saldo insuficiente");
            }
            else
            {
                return Saldo -= retiro;
            }
        }

        public decimal Abonar(decimal abono)
        {
            return Saldo += abono;
        }
    }
}
