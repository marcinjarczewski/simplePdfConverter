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
    public class DesignDialogViewModel : PropertyChangedBase
    {
        public string Text { get; set; }

        public string Title { get; set; }
        public DesignDialogViewModel()
        {
            Text = "The operation was completed successfully.";
            Title = "Confirmation";
        }
    }
}
