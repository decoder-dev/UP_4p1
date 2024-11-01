using MySql.Data.MySqlClient;

namespace Kindergarten
{
    public class DBConnection
    {
        public static string connect = @"database=deti;port=3306;server=localhost;user=root;password=qwerty;SslMode=none;";
        public static MySqlConnection myconnect;
        public static MySqlCommand mycommand;
        public static MySqlDataAdapter msDataAdapter;
        public static string user;
        public static int Role;

        public static bool connect_BD()
        {
            myconnect = new MySqlConnection(connect);
            myconnect.Open();
            mycommand = new MySqlCommand();
            mycommand.Connection = myconnect;
            msDataAdapter = new MySqlDataAdapter(mycommand);
            return true;
        }

        public static void close_BD()
        {
            myconnect.Close();
        }
    }
}