using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelAPI.Models
{
    public class Quadrinhos
    {
        public int IdComics { get; set; }
        
        public string Title { get; set; }

        public string TitleStartsWith { get; set; }

        public int IssueNumber { get; set; }

        public string Thumbnail { get; set; }

    }
}