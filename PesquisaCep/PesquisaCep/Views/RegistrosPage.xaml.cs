using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PesquisaCep
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registros : ContentPage
    {
        string Arquivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ceps.txt");

        public Registros()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (File.Exists(Arquivo))
            {
                listaCEP.Text = File.ReadAllText(Arquivo);
            }
        }

        void ClickApagar(object sender, EventArgs e)
        {
            if (File.Exists(Arquivo))
            {
                File.Delete(Arquivo);
            }
            listaCEP.Text = "Registros deletados com sucesso.";
        }
    }
}