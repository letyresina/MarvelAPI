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
    public class PersonagemController : ApiController
    {

        List<Personagem> personagens = new List<Personagem>(new Personagem[] { new Personagem(1, "Scarlet Witch", "http://i.annihil.us/u/prod/marvel/i/mg/6/70/5261a7d7c394b.jpg"),
                                                            new Personagem(2, "Loki", "http://i.annihil.us/u/prod/marvel/i/mg/d/90/526547f509313.jpg"),
                                                            new Personagem(3, "Spider-Man", "http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available.jpg"),
                                                            new Personagem(4, "Iron Man", "http://i.annihil.us/u/prod/marvel/i/mg/9/c0/527bb7b37ff55.jpg")});

        // GET: api/Marvel/getPersonagem/5
        [HttpGet]
        [ActionName("getPersonagem")]
        public Personagem Get(int id)
        {
            var personagem = personagens.FirstOrDefault((p) => p.IdCharacter == id);
            return personagem;
        }

        //exemplo de método com busca em Banco de dados
        [HttpGet]
        [ActionName("getAll")]
        public IEnumerable GetAllPersonagem()
        {
            try
            {
                BDConexao db = new BDConexao();
                var perso = db.BuscaTodos();
                db.Fechar();
                return perso;
            }
            catch (Exception e)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                throw new HttpResponseException(resp);
            }
        }

        [HttpGet]
        [ActionName("getByNome")]
        public IEnumerable GetPersonagensByNome(string nome)
        {
            return personagens.Where(
                (p) => string.Equals(p.Nome, nome,
                    StringComparison.OrdinalIgnoreCase));
        }

    }
}