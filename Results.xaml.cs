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
using System.Windows.Shapes;

namespace Blackjack
{
    /// <summary>
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : Window
    {
        private string[] results;

        public Results(string[] results)
        {
            this.results = results;
            InitializeComponent();
            DisplayResults();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            string path = sfd.FileName;

            File.WriteAllLines(path, results);
            // Read a file  
            string readText = File.ReadAllText(path);
        }

        private void DisplayResults()
        {
            for (int i = 0; i < results.Count(); i++)
            {
                lblList.Items.Add(results[i]);
            }
        }
    }
}
