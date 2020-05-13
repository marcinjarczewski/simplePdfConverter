using Caliburn.Micro;
using Microsoft.Win32;
using pdfConverter.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace pdfConverter.WPF.ViewModels
{
    public class SettingsViewModel
    {
        private readonly IShell _shell;

        public SettingsViewModel(IShell shell)
        {
            _shell = shell;
        }

        public void Load()
        {
            var dlg = new OpenFileDialog();

            if (dlg.ShowDialog().GetValueOrDefault())
            {
                var asm = Assembly.LoadFrom(dlg.FileName);
                var module = _shell.LoadModule(asm);
                if (module != null)
                    module.Init();
            }
        }
    }
}
