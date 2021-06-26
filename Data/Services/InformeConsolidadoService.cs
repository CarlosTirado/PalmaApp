using System;
using System.Collections.Generic;
using Data.Context;

namespace Data.Services
{
    public abstract class InformeConsolidadoService
    {
        protected readonly PalmAppContext _context;
        protected InformeConsolidadoService(PalmAppContext context)
        {
            _context = context;
        }
        public abstract InformeConsolidadoDto GetInforme();
        public string GetInformeJSON(){
            var informe = GetInforme();
            var informeJson = Newtonsoft.Json.JsonConvert.SerializeObject(informe);
            return informeJson;
        }
    }

    public class InformeConsolidadoDto
    {
        public InformeConsolidadoDto()
        {
            Detalles = new List<InformeConsolidadoDetalleDto>();
        }
        
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<InformeConsolidadoDetalleDto> Detalles { get; set; }         
    }
    public class InformeConsolidadoDetalleDto
    {
        public string Descripcion { get; set; }
        public long Cantidad { get; set; }
    }
}