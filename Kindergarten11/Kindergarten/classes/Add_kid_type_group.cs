using System.Data;

namespace Kindergarten
{
    internal class Add_kid_type_group
    {
        public static DataTable dt = new DataTable();

        public static bool Type(string type)
        {
            try
            {
                string sql = "SELECT Kod_Group,Name FROM group_kid where  Kod_typegroup ='" + type + "';";
                DBConnection.mycommand.CommandText = sql;
                dt.Clear();
                DBConnection.msDataAdapter.Fill(dt);

                if (DBConnection.mycommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}