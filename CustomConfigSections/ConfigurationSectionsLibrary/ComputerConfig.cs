using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationSectionsLibrary
{
    public class ComputerConfig : ConfigurationElement
    {
        public ComputerConfig() { }

        public ComputerConfig(int port, string reportType)
        {
            Port = port;
            ReportType = reportType;
        }

        [ConfigurationProperty("Port", DefaultValue = 0, IsRequired = true, IsKey = true)]
        public int Port
        {
            get { return (int)this["Port"]; }
            set { this["Port"] = value; }
        }

        [ConfigurationProperty("ReportType", DefaultValue = "File", IsRequired = true, IsKey = false)]
        public string ReportType
        {
            get { return (string)this["ReportType"]; }
            set { this["ReportType"] = value; }
        }
    }
}
