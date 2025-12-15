namespace ExtCharlist.Models
{
    public class ExtCharlistDatabaseSettigs
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string CharacterCollectionName { get; set; } = null!;

        public string CharacterRaceCollectionName { get; set; } = null!;
    }
}
