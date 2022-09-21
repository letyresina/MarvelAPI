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
            IdSeries = id;
            Title = title;
            Thumbnail = thumbnail;
        }

        public int IdSeries { get; set; }

        public string Title { get; set; }

        public string TitleStartsWith { get; set; }

        public string Thumbnail { get; set; }
    }
}