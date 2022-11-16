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
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Converters;

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
            //client.BaseAddress = new Uri("http://apirent-env.eba-n7bvnjak.us-east-1.elasticbeanstalk.com/");
            client.BaseAddress = new Uri("http://localhost:8080/");
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
                correctBtnTB.Text = "";
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
                correctBtnTB.Text = "";
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
                correctBtnTB.Text = "";
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
                correctBtnTB.Text = "";
            }
        }
        private void cedulaCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            usListBox.Items.Clear();
            usListBox.Items.Add(cedulaCmb.SelectedItem);
            correctBtnTB.Text = "";

            if (cedulaCmb.SelectedItem != null)
            {
                var usuario = (Usuarios)cedulaCmb.SelectedItem;
                idUsuarioTxt.Text = usuario.idUsuario.ToString();
                nombreUsuarioTxt.Text = usuario.nombreUsuario;
                cedulaUsuarioTxt.Text = usuario.cedulaUsuario;
                apellidoUsuarioTxt.Text = usuario.apellidoUsuario;
                correoUsuarioTxt.Text = usuario.correoUsuario;
                telefonoUsuarioTxt.Text = usuario.telefonoUsuario.ToString();
                rolUsuarioTxt.Text = usuario.rolUsuario.ToString();
                regionUsuarioTxt.Text = usuario.regionUsuario;
                comunaUsuarioTxt.Text = usuario.comunaUsuario;
            }
        }
        private void departamentoCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            deptoListBox.Items.Clear();
            deptoListBox.Items.Add(departamentoCmb.SelectedItem);
            correctBtnTB.Text = "";

            if (departamentoCmb.SelectedItem != null)
            {
                var departamento = (Departamentos)departamentoCmb.SelectedItem;
                idDepartamentoTxt.Text = departamento.idDepartamentos.ToString();
                nombreDepartamentoTxt.Text = departamento.nombreDepartamento;
                nombreComunaDeptoTxt.Text = departamento.nombreComunaDepto;
                nombreRegionDeptoTxt.Text = departamento.nombreRegionDepto;
                nBanosTxt.Text = departamento.nBanos.ToString();
                nDeptoTxt.Text = departamento.nDepto.ToString();
                nEdificioTxt.Text = departamento.nEdificio.ToString();
                nHabitacionTxt.Text = departamento.nHabitacion.ToString();
                vNocheTxt.Text = departamento.vNoche.ToString();
                balconTxt.Text = departamento.balcon.ToString();

            }
        }
        private void serviciosCmb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            correctBtnTB.Text = "";
            if (servicios1Cmb.SelectedItem != null)
            {
                var servicios = (Servicios)servicios1Cmb.SelectedItem;
                idServicios1Txt.Text = servicios.idServicios.ToString();
                nombreServicios1Txt.Text = servicios.nombreServicios;
                descripcionServicios1Txt.Text = servicios.descripcionServicios;
            }
        }
        private void servicios2Cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            correctBtnTB.Text = "";
            if (servicios2Cmb.SelectedItem != null)
            {
                var servicios = (Servicios)servicios2Cmb.SelectedItem;
                idServicios2Txt.Text = servicios.idServicios.ToString();
                nombreServicios2Txt.Text = servicios.nombreServicios;
                descripcionServicios2Txt.Text = servicios.descripcionServicios;
            }
        }
        private void servicios3Cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            correctBtnTB.Text = "";
            if (servicios3Cmb.SelectedItem != null)
            {
                var servicios = (Servicios)servicios3Cmb.SelectedItem;
                idServicios3Txt.Text = servicios.idServicios.ToString();
                nombreServicios3Txt.Text = servicios.nombreServicios;
                descripcionServicios3Txt.Text = servicios.descripcionServicios;
            }
        }
        private void guardarReservaBtn_Click(object sender, RoutedEventArgs e)
        {
            int cntDias = Convert.ToInt32(cntDiasTxt.Text); 
            if (departamentoCmb.SelectedItem != null && cedulaCmb.SelectedItem != null && cntDias > 0
                && fechaInicioDtp.Text != "" && fechaFinDtp.Text != "")
            {
                if (servicios1Cmb.SelectedItem == null)
                {
                    idServicios1Txt.Text = "1";
                    nombreServicios1Txt.Text = "Ningun Servicio";
                    descripcionServicios1Txt.Text = "Nada";
                }

                if (servicios2Cmb.SelectedItem == null)
                {
                    idServicios2Txt.Text = "1";
                    nombreServicios2Txt.Text = "Ningun Servicio";
                    descripcionServicios2Txt.Text = "Nada";
                }

                if (servicios3Cmb.SelectedItem == null)
                {
                    idServicios3Txt.Text = "1";
                    nombreServicios3Txt.Text = "Ningun Servicio";
                    descripcionServicios3Txt.Text = "Nada";
                }

                Reservas reservas = new Reservas()
                {
                    idReserva = 0,
                    fechaInicio = fechaInicioDtp.SelectedDate.Value,
                    fechaFin = fechaFinDtp.SelectedDate.Value,
                    fechaCreacion = DateTime.Today,
                    precioAbono = Convert.ToInt32(precioAbonoTxt.Text),
                    usuarios = new object[] { new Usuarios() {
                    idUsuario = Convert.ToInt32(idUsuarioTxt.Text) }
                },
                    departamentos = new object[] { new Departamentos() {
                    idDepartamentos = Convert.ToInt32(idDepartamentoTxt.Text)}
                },
                    servicios = new object[] { new Servicios() {
                    idServicios = Convert.ToInt32(idServicios1Txt.Text)
                },
                new Servicios() {
                    idServicios = Convert.ToInt32(idServicios2Txt.Text)
                },
                new Servicios() {
                    idServicios = Convert.ToInt32(idServicios3Txt.Text)
                } }
                };


                if (reservas.idReserva == 0)
                {
                    SaveReservas(reservas);

                    cedulaCmb.SelectedItem = null;
                    departamentoCmb.SelectedItem = null;
                    abonoTB.Text = "";
                    precioAbonoTxt.Text = "";
                    reservasDiasTB.Text = "";
                    departamentosTB.Text = "";
                    usuarioTB.Text = "";
                    abonoTB.Text = "";
                    servicios1Cmb.SelectedIndex = 0;
                    servicios2Cmb.SelectedIndex = 0;
                    servicios3Cmb.SelectedIndex = 0;
                    correctBtnTB.Text = "Reserva guardada con exito";
                    reservasDiasTB.Text = "";
                    departamentosTB.Text = "";
                    usuarioTB.Text = "";
                    abonoTB.Text = "";
                }
                else
                {
                    UpdateReserva(reservas);
                    MessageBox.Show("Reserva actualizada con exito");
                }
            }
            else
            {
                ValidarDatos();
                saveBtnTB.Text = "Debe llenar todos los campos";
            } 
        }
        private void Dias_TextChanged(object sender, TextChangedEventArgs e)
        {
            correctBtnTB.Text = "";
            if (cntDiasTxt.Text != "")
            {
                int valorNoche = Convert.ToInt32(vNocheTxt.Text);
                int cantidadDias = Convert.ToInt32(cntDiasTxt.Text);
                double suma = valorNoche * cantidadDias;
                var valorTotal = String.Format("{0:C}", suma);
                valorTotalTxt.Text = Convert.ToString(valorTotal);
            }
            else
            {
                cntDiasTxt.Text = "0";
                valorTotalTxt.Text = "$";
            }
        }
        private void Precio_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (precioAbonoTxt.Text == "")
            {
                precioAbonoTxt.Text = "0";
            }
        }
        private void cargarCedulaBtn_Click(object sender, RoutedEventArgs e)
        {
            //SearchByCedula(new Usuarios());
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
                servicios1Cmb.ItemsSource = servicios;
                servicios2Cmb.ItemsSource = servicios;
                servicios3Cmb.ItemsSource = servicios;
            }
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
        public void GetDepartamentos()
        {
            var response = client.GetAsync("departamentos/departamentos").Result;
            var departamentos = response.Content.ReadAsAsync<List<Departamentos>>().Result;

            foreach (var departamento in departamentos)
            {
                departamentoCmb.ItemsSource = departamentos;
            }
        }
        private async void SaveReservas(Reservas reservas)
        {
            var reservaPost = JsonConvert.SerializeObject(reservas);
            var deserialized = JsonConvert.DeserializeObject<Reservas>(reservaPost);
            await client.PostAsJsonAsync("reserva/reservaAdd", deserialized);
        }
        private async void UpdateReserva(Reservas reservas)
        {
            await client.PostAsJsonAsync("reserva/reservaPut/" + reservas.idReserva, reservas);
        }
        private void ValidarDatos()
        {
            if (string.IsNullOrEmpty(departamentoCmb.Text))
            {
                departamentosTB.Text = "Seleccione un Departamento";
            }

            if (string.IsNullOrEmpty(cedulaCmb.Text))
            {
                usuarioTB.Text = "Seleccione un Usuario";
            }

            if (cntDiasTxt.Text == "" || cntDiasTxt.Text == "0")
            {
                reservasDiasTB.Text = "Ingrese una cantidad de dias";
            }
        }
        private void ValidacionDeNumeros(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
