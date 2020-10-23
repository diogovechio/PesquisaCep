using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace PesquisaCep
{
    public partial class App : Application
    {

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
