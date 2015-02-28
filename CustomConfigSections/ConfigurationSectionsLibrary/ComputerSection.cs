using System.Configuration;

namespace ConfigurationSectionsLibrary
{
    public class ComputerSection : ConfigurationSection
    {
        [ConfigurationProperty("netbiosName", DefaultValue = "DefaultNetBiosName", IsRequired = true)]
        public string NetBiosName
        {
            get
            {
                return (string)this["netbiosName"];
            }

            set
            {
                this["netbiosName"] = value;
            }
        }
    }
}
