using Domain.Cultivos;
using Domain.DatosBasicos;
using Domain.Palmas;
using Domain.Tareas;
using System;

namespace Domain.Base
{
    public interface IPalmAppUnitOfWork
    {
        DateTime DateNow { get; }
        int Commit();
        ITerceroRepository TerceroRepository { get; }
        ICultivoRepository CultivoRepository { get; }
        ITareaRepository TareaRepository { get; }
        IPalmaRepository PalmaRepository { get; }
    }
}