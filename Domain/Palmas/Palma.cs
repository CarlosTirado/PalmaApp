using Domain.Cultivos;
using Domain.DatosBasicos.EstadosGenerales;
using Domain.Lotes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Palmas
{
    public class Palma
    {
        public long Id { get; set; }
        public string Consecutivo { get;  set; }
        public decimal Altura { get;  set; }
        public string Descripcion { get;  set; }
        public DateTime FechaSiembra { get;  set; }
        public string Estado { get;  set; }
        public long LoteId { get;  set; }
        public virtual Lote Lote { get;  set; }

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