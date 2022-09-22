using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelAPI.Models
{
    public class Personagem_Quadrinho
    {

        public Personagem_Quadrinho(int idP, int idQ)
        {
            IdCharacter = idP;
            IdComics = idQ;
        }

        public int IdCharacter { get; set; }

        public int IdComics { get; set; }
    }
}