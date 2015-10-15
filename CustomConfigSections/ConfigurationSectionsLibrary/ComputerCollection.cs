using System;
using System.Configuration;

namespace ConfigurationSectionsLibrary
{
    public class ComputerCollection : ConfigurationElementCollection
    {
        //public ComputerElement this[int index]
        //{
        //    get { return (ComputerElement)BaseGet(index); }
        //    set
        //    {
        //        if (BaseGet(index) != null)
        //        {
        //            BaseRemoveAt(index);
        //        }
        //        BaseAdd(index, value);
        //    }
        //}

        //public void Add(ComputerElement computerConfig)
        //{
        //    BaseAdd(computerConfig);
        //}

        //public void Clear()
        //{
        //    BaseClear();
        //}

        //protected override ConfigurationElement CreateNewElement()
        //{
        //    return new ComputerElement();
        //}

        //protected override object GetElementKey(ConfigurationElement element)
        //{
        //    return ((ComputerElement)element).Name;
        //}

        //public void Remove(ComputerElement computerConfig)
        //{
        //    BaseRemove(computerConfig.Name);
        //}

        //public void RemoveAt(int index)
        //{
        //    BaseRemoveAt(index);
        //}

        //public void Remove(string name)
        //{
        //    BaseRemove(name);
        //}

        internal const string PropertyName = "computer";

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
            return new ComputerElement();
        }

        protected override object GetElementKey(ConfigurationElement environmentConfig)
        {
            return ((ComputerElement)(environmentConfig)).Name;
        }

        public ComputerElement this[int idx]
        {
            get
            {
                return (ComputerElement)BaseGet(idx);
            }
        }
    }
}