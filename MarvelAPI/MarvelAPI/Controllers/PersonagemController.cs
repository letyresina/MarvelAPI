using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MarvelAPI.Models;

namespace MarvelAPI.Controllers
{
    public class PersonagemController : Controller
    {

        List<Personagem> personagens = new List<Personagem>(new Personagem[] { new Personagem(1, "Wanda Maximoff", "wanda.png"),
                                                            new Personagem(2, "Loki", "loki.png"),
                                                            new Personagem(3, "Spider-Man", "spiderman.png"),
                                                            new Personagem(4, "Iron Man", "ironman.png")});

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Livro/getLivro/5
        [HttpGet]
        [ActionName("getPersonagem")]
        public Personagem Get(int id)
        {
            var personagem = personagens.FirstOrDefault((p) => p.IdCharacter == id);
            if (personagem == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                return resp;
            }
            return personagem;
        }

        //exemplo de método com busca em Banco de dados
        [HttpGet]
        [ActionName("getAll")]
        public IEnumerable GetAllLivros()
        {
            try
            {
                BDConexao db = new BDConexao();
                var l = db.BuscaTodos();
                db.Fechar();
                return l;
            }
            catch (Exception e)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                throw new HttpResponseException(resp);
            }
        }
        // POST: api/Livro
        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("addItens")]
        public HttpResponseMessage Post([FromBody] List<Personagem> itens)
        {
            if (itens == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
            personagens.AddRange(itens);
            var response = new HttpResponseMessage(HttpStatusCode.Created);
            return response;
        }

        // PUT: api/Livro/5
        [HttpPut]
        [ActionName("updateItem")]
        public HttpResponseMessage Put(int id, [FromBody] Livro item)
        {

            if (item == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }

            int index = livros.IndexOf((Livro)livros.Where((p) => p.Id == id).FirstOrDefault());
            livros[index] = item;

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        [HttpGet]
        [ActionName("getByCategoria")]
        public IEnumerable GetLivrosByCategory(string categoria)
        {
            return livros.Where(
                (p) => string.Equals(p.Categoria, categoria,
                    StringComparison.OrdinalIgnoreCase));
        }

        [HttpDelete]
        [ActionName("delete")]
        public HttpResponseMessage Delete(int id)
        {
            Livro l = (Livro)livros.Where((p) => p.Id == id);
            int index = livros.IndexOf(l);
            livros.RemoveAt(index);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}