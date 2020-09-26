using Domain.Cultivos;
using Domain.DatosBasicos.EstadosGenerales;
using Domain.Palmas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Lotes
{
    public class Lote
    {
        public Lote(long cultivoId, string nombre, decimal numeroHectareas)
        {
            CultivoId = cultivoId;
            Nombre = nombre;
            NumeroHectareas = numeroHectareas;
            Estado = EstadoGeneralEnumeration.Activo.Id;
            _palmas = new List<Palma>();
        }

        public long Id { get; private set; }
        public string Nombre { get; private set; }
        public decimal NumeroHectareas { get; private set; }
        public string Estado { get; private set; }
        public long CultivoId { get; private set; }
        public virtual Cultivo Cultivo { get; private set; }

        private readonly List<Palma> _palmas;
        public IReadOnlyCollection<Palma> Palmas => _palmas.AsReadOnly();

        public void Editar(string nombre, decimal numeroHectareas, string estado)
        {
            Nombre = nombre;
            NumeroHectareas = numeroHectareas;
            Estado = estado;
        }

        public void AgregarPalma(Palma palma)
        {
            if (Palmas.Any())
            {
                var ultimoConsecutivo = Palmas.OrderByDescending(t => t.Id).FirstOrDefault().Consecutivo;
                palma.AsignarConsecutivo((int.Parse(ultimoConsecutivo) + 1).ToString().PadLeft(4, '0'));
            }
            else
            {
                palma.AsignarConsecutivo(("1").PadLeft(4, '0'));
            }

            _palmas.Add(palma);
            
        }
    }
}
