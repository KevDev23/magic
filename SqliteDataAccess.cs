using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace magic
{
    public class SqliteDataAccess
    {
        public static List<CasterModel> loadChar()
        {
            using (System.Data.IDbConnection conn = new SQLiteConnection(loadConnStr()))
            {
                var retrieved = conn.Query<CasterModel>("select * from casters", new DynamicParameters());
                return retrieved.ToList();
            }
        }

        public static void saveChar(CasterModel character)
        {
            using (System.Data.IDbConnection conn = new SQLiteConnection(loadConnStr())) 
            {
                conn.Execute("insert into casters (level, currMP, Name) values (@level, @mp, @characterName)", character);
            }
        }

        private static String loadConnStr(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }


    }
}
