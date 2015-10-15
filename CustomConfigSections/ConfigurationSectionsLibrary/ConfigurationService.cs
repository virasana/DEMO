using System.Collections;
using System.Configuration;
using InterfacesLibrary;

namespace ConfigurationSectionsLibrary
{
    public class ConfigurationService
    {
        public static EnvironmentsConfigurationSection Environments
        {
            get { return (EnvironmentsConfigurationSection)ConfigurationManager.GetSection("environmentsSection"); }
        }
    }
}
