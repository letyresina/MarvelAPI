using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MarvelAPI.Models;
using ActionNameAttribute = System.Web.Http.ActionNameAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace MarvelAPI.Controllers
{
    public class SeriesController : ApiController
    {
        // GET: Series
        List<Series> series = new List<Series>(new Series[] { new Series(1, "Black Widow", "http://i.annihil.us/u/prod/marvel/i/mg/c/70/4bc37e337b8af,jpg"),
                                                            new Series(2, "Alpha Flight", "http://i.annihil.us/u/prod/marvel/i/mg/2/60/4bc69af2a8afd.jpg")});

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [ActionName("getSerie")]
        public Series Get(int id)
        {
            var serie = series.FirstOrDefault((p) => p.IdSeries == id);
            return serie;
        }

        [HttpGet]
        [ActionName("getAll")]
        public IEnumerable GetAllSeries()
        {
            try
            {
                BDConexao db = new BDConexao();
                var opa = db.BuscaTodosSeries();
                db.Fechar();
                return opa;
            }
            catch (Exception e)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                throw new HttpResponseException(resp);
            }
        }

        [HttpGet]
        [ActionName("getByTitle")]
        public IEnumerable GetSeriesByTitle(string title)
        {
            return series.Where(
                (p) => string.Equals(p.Title, title,
                    StringComparison.OrdinalIgnoreCase));
        }
    }
}