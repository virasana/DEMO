using System;
using System.Configuration;

namespace ConfigurationSectionsLibrary
{
    [ConfigurationCollection(typeof(EnvironmentElement))]
    public class EnvironmentsCollection : ConfigurationElementCollection
    {
        //public EnvironmentElement this[int index]
        //{
        //    get { return (EnvironmentElement)BaseGet(index); }
        //    set
        //    {
        //        if (BaseGet(index) != null)
        //        {
        //            BaseRemoveAt(index);
        //        }
        //        BaseAdd(index, value);
        //    }
        //}

        //public void Add(EnvironmentElement environmentConfig)
        //{
        //    BaseAdd(environmentConfig);
        //}

        //public void Clear()
        //{
        //    BaseClear();
        //}

        //protected override ConfigurationElement CreateNewElement()
        //{
        //    return new EnvironmentElement();
        //}

        //protected override object GetElementKey(ConfigurationElement element)
        //{
        //    return ((EnvironmentElement)element).Name;
        //}

        //public void Remove(EnvironmentElement environmentConfig)
        //{
        //    BaseRemove(environmentConfig.Name);
        //}

        //public void RemoveAt(int index)
        //{
        //    BaseRemoveAt(index);
        //}

        //public void Remove(string name)
        //{
        //    BaseRemove(name);
        //}

        internal const string PropertyName = "Environment";

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
            return new EnvironmentElement();
        }

        protected override object GetElementKey(ConfigurationElement environmentConfig)
        {
            return ((EnvironmentElement)(environmentConfig)).Name;
        }

        public EnvironmentElement this[int idx]
        {
            get
            {
                return (EnvironmentElement)BaseGet(idx);
            }
        }
    }
}