using SQLite;

namespace simplePdfConverter.Database.DbModels
{
    public class DbConfigModel
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string SourcePath { get; set; }

        public string TargetPath { get; set; }

        public bool? AutoSave { get; set; }
    }
}
