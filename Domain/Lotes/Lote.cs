﻿using Domain.Cultivos;
using Domain.DatosBasicos.EstadosGenerales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Lotes
{
    public class Lote
    {
        public Lote(long cultivoId, string nombre, int numeroHectareas)
        {
            CultivoId = cultivoId;
            Nombre = nombre;
            NumeroHectareas = numeroHectareas;
            Estado = EstadoGeneralEnumeration.Activo.Id;
        }

        public long Id { get; private set; }
        public string Nombre { get; private set; }
        public int NumeroHectareas { get; private set; }
        public string Estado { get; private set; }
        public long CultivoId { get; private set; }
        public virtual Cultivo Cultivo { get; private set; }
        public void Editar(string nombre, int numeroHectareas, string estado)
        {
            Nombre = nombre;
            NumeroHectareas = numeroHectareas;
            Estado = estado;
        }
    }
}
