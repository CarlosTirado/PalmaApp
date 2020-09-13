using Domain.DatosBasicos.EstadosGenerales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DatosBasicos
{
    public class Tercero
    {
        public Tercero(
            long id,
            string identificacion,
            string nombres,
            string apellidos,
            string telefono,
            string direccion,
            string email,
            DateTime fechaNacimiento)
        {
            Id = id;
            Identificacion = identificacion;
            Nombres = nombres;
            Apellidos = apellidos;
            Telefono = telefono;
            Direccion = direccion;
            Email = email;
            FechaNacimiento = fechaNacimiento;
            Estado = EstadoGeneralEnumeration.Activo.Id;
        }

        public long Id { get; private set; }
        public string Identificacion { get; private set; }
        public string Nombres { get; private set; }
        public string Apellidos { get; private set; }
        public string Telefono { get; private set; }
        public string Direccion { get; private set; }
        public string Email { get; private set; }
        public DateTime FechaNacimiento { get; private set; }
        public string Estado { get; private set; }

    }
}
