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

        List<Personagem> personagens = new List<Personagem>(new Personagem[] { new Personagem(1, "Wanda Maximoff", "wanda.png"),
                                                            new Personagem(2, "Loki", "loki.png"),
                                                            new Personagem(3, "Spider-Man", "spiderman.png"),
                                                            new Personagem(4, "Iron Man", "ironman.png")});

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

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