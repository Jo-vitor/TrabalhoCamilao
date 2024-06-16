using LivrosAPi.Models;

namespace LivrosAPi.Daos
{
    public class LivroDAO : BaseDAO<Livro>
    {
        public override string NomeTabela => "Livro";
        
    }
}
