using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Data;

namespace WpfApp2
{
    class SQLLiteAccess
    {
        public static string dbFilePath = Path.Combine(Environment.CurrentDirectory, "database.db");
        private static string _connectionString = string.Format("Data Source = {0}", dbFilePath);
        public static List<PlaceModel> Read()
        {
            List<PlaceModel> placeList = new List<PlaceModel>();
            SqliteConnection dbConnection = new SqliteConnection(_connectionString);
            dbConnection.Open();
            if (dbConnection.State == ConnectionState.Open)
            {
                string dbQuery = string.Format("SELECT * FROM Przepisy");
                SqliteCommand dbCommand = new SqliteCommand(dbQuery, dbConnection);

                
                SqliteDataReader dbDataReader = dbCommand.ExecuteReader();
                while (dbDataReader.Read())
                {
                    PlaceModel przepis = new PlaceModel()
                     {
                         id = Convert.ToInt32(dbDataReader["id"]),
                         Name = dbDataReader["Name"].ToString(),
                         Country = dbDataReader["Country"].ToString(),
                         Description = dbDataReader["Description"].ToString(),
                         PhotoName = dbDataReader["PhotoName"].ToString(),

                     };
                   /* {
                        id = dbDataReader.GetInt32(0),
                        Name = dbDataReader.GetString(1),
                        Country = dbDataReader.GetString(2),
                        Description = dbDataReader.GetString(3),
                        PhotoName = dbDataReader.GetString(4),
                   };*/
                    placeList.Add(przepis);
                }

            }
            dbConnection.Close();
            return placeList;
        }
        public static bool Create(PlaceModel item)
        {
            bool isCreated = false;

            SqliteConnection dbConnection = new SqliteConnection(_connectionString);
            dbConnection.Open();
            if (dbConnection.State == ConnectionState.Open)
            {
                string dbQuery = string.Format("SELECT COUNT(*) FROM Przepisy WHERE Name = '{0}'", item.Name);
                SqliteCommand dbCommand = new SqliteCommand(dbQuery, dbConnection);

                int result = Convert.ToInt32(dbCommand.ExecuteScalar());

                if(result == 0)
                {
                   // dbQuery = string.Format("INSERT INTO Przepisy(Name, Country, Description, PhotoName) VALUES('{0}', '{1}', '{2}', '{3}')", item.Name, item.Country, item.Description, item.PhotoName);
                    dbQuery = string.Format ("INSERT INTO Przepisy VALUES(null, '{0}', '{1}', '{2}', '{3}' )", item.Name, item.Country, item.Description, item.PhotoName);
                    dbCommand.CommandText = dbQuery;

                    if (dbCommand.ExecuteNonQuery() == 1)
                    {
                        isCreated = true;
                    }               
                }
            }
            dbConnection.Close();
            return isCreated;
        }
        public static bool Delete(PlaceModel item)
        {
            bool isDeleted = false;
            SqliteConnection dbConnection = new SqliteConnection(_connectionString);
            dbConnection.Open();
            if (dbConnection.State == ConnectionState.Open)
            {
                string dbQuery = string.Format("SELECT COUNT(*) FROM Przepisy WHERE Name = '{0}'", item.Name);
                SqliteCommand dbCommand = new SqliteCommand(dbQuery, dbConnection);

                int result = Convert.ToInt32(dbCommand.ExecuteScalar());
                if (result == 1)
                {
                    dbQuery = string.Format("DELETE FROM Przepisy WHERE id = {0}", item.id);
                    dbCommand.CommandText = dbQuery;

                    if (dbCommand.ExecuteNonQuery() == 1)
                    {
                        isDeleted = true;
                    }
                }
            }
                  /*  public static bool Update(PlaceModel item)
            {
                bool isUpdated = false;
                SqliteConnection sqliteConnection = new SqliteConnection(_connectionString);
                dbConnection.Open();
                
                    if (dbConnection.State == ConnectionState.Open)
                {
                }*/
     
            
            dbConnection.Close();

            return isDeleted;
        }
        public static bool CreateTablePlaces()
        {
            bool isTableCreated = false;
            SqliteConnection dbConnection = new SqliteConnection(_connectionString);
            dbConnection.Open();
            if (dbConnection.State == ConnectionState.Open)
            {
                string dbQuery = string.Format("CREATE TABLE IF NOT EXISTS Przepisy (od INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Country TEXT, Description TEXT, PhotoName TEXT)");
                SqliteCommand dbCommand = new SqliteCommand(dbQuery, dbConnection);
                int result = dbCommand.ExecuteNonQuery();
                if (result == 0)
                {
                    isTableCreated = true;
                }
            }
            dbConnection.Close();
            return isTableCreated;
        }

        public static bool Update(PlaceModel placeItem)
        {
            bool isUpdated = false;
            SqliteConnection dbConnection = new SqliteConnection(_connectionString);
            dbConnection.Open();
            if (dbConnection.State == ConnectionState.Open)
            {
                string dbQuery = string.Format("SELECT COUNT(id) FROM Przepisy WHERE Name = '{0}'", placeItem.Name);
                SqliteCommand dbCommand = new SqliteCommand(dbQuery, dbConnection);
                int result = Convert.ToInt32(dbCommand.ExecuteScalar());
                if (result == 1)
                {
                    dbQuery = string.Format("UPDATE Przepisy SET Country = '{0}', Description = '{1}', PhotoName = '{2}' WHERE id = {3}", placeItem.Country, placeItem.Description, placeItem.PhotoName, placeItem.id);
                    dbCommand.CommandText = dbQuery;
                    if (dbCommand.ExecuteNonQuery()==1)
                    {
                        isUpdated = true;
                    }
                }
            }
            dbConnection.Close();
            return isUpdated;
        }
    }
}
