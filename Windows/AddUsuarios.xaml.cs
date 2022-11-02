using Newtonsoft.Json;
using RENT.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            client.BaseAddress = new Uri("http://apirent-env.eba-n7bvnjak.us-east-1.elasticbeanstalk.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        private void guardarbtn_Click(object sender, RoutedEventArgs e)
        {

            var usuario = new Usuarios()
            {
                idUsuario = Convert.ToInt32(idtxt.Text),
                nombreUsuario = nombretxt.Text,
                apellidoUsuario = apellidotxt.Text,
                correoUsuario = correotxt.Text,
                cedulaUsuario = cedulatxt.Text,
                telefonoUsuario = Convert.ToInt32(telefonotxt.Text),
                rolUsuario = roltxt.Text
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

            idtxt.Text = 0.ToString();
            nombretxt.Text = "";
            apellidotxt.Text = "";
            correotxt.Text = "";
            cedulatxt.Text = "";
            telefonotxt.Text = "";
            roltxt.Text = "";

        }

        private async void SaveUsuario(Usuarios usuario)
        {
            await client.PostAsJsonAsync("usuario/usuariosSave ", usuario);
        }

        private async void UpdateUsuario(Usuarios usuario)
        {
            await client.PostAsJsonAsync("/usuario/usuariosPut/" + usuario.idUsuario, usuario);
        }

        public void GetRegiones()
        {
            var response = client.GetAsync("region/regiones").Result;
            var regiones = response.Content.ReadAsAsync<List<Regiones>>().Result;

            foreach (var region in regiones)
            {
                regionescmb.ItemsSource = regiones;
                regionescmb.SelectedValue = "idRegion";
                regionescmb.DisplayMemberPath = "nombreRegion";
            }
        }

        public void GetComunas()
        {
            var response = client.GetAsync("comuna/comunas").Result;
            var comunas = response.Content.ReadAsAsync<List<Comunas>>().Result;

            foreach (var comuna in comunas)
            {
                comunascmb.ItemsSource = comunas;
                comunascmb.SelectedValue = "idComuna";
                comunascmb.DisplayMemberPath = "nombreComuna";
            }
        }
        

    }
}
