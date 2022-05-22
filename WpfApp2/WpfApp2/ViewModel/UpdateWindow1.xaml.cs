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
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Navigation;

namespace WpfApp2
{
    /// <summary>
    /// Logika interakcji dla klasy UpdateWindow1.xaml
    /// </summary>
    public partial class UpdateWindow1 : Window
    {
        private PlaceModel _place = new PlaceModel();
        private string _photoPath;
        public UpdateWindow1(PlaceModel place)
        {
            InitializeComponent();
            _place = place;
            txtName.Text = _place.Name;
            txtCountry.Text = _place.Country;
            textDescription.Text = _place.Description;
            if(!string.IsNullOrEmpty(_place.PhotoName))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, _place.PhotoName));
                image.EndInit();
                imgPhoto.Source = image;
            }
            else
            {
                imgPhoto.Source = null;
            }
        }
          private void btnSave_Click (object sender, RoutedEventArgs e)
          {
              _place.Country = txtCountry.Text;
              _place.Description = textDescription.Text;
              if (!string.IsNullOrEmpty(_photoPath))
              {
                  _place.PhotoName = _place.Name + ".jpg";
                  string destFileName = System.IO.Path.Combine(Environment.CurrentDirectory, _place.PhotoName);
                  File.Copy(_photoPath, destFileName, true);
              }
              if (SQLLiteAccess.Update(_place))
              {
                  this.Close();
              }
              else
              {
                  MessageBox.Show("Wystąpił błąd", "Error", MessageBoxButton.OK);
              }
          }
      /*  private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            PlaceModel item = new PlaceModel();

            item.Name = txtName.Text;
            item.Country = textCountry.Text;
            item.Description = textDescription.Text;
            if (_photoPath != null)
            {
                item.PhotoName = item.Name + ".jpg";
                string destPhotoPath = System.IO.Path.Combine(Environment.CurrentDirectory, item.PhotoName);
                File.Copy(_photoPath, destPhotoPath, true);
            }
            if (SQLLiteAccess.Create(item))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Ale beka błąd!", "Error", MessageBoxButton.OK);
            }
        }*/


        private void btnLoadPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog()== true)
            {
                _photoPath = openFileDialog.FileName;
                Uri fileUri = new Uri(_photoPath);
                imgPhoto.Source = new BitmapImage(fileUri);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
       }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // for .NET Core you need to add UseShellExecute = true
            // see https://docs.microsoft.com/dotnet/api/system.diagnostics.processstartinfo.useshellexecute#property-value

            //  System.Diagnostics.Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            //  e.Handled = true;

            var parameter = new ProcessStartInfo { Verb = "open", FileName = "explorer", Arguments = "https://www.kwestiasmaku.com/" };
            Process.Start(parameter);
        }
    }
}
