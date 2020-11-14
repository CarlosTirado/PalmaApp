using Domain.Contrato;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Palmas
{
    public partial class Palma
    {
        public class PalmaBuilder : IBuilderPalma
        {        
            private string consecutivo;
            private decimal altura;
            private string descripcion;
            private DateTime fechaSiembra;
            private string estado;

            public PalmaBuilder() { }
            
            public PalmaBuilder Altura(decimal altura)
            {
                this.altura = altura;
                return this;
            }
            public PalmaBuilder Consecutivo(string consecutivo)
            {
                this.consecutivo = consecutivo;
                return this;
            }
            public PalmaBuilder Descripcion(string descripcion)
            {
                this.descripcion = descripcion;
                return this;
            }
            public PalmaBuilder FechaSiembra(DateTime fechaSiembra)
            {
                this.fechaSiembra = fechaSiembra;
                return this;
            }
            public PalmaBuilder Estado(string estado)
            {
                this.estado = estado;
                return this;
            }

            public Palma Build()
            {
                Palma palma = new Palma();
                palma.Altura = altura;
                palma.Consecutivo = consecutivo;
                palma.Descripcion = descripcion;
                palma.FechaSiembra = fechaSiembra;
                palma.Estado = estado;
                return palma;
            }
        }
    }
}
