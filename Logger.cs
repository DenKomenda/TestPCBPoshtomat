using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Modbus_Poll_CS
{
        public static class Logger
        {
            public static void Test()
            {
               BasicConfigurator.Configure(SqLiteAppender.GetSqliteAppender("DB-demo.db"));
             //  LogManager.GetLogger(typeof(SqLiteAppender)).ErrorFormat("", "TTTTTT");

            }
        public static void WriteInfo(string text)
        {
            LogManager.GetLogger(typeof(SqLiteAppender)).Info(text);
        }
        public static void WriteDebug(string text)
        {
            LogManager.GetLogger(typeof(SqLiteAppender)).Debug(text);
        }
        public static void WriteError(string text)
        {
            LogicalThreadContext.Properties["Message"] = text;
            LogManager.GetLogger(typeof(SqLiteAppender)).Error(text);
        }

        public static class SqLiteAppender
            {
                public static IAppender GetSqliteAppender(string dbFilename)
                {
                    var dbFile = new FileInfo(dbFilename);

                    if (!dbFile.Exists)
                    {
                        CreateLogDb(dbFile);
                    }

                    var appender = new AdoNetAppender
                    {
                        BufferSize = 1,
                        ConnectionType = "System.Data.SQLite.SQLiteConnection, System.Data.SQLite",
                        ConnectionString = SqlLiteDataAccess.LoadConnectionString(),
                        CommandText = "INSERT INTO Board (Date, Level, Logger, Message) VALUES (@Date, @Level, @Logger, @Message)"
                    };

                //appender.AddParameter(new AdoNetAppenderParameter
                //{
                //    ParameterName = "@SerialNumber",
                //    DbType = DbType.String,
                //    Layout = new Layout2RawLayoutAdapter(new PatternLayout("%serialnumber"))

                //});

                appender.AddParameter(new AdoNetAppenderParameter
                    {
                        ParameterName = "@Date",
                        DbType = DbType.DateTime,
                        Layout = new RawTimeStampLayout()

                    });             

                appender.AddParameter(new AdoNetAppenderParameter
                    {
                        ParameterName = "@Level",
                        DbType = DbType.String,
                        Layout = new Layout2RawLayoutAdapter(new PatternLayout("%level"))
                    });

                    appender.AddParameter(new AdoNetAppenderParameter
                    {
                        ParameterName = "@Logger",
                        DbType = DbType.String,
                        Layout = new Layout2RawLayoutAdapter(new PatternLayout("%logger"))
                    });

                    appender.AddParameter(new AdoNetAppenderParameter
                    {
                        ParameterName = "@Message",
                        DbType = DbType.String,
                        Layout = new Layout2RawLayoutAdapter ( new PatternLayout("%message"))
                    });

                    appender.ActivateOptions();
                    return appender;
                }

                public static void CreateLogDb(FileInfo file)
                {
                    using (var conn = new SQLiteConnection())
                    {
                        conn.ConnectionString = SqlLiteDataAccess.LoadConnectionString();
                        conn.Open();
                        var cmd = conn.CreateCommand();

                        cmd.CommandText =
                                         @"CREATE TABLE BoardsLog(
                            LogId     INTEGER PRIMARY KEY,
                            Date      DATETIME NOT NULL,
                            Level     VARCHAR(50) NOT NULL,
                            Logger    VARCHAR(255) NOT NULL,
                            Message   VARCHAR(255) DEFAULT NULL
                        );";
                  // / try
                   // {
                        cmd.ExecuteNonQuery();
                   // }
                    //catch (Exception)
                    //{
                    //}
                       
                        cmd.Dispose();
                        conn.Close();
                    }
                }
            }
        }
     }
