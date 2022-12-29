using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Filtros
{
    public class PontoTuristicoFilter
    {
        public string Nome { get; set; } = "";
        public string Descricao { get; set; } = "";
        public int EstadoId { get; set; }
        public int MunicipioId { get; set; }
    }
}
