using Domain.Cultivos;
using Domain.DatosBasicos;
using Domain.Lotes;
using Domain.Palmas;
using Domain.Tareas;

namespace Domain.Base
{
    public interface IRepositoryAbstractFactory
    {
        ITerceroRepository CreateTerceroRepository();
        ICultivoRepository CreateCultivoRepository(); 
        ILoteRepository CreateLoteRepository();
        ITareaRepository CreateTareaRepository();
        IPalmaRepository CreatePalmaRepository();
    }
}