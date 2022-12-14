using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelAPI.Models
{
    public class Quadrinhos
    {

        public Quadrinhos(int id, string title, int issuenumber, string thumbnail)
        {
            IdComics = id;
            Title = title;
            IssueNumber = issuenumber;
            Thumbnail = thumbnail;
        }

        public int IdComics { get; set; }
        
        public string Title { get; set; }

        public string TitleStartsWith { get; set; }

        public int IssueNumber { get; set; }

        public string Thumbnail { get; set; }

    }
}