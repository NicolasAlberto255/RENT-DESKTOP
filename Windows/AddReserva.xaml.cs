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
using Newtonsoft.Json.Linq;
using System.Globalization;

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

        private void cntPersonas_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Convert.ToInt32(cntAdultosTxt.Text) > 6)
            {
                cntAdultosErr.Text = "No se pueden mas de 6 personas";
                cntAdultosTxt.Text = "0";
            }
            else
            {
                if (Convert.ToInt32(cntAdultosTxt.Text) < 6)
                {
                    cntAdultosTxt.Text = cntAdultosTxt.Text;
                }
            }
        }

        private void cntNinos_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Convert.ToInt32(cntNinosTxt.Text) > 6)
            {
                cntNinosErr.Text = "No se pueden mas de 6 Niños";
                cntNinosTxt.Text = "0";
            }
            else
            {
                if (Convert.ToInt32(cntNinosTxt.Text) < 6)
                {
                    cntNinosTxt.Text = cntNinosTxt.Text;
                }
            }
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
            }
        }

        private void acercamientoCbx_Checked(object sender, RoutedEventArgs e)
        {
            int valorTotalInt = Convert.ToInt32(valorTotalIntTxt.Text);
            int servicioValor = Convert.ToInt32(precioServicios1Txt.Text);

            if (acercamientoCbx.IsChecked == true)
            {
                valorTotalIntTxt.Text = (valorTotalInt + servicioValor).ToString();
            }
        }
        private void acercamientoCbx_Unchecked(object sender, RoutedEventArgs e)
        {
            int valorTotalInt = Convert.ToInt32(valorTotalIntTxt.Text);
            int servicioValor = Convert.ToInt32(precioServicios1Txt.Text);

            if (acercamientoCbx.IsChecked == false)
            {
                valorTotalIntTxt.Text = (valorTotalInt - servicioValor).ToString();
            }
        }
        private void taxiCbx_Checked(object sender, RoutedEventArgs e)
        {
            int valorTotalInt = Convert.ToInt32(valorTotalIntTxt.Text);
            int servicioValor = Convert.ToInt32(precioServicios2Txt.Text);

            if (taxiCbx.IsChecked == true)
            {
                valorTotalIntTxt.Text = (valorTotalInt + servicioValor).ToString();
            }            
        }
        private void taxiCbx_Unchecked(object sender, RoutedEventArgs e)
        {
            int valorTotalInt = Convert.ToInt32(valorTotalIntTxt.Text);
            int servicioValor = Convert.ToInt32(precioServicios2Txt.Text);

            if (taxiCbx.IsChecked == false)
            {
                valorTotalIntTxt.Text = (valorTotalInt - servicioValor).ToString();
            }
        }
        private void tourCbx_Checked(object sender, RoutedEventArgs e)
        {
            int valorTotalInt = Convert.ToInt32(valorTotalIntTxt.Text);
            int servicioValor = Convert.ToInt32(precioServicios3Txt.Text);

            if (tourCbx.IsChecked == true)
            {
                valorTotalIntTxt.Text = (valorTotalInt + servicioValor).ToString();
            }
        }
        private void tourCbx_Unchecked(object sender, RoutedEventArgs e)
        {
            int valorTotalInt = Convert.ToInt32(valorTotalIntTxt.Text);
            int servicioValor = Convert.ToInt32(precioServicios3Txt.Text);

            if (tourCbx.IsChecked == false)
            {
                valorTotalIntTxt.Text = (valorTotalInt - servicioValor).ToString();
            }
        }
        private void vehiculoCbx_Checked(object sender, RoutedEventArgs e)
        {
            int valorTotalInt = Convert.ToInt32(valorTotalIntTxt.Text);
            int servicioValor = Convert.ToInt32(precioServicios4Txt.Text);

            if (vehiculoCbx.IsChecked == true)
            {
                valorTotalIntTxt.Text = (valorTotalInt + servicioValor).ToString();
            }
        }
        private void vehiculoCbx_Unchecked(object sender, RoutedEventArgs e)
        {
            int valorTotalInt = Convert.ToInt32(valorTotalIntTxt.Text);
            int servicioValor = Convert.ToInt32(precioServicios4Txt.Text);

            if (vehiculoCbx.IsChecked == false)
            {
                valorTotalIntTxt.Text = (valorTotalInt - servicioValor).ToString();
            }
        }
        private void bicicletasCbx_Checked(object sender, RoutedEventArgs e)
        {
            int valorTotalInt = Convert.ToInt32(valorTotalTxt.Text);
            int servicioValor = Convert.ToInt32(precioServicios5Txt.Text);
            
            if (bicicletasCbx.IsChecked == true)
            {
                valorTotalIntTxt.Text = (valorTotalInt + servicioValor).ToString();
            }
        }
        private void bicicletasCbx_Unchecked(object sender, RoutedEventArgs e)
        {
            int valorTotalInt = Convert.ToInt32(valorTotalIntTxt.Text);
            int servicioValor = Convert.ToInt32(precioServicios5Txt.Text);

            if (bicicletasCbx.IsChecked == false)
            {
                valorTotalIntTxt.Text = (valorTotalInt - servicioValor).ToString();
            }
        }
        private void cenasCbx_Checked(object sender, RoutedEventArgs e)
        {
            int valorTotalInt = Convert.ToInt32(valorTotalIntTxt.Text);
            int servicioValor = Convert.ToInt32(precioServicios6Txt.Text);
            
            if (cenasCbx.IsChecked == true)
            {
                valorTotalIntTxt.Text = (valorTotalInt + servicioValor).ToString();
            }
        }
        private void cenasCbx_Unchecked(object sender, RoutedEventArgs e)
        {
            int valorTotalInt = Convert.ToInt32(valorTotalIntTxt.Text);
            int servicioValor = Convert.ToInt32(precioServicios6Txt.Text);

            if (cenasCbx.IsChecked == false)
            {
                valorTotalIntTxt.Text = (valorTotalInt - servicioValor).ToString();
            }
        }
        private void guardarReservaBtn_Click(object sender, RoutedEventArgs e)
        {
            int cntDias = Convert.ToInt32(cntDiasTxt.Text);
            if (departamentoCmb.SelectedItem != null && cedulaCmb.SelectedItem != null && cntDias > 0
                && fechaInicioDtp.Text != "" && fechaFinDtp.Text != "")
            {
                ValidarServicios();

                if ((Convert.ToInt32(cntAdultosTxt.Text) < 6 && cntAdultosTxt.Text == "")
                && (Convert.ToInt32(cntNinosTxt.Text) < 6 && cntNinosTxt.Text == ""))
                {
                    double valorTotal = Double.Parse(valorTotalTxt.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("es-CL"));

                    Reservas reservas = new Reservas()
                    {
                        fechaInicio = fechaInicioDtp.SelectedDate.Value,
                        fechaFin = fechaFinDtp.SelectedDate.Value,
                        fechaCreacion = DateTime.Today,
                        precioAbono = Convert.ToInt32(precioAbonoTxt.Text),
                        precioTotal = (valorTotal - Convert.ToDouble(precioAbonoTxt.Text)),
                        cntPersonas = Convert.ToInt32(cntAdultosTxt.Text) + Convert.ToInt32(cntNinosTxt.Text),
                        usuarios = new object[] {
                        new Usuarios() {
                            idUsuario = Convert.ToInt32(idUsuarioTxt.Text) }
                        },
                                departamentos = new object[] {
                        new Departamentos() {
                            idDepartamentos = Convert.ToInt32(idDepartamentoTxt.Text)}
                        },
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

                    var checkIn = new CheckIn()
                    {
                        nombreCliente = nombreUsuarioTxt.Text + " " + apellidoUsuarioTxt.Text,
                        anotaciones = anotacionesTxt.Text,
                        fechaCheckIn = fechaInicioDtp.SelectedDate.Value,
                        montoFinalReserva = (valorTotal - Convert.ToDouble(precioAbonoTxt.Text))
                    };


                    if (valorTotal < Convert.ToDouble(precioAbonoTxt.Text))
                    {
                        abonoMayorErr.Text = "El abono no puede ser mayor al valor total";
                    }
                    else
                    {
                        abonoMayorErr.Text = "";
                        if (valorTotal > Convert.ToDouble(precioAbonoTxt.Text))
                        {
                            if (reservas.idReserva == 0)
                            {
                                SaveReservas(reservas);
                                SaveCheckIn(checkIn);
                                LimpiarDatos();
                            }
                            else
                            {
                                UpdateReserva(reservas);
                                MessageBox.Show("Reserva actualizada con exito");
                            }

                            GetDepartamentos();
                        }
                    }
                }
                else
                {
                    saveBtnTB.Text = "Ingrese una Cantidad Correcta de Personas";
                }
            }
            else
            {
                ValidarDatos();
                saveBtnTB.Text = "Debe llenar todos los campos";
            }
        }

        private void Precio_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (precioAbonoTxt.Text == "")
            {
                precioAbonoTxt.Text = "0";
            }
        }
        
        private void dias_Changed(object sender, TextChangedEventArgs e)
        {
            Suma();
        }

        private void valor_Changed(object sender, TextChangedEventArgs e)
        {
            valorTotalTxt.Text = valorTotalIntTxt.Text;
            Suma();
        }
        private void Suma()
        {
            if (cntDiasTxt.Text == "")
            {
                cntDiasTxt.Text = "0";
            }
            if (valorTotalIntTxt.Text == "")
            {
                valorTotalIntTxt.Text = "0";
            }
            
            NumberFormatInfo formatoChileno = new CultureInfo("es-CL", false).NumberFormat;
            int valorNoche = Convert.ToInt32(vNocheTxt.Text);
            int cantidadDias = Convert.ToInt32(cntDiasTxt.Text);
            double suma = (valorNoche * cantidadDias)+ Convert.ToDouble(valorTotalIntTxt.Text);
            var valorTotalInt= suma.ToString();
            double sumaFinal = Convert.ToDouble(valorTotalInt);
            var valorTotalChile = sumaFinal.ToString("C", formatoChileno);
            valorTotalTxt.Text = Convert.ToString(valorTotalChile);      
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

        private void LimpiarDatos()
        {
            cedulaCmb.SelectedItem = null;
            departamentoCmb.SelectedItem = null;
            abonoTB.Text = "";
            precioAbonoTxt.Text = "";
            reservasDiasTB.Text = "";
            departamentosTB.Text = "";
            usuarioTB.Text = "";
            abonoTB.Text = "";
            acercamientoCbx.IsChecked = false;
            taxiCbx.IsChecked = false;
            tourCbx.IsChecked = false;
            vehiculoCbx.IsChecked = false;
            bicicletasCbx.IsChecked = false;
            cenasCbx.IsChecked = false;
            correctBtnTB.Text = "Reserva guardada con exito";
            reservasDiasTB.Text = "";
            departamentosTB.Text = "";
            usuarioTB.Text = "";
            abonoTB.Text = "";
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

            var serialize = JsonConvert.SerializeObject(departamentos);
            var deserialize = JsonConvert.DeserializeObject<List<Departamentos>>(serialize);

            var estado = deserialize.Where(x => x.estadoDepartamento == "Disponible").ToList();

            foreach (var departamento in departamentos)
            {
                if (departamento.estadoDepartamento == "Disponible")
                {
                    departamentoCmb.ItemsSource = estado;
                }
            }
        }

        public void GetServicios()
        {
            var response = client.GetAsync("servicio/servicios").Result;
            var servicios = response.Content.ReadAsAsync<List<Servicios>>().Result;
                    

            foreach (var servicio in servicios)
            {
                if (servicio.nombreServicios == "Tour")
                {
                    precioServicios1Txt.Text = servicio.precioServicios.ToString();
                    if (servicio.estadoServicios == "No Disponible")
                    {
                        tourCbx.IsEnabled = false;
                    }
                    else
                    {
                        tourCbx.IsEnabled = true;
                    }
                }
                if (servicio.nombreServicios == "Taxi")
                {
                    precioServicios2Txt.Text = servicio.precioServicios.ToString();
                    if (servicio.estadoServicios == "No Disponible")
                    {
                        taxiCbx.IsEnabled = false;
                    }
                    else
                    {
                        taxiCbx.IsEnabled = true;
                    }
                }
                if (servicio.nombreServicios == "Acercamiento")
                {
                    precioServicios3Txt.Text = servicio.precioServicios.ToString();
                    if (servicio.estadoServicios == "No Disponible")
                    {
                        acercamientoCbx.IsEnabled = false;
                    }
                    else
                    {
                        acercamientoCbx.IsEnabled = true;
                    }
                }
                if (servicio.nombreServicios == "Vehiculos")
                {
                    precioServicios4Txt.Text = servicio.precioServicios.ToString();
                    if (servicio.estadoServicios == "No Disponible")
                    {
                        vehiculoCbx.IsEnabled = false;
                    }
                    else
                    {
                        vehiculoCbx.IsEnabled = true;
                    }
                }
                if (servicio.nombreServicios == "Bicicletas")
                {
                    precioServicios5Txt.Text = servicio.precioServicios.ToString();
                    if (servicio.estadoServicios == "No Disponible")
                    {
                        bicicletasCbx.IsEnabled = false;
                    }
                    else
                    {
                        bicicletasCbx.IsEnabled = true;
                    }
                }
                if (servicio.nombreServicios == "Cenas")
                {
                    precioServicios6Txt.Text = servicio.precioServicios.ToString();
                    if (servicio.estadoServicios == "No Disponible")
                    {
                        cenasCbx.IsEnabled = false;
                    }
                    else
                    {
                        cenasCbx.IsEnabled = true;
                    }
                }
            }
        }

        private async void SaveCheckIn(CheckIn checkIn)
        {
            await client.PostAsJsonAsync("checkin/checkinSave", checkIn);
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
