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
    public class Personagem_SeriesController : ApiController
    {
        // GET: Personagem_Series
        List<Personagem_Series]> ps = new List<Personagem_Series>(new Personagem_Series[] { new Personagem_Series(1, 2)});

        [HttpGet]
        [ActionName("getPersonagemSerie")]
        public Personagem_Series Get(int id)
        {
            var personagemserie = ps.FirstOrDefault((p) => p.IdCharacter == id);
            return personagemserie;
        }

        //exemplo de método com busca em Banco de dados
        [HttpGet]
        [ActionName("getAll")]
        public IEnumerable GetAllPersoSeries()
        {
            try
            {
                BDConexao db = new BDConexao();
                var persoS = db.BuscaTodosPS();
                db.Fechar();
                return persoS;
            }
            catch (Exception e)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                throw new HttpResponseException(resp);
            }
        }
    }
}