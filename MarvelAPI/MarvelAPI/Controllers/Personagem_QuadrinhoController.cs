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
    public class Personagem_QuadrinhoController : ApiController
    {
        // GET: Personagem_Quadrinho

        List<Personagem_Quadrinho> pq = new List<Personagem_Quadrinho>(new Personagem_Quadrinho[] { new Personagem_Quadrinho(1, 1)});

        [HttpGet]
        [ActionName("getPersonagemQuadrinho")]
        public Personagem_Quadrinho Get(int id)
        {
            var personagemquadrinho = pq.FirstOrDefault((p) => p.IdCharacter == id);
            return personagemquadrinho;
        }

        //exemplo de método com busca em Banco de dados
        [HttpGet]
        [ActionName("getAll")]
        public IEnumerable GetAllPersoQuadrinho()
        {
            try
            {
                BDConexao db = new BDConexao();
                var persoq = db.BuscaTodosPQ();
                db.Fechar();
                return persoq;
            }
            catch (Exception e)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                throw new HttpResponseException(resp);
            }
        }

    }
}