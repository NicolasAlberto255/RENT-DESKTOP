using Newtonsoft.Json;
using RENT.Models;
using System;
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
using System.Windows.Shapes;

namespace RENT.Windows
{
    /// <summary>
    /// Interaction logic for ListUsuario.xaml
    /// </summary>
    public partial class ListUsuario : Window
    {
        HttpClient client = new HttpClient();
        public ListUsuario()
        {
            client.BaseAddress = new Uri("http://apirent-env.eba-n7bvnjak.us-east-1.elasticbeanstalk.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }
        private void cargarUsuariobtn_Click(object sender, RoutedEventArgs e)
        {
            dgUsuarios.ItemsSource = null;
            this.GetUsuarios();
        }

        private void idbtn_Click(object sender, RoutedEventArgs e)
        {
            this.SearchByIdUsuario(new Usuarios());
        }

        private void nombrebtn_Click(object sender, RoutedEventArgs e)
        {
            this.SearchByNombre(new Usuarios());
        }

        private void apellidobtn_Click(object sender, RoutedEventArgs e)
        {
            this.SearchByApellido(new Usuarios());
        }

        private void cedulabtn_Click(object sender, RoutedEventArgs e)
        {
            this.SearchByCedula(new Usuarios());
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
            var id = idFindtxt.Text;
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

        private async void SearchByNombre(Usuarios usuario)
        {
            var nombreUsuario = nombreFindtxt.Text;
            var url = "usuario/nombreUsuario?nombreUsuario=" + nombreUsuario;

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

        private async void SearchByApellido(Usuarios usuario)
        {
            var apellidoUsuario = apellidoFindtxt.Text;
            var url = "usuario/apellidoUsuario?apellidoUsuario=" + apellidoUsuario;

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

        private async void SearchByCedula(Usuarios usuario)
        {
            var cedulaUsuario = cedulaFindtxt.Text;
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
    }
}
