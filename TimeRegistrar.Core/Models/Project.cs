using SQLite;
using TimeRegistrar.Core.Data;

namespace TimeRegistrar.Core.Models
{
    public class Project : Entity
    {
        [Unique]
        public string Name { get; set; }

        public Project()
        {
        }

        public Project(string name)
        {
            Name = name;
        }
    }
}