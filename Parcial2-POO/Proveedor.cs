using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_POO
{
    public class Proveedor
    {
        private static int ultimoCodigo = 1;
        public int Codigo { get; private set; }

        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public override string ToString() => Nombre;

        public List<Negocio> NegociosQueAtiende { get; set; } = new();

        public Proveedor()
        {
            Codigo = ultimoCodigo++;
        }
    }


}
