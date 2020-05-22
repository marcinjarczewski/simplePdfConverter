namespace simplePdfConverter.Contracts.Db
{
    public class DbConfigDto
    {
        public int Id { get; set; }
        public string SourcePath { get; set; }

        public string TargetPath { get; set; }

        public bool? AutoSave { get; set; }
    }
}
