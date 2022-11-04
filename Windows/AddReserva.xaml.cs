using System;
using RENT.Models;
using System.Collections.Generic;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.Data;

namespace RENT.Windows
{
    /// <summary>
    /// Interaction logic for AddReserva.xaml
    /// </summary>
    public partial class AddReserva : Page
    {
        HttpClient client = new HttpClient();
        public AddReserva()
        {
            client.BaseAddress = new Uri("http://apirent-env.eba-n7bvnjak.us-east-1.elasticbeanstalk.com/");
            //client.BaseAddress = new Uri("http://localhost:8080/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        private void fechaInicioDtp_SelectedChanged(object sender, SelectionChangedEventArgs e)
        {
            AddDaysBetween();
        }

        private void fechaFinDtp_SelectedChanged(object sender, SelectionChangedEventArgs e)
        {
            GetDaysBetween();
        }

        private void diasFinCbx_Checked(object sender, RoutedEventArgs e)
        {
            
            if (diasFinCbx.IsChecked == true)
            {
                fechaFinDtp.IsEnabled = true;
                cntDiasTxt.IsEnabled = false;
                diasBetweenCbx.IsEnabled = false;
                cntDiasTxt.Text = "0";
                fechaInicioDtp.SelectedDate = DateTime.Now;
                fechaFinDtp.SelectedDate = DateTime.Now;
            }
        }

        private void diasFinCbx_Unchecked(object sender, RoutedEventArgs e)
        {
            fechaInicioDtp.BlackoutDates.Clear();
            if (diasFinCbx.IsChecked == false)
            {
                fechaFinDtp.IsEnabled = false;
                cntDiasTxt.IsEnabled = false;
                diasBetweenCbx.IsEnabled = true;
                cntDiasTxt.Text = "0";
                fechaInicioDtp.SelectedDate = DateTime.Now;
                fechaFinDtp.SelectedDate = DateTime.Now;
            }
        }

        private void diasBetweenCbx_Checked(object sender, RoutedEventArgs e)
        {
            if (diasBetweenCbx.IsChecked == true)
            {
                diasFinCbx.IsEnabled = false;
                cntDiasTxt.IsEnabled = true;
                fechaFinDtp.IsEnabled = false;
                cntDiasTxt.Text = "0";
                fechaInicioDtp.SelectedDate = DateTime.Now;
                fechaFinDtp.SelectedDate = DateTime.Now;
            }
        }
        private void diasBetweenCbx_Unchecked(object sender, RoutedEventArgs e)
        {
            if (diasBetweenCbx.IsChecked == false)
            {
                fechaFinDtp.IsEnabled = false;
                cntDiasTxt.IsEnabled = false;
                diasFinCbx.IsEnabled = true;
                cntDiasTxt.Text = "0";
                fechaInicioDtp.SelectedDate = DateTime.Now;
                fechaFinDtp.SelectedDate = DateTime.Now;
            }
        }
        
        public void Today()
        {
            cntDiasTxt.Text = "0";
            fechaInicioDtp.SelectedDate = DateTime.Now;
            fechaInicioDtp.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Now.AddDays(-1)));
        }

        private void GetDaysBetween()
        {
            DateTime? fechaInicio = fechaInicioDtp.SelectedDate;
            DateTime? fechaFin = fechaFinDtp.SelectedDate;

            if (fechaInicio != null && fechaFin != null)
            {
                TimeSpan ts = (DateTime)fechaFin - (DateTime)fechaInicio;
                int cntDias = ts.Days;
                cntDiasTxt.Text = cntDias.ToString();
            }
        }

        private void AddDaysBetween()
        {
            DateTime fechaInicio = (DateTime)fechaInicioDtp.SelectedDate;
            fechaFinDtp.SelectedDate = fechaInicio.AddDays(Convert.ToInt32(cntDiasTxt.Text));
        }

        public void GetServicios()
        {
            var response = client.GetAsync("servicio/servicios").Result;
            var servicios = response.Content.ReadAsAsync<List<Servicios>>().Result;

            foreach (var servicio in servicios)
            {
                serviciosCmb.ItemsSource = servicios;
            }
        }

        private void cargarCedulaBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchByCedula(new Usuarios());
        }

        public void GetUsuarios()
        {
            var response = client.GetAsync("usuario/usuarios").Result;
            var usuarios = response.Content.ReadAsAsync<List<Usuarios>>().Result;
          
            foreach (var usuario in usuarios)
            {
                cedulaCmb.ItemsSource = usuarios;                  
            }
        }
        private async void SearchByCedula(Usuarios usuario)
        {
            var cedulaUsuario = cedulaFindTxt.Text;
            var url = "usuario/cedulaUsuario?cedulaUsuario=" + cedulaUsuario;

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var _Data = JsonConvert.DeserializeObject<List<Usuarios>>(jsonString);
                usListBox.ItemsSource = _Data;
                
                //if(_Data != null)
                //{
                //    cedulaTxt.Text = _Data[0].cedulaUsuario;
                //    nombreTxt.Text = _Data[0].nombreUsuario;
                //    apellidoTxt.Text = _Data[0].apellidoUsuario;
                //    telefonoTxt.Text = Convert.ToString(_Data[0].telefonoUsuario);
                //}
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void cedulaCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            usListBox.Items.Clear();
            usListBox.Items.Add(cedulaCmb.SelectedItem);
        }
    }
}
