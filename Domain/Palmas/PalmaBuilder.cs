using Domain.Contrato;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Palmas
{
    public class PalmaBuilder : IBuilder
    {
        public PalmaBuilder() { }

        private long Id;
        private string _Consecutivo;
        private decimal _Altura;
        private string _Descripcion;
        private DateTime _FechaSiembra;
        private string _Estado;

        public PalmaBuilder Altura(decimal altura)
        {
            _Altura = altura;
            return this;
        }
        public PalmaBuilder Consecutivo(string consecutivo)
        {
            this._Consecutivo = consecutivo;
            return this;
        }
        public PalmaBuilder Descripcion(string descripcion)
        {
            this._Descripcion = descripcion;
            return this;
        }
        public PalmaBuilder FechaSiembra(DateTime fechaSiembra)
        {
            _FechaSiembra = fechaSiembra;
            return this;
        }
        public PalmaBuilder Estado(string estado)
        {
            _Estado = estado;
            return this;
        }

        public Palma Build()
        {
            Palma palma = new Palma();
            palma.Altura = _Altura;
            palma.Consecutivo = _Consecutivo;
            palma.Descripcion = _Descripcion;
            palma.FechaSiembra = _FechaSiembra;
            palma.Estado = _Estado;
            return palma;
        }
    }
}
