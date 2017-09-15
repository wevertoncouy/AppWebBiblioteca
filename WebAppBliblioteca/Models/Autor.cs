using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppBliblioteca.Models
{
    public class Autor
    {
        public int LivroId { get; set; }
        public int AutorId { get; set; }



        public List<Livro> Livros { get; set; }
      
    }
}