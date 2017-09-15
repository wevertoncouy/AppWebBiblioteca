using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppBliblioteca.Models
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Rua { get; set; }
        public string Cep { get; set; }
    }
}