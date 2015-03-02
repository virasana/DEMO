using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationSectionsLibrary
{
    public class ComputerElement : ConfigurationElement
    {
        public ComputerElement() { }

        public ComputerElement(string name)
        {
            Name = name;
        }

        [ConfigurationProperty("name", DefaultValue = "Default", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("drives")]
        public DrivesCollection Drives
        {
            get { return (DrivesCollection)this["drives"]; }
            set { this["drives"] = value; }
        }
    }
}
