using Microsoft.AspNetCore.Mvc.Infrastructure;
using RENT.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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
            ValidarServicios();
                
            if (nombreDeptoTxt.Text != "" && nBanosTxt.Text != "" && nDeptoTxt.Text != ""
                && nHabitacionesTxt.Text != "" && vNocheTxt.Text != "" && regionCmb.SelectedItem != null
                && comunaCmb.SelectedItem != null)
            {
                Departamentos departamentos = new Departamentos()
                {                   
                    nombreDepartamento = nombreDeptoTxt.Text,
                    nombreComunaDepto = comunaCmb.Text,
                    nombreRegionDepto = regionCmb.Text,
                    nBanos = Convert.ToInt32(nBanosTxt.Text),
                    nDepto = Convert.ToInt32(nDeptoTxt.Text),
                    nEdificio = Convert.ToInt32(nEdificioTxt.Text),
                    nHabitacion = Convert.ToInt32(nHabitacionesTxt.Text),
                    estadoDepartamento = "Disponible",
                    vNoche = Convert.ToInt32(vNocheTxt.Text),
                    tipoDepto = tipoDeptoCmb.Text,
                    direccionDepartamento = direccionTxt.Text,
                    balcon = Convert.ToBoolean(balcon),
                    servicios = new object[] {
                       new Servicios() {
                        idServicios = Convert.ToInt32(servicios1Txt.Text)
                    },
                    new Servicios() {
                        idServicios = Convert.ToInt32(servicios2Txt.Text)
                    },
                    new Servicios() {
                        idServicios = Convert.ToInt32(servicios3Txt.Text)
                    },
                    new Servicios() {
                        idServicios = Convert.ToInt32(servicios4Txt.Text)
                    },
                    new Servicios() {
                        idServicios = Convert.ToInt32(servicios5Txt.Text)
                    },
                    new Servicios() {
                        idServicios = Convert.ToInt32(servicios6Txt.Text)
                    } }
                };

                if (departamentos.idDepartamentos == 0)
                {
                    this.SaveDepartamento(departamentos);
                    lblMessage.Content = "Departamento guardado";
                }
                else
                {
                    this.UpdateDepartamento(departamentos);
                    lblMessage.Content = "Departamento actualizado";
                }
                
                nombreDeptoTxt.Text = "";
                nBanosTxt.Text = "";
                nDeptoTxt.Text = "";
                nEdificioTxt.Text = "";
                nHabitacionesTxt.Text = "";
                vNocheTxt.Text = "";

                nomErrTB.Text = "";
                nBanosErrTB.Text = "";
                nDeptoErrTB.Text = "";
                nHabitErrTB.Text = "";
                vNocheErrTB.Text = "";
            }
            else
            {
                ValidarDatos();
            }
            
        }
        private void regionCmb_Changed(object sender, SelectionChangedEventArgs e)
        {
            RegionComuna();
        }
        private async void SaveDepartamento(Departamentos departamentos)
        {
            await client.PostAsJsonAsync("departamentos/deptoAdd", departamentos);
        }
        private async void UpdateDepartamento(Departamentos departamentos)
        {
            await client.PostAsJsonAsync("departamentos/departamentosPut/" + departamentos.idDepartamentos, departamentos);
        }
        private void ValidarServicios()
        {
            if (tourCbx.IsChecked == true)
            {
                servicios1Txt.Text = "2";
            }
            else
            {
                servicios1Txt.Text = "1";
            }
            if (taxiCbx.IsChecked == true)
            {
                servicios2Txt.Text = "3";
            }
            else
            {
                servicios2Txt.Text = "1";
            }
            if (acercamientoCbx.IsChecked == true)
            {
                servicios3Txt.Text = "4";
            }
            else
            {
                servicios3Txt.Text = "1";
            }
            if (vehiculoCbx.IsChecked == true)
            {
                servicios4Txt.Text = "5";
            }
            else
            {
                servicios4Txt.Text = "1";
            }
            if (bicicletasCbx.IsChecked == true)
            {
                servicios5Txt.Text = "6";
            }
            else
            {
                servicios5Txt.Text = "1";
            }
            if (cenasCbx.IsChecked == true)
            {
                servicios6Txt.Text = "7";
            }
            else
            {
                servicios6Txt.Text = "1";
            }
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
        private void RegionComuna()
        {
            var idRegion = regionCmb.SelectedValue;
            var response = client.GetAsync("comuna/comunasByRegionId?id=" + idRegion).Result;
            var comunas = response.Content.ReadAsAsync<List<Comunas>>().Result;
            foreach (var regionCOmuna in comunas)
            {
                comunaCmb.ItemsSource = comunas;
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
        private void balconCbx_Unckechecked(object sender, RoutedEventArgs e)
        {
            balcon= 0;
        }

        private void ValidacionDeNumeros(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ValidacionDeTexto(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ValidarDatos()
        {
            if (string.IsNullOrEmpty(nombreDeptoTxt.Text))
            {
                nomErrTB.Text = "Debe ingresar un nombre";
                nombreDeptoTxt.Focus();
                return;
            }            
            if (string.IsNullOrEmpty(nBanosTxt.Text))
            {
                nBanosErrTB.Text = "Debe ingresar un numero de baños";
                nBanosTxt.Focus();
                return;
            }
            if (string.IsNullOrEmpty(nDeptoTxt.Text))
            {
                nDeptoErrTB.Text = "Debe ingresar un numero de departamento";
                nDeptoTxt.Focus();
                return;
            }
            if (string.IsNullOrEmpty(nEdificioTxt.Text))
            {
                nEdificioErrTB.Text = "Debe ingresar un numero de edificio";
                nEdificioTxt.Focus();
                return;
            }
            if (string.IsNullOrEmpty(nHabitacionesTxt.Text))
            {
                nHabitErrTB.Text = "Debe ingresar un numero de habitaciones";
                nHabitacionesTxt.Focus();
                return;
            }
            if (string.IsNullOrEmpty(vNocheTxt.Text))
            {
                vNocheErrTB.Text = "Debe ingresar un valor por noche";
                vNocheTxt.Focus();
                return;
            }
            if (string.IsNullOrEmpty(regionCmb.Text))
            {
                regionErrTB.Text = "Debe ingresar una region";
                regionCmb.Focus();
                return;
            }
            if (string.IsNullOrEmpty(comunaCmb.Text))
            {
                comunaErrTB.Text = "Debe ingresar una comuna";
                comunaCmb.Focus();
                return;
            }
            
        }
    }
}
