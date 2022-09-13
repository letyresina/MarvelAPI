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
        static string database = "marvelapi.sql";

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



        public void Fechar()
        {
            //fechando a conexão no banco
            conexao.Close();
        }


    }
}