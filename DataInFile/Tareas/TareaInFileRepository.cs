using Domain.Base;
using Domain.Tareas;
using System.Collections.Generic;
using System.IO;

namespace DataInFile.Tareas
{
    public class TareaInFileRepository : ITareaRepository
    {
        private readonly StreamReader _fileData;

        public TareaInFileRepository(StreamReader fileData)
        {
            _fileData = fileData;
        }

        public ICollection<Tarea> Gets(ISpecification<Tarea> especificacion)
        {
            /// Logica de consultar una lista de Tarea en archivo plano
            /// ...
            /// ...
            /// ...
            ///  

            return new List<Tarea>()
            {
                new Tarea(nombre: "Tarea_Fake 1", descripcion: "..."),
                new Tarea(nombre: "Tarea_Fake 2", descripcion: "..."),
                new Tarea(nombre: "Tarea_Fake 3", descripcion: "...")
            };
        }

        public Tarea Get(ISpecification<Tarea> especificacion)
        {
            /// Logica de consultar una Tarea en archivo plano
            /// ...
            /// ...
            /// ...
            /// 

            return new Tarea(nombre: "Tarea_Fake 1", descripcion: "...");
        }

        public void Add(Tarea Tarea)
        {
            //Logica de guardar Tarea en archivo plano
        }

        public ICollection<Tarea> Gets()
        {
            /// Logica de consultar una lista de Tarea en archivo plano
            /// ...
            /// ...
            /// ...
            ///  

            return new List<Tarea>()
            {
                new Tarea(nombre: "Tarea_Fake 1", descripcion: "..."),
                new Tarea(nombre: "Tarea_Fake 2", descripcion: "..."),
                new Tarea(nombre: "Tarea_Fake 3", descripcion: "...")
            };
        }
    }
}
