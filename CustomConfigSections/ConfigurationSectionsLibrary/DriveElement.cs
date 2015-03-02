using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationSectionsLibrary
{
    public class DriveElement : ConfigurationElement
    {
        public DriveElement() { }

        public DriveElement(string name)
        {
            Name = name;
        }

        [ConfigurationProperty("name", DefaultValue = "Default", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("minimumSpaceRequired", DefaultValue = "Default", IsRequired = true)]
        public string MinimumSpaceRequired
        {
            get { return (string)this["minimumSpaceRequired"]; }
            set { this["minimumSpaceRequired"] = value; }
        }
    }
}
