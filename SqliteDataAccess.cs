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
                var retrieved = conn.Query<CasterModel>("Select * from casters", new DynamicParameters());
                return retrieved.ToList();
            }
        }

        public static void saveChar(CasterModel character)
        {
            using (System.Data.IDbConnection conn = new SQLiteConnection(loadConnStr())) 
            {
            
                conn.Execute("insert into casters (level, mp, characterName) values (@level, @mp, @characterName)", character);
            }
        }

        public static void updateChar(CasterModel character)
        {
            using (System.Data.IDbConnection conn = new SQLiteConnection(loadConnStr()))
            {
                System.Diagnostics.Debug.WriteLine("updateChar name, mp, max, level:"+ character.characterName + " " + character.mp + " " + character.maxMP + " " + character.level);
                conn.Execute("update casters set level = @level, mp = @mp where characterName = @characterName", character);
            }
        }

        public static void deleteChar(CasterModel character)
        {
            using (System.Data.IDbConnection conn = new SQLiteConnection(loadConnStr()))
            {
                System.Diagnostics.Debug.WriteLine("deleteChar name, mp, max, level:" + character.characterName + " " + character.mp + " " + character.maxMP + " " + character.level);
                conn.Execute("delete from casters where characterName = @characterName", character);
            }
        }
        private static String loadConnStr(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }


    }
}
