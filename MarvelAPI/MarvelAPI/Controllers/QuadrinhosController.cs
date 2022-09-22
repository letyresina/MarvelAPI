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
    public class QuadrinhosController : ApiController
    {
        List<Quadrinhos> quadrinhos = new List<Quadrinhos>(new Quadrinhos[] { new Quadrinhos(1, "Alpha Flight (2011) #8 (Yu Variant)", 8, "http://i.annihil.us/u/prod/marvel/i/mg/c/70/4bc37e337b8af,jpg"),});

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [ActionName("getQuadrinhos")]
        public Quadrinhos Get(int id)
        {
            var quadrinho = quadrinhos.FirstOrDefault((p) => p.IdComics == id);
            return quadrinho;
        }

        [HttpGet]
        [ActionName("getAll")]
        public IEnumerable GetAllQuadrinhos()
        {
            try
            {
                BDConexao db = new BDConexao();
                var quadrinho = db.BuscaTodosComics();
                db.Fechar();
                return quadrinho;
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
            return quadrinhos.Where(
                (p) => string.Equals(p.Title, title,
                    StringComparison.OrdinalIgnoreCase));
        }
    }
}