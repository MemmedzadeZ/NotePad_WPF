using Microsoft.Win32;
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

namespace NotePad_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentFilePath = "";
        private bool autoSaveEnabled = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click_Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                currentFilePath = openFileDialog.FileName;
                TextBox.Text = File.ReadAllText(currentFilePath);
            }
        }

        private void Click_New(object sender, RoutedEventArgs e)
        {
            TextBox.Clear();
            currentFilePath = "";
        }

        private void Click_Save(object sender, RoutedEventArgs e)
        {
            if (currentFilePath == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                {
                    currentFilePath = saveFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }
            File.WriteAllText(currentFilePath, TextBox.Text);
        }

        private void Click_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Click_Cut(object sender, RoutedEventArgs e)
        {
            TextBox.Cut();
        }

        private void Click_Copy(object sender, RoutedEventArgs e)
        {
            TextBox.Copy();
        }

        private void Click_Paste(object sender, RoutedEventArgs e)
        {
            TextBox.Paste();
        }

        private void Click_SelectAll(object sender, RoutedEventArgs e)
        {
            TextBox.SelectAll();
        }
    }
}
