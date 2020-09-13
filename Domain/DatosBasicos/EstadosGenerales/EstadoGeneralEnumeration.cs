using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.DatosBasicos.EstadosGenerales
{
    public class EstadoGeneralEnumeration : Enumeration<EstadoGeneralEnumeration, string>
    {
        public static readonly EstadoGeneralEnumeration Activo = new EstadoGeneralEnumeration("AC", "ACTIVO");
        public static readonly EstadoGeneralEnumeration Inactivo = new EstadoGeneralEnumeration("IN", "INACTIVO");

        protected EstadoGeneralEnumeration(string id, string name) : base(id, name) { }

        public static bool IsValid(string estado)
        {
            return GetAll().Any(t => t.Id == estado);
        }
    }
}
