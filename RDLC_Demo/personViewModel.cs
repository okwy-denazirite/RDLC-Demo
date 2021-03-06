﻿using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RDLC_Demo
{
    public class PersonViewModel
    {
        private MainWindow _window;
        private LocalReport _Report;
        private ReportViewer _reportviewer;

        //private static string _path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
        private static string _path = System.IO.Directory.GetCurrentDirectory();
        //public static string ContentStart = _path + @"\ReportProject\MainPage.rdlc";
        public static string ContentStart = _path + @"\ReportProject\Report1.rdlc";

        public PersonViewModel(MainWindow window)
        {
            _window = window;
            this._reportviewer = window._reportviewer;
            Initialize();
        }

        private IEnumerable<Person> people = new List<Person>() { new Person { Name = "Gloria", id = 46, Age =12} ,
        new Person {Name = "John", id = 1, Age =23},
         new Person {Name = "Francis My Staff", id = 2, Age =12},
        new Person {Name = "Ndu", id = 3, Age =32},
        new Person {Name = "Murphy", id = 4, Age =22},
        new Person {Name = "Mr Charles our boss", id = 5, Age =52}};

        private void Initialize()
        {
            _reportviewer.LocalReport.DataSources.Clear();
            var rpds_model = new ReportDataSource() { Name = "Person_DS", Value = people };
            _reportviewer.LocalReport.DataSources.Add(rpds_model);
            _reportviewer.LocalReport.EnableExternalImages = true;
        _reportviewer.LocalReport.ReportPath = ContentStart;  
            _reportviewer.SetDisplayMode(DisplayMode.PrintLayout);  
            _reportviewer.Refresh();  
            _reportviewer.RefreshReport();  
        }
    }
}
