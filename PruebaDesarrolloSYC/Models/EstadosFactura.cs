using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaDesarrolloSYC.Models
{
    public partial class EstadosFactura
    {
        public EstadosFactura()
        {
            Facturas = new HashSet<Factura>();
        }

        public int CodiEstado { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
