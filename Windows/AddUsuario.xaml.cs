using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RENT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
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
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace RENT.Windows
{
    /// <summary>
    /// Interaction logic for AddUsuario.xaml
    /// </summary>
    public partial class AddUsuario : Window
    {
        HttpClient client = new HttpClient();
        public AddUsuario()
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

        private async Task CargarRegiones()
        {
            string response = await client.GetStringAsync("region/regiones");
            List<Regiones> regiones = JsonConvert.DeserializeObject<List<Regiones>>(response);
            regiones.Insert(0, new Regiones() { idRegion = 0, nombreRegion = "Seleccione una región" });
            regionescmb.ItemsSource = regiones;
            regionescmb.DisplayMemberPath = "nombreRegion";
            regionescmb.SelectedValuePath = "idRegion";
            
        }
        


        private void regionescmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.CargarRegiones();
        }

    }
}
