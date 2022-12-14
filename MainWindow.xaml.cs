using RENT.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace RENT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rgUsuarioBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUsuarios addUsuarios = new AddUsuarios();
            ListUsuarios listUsuarios = new ListUsuarios();
            Main.Content = addUsuarios;
            addUsuarios.GetRegiones();
            addUsuarios.GetComunas();
            logoImg.Visibility = Visibility.Hidden;
        }

        private void bUsuariosBtn_Click(object sender, RoutedEventArgs e)
        {
            ListUsuarios listUsuarios = new ListUsuarios();
            Main.Content = listUsuarios;
            logoImg.Visibility = Visibility.Hidden;
        }

        private void addReservaBtn_Click(object sender, RoutedEventArgs e)
        {
            AddReserva addReserva = new AddReserva();
            Main.Content = addReserva;
            addReserva.cntDiasTxt.IsEnabled = false;
            addReserva.fechaFinDtp.IsEnabled = false;
            addReserva.GetUsuarios();
            addReserva.GetDepartamentos();
            addReserva.GetServicios();
            addReserva.Today();
            addReserva.valorTotalTxt.Text = "0";
            addReserva.precioAbonoTxt.Text = "0";
            addReserva.cntAdultosTxt.Text = "1";
            addReserva.cntNinosTxt.Text = "0";
            logoImg.Visibility = Visibility.Hidden;
        }

        private void addDepartamentoBtn_Click(object sender, RoutedEventArgs e)
        {
            AddDepartamento addDepartamento = new AddDepartamento();
            Main.Content = addDepartamento;
            addDepartamento.GetRegiones();
            addDepartamento.GetComunas();
            logoImg.Visibility = Visibility.Hidden;
        }

        private void inicioBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = null;
            logoImg.Visibility = Visibility.Visible;
        }

        private void imagenesDeptoBtn_Click(object sender, RoutedEventArgs e)
        {
            AddDeptoImagen imagenDepto = new AddDeptoImagen();
            Main.Content = imagenDepto;
            imagenDepto.GetDepartamentos();
            logoImg.Visibility = Visibility.Hidden;
        }

        private void addInventarioBtn_Click(object sender, RoutedEventArgs e)
        {
            AddInventario addInventario = new AddInventario();
            Main.Content = addInventario;
            addInventario.GetDepartamentos();
            logoImg.Visibility = Visibility.Hidden;
        }

        private void addServicioImagenBtn_Click(object sender, RoutedEventArgs e)
        {
            AddServicioImagen imagenServicio = new AddServicioImagen();
            Main.Content = imagenServicio;
            imagenServicio.GetServicios();
            logoImg.Visibility = Visibility.Hidden;
        }
    }
}
