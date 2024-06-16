using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrosFront.Model
{
    public class Livro
    {
        public int? Id { get; set; }
        
        public string Titulo {get; set;}

        public string Categoria {get; set;}

        public string Descricao {get; set;}

        public string Autor {get; set;}
    }
}