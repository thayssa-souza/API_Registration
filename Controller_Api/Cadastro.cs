using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;

namespace Controller_Api
{
    public class Cadastro
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "CPF obrigat�rio")]
        [MaxLength(11, ErrorMessage = "CPF deve conter apenas 11 caracteres")]
        [MinLength(11, ErrorMessage = "CPF deve conter 11 caracteres")]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "Nome obrigat�rio")]
        [MinLength(3, ErrorMessage = "Nome precisa conter, no m�nimo, 3 caracteres")]
        public string? Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        [Range(18, 90, ErrorMessage = "Aceitamos clientes com idade a partir de 18 anos e idade m�xima de 90 anos")]
        public int? Idade => DateTime.Now.Year - DataNascimento.Year;
    }
}