using RENT.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wisej.Core;

namespace RENT.Windows
{
    /// <summary>
    /// Interaction logic for AddInventario.xaml
    /// </summary>
    public partial class AddInventario : Page
    {
        HttpClient client = new HttpClient();
        public AddInventario()
        {
            //client.BaseAddress = new Uri("http://apirent-env.eba-n7bvnjak.us-east-1.elasticbeanstalk.com/");
            client.BaseAddress = new Uri("http://localhost:8080/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        private void guardarBtn_Click(object sender, RoutedEventArgs e)
        {
            RellenadoSiVacio();
            ValidarCmb();
            var inventario = new Inventario()
            {
                departamentos = new Departamentos()
                {
                    idDepartamentos = Convert.ToInt32(departamentosCmb.SelectedValue)
                },
                cntSillas = Convert.ToInt32(cntSillasTxt.Text),
                cntMesas = Convert.ToInt32(cntMesasTxt.Text),
                cntSofas = Convert.ToInt32(cntSofasTxt.Text),
                cntCamas = Convert.ToInt32(cntCamasTxt.Text),
                cntCojines = Convert.ToInt32(cntCojinesTxt.Text),
                cntLamparas = Convert.ToInt32(cntLamparasTxt.Text),
                cntCortinas = Convert.ToInt32(cntCortinasTxt.Text),
                cntMuebles = Convert.ToInt32(cntMueblesTxt.Text),
                cntCloset = Convert.ToInt32(cntClosetTxt.Text),
                cntCuadros = Convert.ToInt32(cntCuadrosTxt.Text),
                cntAdornos = Convert.ToInt32(cntAdornosTxt.Text),
                cntEspejosHabitacion = Convert.ToInt32(cntEspejosHabitacionTxt.Text),
                cntPlantas = Convert.ToInt32(cntPlantasTxt.Text),
                cntTV = Convert.ToInt32(cntTvTxt.Text),
                cntMicroondas = Convert.ToInt32(cntMicroondasTxt.Text),
                cntRefrigeradores = Convert.ToInt32(cntRefrigeradoresTxt.Text),
                cntEstufas = Convert.ToInt32(cntEstufasTxt.Text),
                cntHoyas = Convert.ToInt32(cntHoyasTxt.Text),
                cntCafeteras = Convert.ToInt32(cntCafeterasTxt.Text),
                cntHornos = Convert.ToInt32(cntHornosTxt.Text),
                cntTenedores = Convert.ToInt32(cntTenedoresTxt.Text),
                cntCucharas = Convert.ToInt32(cntCucharasTxt.Text),
                cntCuchillos = Convert.ToInt32(cntCuchillosTxt.Text),
                cntPlatos = Convert.ToInt32(cntPlatosTxt.Text),
                cntTazas = Convert.ToInt32(cntTazasTxt.Text),
                cntVasos = Convert.ToInt32(cntVasosTxt.Text),
                cntAlfombras = Convert.ToInt32(cntAlfombrasTxt.Text),
                cntEspejosBano = Convert.ToInt32(cntEspejosBanoTxt.Text),
                cntToallas = Convert.ToInt32(cntToallasTxt.Text),
                cntDuchas = Convert.ToInt32(cntDuchasTxt.Text),
                cntBaneras = Convert.ToInt32(cntBanerasTxt.Text),
                cntJacuzzis = Convert.ToInt32(cntJacuzzisTxt.Text)
            };

            if (inventario.idInventarioDepto == 0)
            {
                this.GuardarDatos(inventario);
            }
            else
            {
                this.ActualizarDatos(inventario);
            }

            this.LimpiarDatos();
        }

        public void ValidarCmb()
        {
            if (departamentosCmb.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un departamento");
            }
        }

        public void RellenadoSiVacio()
        {
            if (cntSillasTxt.Text == "")
            {
                cntSillasTxt.Text = "0";
            }
            if (cntMesasTxt.Text == "")
            {
                cntMesasTxt.Text = "0";
            }
            if (cntSofasTxt.Text == "")
            {
                cntSofasTxt.Text = "0";
            }
            if (cntCamasTxt.Text == "")
            {
                cntCamasTxt.Text = "0";
            }
            if (cntCojinesTxt.Text == "")
            {
                cntCojinesTxt.Text = "0";
            }
            if (cntLamparasTxt.Text == "")
            {
                cntLamparasTxt.Text = "0";
            }
            if (cntCortinasTxt.Text == "")
            {
                cntCortinasTxt.Text = "0";
            }
            if (cntMueblesTxt.Text == "")
            {
                cntMueblesTxt.Text = "0";
            }
            if (cntClosetTxt.Text == "")
            {
                cntClosetTxt.Text = "0";
            }
            if (cntCuadrosTxt.Text == "")
            {
                cntCuadrosTxt.Text = "0";
            }
            if (cntAdornosTxt.Text == "")
            {
                cntAdornosTxt.Text = "0";
            }
            if (cntEspejosHabitacionTxt.Text == "")
            {
                cntEspejosHabitacionTxt.Text = "0";
            }
            if (cntPlantasTxt.Text == "")
            {
                cntPlantasTxt.Text = "0";
            }
            if (cntTvTxt.Text == "")
            {
                cntTvTxt.Text = "0";
            }
            if (cntMicroondasTxt.Text == "")
            {
                cntMicroondasTxt.Text = "0";
            }
            if (cntRefrigeradoresTxt.Text == "")
            {
                cntRefrigeradoresTxt.Text = "0";
            }
            if (cntEstufasTxt.Text == "")
            {
                cntEstufasTxt.Text = "0";
            }
            if (cntHoyasTxt.Text == "")
            {
                cntHoyasTxt.Text = "0";
            }
            if (cntCafeterasTxt.Text == "")
            {
                cntCafeterasTxt.Text = "0";
            }
            if (cntHornosTxt.Text == "")
            {
                cntHornosTxt.Text = "0";
            }
            if (cntTenedoresTxt.Text == "")
            {
                cntTenedoresTxt.Text = "0";
            }
            if (cntCucharasTxt.Text == "")
            {
                cntCucharasTxt.Text = "0";
            }
            if (cntCuchillosTxt.Text == "")
            {
                cntCuchillosTxt.Text = "0";
            }
            if (cntPlatosTxt.Text == "")
            {
                cntPlatosTxt.Text = "0";
            }
            if (cntTazasTxt.Text == "")
            {
                cntTazasTxt.Text = "0";
            }
            if (cntVasosTxt.Text == "")
            {
                cntVasosTxt.Text = "0";
            }
            if (cntAlfombrasTxt.Text == "")
            {
                cntAlfombrasTxt.Text = "0";
            }
            if (cntEspejosBanoTxt.Text == "")
            {
                cntEspejosBanoTxt.Text = "0";
            }
            if (cntToallasTxt.Text == "")
            {
                cntToallasTxt.Text = "0";
            }
            if (cntDuchasTxt.Text == "")
            {
                cntDuchasTxt.Text = "0";
            }
            if (cntBanerasTxt.Text == "")
            {
                cntBanerasTxt.Text = "0";
            }
            if (cntJacuzzisTxt.Text == "")
            {
                cntJacuzzisTxt.Text = "0";
            }
        }
        public void GetDepartamentos()
        {
            var response = client.GetAsync("departamentos/departamentos").Result;
            var departamentos = response.Content.ReadAsAsync<List<Departamentos>>().Result;

            foreach (var departamento in departamentos)
            {
                departamentosCmb.ItemsSource = departamentos;
            }
        }

        public void LimpiarDatos()
        {
            departamentosCmb.Text = "";
            cntSillasTxt.Text = "";
            cntMesasTxt.Text = "";
            cntSofasTxt.Text = "";
            cntCamasTxt.Text = "";
            cntCojinesTxt.Text = "";
            cntLamparasTxt.Text = "";
            cntCortinasTxt.Text = "";
            cntMueblesTxt.Text = "";
            cntClosetTxt.Text = "";
            cntCuadrosTxt.Text = "";
            cntAdornosTxt.Text = "";
            cntEspejosHabitacionTxt.Text = "";
            cntPlantasTxt.Text = "";
            cntTvTxt.Text = "";
            cntMicroondasTxt.Text = "";
            cntRefrigeradoresTxt.Text = "";
            cntEstufasTxt.Text = "";
            cntHoyasTxt.Text = "";
            cntCafeterasTxt.Text = "";
            cntHornosTxt.Text = "";
            cntTenedoresTxt.Text = "";
            cntCucharasTxt.Text = "";
            cntCuchillosTxt.Text = "";
            cntPlatosTxt.Text = "";
            cntTazasTxt.Text = "";
            cntVasosTxt.Text = "";
            cntAlfombrasTxt.Text = "";
            cntEspejosBanoTxt.Text = "";
            cntToallasTxt.Text = "";
            cntDuchasTxt.Text = "";
            cntBanerasTxt.Text = "";
            cntJacuzzisTxt.Text = "";
        }

        private void ValidacionDeNumeros(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void GuardarDatos(Inventario inventario)
        {
            var response = await client.PostAsJsonAsync("inventarioDepto/inventarioDeptoSave", inventario);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Datos guardados correctamente");
            }
            else
            {
                MessageBox.Show("Error al guardar los datos");
            }
        }

        private async void ActualizarDatos(Inventario inventario)
        {
            await client.PutAsJsonAsync("inventarioDepto/inventarioDeptoUpdate/" + inventario.idInventarioDepto, inventario);
        }
    }
}
