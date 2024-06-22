using System;
using System.ComponentModel.DataAnnotations;


namespace LivrosFront.Model
{
    public class Livro
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O título do livro é obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A categoria do livro é obrigatória.")]
        public string Categoria { get; set; }

        [StringLength(500, MinimumLength = 10, ErrorMessage = "A descrição deve ter entre 10 e 500 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O nome do autor é obrigatório.")]
        public string Autor { get; set; }
    }
}