using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RENT.Windows
{
    /// <summary>
    /// Interaction logic for AddServicioImagen.xaml
    /// </summary>
    public partial class AddServicioImagen : Page
    {
        HttpClient client = new HttpClient();

        OpenFileDialog showImagen = new OpenFileDialog();
        public AddServicioImagen()
        {
            //client.BaseAddress = new Uri("http://apirent-env.eba-n7bvnjak.us-east-1.elasticbeanstalk.com/");
            client.BaseAddress = new Uri("http://localhost:8080/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        private void CargarBtn_Click(object sender, RoutedEventArgs e)
        {
            SubirImagen();
        }

        private void GuardarBtn_Click(object sender, RoutedEventArgs e)
        {
            GuardarDatos();
        }

        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files)
                {
                    showImagen.FileName = file;
                    uplListImagenes.Items.Add(showImagen.SafeFileName);
                    imagenesListBox.Items.Add(showImagen.FileName);
                }
            }
        }
        
        private void serviciosListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectIdServicio();
        }

        private void uplListImagenes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (uplListImagenes.SelectedIndex != -1)
            {
                ShowImagenSelected();
            }
        }

        private void ShowImagenSelected()
        {
            foreach (string item in imagenesListBox.Items)
            {
                if (uplListImagenes.SelectedItem.ToString() == System.IO.Path.GetFileName(item))
                {
                    var uri = new Uri(item);
                    var bitmap = new BitmapImage(uri);
                    imagenSelected.Source = bitmap;
                }
            }
        }
        
        private void SelectIdServicio()
        {
            foreach (var item in serviciosListBox.Items)
            {
                var id = (Servicios)serviciosListBox.SelectedItem;

                if (id != null)
                {
                    idServicioTxt.Text = id.idServicios.ToString();
                }
            }
        }

        private void SubirImagen()
        {
            showImagen.Multiselect = true;
            showImagen.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            
            if (showImagen.ShowDialog() == true)
            {
                foreach (string item in showImagen.SafeFileNames)
                {
                    uplListImagenes.Items.Add(item);
                    imagenesListBox.Items.Add(showImagen.FileName);
                }
            }
        }
        
        public void GetServicios()
        {
            var response = client.GetAsync("servicio/servicios").Result;
            var servicios = response.Content.ReadAsAsync<List<Servicios>>().Result;
            
            foreach (var sevicio in servicios)
            {
                var serviciosList = new Servicios
                {
                    idServicios = sevicio.idServicios
                };

                if (serviciosList.idServicios > 1)
                {
                    serviciosListBox.Items.Add(sevicio);
                }
            }
        }
        
        private void GuardarDatos()
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            foreach (string item in uplListImagenes.Items)
            {
                MultipartFormDataContent imagen = new MultipartFormDataContent();

                string fileName = item;
                string fileExt = System.IO.Path.GetExtension(fileName);
                string contentType = string.Empty;

                switch (fileExt)
                {
                    case ".jpg":
                        contentType = "image/jpeg";
                        break;
                    case ".jpeg":
                        contentType = "image/jpeg";
                        break;
                    case ".png":
                        contentType = "image/png";
                        break;
                    default:
                        break;
                }

                if (contentType != string.Empty)
                {
                    byte[] data = System.IO.File.ReadAllBytes(showImagen.FileName);
                    ByteArrayContent bytes = new ByteArrayContent(data);
                    bytes.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                    imagen.Add(bytes, "imagen", fileName);
                    imagen.Add(new StringContent(idServicioTxt.Text), "idServicios");
                    httpResponseMessage = client.PostAsync("serviciosImagen/imagenUpload", imagen).Result;
                }
                else
                {
                    MessageBox.Show("Ingrese una Imagen Valida.");
                }
            }
                        
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show("Imagen Guardada Correctamente.");
                uplListImagenes.Items.Clear();
                imagenesListBox.Items.Clear();
                imagenSelected.Source = null;
                idServicioTxt.Text = "";
            }
            else
            {
                MessageBox.Show("Error al Guardar la Imagen.");
            }
        }
    }
}
