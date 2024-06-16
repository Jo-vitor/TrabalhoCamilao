namespace LivrosAPi.Models
{
    public class Livro : IBaseModel
    {
        public int? Id { get; set; }

        public string Titulo {get; set;}

        public string Categoria {get; set;}

        public string Descricao {get; set;}

        public string Autor {get; set;}
    }
}
