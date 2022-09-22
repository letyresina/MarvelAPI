using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using MarvelAPI.Models;
using System.Web;

namespace MarvelAPI.Controllers
{
    public class BDConexao
    {
        MySqlConnection conexao;

        //servidor qual está localizado o banco de dados
        static string host = "localhost";

        //nome do arquivo de banco de dados
        static string database = "dbMarvelAPI";

        //usuário de conexão do banco
        static string userDB = "root";

        //senha do usuário para acesso
        static string password = "leleca0404";

        //string de conexão ao banco
        public static string strProvider = "server=" + host +
                                            ";Database=" + database +
                                            ";User ID=" + userDB +
                                            ";Password=" + password;

        public static Boolean novo = false;
        public String sql;

        public BDConexao()
        {
            //criando a conexão
            conexao = new MySqlConnection(strProvider);
            //abre uma conexão no banco
            conexao.Open();
        }

        //Para toda ação, necessito criar um metódo no banco.

        //Select de personagem
        public List<Personagem> BuscaTodos()
        {     
            MySqlDataReader reader;

            sql = "SELECT * FROM Personagem;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            reader = cmd.ExecuteReader();
            List<Personagem> perso = new List<Personagem>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    perso.Add(new Personagem(int.Parse(reader["IdCharacter"].ToString()), reader["Nome"].ToString(), reader["Thumbnail"].ToString()));

                }
            }
            return perso;
        }

        //Select de series
        public List<Series> BuscaTodosSeries()
        {
            MySqlDataReader reader;

            sql = "SELECT * FROM Series;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            reader = cmd.ExecuteReader();
            List<Series> serie = new List<Series>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    serie.Add(new Series(int.Parse(reader["IdSerie"].ToString()), reader["Title"].ToString(), reader["Thumbnail"].ToString()));

                }
            }
            return serie;
        }

        //Select de Comics 
        public List<Quadrinhos> BuscaTodosComics()
        {
            MySqlDataReader reader;

            sql = "SELECT * FROM Quadrinhos;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            reader = cmd.ExecuteReader();
            List<Quadrinhos> quadrinho = new List<Quadrinhos>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    quadrinho.Add(new Quadrinhos(int.Parse(reader["IdComics"].ToString()), reader["Title"].ToString(), int.Parse(reader["IssueNumber"].ToString()), reader["Thumbnail"].ToString()));

                }
            }
            return quadrinho;
        }

        //Selects para tabelas intermediárias (sujeito a mudanças futuras)

        public List<Personagem_Series> BuscaTodosPS()
        {
            MySqlDataReader reader;

            sql = "SELECT * FROM PersonagemSerie;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            reader = cmd.ExecuteReader();
            List<Personagem_Series> PS = new List<Personagem_Series>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    PS.Add(new Personagem_Series(int.Parse(reader["IdSerie"].ToString()), int.Parse(reader["IdCharacter"].ToString())));

                }
            }
            return PS;
        }

        public List<Personagem_Quadrinho> BuscaTodosPQ()
        {
            MySqlDataReader reader;

            sql = "SELECT * FROM PersonagemQuadrinho;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            reader = cmd.ExecuteReader();
            List<Personagem_Quadrinho> PQ = new List<Personagem_Quadrinho>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    PQ.Add(new Personagem_Quadrinho(int.Parse(reader["IdComics"].ToString()), int.Parse(reader["IdCharacter"].ToString())));

                }
            }
            return PQ;
        }

        public void Fechar()
        {
            //fechando a conexão no banco
            conexao.Close();
        }


    }
}