using TimeRegistrar.Core.Data;

namespace TimeRegistrar.Core.Models
{
    public class Project : Entity
    {
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