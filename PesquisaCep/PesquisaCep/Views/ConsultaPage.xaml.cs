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
using SQLite;


namespace PesquisaCep
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Consulta : ContentPage
    {
        string Arquivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ceps.txt");

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

                    if (ObjCEP.cep == null)
                    {
                        titleCEP.Text = "Erro";
                        resCEP.Text = "CEP inexistente.";
                        return;
                    }

                    titleCEP.Text = ObjCEP.cep;
                    resCEP.Text = $"{ObjCEP.logradouro}, {ObjCEP.bairro}\n{ObjCEP.localidade}/{ObjCEP.uf}";

                    string SaveCEP;
                    string NovoCEP;

                    SaveCEP = $"{ObjCEP.cep}\n{ObjCEP.logradouro}, {ObjCEP.bairro}\n{ObjCEP.localidade}/{ObjCEP.uf}";

                    if (File.Exists(Arquivo))
                    {
                        NovoCEP = File.ReadAllText(Arquivo);
                        SaveCEP += "\n\n" + NovoCEP;
                    }

                    File.WriteAllText(Arquivo, SaveCEP);
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