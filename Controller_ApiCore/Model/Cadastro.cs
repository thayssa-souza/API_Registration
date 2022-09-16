using System.ComponentModel.DataAnnotations;

namespace ApiBanco.Core.Services
{
    public class Cadastro
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "CPF obrigatório")]
        [MaxLength(11, ErrorMessage = "CPF deve conter apenas 11 caracteres")]
        [MinLength(11, ErrorMessage = "CPF deve conter 11 caracteres")]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        [MinLength(3, ErrorMessage = "Nome precisa conter, no mínimo, 3 caracteres")]
        public string? Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        [Range(18, 90, ErrorMessage = "Aceitamos clientes com idade a partir de 18 anos e idade máxima de 90 anos")]
        public int? Idade { get; private set; }

        [Required]
        public string Permissao { get; set; }

        public Cadastro(long id, string cpf, string nome, DateTime dataNascimento, int idade, string permissao)
        {
            Id = id;
            Cpf = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
            Idade = GetIdade();
            Permissao = permissao;
        }

        public int GetIdade()
        {
            int idade = DateTime.Now.Year - DataNascimento.Year;
            if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
                idade--;
            return idade;
        }
    }
}