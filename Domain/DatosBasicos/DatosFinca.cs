using Newtonsoft.Json;
using System;
using System.IO;

namespace Domain.DatosBasicos
{
    public class DatosFinca
    {
        private DatosFinca() { }

        private static DatosFinca _datosFinca { get; set; }

        public Guid InstanceId { get; private set; }
        
        [JsonProperty]
        public string FincaNombre { get; private set; }
        [JsonProperty]
        public string PropietarioIdentificacion { get; private set; }
        [JsonProperty]
        public string PropietarioNombre { get; private set; }
        [JsonProperty]
        public string Direccion { get; private set; }
        [JsonProperty]
        public string Telefono { get; private set; }
        [JsonProperty]
        public string FincaLogo { get; private set; }

        public static DatosFinca GetDatosFinca()
        {
            if (_datosFinca == null)
            {
                string path = $"{AppDomain.CurrentDomain.BaseDirectory}/datosFinca.json";
                _datosFinca = new DatosFinca();
                _datosFinca = JsonConvert.DeserializeObject<DatosFinca>(File.ReadAllText(path));
                _datosFinca.InstanceId = Guid.NewGuid();
            }

            return _datosFinca;
        }
    }
}
