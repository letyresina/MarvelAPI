using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelAPI.Models
{
    public class Personagem_Series
    {

        public Personagem_Series(int idP, int idS)
        {
            IdCharacter = idP;
            IdSeries = idS;
        }

        public int IdCharacter { get; set; }

        public int IdSeries { get; set; }
    }
}