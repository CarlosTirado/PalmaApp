using Domain.Cultivos;
using Domain.Lotes;
using Domain.Palmas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Alertas
{
    public class AlertaSeguimiento
    {
        public long Id { get; private set; }
        public long AlertaId { get; private set; }
        public virtual Alerta Alerta { get; private set; }
        public DateTime Fecha { get; private set; }
        public string Descripcion { get; private set; }
        public byte[] Adjunto { get; private set; }
        public string Estado { get; private set; }
    }
}
