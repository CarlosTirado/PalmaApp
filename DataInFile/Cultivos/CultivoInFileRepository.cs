using Domain.Cultivos;
using Domain.Lotes;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataInfile.Cultivos
{
    public class CultivoInFileRepository : ICultivoRepository
    {
        private readonly StreamReader _fileData;

        public CultivoInFileRepository(StreamReader fileData)
        {
            _fileData = fileData;
        }

        public ICollection<Cultivo> Gets()
        {
            /// Logica de consultar una lista de Cultivo en archivo plano
            /// ...
            /// ...
            /// ...
            /// 

            return new List<Cultivo>()
            {
                new Cultivo("Cultivo_Fake 1",DateTime.Now),
                new Cultivo("Cultivo_Fake 2",DateTime.Now),
                new Cultivo("Cultivo_Fake 3",DateTime.Now)
            };
        }

        public Cultivo Get(long id)
        {
            /// Logica de consultar un Cultivo en archivo plano
            /// ...
            /// ...
            /// ...
            /// 

            return new Cultivo("Cultivo_Fake 1",DateTime.Now);
        }

        public void Add(Cultivo cultivo)
        {
            // Logica de guardar un cultivo en archivo plano
        }

        public Lote GetLotePorId(long loteId)
        {
            /// Logica de consultar un Lote de un cultivo por Id en archivo plano
            /// ...
            /// ...
            /// ...
            /// 

            return new Lote(cultivoId: 1, nombre: "Lote_Fake", numeroHectareas: 5);
        }

        public ICollection<Lote> GetLotes(long cultivoId)
        {
            /// Logica de consultar una Lotes de Cultivo en archivo plano
            /// ...
            /// ...
            /// ...
            /// 

            return new List<Lote>()
            {
                new Lote(cultivoId: 1, nombre: "Lote_Fake 1", numeroHectareas: 5),
                new Lote(cultivoId: 1, nombre: "Lote_Fake 2", numeroHectareas: 5),
                new Lote(cultivoId: 1, nombre: "Lote_Fake 3", numeroHectareas: 5)
            };
        }
    }
}
