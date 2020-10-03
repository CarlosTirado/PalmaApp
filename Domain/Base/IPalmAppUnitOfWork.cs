using Domain.Cultivos;
using Domain.DatosBasicos;
using Domain.Palmas;
using Domain.Tareas;

namespace Domain.Base
{
    public interface IPalmAppUnitOfWork
    {
        void Commit();
        ITerceroRepository TerceroRepository { get; }
        ICultivoRepository CultivoRepository { get; }
        ITareaRepository TareaRepository { get; }
        IPalmaRepository PalmaRepository { get; }
    }
}