using Microsoft.Win32;
using Newtonsoft.Json;
using RENT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
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
using Wisej.Web.VisualBasic;

namespace RENT.Windows
{
    /// <summary>
    /// Interaction logic for ListTipoDepartamento.xaml
    /// </summary>
    public partial class ListTipoDepartamento : Page
    {
        HttpClient client = new HttpClient();
        public ListTipoDepartamento()
        {
            //client.BaseAddress = new Uri("http://apirent-env.eba-n7bvnjak.us-east-1.elasticbeanstalk.com/");
            client.BaseAddress = new Uri("http://localhost:8080/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        private void CargarTabla_Click(object sender, RoutedEventArgs e)
        {
            CargarImagenData(new TipoDeptoImagen());
        }
        
        private void CargarBtn_Click(object sender, RoutedEventArgs e)
        {
            SubirImagen();            
        }

        private void GuardarBtn_Click(object sender, RoutedEventArgs e)
        {
            GuardarDatos();
        }

        private async void CargarImagenData(TipoDeptoImagen tipoDeptoImagen)
        {
            HttpResponseMessage response = client.GetAsync("tipoDeptoImagen/imagenList").Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var tipoDeptoList = JsonConvert.DeserializeObject<List<TipoDeptoImagen>>(json);

                imagenListBox.ItemsSource = tipoDeptoList;
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }

        }

        OpenFileDialog showImagen = new OpenFileDialog();
        private void SubirImagen() 
        {            
            showImagen.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            

            bool? response = showImagen.ShowDialog();

            if (response == true)
            {
                imagenPanel.Source = new BitmapImage(new Uri(showImagen.FileName));
            }                       
        }    
        
        private void GuardarDatos()
        {
            MultipartFormDataContent imagen = new MultipartFormDataContent();
            string fileName = showImagen.SafeFileName;
            string fileExt = System.IO.Path.GetExtension(fileName);
            string contentype = string.Empty;

            switch (fileExt)
            {
                case ".jpg":
                    contentype = "image/jpg";
                    break;
                case ".jpeg":
                    contentype = "image/jpeg";
                    break;
                case ".png":
                    contentype = "image/png";
                    break;
            }

            if (contentype != string.Empty)
            {
                byte[] data = System.IO.File.ReadAllBytes(showImagen.FileName);
                ByteArrayContent bytes = new ByteArrayContent(data);
                bytes.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentype);
                imagen.Add(bytes, "imagen", fileName);
                imagen.Add(new StringContent("1"), "idTipoDepartamento");
                var responseUpload = client.PostAsync("tipoDeptoImagen/imagenUpload", imagen).Result;
                if (responseUpload.IsSuccessStatusCode)
                {
                    MessageBox.Show("Imagen subida exitosamente.");
                }
                else
                {
                    MessageBox.Show("Error al Subir Imagen.");
                }
            }
            else
            {
                MessageBox.Show("Ingresa una Imagen Valida.");
            }
        }

        
    }
}
