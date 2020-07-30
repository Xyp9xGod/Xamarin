using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BuscaCep.Servico.Modelo;
using BuscaCep.Servico;

namespace BuscaCep
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCep;
        }
        private void BuscarCep(object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim().Replace("-", "");
            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {0}, {1}, {2},{3}.", end.logradouro, end.bairro, end.localidade, end.uf);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o cep informado: " + cep, "OK");
                    }
                }
                catch(Exception e)
                {
                    DisplayAlert("Um erro aconteceu, verifique o cep digitado e sua conexão com a internet e tente novamente.", e.Message, "OK");
                }
            }
        }
        public bool isValidCEP(string cep)
        {
            bool valido = true;
            int NovoCep = 0;

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP Inválido", "O CEP deve conter 8 caracteres.", "OK");
                valido = false;
            }
            
            if(!int.TryParse(cep, out NovoCep))
            {
                DisplayAlert("ERRO", "CEP Inválido", "O CEP deve conter apenas números.", "OK");
                valido = false;
            }
            return valido;
        }
    }
}
