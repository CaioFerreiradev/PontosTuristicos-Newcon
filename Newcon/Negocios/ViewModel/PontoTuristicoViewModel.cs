using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ViewModel
{
    public class PontoTuristicoViewModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public DateTime CriadoEm { get; set; }
        //public Estado Estado { get; set; }
        //public Municipio Municipio { get; set; }
        public int EstadoId { get; set; }
        public int MunicipioId { get; set; }
    }
}
