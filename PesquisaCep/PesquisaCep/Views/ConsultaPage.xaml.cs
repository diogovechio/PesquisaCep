using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Dynamic;
using Ceps.Models;
using SQLite;


namespace PesquisaCep
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Consulta : ContentPage
    {
        public Consulta()
        {
            InitializeComponent();
        }

        private void ClickConsulta(object sender, EventArgs e)
        {
            if(etCEP.Text != null && (etCEP.Text).Length == 8)
            {
                string HTTP = "http://viacep.com.br/ws/";
                HTTP += etCEP.Text;
                HTTP += "/json/";

                var HTTPRequest = WebRequest.CreateHttp(HTTP);
                HTTPRequest.Method = "GET";
                HTTPRequest.UserAgent = "PesquisaCEP";

                using(var resposta = HTTPRequest.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    object objResponse = reader.ReadToEnd();

                    var ObjCEP = JsonSerializer.Deserialize<EnderecoJSON>(objResponse.ToString());

                    titleCEP.Text = ObjCEP.cep;
                    resCEP.Text = $"{ObjCEP.logradouro}, {ObjCEP.bairro}\n{ObjCEP.localidade}/{ObjCEP.uf}";

                    var cepSave = (CepModel)BindingContext;

                    /*cepSave.Cep = ObjCEP.cep;
                    cepSave.Logradouro = "TesteLOG";
                    cepSave.Bairro = "Teste";
                    cepSave.Localidade = (ObjCEP.localidade).ToString();
                    cepSave.Uf = (ObjCEP.uf).ToString();*/

                    App.Database.SaveCepAsync(cepSave);
                    Navigation.PopAsync();
                }
            }
            else
            {
                titleCEP.Text = "Erro";
                resCEP.Text = "Por favor, insira um CEP válido.";
                return;
            }
        }

        public class EnderecoJSON
        {
            public string logradouro { get; set; }
            public string cep { get; set; }
            public string bairro { get; set;  }
            public string localidade { get; set; }
            public string uf { get; set; }
        }
    }
}