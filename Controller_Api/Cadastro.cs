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
        [MinLength(3, ErrorMessage = "Nome precisa conter, no mínimo, 3 caracteres")]
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        [Range(10, 60, ErrorMessage = "Aceitamos clientes com idade a partir de 10 anos e idade máxima de 60 anos")]
        public int Idade => GetIdade(DataNascimento);

        public Cadastro(string cpf, string nome, DateTime dataNasc)
        {
            Cpf = cpf;
            Nome = nome;
            DataNascimento = dataNasc;
        }

        public Cadastro()
        {
        }

        public int GetIdade(DateTime DataNascimento)
        {
            int Idade;

            if (DataNascimento.Month > DateTime.Now.Month)
            {
                Idade = (DateTime.Now.Year - DataNascimento.Year) - 1;
                return Idade;
            }
            else if (DataNascimento.Month < DateTime.Now.Month)
            {
                Idade = (DateTime.Now.Year - DataNascimento.Year);
                return Idade;
            }
            else
            {
                if (DataNascimento.Day > DateTime.Now.Day)
                {
                    Idade = (DateTime.Now.Year - DataNascimento.Year) - 1;
                    return Idade;
                }
                else
                {
                    Idade = (DateTime.Now.Year - DataNascimento.Year);
                    return Idade;
                }
            }
        }
    }
}