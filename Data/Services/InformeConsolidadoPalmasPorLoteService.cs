using System;
using System.Collections.Generic;
using System.Linq;
using Data.Context;

namespace Data.Services
{
    public class InformeConsolidadoPalmasPorLoteService : InformeConsolidadoService
    {
        public InformeConsolidadoPalmasPorLoteService(PalmAppContext context) : base(context)
        {
        }

        public override InformeConsolidadoDto GetInforme()
        {
            var informe = new InformeConsolidadoDto()
            {
                Titulo = "Informe consolidado de Palmas por Lote",
                Fecha = DateTime.Now
            };

            informe.Detalles = _context.Lotes.Select(t => new InformeConsolidadoDetalleDto()
            {
                Descripcion = (t.Cultivo.Nombre + " - " + t.Nombre),
                Cantidad = t.Palmas.Count
            }).ToList();

            return informe;
        }
    }
}