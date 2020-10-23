using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ceps.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ceps.Data;
using System.IO;

namespace PesquisaCep
{
    public partial class App : Application
    {
        static CepsDatabase database;

        public static CepsDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new CepsDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Ceps.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            TabbedPage tb = new TabbedPage();
            tb.Children.Add(new Consulta());
            tb.Children.Add(new Registros());
            tb.Children.Add(new Mapa());

            MainPage = tb;

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
