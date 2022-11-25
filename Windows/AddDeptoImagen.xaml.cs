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
    public partial class AddDeptoImagen : Page
    {
        HttpClient client = new HttpClient();

        OpenFileDialog showImagen = new OpenFileDialog();
        
        public AddDeptoImagen()
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
        
        private void deptoListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectIdDepto();
        }
        private void uplListImagenes_SelectionChanged(object sender, RoutedEventArgs e)
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
        private void SelectIdDepto()
        {
            var idListBox = deptoListBox.SelectedIndex + 1;
            foreach (Departamentos item in deptoListBox.Items)
            {
                
                if (idListBox.ToString() == item.idDepartamentos.ToString())
                {
                    idDeptoTxt.Text = item.idDepartamentos.ToString();
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
        public void GetDepartamentos()
        {
            var response = client.GetAsync("departamentos/departamentos").Result;
            var departamentos = response.Content.ReadAsAsync<List<Departamentos>>().Result;

            foreach (var departamento in departamentos)
            {
                deptoListBox.Items.Add(departamento);
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
                    imagen.Add(new StringContent(idDeptoTxt.Text), "idDepartamentos");
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
                uplListImagenes.Items.Clear();
            }
            else
            {
                MessageBox.Show("Error Code" + httpResponseMessage.StatusCode + " : Message - " + httpResponseMessage.ReasonPhrase);
            }
        }

        
    }
}
