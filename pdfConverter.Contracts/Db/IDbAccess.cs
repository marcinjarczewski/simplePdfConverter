using simplePdfConverter.Contracts.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdfConverter.Contracts.Db
{
    public interface IDbAccess
    {
        void Init();

        void Drop();

        void AddLog(DbLogDto log);

        DbLogDto GetLog(int logId);

        DbConfigDto GetConfig();

        void SaveConfig(DbConfigDto config);
    }
}
