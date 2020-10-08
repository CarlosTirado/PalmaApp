using System;
using System.Collections.Generic;
using System.Linq;
using Data.Context;

namespace Data.Services
{
    public class InformeConsolidadoLotesPorCultivoService: InformeConsolidadoService
    {
        public InformeConsolidadoLotesPorCultivoService(PalmAppContext context) : base(context)
        {
        }

        public override InformeConsolidadoDto GetInforme()
        {
             var informe = new InformeConsolidadoDto()
            {
                Titulo = "Informe consolidado de Lotes por Cultivo",
                Fecha = DateTime.Now
            };

            informe.Detalles = _context.Cultivos.Select(t => new InformeConsolidadoDetalleDto()
            {
                Descripcion = (t.Nombre),
                Cantidad = t.Lotes.Count
            }).ToList();

            return informe;
        }
    }
}