using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoTuristicos.API.DTO
{
    public class PontoTuristicoDTO
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int EstadoId { get; set; }
        public int MunicipioId { get; set; }
    }
}
