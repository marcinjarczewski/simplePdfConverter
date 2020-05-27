using AutoMapper;
using Caliburn.Micro;
using Microsoft.Win32;
using pdfconverter.Domain;
using pdfConverter.Contracts;
using pdfConverter.Contracts.Db;
using pdfConverter.WPF.Models;
using simplePdfConverter.Contracts.Bootstrappers;
using System;
using System.IO;

namespace pdfConverter.WPF.ViewModels
{
    public class DialogViewModel : PropertyChangedBase, IScreenViewModel
    {
        private string _Title;

        public string Title 
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _Text;

        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        public DialogViewModel(string title, string text)
        {
            Text = text;
            Title = title;
        }

        public void Init()
        {
        }
    }
}
