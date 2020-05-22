using AutoMapper;
using pdfConverter.Contracts.Db;
using simplePdfConverter.Contracts.Db;
using simplePdfConverter.Database.DbModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace simplePdfConverter.Database.Services
{
    public class DbAccess : IDbAccess
    {
        private IMapper _mapper;

        public DbAccess(IMapper mapper)
        {
            _mapper = mapper;
        }

        static object locker = new object();
        private SQLiteConnection GetConnection()
        {
            return new SQLiteConnection("converterDB");
        }

        public void Init()
        {
            var database = GetConnection();
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

        public void Drop()
        {
            var database = GetConnection();
            database.DropTable<DbLogModel>();
            database.DropTable<DbConfigModel>();
            database.Commit();
        }

        public void AddLog(DbLogDto log)
        {
            var logModel = _mapper.Map<DbLogModel>(log);
            var database = GetConnection();
            lock (locker)
            {
                database.Insert(logModel);
                database.Commit();
            }
        }

        public DbLogDto GetLog(int logId)
        {
            var database = GetConnection();
            var model = database.Table<DbLogModel>().FirstOrDefault(f => f.Id == logId);
            return _mapper.Map<DbLogDto>(model);
        }
    }
}
