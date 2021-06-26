using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesarrolloSYC.Models;
using Microsoft.EntityFrameworkCore;
using PruebaDesarrolloSYC.Services;

namespace PruebaDesarrolloSYC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturaController : Controller
    {
        private readonly IFacturaService _facturaService;

        public FacturaController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpGet]
        public async Task<IEnumerable<Factura>> GetFacturas()
        {
            var result = await _facturaService.GetFacturas();

            if(result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CrearFactura(Factura factura)
        {
            var result = await _facturaService.AddFactura(factura);

            if (result != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
