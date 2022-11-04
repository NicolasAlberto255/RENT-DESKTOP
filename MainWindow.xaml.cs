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
            this.Content = addUsuarios;
            addUsuarios.GetRegiones();
            addUsuarios.GetComunas();
        }

        private void bUsuariosBtn_Click(object sender, RoutedEventArgs e)
        {
            ListUsuarios listUsuarios = new ListUsuarios();
            this.Content = listUsuarios;
        }

        private void addReservaBtn_Click(object sender, RoutedEventArgs e)
        {
            AddReserva addReserva = new AddReserva();
            this.Content = addReserva;
            addReserva.cntDiasTxt.IsEnabled = false;
            addReserva.fechaFinDtp.IsEnabled = false;
            addReserva.GetServicios();
            addReserva.Today();
        }

        private void addDepartamentoBtn_Click(object sender, RoutedEventArgs e)
        {
            AddDepartamento addDepartamento = new AddDepartamento();
            this.Content = addDepartamento;
            addDepartamento.GetRegiones();
            addDepartamento.GetComunas();
        }
    }
}
