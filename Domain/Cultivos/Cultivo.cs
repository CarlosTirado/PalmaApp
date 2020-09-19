using Domain.DatosBasicos.EstadosGenerales;
using Domain.Lotes;
using System;
using System.Collections.Generic;

namespace Domain.Cultivos
{
    public class Cultivo
    {
        public Cultivo(string nombre, DateTime fechaSiembra)
        {
            Nombre = nombre;
            FechaSiembra = fechaSiembra;
            Estado = EstadoGeneralEnumeration.Activo.Id;
        }

        public long Id { get; private set; }
        public string Nombre { get; private set; }
        public DateTime FechaSiembra { get; private set; }
        public string Estado { get; private set; }
        public virtual IReadOnlyCollection<Lote> Lotes { get; private set; }
        private ICollection<Lote> _lotes => (Lotes as ICollection<Lote>);

        public void Editar(string nombre, DateTime fechaSiembra, string estado)
        {
            Nombre = nombre;
            FechaSiembra = fechaSiembra;
            Estado = estado;
        }

        public void AgregarLote(string nombre, int numeroHectareas)
        {
            var lote = new Lote(cultivoId: Id, nombre, numeroHectareas);
            _lotes.Add(lote);
        }
    }
}
