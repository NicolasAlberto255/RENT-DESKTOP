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
            ListUsuario listUsuario = new ListUsuario();
            listUsuario.Show();
        }
    }
}
