using pdfConverter.Contracts;
using System.Collections.Generic;
using System.Reflection;

namespace simplePdfConverter.Contracts.Bootstrappers
{
    public interface IShell
    {
        IList<ShellMenuItem> MenuItems { get; }
        IModule LoadModule(Assembly assembly);
    }
}
