using System;
using System.Collections.Generic;
using System.IO;
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


namespace Rename
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                FileNameTextBox.Text = dialog.SelectedPath;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                DirectoryInfo d = new DirectoryInfo(FileNameTextBox.Text);
                int i = 1;

                string exetension = "." + dateityp.Text;

                foreach (var file in d.GetFiles("*"+exetension))
                {
                    var intnummer = Convert.ToInt32(nummerbox.Text); 

                    Directory.Move(file.FullName, FileNameTextBox.Text +"\\" + veranschaltungsbox.Text  + (i-1+intnummer) + exetension);
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            MessageBox.Show("Done");
        }


    }
}
