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
        private long _Id;
        private string _Consecutivo;
        private decimal _Altura;
        private string _Descripcion;
        private DateTime _FechaSiembra;
        private string _Estado;
        private long _LoteId;
        public virtual Lote Lote { get;  set; }

        public long Id { get => _Id; set => _Id = value; }
        public string Consecutivo { get => _Consecutivo; set => _Consecutivo = value; }
        public decimal Altura { get => _Altura; set => _Altura = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public DateTime FechaSiembra { get => _FechaSiembra; set => _FechaSiembra = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public long LoteId { get => _LoteId; set => _LoteId = value; }

        public Palma() { }

        public Palma(
            decimal altura,
            string descripcion,
            DateTime fechaSiembra)
        {
            _Altura = altura;
            _Descripcion = descripcion;
            _FechaSiembra = fechaSiembra;
            _Estado = EstadoGeneralEnumeration.Activo.Id;
        }

        public void Editar(
            decimal altura, 
            string descripcion, 
            DateTime fechaSiembra,
            string estado)
        {
            _Altura = altura;
            _Descripcion = descripcion;
            _FechaSiembra = fechaSiembra;
            _Estado = estado;
        }

        public void AsignarConsecutivo(
           string consecutivo)
        {
            _Consecutivo = consecutivo;
        }
    }
}