using System;

namespace Kindergarten
{
    internal class DBAdd_data_vac
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="kod_vak"></param>
        /// <param name="data"></param>
        /// <param name="kod_kid"></param>
        /// <returns></returns>
        public static bool Add(string kod_vak, DateTime data, string kod_kid)
        {
            try
            {
                string sql = @"insert into vaccination_data values(null,'" + kod_vak + "','" + data.ToString("yy-MM-dd") + "','" + kod_kid + "')";
                DBConnection.mycommand.CommandText = sql;
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