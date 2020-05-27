using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdfConverter.Contracts
{
    public interface INavigator
    {
        void ShowDialog(string title, string message);
    }
}
