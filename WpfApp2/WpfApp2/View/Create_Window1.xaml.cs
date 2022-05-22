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
using Microsoft.Win32;
using System.IO;

namespace WpfApp2
{
    /// <summary>
    /// Logika interakcji dla klasy Create_Window1.xaml
    /// </summary>
    public partial class Create_Window1 : Window
    {



        private string _photoPath;
        public Create_Window1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            PlaceModel item = new PlaceModel();

            item.Name = txtName.Text;
            item.Country = txtCountry.Text;
            item.Description = txtDescription.Text;
            if (_photoPath !=null)
            {
                item.PhotoName = item.Name + ".jpg";
                string destPhotoPath = System.IO.Path.Combine(Environment.CurrentDirectory, item.PhotoName);
                File.Copy(_photoPath, destPhotoPath, true);
            }
            if(SQLLiteAccess.Create(item))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Błąd!", "Error", MessageBoxButton.OK);
            }
        }
       // private void btnClose_Click(object sender, RoutedEventArgs e)
      //  {
      //      this.Close();
       // }

        private void btnUploadPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Image files (*.jpg, *jpeg, *.jpe, *,jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                _photoPath = openFileDialog.FileName;
                Uri uri = new Uri(_photoPath);
                imgPhoto.Source = new BitmapImage(uri);
            }
        }
            private void btnClose_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }
        
    }
}
