using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locadoraAPI.Model
{
    public class Locador
    {
        public int idLocador { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string NumeroContato { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string DataNascimento { get; set; }

    }
}
