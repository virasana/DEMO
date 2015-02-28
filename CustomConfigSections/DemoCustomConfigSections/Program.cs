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
            var config = (ComputerSection)ConfigurationManager.GetSection("computerGroup/computer");
            Console.WriteLine(config.NetBiosName);
            Console.ReadKey();
        }
    }
}
