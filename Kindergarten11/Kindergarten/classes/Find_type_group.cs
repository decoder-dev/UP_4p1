using System;

namespace Kindergarten
{
    internal class Find_type_group
    {
        public static string Type;

        public static bool Proverka(string Group)
        {
            try
            {
                string sql = "SELECT types_of_group.Name FROM types_of_group,group_kid Where types_of_group.Kod_typegroup = group_kid.Kod_typegroup AND group_kid.Name='" + Group + "';";
                DBConnection.mycommand.CommandText = sql;
                Object rez = DBConnection.mycommand.ExecuteScalar();

                if (rez != null)
                {
                    Type = rez.ToString();
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