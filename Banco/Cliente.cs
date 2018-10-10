using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Entities
{
    internal class Cliente
    {
        public int ID { get; private set; }
        public Persona Individuo { get; private set; }
        public List<Cuenta> Cuentas { get; }
    }
}
