using System.Configuration;

namespace ConfigurationSectionsLibrary
{
    public class EnvironmentsConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("environments", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(EnvironmentsCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public EnvironmentsCollection Environments
        {
            get
            {
                return (EnvironmentsCollection)base["environments"];
            }
        }
    }
}