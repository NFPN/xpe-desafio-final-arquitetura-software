using System.ComponentModel.DataAnnotations;

namespace VendasOnline.Dominio.DTOs
{
    public class ClienteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome do cliente deve ter no máximo 100 caracteres")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "O email informado não é válido")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(14, ErrorMessage = "O CPF deve ter 14 caracteres incluindo pontuação")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF deve estar no formato 000.000.000-00")]
        public required string CPF { get; set; }

        [Phone(ErrorMessage = "O telefone informado não é válido")]
        public required string Telefone { get; set; }

        public bool Ativo { get; set; } = true;
    }
}
