using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_POO
{
    public class Negocio
    {
        private static int ultimoCodigo = 1;
        public int Codigo { get; private set; }

        public string RazonSocial { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public override string ToString() => RazonSocial;

        public List<Proveedor> ProveedoresAsignados { get; set; } = new();

        public Negocio()
        {
            Codigo = ultimoCodigo++;
        }
    }

}
