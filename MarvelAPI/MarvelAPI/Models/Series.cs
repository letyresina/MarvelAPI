using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelAPI.Models
{
    public class Series
    {

        public Series(int id, string title, string thumbnail)
        {
            IdSerie = id;
            Title = title;
            Thumbnail = thumbnail;
        }

        public int IdSerie { get; set; }

        public string Title { get; set; }

        public string TitleStartsWith { get; set; }

        public string Thumbnail { get; set; }
    }
}