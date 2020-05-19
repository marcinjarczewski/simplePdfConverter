using simplePdfConverter.Database.DbModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace simplePdfConverter.Database.Servicess
{
    public static class DbAccess
    {
        static object locker = new object();
        private static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection("converterDB");
        }

        public static void Init()
        {
            var database = GetConnection();
            //Drop();
            database.CreateTable<DbLogModel>();
            database.CreateTable<DbConfigModel>();         
            if (database.Table<DbConfigModel>().FirstOrDefault(u => u.Id == 1) == null)
            {
                database.Insert(new DbConfigModel
                {
                    AutoSave = false,
                    Id = 1,
                    SourcePath = "",
                    TargetPath = ""
                });
            }        
            database.Commit();
        }

        public static void Drop()
        {
            var database = GetConnection();
            database.DropTable<DbLogModel>();
            database.DropTable<DbConfigModel>();
            database.Commit();
        }

        public static void AddLog(DbLogModel log)
        {
            var database = GetConnection();
            lock (locker)
            {
                database.Insert(log);
                database.Commit();
            }
        }
        public static void DeleteLogs(List<DbLogModel> logs)
        {
            var database = GetConnection();
            foreach (var item in logs)
            {
                database.Delete(item);
            }
            database.Commit();
        }
    }
}
