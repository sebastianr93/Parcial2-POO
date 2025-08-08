using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_POO
{
    public class MedioDePago
    {
        public string Nombre { get; private set; }

        // Constructor privado para que no se puedan crear desde afuera sin control
        private MedioDePago(string nombre)
        {
            Nombre = nombre;
        }

        // Equivalentes a los valores del enum
        public static readonly MedioDePago Efectivo = new MedioDePago("Efectivo");
        public static readonly MedioDePago Tarjeta = new MedioDePago("Tarjeta");

        // Si necesitas listar todos los medios de pago
        public static IEnumerable<MedioDePago> ObtenerTodos()
        {
            return new[] { Efectivo, Tarjeta };
        }

        public override string ToString() => Nombre;
    }
}

