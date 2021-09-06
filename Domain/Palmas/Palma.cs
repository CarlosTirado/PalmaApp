using Domain.Cultivos;
using Domain.DatosBasicos.EstadosGenerales;
using Domain.Lotes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Palmas
{
    public partial class Palma
    {
        public long Id { get; private set; }
        public string Consecutivo { get; private set; }
        public decimal Altura { get; private set; }
        public string Descripcion { get; private set; }
        public DateTime FechaSiembra { get; private set; }
        public string Estado { get; private set; }
        public long LoteId { get; private set; }
        public virtual Lote Lote { get; private set; }

        public Palma() { }

        public Palma(
            decimal altura,
            string descripcion,
            DateTime fechaSiembra)
        {
            Altura = altura;
            Descripcion = descripcion;
            FechaSiembra = fechaSiembra;
            Estado = EstadoGeneralEnumeration.Activo.Id;
        }

        public void Editar(
            decimal altura, 
            string descripcion, 
            DateTime fechaSiembra,
            string estado)
        {
            Altura = altura;
            Descripcion = descripcion;
            FechaSiembra = fechaSiembra;
            Estado = estado;
        }

        public void AsignarConsecutivo(
           string consecutivo)
        {
            Consecutivo = consecutivo;
        }
    }
}