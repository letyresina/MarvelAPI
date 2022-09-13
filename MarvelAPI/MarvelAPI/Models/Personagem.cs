using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelAPI.Models
{
    public class Personagem
    {
        public int IdCharacter { get; set; }

        public string Name { get; set; }

        public string NameStartsWith { get; set; }

        public string Thumbnail { get; set; }
    }
}