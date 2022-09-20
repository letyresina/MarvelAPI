using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}