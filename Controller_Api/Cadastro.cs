using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Controller_Api
{
    public class Cadastro
    {
        public string Cpf { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

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