using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;

namespace Controller_Api
{
    public class Cadastro
    {
        [Required(ErrorMessage = "CPF obrigatório")]
        [MaxLength(11, ErrorMessage = "CPF deve conter apenas 11 caracteres")]
        [MinLength(11, ErrorMessage = "CPF deve conter 11 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        [MinLength(2)]
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        [Range(10, 30)]
        public int Idade { get; set; }

        public Cadastro(string nome, string cpf, DateTime dataNasc, int idade)
        {
            Cpf = cpf;
            Nome = nome;
            DataNascimento = dataNasc;
            Idade = idade;
        }

        public Cadastro()
        {
        }
    }
}