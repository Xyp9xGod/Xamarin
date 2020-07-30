using BuscaCep.Servico.Modelo;
using System.Net;
using Newtonsoft.Json;
namespace BuscaCep.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";
        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NovoEnderecoURL);
            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (endereco.cep == null) return null;

            return endereco;
        }
    }
}
