using System;
using System.Configuration;

namespace ConfigurationSectionsLibrary
{
    public class ComputerCollection : ConfigurationElementCollection
    {
        public ComputerConfig this[int index]
        {
            get { return (ComputerConfig)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(ComputerConfig computerConfig)
        {
            BaseAdd(computerConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ComputerConfig();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ComputerConfig)element).Port;
        }

        public void Remove(ComputerConfig computerConfig)
        {
            BaseRemove(computerConfig.Port);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }
    }
}