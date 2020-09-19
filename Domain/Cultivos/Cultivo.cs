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

            _lotes = new List<Lote>();
        }

        public long Id { get; private set; }
        public string Nombre { get; private set; }
        public DateTime FechaSiembra { get; private set; }
        public string Estado { get; private set; }

        private readonly List<Lote> _lotes;
        public IReadOnlyCollection<Lote> Lotes => _lotes.AsReadOnly();

        public void Editar(string nombre, DateTime fechaSiembra, string estado)
        {
            Nombre = nombre;
            FechaSiembra = fechaSiembra;
            Estado = estado;
        }

        public void AgregarLote(Lote lote)
        {
            _lotes.Add(lote);
        }
    }
}
