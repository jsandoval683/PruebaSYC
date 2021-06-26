using PruebaDesarrolloSYC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesarrolloSYC.Models;
using Microsoft.EntityFrameworkCore;

namespace PruebaDesarrolloSYC.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly PruebaDBContext _context;

        public FacturaService(PruebaDBContext context)
        {
            _context = context;
        }
        public async Task<Factura> AddFactura(Factura factura)
        {
            try
            {
                await _context.Facturas.AddAsync(factura);
                await _context.SaveChangesAsync();
                return factura;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Factura>> GetFacturas()
        {
            try
            {
                try
                {
                    return await _context.Facturas.Include(f => f.NumeDocNavigation).Include(f => f.CodiEstadoNavigation).ToListAsync();
                }
                catch (Exception e)
                {

                    return null;
                }
            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}
