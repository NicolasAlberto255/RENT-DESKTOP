using Microsoft.AspNetCore.Mvc.Infrastructure;
using RENT.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RENT.Windows
{
    /// <summary>
    /// Interaction logic for AddDepartamento.xaml
    /// </summary>
    public partial class AddDepartamento : Page
    {
        HttpClient client = new HttpClient();
        public int balcon;

        public AddDepartamento()
        {
            //client.BaseAddress = new Uri("http://apirent-env.eba-n7bvnjak.us-east-1.elasticbeanstalk.com/");
            client.BaseAddress = new Uri("http://localhost:8080/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        private void guardarBtn_Click(object sender, RoutedEventArgs e)
        {
            var departamentos = new Departamentos()
            {

                idDepto = Convert.ToInt32(idDeptoTxt.Text),
                nombreDepartamento = nombreDeptoTxt.Text,
                nombreComunaDepto = comunaCmb.Text,
                nombreRegionDepto = regionCmb.Text,
                nBanos = Convert.ToInt32(nBanosTxt.Text),
                nDepto = Convert.ToInt32(nDeptoTxt.Text),
                nEdificio = Convert.ToInt32(nEdificioTxt.Text),
                nHabitacion = Convert.ToInt32(nHabitacionesTxt.Text),
                vNoche = Convert.ToInt32(vNocheTxt.Text),
                balcon = Convert.ToInt32(balcon)
            };

            if (departamentos.idDepto == 0)
            {
                this.SaveDepartamento(departamentos);
                lblMessage.Content = "Departamento guardado";
            }
            else
            {
                this.UpdateDepartamento(departamentos);
                lblMessage.Content = "Departamento actualizado";
            }

            idDeptoTxt.Text = 0.ToString();
            nombreDeptoTxt.Text = "";
            comunaCmb.SelectedIndex = -1;
            regionCmb.SelectedIndex = -1;
            nBanosTxt.Text = "";
            nDeptoTxt.Text = "";
            nEdificioTxt.Text = "";
            nHabitacionesTxt.Text = "";
            vNocheTxt.Text = "";
        }


        private async void SaveDepartamento(Departamentos departamentos)
        {
            await client.PostAsJsonAsync("departamentos/departamentosSave", departamentos);
        }

        private async void UpdateDepartamento(Departamentos departamentos)
        {
            await client.PostAsJsonAsync("departamentos/departamentosPut/" + departamentos.idDepto, departamentos);
        }



        public void GetRegiones()
        {
            var response = client.GetAsync("region/regiones").Result;
            var regiones = response.Content.ReadAsAsync<List<Regiones>>().Result;

            foreach (var region in regiones)
            {
                regionCmb.ItemsSource = regiones;
            }
        }

        public void GetComunas()
        {
            var response = client.GetAsync("comuna/comunas").Result;
            var comunas = response.Content.ReadAsAsync<List<Comunas>>().Result;

            foreach (var comuna in comunas)
            {
                comunaCmb.ItemsSource = comunas;
            }
        }

        public void balconCbx_Checked(object sender, RoutedEventArgs e)
        {
            balcon = 1;
        }

        private void balconCbx_Unckechecked(Object sender, RoutedEventArgs e)
        {
            balcon= 0;
        }
    }
}
