using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationSectionsLibrary;

namespace DemoCustomConfigSections
{
    class Program
    {
        static void Main(string[] args)
        {
            var computerConfigSection = (ComputersConfigurationSection)ConfigurationManager.GetSection("ComputersSection");

            if (computerConfigSection != null) Console.WriteLine(computerConfigSection.Computers.Count);

            Console.ReadKey();
        }
    }
}
