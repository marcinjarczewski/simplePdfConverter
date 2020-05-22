using Caliburn.Micro;
using pdfConverter.Contracts;
using pdfConverter.Contracts.Db;
using pdfConverter.WPF.Models;
using System;

namespace pdfConverter.WPF.ViewModels
{
    public class MainViewModel 
    {
        private Models.SettingsModel _settingsModel;
        private IDbAccess _database;

        public MainViewModel(IDbAccess db)
        {
            _database = db;
        }

    }
}
