using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;


namespace Modbus_Poll_CS
{
    public class SqlLiteDataAccess
    {
        public static  List<BoardsModel> LoadBoards()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) 
            {
                var output = cnn.Query<BoardsModel>("select * from Board", new DynamicParameters());
                return output.ToList();
            } 
        }

        //public static void SaveListBoxes(BoardsModel board) 
        //{
        //    using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) 
        //    {
        //        cnn.Execute("insert into Board (SlaveID, SerialNumber) values (@Id, @SerialNumber)", board);
        //    }
        //}

        public static string LoadConnectionString(string id ="Default") 
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
