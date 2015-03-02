using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationSectionsLibrary
{
    public class EnvironmentElement : ConfigurationElement
    {
        public EnvironmentElement() { }

        public EnvironmentElement(string name)
        {
            Name = name;
        }

        [ConfigurationProperty("name", DefaultValue = "Default", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("computers")]
        public ComputerCollection Computers
        {
            get { return (ComputerCollection) this["computers"]; }
            set { this["computers"] = value; }
        }
    }
}
