using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locadoraAPI.Model
{
    public class Filme
    {
        public int IdFilme { get; set; }
        public string Titulo { get; set; }
        public string DataLancamento { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public int Alugado { get; set; }
        public int Ativo { get; set; }
        
    }
}
