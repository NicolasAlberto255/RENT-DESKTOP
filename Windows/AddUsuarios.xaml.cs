using Newtonsoft.Json;
using RENT.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
    /// Lógica de interacción para AddUsuarios.xaml
    /// </summary>
    public partial class AddUsuarios : Page
    {
        HttpClient client = new HttpClient();
        public AddUsuarios()
        {
            //client.BaseAddress = new Uri("http://apirent-env.eba-n7bvnjak.us-east-1.elasticbeanstalk.com/");
            client.BaseAddress = new Uri("http://localhost:8080/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        private void guardarBtn_Click(object sender, RoutedEventArgs e)
        {
            var usuario = new Usuarios()
            {
                idUsuario = Convert.ToInt32(idTxt.Text),
                nombreUsuario = nombreTxt.Text,
                apellidoUsuario = apellidoTxt.Text,
                correoUsuario = correoTxt.Text,
                cedulaUsuario = cedulaTxt.Text,
                telefonoUsuario = Convert.ToInt32(telefonoTxt.Text),
                rolUsuario = Convert.ToInt32(rolTxt.Text),
                regionUsuario = regionesCmb.Text,
                comunaUsuario = comunasCmb.Text
            };

            if (usuario.idUsuario == 0)
            {
                this.SaveUsuario(usuario);
                lblMessage.Content = "Usuario guardado";
            }
            else
            {
                this.UpdateUsuario(usuario);
                lblMessage.Content = "Usuario actualizado";
            }

            idTxt.Text = 0.ToString();
            nombreTxt.Text = "";
            apellidoTxt.Text = "";
            correoTxt.Text = "";
            cedulaTxt.Text = "";
            telefonoTxt.Text = "";
            rolTxt.Text = "";
            regionesCmb.SelectedIndex = -1;
            comunasCmb.SelectedIndex = -1;

        }

        private async void SaveUsuario(Usuarios usuario)
        {
            await client.PostAsJsonAsync("usuario/usuariosSave ", usuario);
        }

        private async void UpdateUsuario(Usuarios usuario)
        {
            await client.PostAsJsonAsync("usuario/usuariosPut/" + usuario.idUsuario, usuario);
        }

        public void GetRegiones()
        {
            var response = client.GetAsync("region/regiones").Result;
            var regiones = response.Content.ReadAsAsync<List<Regiones>>().Result;

            foreach (var region in regiones)
            {
                regionesCmb.ItemsSource = regiones;
            }
        }

        public void GetComunas()
        {
            var response = client.GetAsync("comuna/comunas").Result;
            var comunas = response.Content.ReadAsAsync<List<Comunas>>().Result;

            foreach (var comuna in comunas)
            {
                comunasCmb.ItemsSource = comunas;
            }
        }
    }
}
