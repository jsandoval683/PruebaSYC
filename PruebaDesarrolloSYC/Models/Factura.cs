using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaDesarrolloSYC.Models
{
    public partial class Factura
    {
        public int IdFactura { get; set; }
        public int NumeDoc { get; set; }
        public int CodiEstado { get; set; }
        public int ValorFac { get; set; }
        public DateTime? FechaFac { get; set; }

        public virtual EstadosFactura CodiEstadoNavigation { get; set; }
        public virtual Cliente NumeDocNavigation { get; set; }
    }
}
