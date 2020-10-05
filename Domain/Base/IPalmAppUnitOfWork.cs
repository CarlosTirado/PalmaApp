using Domain.Cultivos;
using Domain.DatosBasicos;
using Domain.Lotes;
using Domain.Palmas;
using Domain.Tareas;

namespace Domain.Base
{
    public interface IPalmAppUnitOfWork
    {
        void Commit();
        ITerceroRepository TerceroRepository { get; }
        ICultivoRepository CultivoRepository { get; } 
        ILoteRepository LoteRepository { get; }
        ITareaRepository TareaRepository { get; }
        IPalmaRepository PalmaRepository { get; }
    }
}