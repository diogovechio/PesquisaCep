using System;
using SQLite;

namespace Ceps.Models
{
    public class CepModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
    }
}