using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelAPI.Models
{
    public class Personagem
    {
        private int v1;
        private string v2;
        private string v3;

        public Personagem(int id, string nome, string thumbnail)
        {
            IdCharacter = id;
            Nome = Nome;
            Thumbnail = thumbnail;
        }

        public int IdCharacter { get; set; }

        public string Nome { get; set; }

        public string Thumbnail { get; set; }
    }
}