using System;
using System.Configuration;

namespace ConfigurationSectionsLibrary
{
    [ConfigurationCollection(typeof(DriveElement))]
    public class DrivesCollection : ConfigurationElementCollection
    {
        internal const string PropertyName = "drive";

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }
        protected override string ElementName
        {
            get
            {
                return PropertyName;
            }
        }

        protected override bool IsElementName(string elementName)
        {
            return elementName.Equals(PropertyName, StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool IsReadOnly()
        {
            return false;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new DriveElement();
        }

        protected override object GetElementKey(ConfigurationElement driveConfig)
        {
            return ((DriveElement)(driveConfig)).Name;
        }

        public DriveElement this[int idx]
        {
            get
            {
                return (DriveElement)BaseGet(idx);
            }
        }
    }
}