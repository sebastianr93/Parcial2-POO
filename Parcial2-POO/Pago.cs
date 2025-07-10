using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Parcial2_POO
{
    public class Pago
    {
        public int Id { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime? FechaPago { get; set; }
        public decimal Importe { get; set; }
        public decimal Recargo { get; set; }
        public decimal Total => Importe + Recargo;
        public MedioDePago MedioDePago { get; set; }
        public bool Cancelado => FechaPago.HasValue;

        public Negocio Negocio { get; set; }
        public Proveedor Proveedor { get; set; }

        public string NombreNegocio => Negocio?.RazonSocial;
        public string NombreProveedor => Proveedor?.Nombre;

    }

}
