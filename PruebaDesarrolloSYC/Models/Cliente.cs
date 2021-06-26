using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaDesarrolloSYC.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public int NumeDoc { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
