using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace SFHelper
{
    public class DataBaseSupport
    {
        public static Dictionary<string, string> records = new Dictionary<string, string>();

        public static string pathDataBaseFile = "DataSource=" + @Environment.CurrentDirectory + @"\MyDataBase.db;Version=3;";
        public static List<string> GetTables()
        {
            List<string> listTables = new List<string>();            
            using (SQLiteConnection connect = new SQLiteConnection(pathDataBaseFile))
            {
                connect.Open();                
                SQLiteCommand command = new SQLiteCommand
                {
                    Connection = connect,
                    CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' ORDER BY 1"
                };
                using (SQLiteDataReader sqlReader = command.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        string record = (string)sqlReader["NAME"];
                        listTables.Add(record);
                    }
                }
                connect.Close();
                return listTables;
            }
        }
                
        public static List<string> GetTitles(string table)
        {
            List<string> listNames = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(pathDataBaseFile))
            {
                connect.Open();                
                SQLiteCommand command = new SQLiteCommand
                {
                    Connection = connect,
                    CommandText = "SELECT * FROM " + table
                };
                using (SQLiteDataReader sqlReader = command.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        string title = sqlReader.GetValue(1).ToString();
                        string titleText = sqlReader.GetValue(2).ToString();
                        records[title] = titleText;
                        listNames.Add(title);
                    }
                }
                connect.Close();
                return listNames;
            }
        }

        public static void CreateTable(string NameTable)
        {
            string commandStr = @"CREATE TABLE " + @NameTable + @"(id INTEGER PRIMARY KEY UNIQUE NOT NULL, Name STRING  UNIQUE NOT NULL, TitleText TEXT);";
            using (SQLiteConnection connect = new SQLiteConnection(pathDataBaseFile))
            {
                connect.Open();
                SQLiteCommand command = new SQLiteCommand
                {
                    Connection = connect,
                    CommandText = commandStr
                };
                command.ExecuteNonQuery();
                connect.BeginTransaction();
                connect.Close();
            }
        }

        public static void DeleteTable(string NameTable)
        {
            string commandStr = "drop table " + NameTable + ";";
            using (SQLiteConnection connect = new SQLiteConnection(pathDataBaseFile))
            {
                connect.Open();
                SQLiteCommand command = new SQLiteCommand
                {
                    Connection = connect,
                    CommandText = commandStr
                };
                command.ExecuteNonQuery();
                //connect.BeginTransaction();
                connect.Close();
            }
        }

        public static void CreateTitle(string nameTable, string nameTitle)
        {
            string commandStr = @"INSERT INTO " + @nameTable + @" (Name, TitleText) VALUES ('" + @nameTitle + @"', 'Text');";
            using (SQLiteConnection connect = new SQLiteConnection(pathDataBaseFile))
            {
                connect.Open();
                SQLiteCommand command = new SQLiteCommand
                {
                    Connection = connect,
                    CommandText = commandStr
                };
                command.ExecuteNonQuery();
                connect.Close();
            }
        }

        public static void SendQuery(string query)
        {
            using (SQLiteConnection connect = new SQLiteConnection(pathDataBaseFile))
            {
                connect.Open();
                SQLiteCommand command = new SQLiteCommand
                {
                    Connection = connect,
                    CommandText = query
                };
                command.ExecuteNonQuery();
                connect.Close();
            }
        }
    }
}
