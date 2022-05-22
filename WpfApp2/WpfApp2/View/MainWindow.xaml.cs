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
using System.IO;




namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      

        List<PlaceModel> placeList = new List<PlaceModel>();
        public MainWindow()
        {
            InitializeComponent();

           /* ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("C://food.png", UriKind.Absolute));
            this.Background = myBrush; */

            //  new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Zdjęcia/food.png")));
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Create_Window1 createwindow1 = new Create_Window1();
           // this.Hide();
            createwindow1.ShowDialog();
            // this.Show();
            cmbListView.SelectedIndex = -1;
            
        }
      //  private void btn;
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (cmbListView.SelectedItem != null)
            {
                UpdateWindow1 updateWindow1 = new UpdateWindow1(placeList[cmbListView.SelectedIndex]);
                updateWindow1.ShowDialog();
                cmbListView.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Wybierz wpis do aktualizacji", "Error", MessageBoxButton.OK);

            }
            
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbListView_DropDownOpened(object sender, EventArgs e)
        {
            placeList = SQLLiteAccess.Read();
           cmbListView.ItemsSource = placeList.Select(n => n.Name);
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (cmbListView.SelectedItem != null)
            {
                if (MessageBox.Show("Czy jesteś pewien?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (SQLLiteAccess.Delete(placeList[cmbListView.SelectedIndex]))
                    {
                        if (placeList[cmbListView.SelectedIndex].PhotoName != string.Empty)
                     {
                            string destPhotoPath = System.IO.Path.Combine(Environment.CurrentDirectory, placeList[cmbListView.SelectedIndex].PhotoName);
                            File.Delete(destPhotoPath);
                        }
                        cmbListView.SelectedIndex--;
                    }
                    else
                    {
                        MessageBox.Show("Wystąpił błąd", "Error", MessageBoxButton.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("Wybierz wpis do usunięcia", "Warning", MessageBoxButton.OK);
            }
        }

          private void cmbListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {
              if (cmbListView.SelectedIndex != -1)
              {
                  txtName.Text = placeList[cmbListView.SelectedIndex].Name;
                  txtCountry.Text = placeList[cmbListView.SelectedIndex].Country;
                  txtDescription.Text = placeList[cmbListView.SelectedIndex].Description;
                  if (placeList[cmbListView.SelectedIndex].PhotoName != string.Empty)
                  {

                      string _photoPath = System.IO.Path.Combine(Environment.CurrentDirectory, placeList[cmbListView.SelectedIndex].PhotoName);
                      BitmapImage image = new BitmapImage();
                      image.BeginInit();
                      image.CacheOption = BitmapCacheOption.OnLoad;
                      image.UriSource = new Uri(_photoPath);
                      image.EndInit();
                      imgPhoto.Source = image;
                      // Uri fileUri = new Uri(_photoPath);
                      //  imgPhoto.Source = new BitmapImage(fileUri);
                  }
                  else
                  {
                      imgPhoto.Source = null;
                  }
              } 
          }
          public void RefreshListView()
          {
              placeList = SQLLiteAccess.Read();
              cmbListView.ItemsSource = placeList.Select(n => n.Name);
          }

          
    }
}
