using System.IO;
using System.Reflection;
using DataInfile.Cultivos;
using DataInFile.DatosBasicos.Terceros;
using DataInFile.Lotes;
using DataInFile.Palmas;
using DataInFile.Tareas;
using Domain.Base;
using Domain.Cultivos;
using Domain.DatosBasicos;
using Domain.Lotes;
using Domain.Palmas;
using Domain.Tareas;

namespace DataInFile.Base
{
    public class RepositoryInFileAbstractFactory: IRepositoryAbstractFactory
    {
        private ITerceroRepository _terceroRepository;
        private ICultivoRepository _cultivoRepository;
        private ILoteRepository _loteRepository;
        private ITareaRepository _tareaRepository; 
        private IPalmaRepository _palmaRepository;
        
        private readonly StreamReader _fileData;


        public RepositoryInFileAbstractFactory()
        {
            var currentDirectory = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var rutaArchivo = $"{currentDirectory}/DataInFile/PalmAppData.txt";
            _fileData = new StreamReader(rutaArchivo);
        }
        
        public ITerceroRepository CreateTerceroRepository()
        {
            return _terceroRepository ??= new TerceroInFileRepository(_fileData);
        }

        public ICultivoRepository CreateCultivoRepository()
        {
            return _cultivoRepository ??= new CultivoInFileRepository(_fileData);
        }

        public ILoteRepository CreateLoteRepository()
        {
            return _loteRepository ??= new LoteInFileRepository(_fileData);
        }

        public ITareaRepository CreateTareaRepository()
        {
            return _tareaRepository ??= new TareaInFileRepository(_fileData);
        }

        public IPalmaRepository CreatePalmaRepository()
        {
            return _palmaRepository ??= new PalmaInFileRepository(_fileData);
        }
    }
}