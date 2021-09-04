using Domain.Cultivos;
using Domain.Lotes;
using Domain.Palmas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Alertas
{
    public class Alerta
    {
        public long Id { get; private set; }
        public DateTime Fecha { get; private set; }
        public string Asunto { get; private set; }
        public string Descripcion { get; private set; }
        public byte[] Adjunto { get; private set; }
        public long? CultivoId { get; private set; }
        public virtual Cultivo Cultivo { get; private set; }
        public long? LoteId { get; private set; }
        public virtual Lote Lote { get; private set; }
        public long? PalmaId { get; private set; }
        public virtual Palma Palma { get; private set; }
        public string Estado { get; private set; }

        private readonly List<AlertaSeguimiento> _seguimiento;
        public IReadOnlyCollection<AlertaSeguimiento> Seguimiento => _seguimiento.AsReadOnly();
    }
}
