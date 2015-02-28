using System.Configuration;

namespace ConfigurationSectionsLibrary
{
    public class ComputersConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("Computers", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ComputerCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public ComputerCollection Computers
        {
            get
            {
                return (ComputerCollection)base["Computers"];
            }
        }
    }
}