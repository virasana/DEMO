using System.Collections;
using System.Collections.Generic;

namespace InterfacesLibrary
{
    public interface ISettingsProvider
    {
        IEnumerable<IEnvironment> Environments { get;  }
    }

    public interface IEnvironment
    {
        string Name { get; set; }
        IEnumerable<IComputer> Computers { get; }
    }

    public interface IComputer
    {
        string Name { get; set; }
        IEnumerable<IDrive> Drives { get; }
    }
    }

    public interface IDrive
    {
        string Name { get; }
        long MinimumSpaceRequired { get; }
}