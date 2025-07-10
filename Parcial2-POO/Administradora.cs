using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_POO
{
    public class Administradora
    {
        public List<Negocio> Negocios { get; set; } = new();
        public List<Proveedor> Proveedores { get; set; } = new();
        public List<Pago> Pagos { get; set; } = new();
        public List<MedioDePago> MediosDePago { get; set; } = new();
        public List<PagoCompletado> PagosCompletados { get; set; } = new();
    }

}
