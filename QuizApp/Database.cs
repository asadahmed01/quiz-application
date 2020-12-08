using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
namespace QuizApp
{
    
    public class Database
    {
        private static string username = "root";
        private static string password = "root";
        private static string server = "localhost";
        private static string dbase = "quizDB";
        private static string connectionString = "SERVER=" + server + ";" + "DATABASE=" + dbase + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";

        MySqlConnection newCon = new MySqlConnection(connectionString);

    }
}
