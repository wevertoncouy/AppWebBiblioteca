using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppBliblioteca.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string Nome { get; set; }

        public List<Livro> Livros { get; set; }
        public List<Requisicao> Requisicaos { get; set; }
        public List<Funcionario>Funcionariros { get; set; }
    }
}