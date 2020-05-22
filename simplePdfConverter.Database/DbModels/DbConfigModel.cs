using SQLite;

namespace simplePdfConverter.Database.DbModels
{
    public class DbConfigModel
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string SourceFolderPath { get; set; }

        public string TargetFolderPath { get; set; }

        public bool? AutoSave { get; set; }
    }
}
