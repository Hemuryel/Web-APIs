using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos
{
    public class ReadGerenteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        //public List<Cinema> Cinemas { get; set; }
        // deixar object (anônimo) para poder manipular no profile
        //   e evitar de repetir a informação gerente dentro do cinema
        public object Cinemas { get; set; }
    }
}
