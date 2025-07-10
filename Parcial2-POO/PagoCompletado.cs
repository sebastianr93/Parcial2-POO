using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_POO
{
    public class PagoCompletado
    {
        public int Codigo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Importe { get; set; }
        public decimal Recargo { get; set; }
        public decimal Total => Importe + Recargo;
        public MedioDePago MedioDePago { get; set; }

        public string Negocio { get; set; }
        public string Proveedor { get; set; }
    }
}
