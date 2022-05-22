using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (File.Exists(SQLLiteAccess.dbFilePath)== false)
            {
                if(SQLLiteAccess.CreateTablePlaces())
                {
                    MessageBox.Show("Utworzono tabelę", "Info", MessageBoxButton.OK);
                }

            }
        }
    }
}
