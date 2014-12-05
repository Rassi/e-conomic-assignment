using SQLite;

namespace TimeRegistrar.Core.Data
{
    public class Entity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}