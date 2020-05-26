using Caliburn.Micro;
using pdfConverter.Contracts;
using simplePdfConverter.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simplePdfConverter.WPF.DesignTime.Models
{
    public class DesignShellViewModel : PropertyChangedBase
    {
        public DesignShellViewModel()
        {
            MenuItems = new ObservableCollection<ShellMenuItem>();
            MenuItems.Add(new ShellMenuItem() { Caption = "Convert" });
            MenuItems.Add(new ShellMenuItem() { Caption = "Settings"});      
        }

        public ObservableCollection<ShellMenuItem> MenuItems { get; private set; }
    }
}
