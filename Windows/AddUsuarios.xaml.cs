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
            client.BaseAddress = new Uri("http://apirent-env.eba-n7bvnjak.us-east-1.elasticbeanstalk.com/");
            //client.BaseAddress = new Uri("http://localhost:8080/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        private void guardarBtn_Click(object sender, RoutedEventArgs e)
        { 
            if (nombreTxt.Text == "" || apellidoTxt.Text == "" || correoTxt.Text == "" || cedulaTxt.Text == ""
                || telefonoTxt.Text == "" || rolTxt.Text == "" || passNewPB.Password == "" || conPassPB.Password == null
                || regionCmb.SelectedItem == null || comunaCmb.SelectedItem == null)
            {
                lblError.Content = "Debe llenar todos los campos";
                VerificarUsuario();
            }
            else
            {
                if (passNewPB.Password != conPassPB.Password)
                {
                    incPassLbl.Text = "Las contraseñas no coinciden";
                }
                else
                {
                    if (nombreTxt.Text != "" && apellidoTxt.Text != "" && correoTxt.Text != "" && cedulaTxt.Text != ""
                        && telefonoTxt.Text != "" && rolTxt.Text != null && passNewPB.Password != "" && conPassPB.Password != ""
                        && regionCmb.SelectedItem != null && comunaCmb.SelectedItem != null)
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
                            regionUsuario = regionCmb.Text,
                            comunaUsuario = comunaCmb.Text,
                            passwordUsuario = conPassPB.Password
                        };

                        if (usuario.idUsuario == 0)
                        {
                            this.SaveUsuario(usuario);
                            lblMessage.Content = "Usuario guardado";
                            idTxt.Text = 0.ToString();
                            nombreTxt.Text = "";
                            apellidoTxt.Text = "";
                            correoTxt.Text = "";
                            cedulaTxt.Text = "";
                            telefonoTxt.Text = "";
                            rolTxt.Text = "";
                            conPassPB.Password = "";
                        }
                        else
                        {
                            this.UpdateUsuario(usuario);
                            lblMessage.Content = "Usuario actualizado";
                            idTxt.Text = 0.ToString();
                            nombreTxt.Text = "";
                            apellidoTxt.Text = "";
                            correoTxt.Text = "";
                            cedulaTxt.Text = "";
                            telefonoTxt.Text = "";
                            rolTxt.Text = "";
                            conPassPB.Password = "";
                        }
                    }
                }
            }
        }
        private void regionCmb_Changed(object sender, SelectionChangedEventArgs e)
        {
            RegionComuna();
        }

        private void VerificarUsuario()
        {
            if (string.IsNullOrEmpty(nombreTxt.Text))
            {
                nomErrLbl.Text = "Ingrese Nombre Valido.";
            }
            else if (string.IsNullOrEmpty(apellidoTxt.Text))
            {
                apeErrLbl.Text = "Ingrese Apellido Valido.";
            }
            else if (string.IsNullOrEmpty(cedulaTxt.Text))
            {
                cedErrLbl.Text = "Ingrese Cedula Valida.";
            }
            else if (string.IsNullOrEmpty(correoTxt.Text))
            {
                emailErrLbl.Text = "Ingrese Correo Valido.";
            }
            else if (string.IsNullOrEmpty(telefonoTxt.Text))
            {
                telErrLbl.Text = "Ingrese Telefono Valido.";
            }
            else if (string.IsNullOrEmpty(regionCmb.Text))
            {
                regErrLbl.Text = "Ingrese Region.";
            }
            else if (string.IsNullOrEmpty(comunaCmb.Text))
            {
                comErrLbl.Text = "Ingrese Comuna.";
            }
            else if (string.IsNullOrEmpty(passNewPB.Password))
            {
                noPassLbl.Text = "Ingrese Contraseña.";
            }
            else if (passNewPB.Password != conPassPB.Password)
            {
                incPassLbl.Text = "Las contraseñas no coinciden.";
            }                
        }

        private void RegionComuna()
        {
            var idRegion = regionCmb.SelectedValue;
            var response = client.GetAsync("comuna/comunasByRegionId?id=" + idRegion).Result;
            var comunas = response.Content.ReadAsAsync<List<Comunas>>().Result;
            comunaCmb.ItemsSource = comunas;
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

        private void ValidarRut_LostFocus(object sender, EventArgs e)
        {
            cedulaTxt.Text = FormatearRut(cedulaTxt.Text);
        }

        public string FormatearRut(string rut)
        {
            int cont = 0;
            string formato;
            if (rut.Length == 0)
            {
                return "";
            }
            else
            {
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                formato = "-" + rut.Substring(rut.Length - 1);
                for (int i = rut.Length - 2; i >= 0; i--)
                {
                    formato = rut.Substring(i, 1) + formato;
                    cont++;
                    if (cont == 3 && i != 0)
                    {
                        formato = "." + formato;
                        cont = 0;
                    }
                }
                return formato;
            }
        }
    }
}
