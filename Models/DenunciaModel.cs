using System.ComponentModel.DataAnnotations;

namespace ProjetoFloresta.Models
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DenunciaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public CategoriaEnum Categoria { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A hora é obrigatória.")]
        public TimeSpan Hora { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; }

        [NotMapped]
        public IFormFile ImagemUpload { get; set; }

        public string Imagem { get; set; }

        public string Localizacao { get; set; }
    }
    // Enum para as categorias (Exemplo)
    public enum CategoriaEnum
    {
        Ambiente,
        Trânsito,
        Segurança,
        Outros
    }

}
