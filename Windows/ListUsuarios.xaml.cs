using Newtonsoft.Json;
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

namespace RENT.Windows
{
    /// <summary>
    /// Interaction logic for ListUsuarios.xaml
    /// </summary>
    public partial class ListUsuarios : Page
    {
        HttpClient client = new HttpClient();
        public ListUsuarios()
        {
            //client.BaseAddress = new Uri("http://apirent-env.eba-n7bvnjak.us-east-1.elasticbeanstalk.com/");
            client.BaseAddress = new Uri("http://localhost:8080/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }
        private void cargarUsuariobtn_Click(object sender, RoutedEventArgs e)
        {
            GetUsuarios();
        }
        private void idBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchByIdUsuario(new Usuarios());
        }
        private void cedulaBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchByCedula(new Usuarios());
        }
        private void GetUsuarios()
        {
            HttpResponseMessage response = client.GetAsync("usuario/usuarios").Result;
            if (response.IsSuccessStatusCode)
            {
                var usuarios = response.Content.ReadAsAsync<IEnumerable<Usuarios>>().Result;
                dgUsuarios.ItemsSource = usuarios;
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }
        private async void SearchByIdUsuario(Usuarios usuario)
        {
            var id = idFindTxt.Text;
            var url = "usuario/usuariosGet/" + id;

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var usuarioFind = await response.Content.ReadAsAsync<Usuarios>();
                dgUsuarios.ItemsSource = new List<Usuarios> { usuarioFind };
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
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
                dgUsuarios.ItemsSource = _Data;
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
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
    }
}
