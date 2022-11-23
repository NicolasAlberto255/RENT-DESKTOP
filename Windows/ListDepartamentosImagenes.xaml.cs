using Microsoft.AspNetCore.Mvc;
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
    public partial class ListDepartamentosImagenes : Page
    {
        HttpClient client = new HttpClient();
        public ListDepartamentosImagenes()
        {
            //client.BaseAddress = new Uri("http://apirent-env.eba-n7bvnjak.us-east-1.elasticbeanstalk.com/");
            client.BaseAddress = new Uri("http://localhost:8080/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        private void CargarTabla_Click(object sender, RoutedEventArgs e)
        {
            CargarImagenData(new DeptoImagen());
        }
        
        private void CargarBtn_Click(object sender, RoutedEventArgs e)
        {
            SubirImagen();            
        }

        private void GuardarBtn_Click(object sender, RoutedEventArgs e)
        {
            GuardarDatos();
        }

        private async void CargarImagenData(DeptoImagen deptoImagen)
        {
            HttpResponseMessage response = client.GetAsync("deptoImagen/imagenList").Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var deptoList = JsonConvert.DeserializeObject<List<DeptoImagen>>(json);

                imagenListBox.ItemsSource = deptoList;
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }

        }

        OpenFileDialog showImagen = new OpenFileDialog();
        
        private void SubirImagen() 
        {
            showImagen.Multiselect = true;
            showImagen.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            
            if (showImagen.ShowDialog() == true)
            {
                foreach (string item in showImagen.SafeFileNames)
                {
                    uplListImagenes.Items.Add(item);
                }
            }   
        }    
        
        private void GuardarDatos()
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
            
            foreach (string item in showImagen.SafeFileNames)
            {
                MultipartFormDataContent imagen = new MultipartFormDataContent();

                string fileName = item;
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
                    imagen.Add(new StringContent(idDepartamentosTxt.Text), "idDepartamentos");
                    httpResponseMessage = client.PostAsync("deptoImagen/imagenesUpload", imagen).Result;
                }
                else
                {
                    MessageBox.Show("Ingresa una Imagen Valida.");
                }
            }

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show("Imagenes subidas correctamente");
            }
            else
            {
                MessageBox.Show("Error Code" + httpResponseMessage.StatusCode + " : Message - " + httpResponseMessage.ReasonPhrase);
            }
        }
    }
}
