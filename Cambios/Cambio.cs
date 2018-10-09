namespace Cambios
{
    public struct Capital
    {
        public int Billete500;
        public int Billete200;
        public int Billete100;
        public int Billete50;
        public int Billete20;
        public int Moneda10;
        public int Moneda5;
        public int Moneda2;
        public int Moneda1;
        public int Moneda05;
    }

    public class Cambio
    {
        /* Calcular cuantos billetes y de que valor devolver */

        private static int CalcularMultiplos(float denominacion, ref float monto)
        {
            if (monto == 0)
                return 0;

            int multiplo = (int)System.Math.Floor(monto / denominacion);
            monto %= denominacion;

            return multiplo;
        }

        public static Capital Cambiar(int montoRecibido, float costo)
        {
            Capital capital = new Capital();
            float cambio = montoRecibido - costo;

            capital.Billete500 = CalcularMultiplos(500f, ref cambio);
            capital.Billete200 = CalcularMultiplos(200f, ref cambio);
            capital.Billete100 = CalcularMultiplos(100f, ref cambio);
            capital.Billete50 = CalcularMultiplos(50f, ref cambio);
            capital.Billete20 = CalcularMultiplos(20f, ref cambio);
            capital.Moneda10 = CalcularMultiplos(10f, ref cambio);
            capital.Moneda5 = CalcularMultiplos(5f, ref cambio);
            capital.Moneda2 = CalcularMultiplos(2f, ref cambio);
            capital.Moneda1 = CalcularMultiplos(1f, ref cambio);
            capital.Moneda05 = CalcularMultiplos(0.5f, ref cambio);

            return capital;
        }
    }
}
