using Dapper;
using Microsoft.Data.Sqlite;
using LivrosAPi.Models;

namespace LivrosAPi.Daos
{
    public abstract class BaseDAO<T> where T:IBaseModel
    {
        private static string GetStringConexao() => 
        "Data Source=./db/livroDB.db";
        public abstract string NomeTabela { get; }

        public async Task InserirAsync(T obj)
        {

            using (var conexao = new SqliteConnection(GetStringConexao()))
            {
                conexao.Open();

                string sql = $"INSERT INTO {NomeTabela}" +
                                    $" (titulo, categoria, descricao, autor)" +
                                    $" VALUES (@Titulo, @Categoria, @Descricao, @Autor)";

                await conexao.ExecuteAsync(sql, obj);
            }
        }

        public async Task AlterarAsync(T obj)
        {
            using (var conexao = new SqliteConnection(GetStringConexao()))
            {
                conexao.Open();

                string sql = $"UPDATE {NomeTabela}" +
                    $" SET titulo = @Titulo, categoria = @Categoria, descricao = @Descricao, Autor = @Autor" +
                    " WHERE id = @Id";

                await conexao.ExecuteAsync(sql, obj);
            }
        }

        public async Task ExcluirAsync(int id)
        {
            using (var conexao = new SqliteConnection(GetStringConexao()))
            {
                conexao.Open();

                string sql = $"DELETE FROM {NomeTabela} WHERE id = @Id";

                await conexao.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IList<T>> RetornarTodosAsync()
        {
            using (var conexao = new SqliteConnection(GetStringConexao()))
            {
                conexao.Open();

                string sql = $"SELECT * FROM {NomeTabela}";

                var objetos = await conexao.QueryAsync<T>(sql);

                return objetos.ToList();
            }
        }

        public async Task<T> RetornarPorIdAsync(int id)
        {
            using (var conexao = new SqliteConnection(GetStringConexao()))
            {
                conexao.Open();

                string sql = $"SELECT * FROM {NomeTabela} WHERE id = @Id";

                var obj = await conexao.QuerySingleAsync<T>(sql, new { Id = id });

                return obj;
            }
        }
    }
}
