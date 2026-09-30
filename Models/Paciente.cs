using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agendamento.Models
{
    [Index(nameof(CPF), IsUnique = true)]
    public class Paciente
    {
        [Key]
        public int PacienteId { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Nome { get; set; }
        [Required]
        [MaxLength(11)]
        public string? CPF { get; set; }
        [Required]
        [MaxLength(14)]
        public string? Telefone { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Endereco { get; set; }
        [Required]
        public DateOnly DataNascimento { get; set; }
    }
}
