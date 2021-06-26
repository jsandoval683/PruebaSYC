using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesarrolloSYC.Models;

namespace PruebaDesarrolloSYC.Services
{
    public interface IFacturaService
    {
        Task<IEnumerable<Factura>> GetFacturas();
        Task<Factura> AddFactura(Factura factura);
    }
}
