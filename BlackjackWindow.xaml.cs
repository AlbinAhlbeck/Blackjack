using BlackjackBLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for BlackjackWindow.xaml
    /// </summary>

    public partial class BlackjackWindow : Window
    {
        bool hit = false;
        bool stand = false;
        public BlackjackWindow()
        {                              
            InitializeComponent();
           
        }       

        private void btnHit_Click(object sender, RoutedEventArgs e)
        {
            hit = true;
        }

        public void Turn(List<Uri> imagePaths)
        {
            playerCardPanel.Children.Clear(); // reset
            for (int i = 0; i < imagePaths.Count; i++)
            {
                Image image = new Image();
                image.Source = new BitmapImage(imagePaths[i]);
                image.Width = 128;
                image.Height = 256;
                playerCardPanel.Children.Add(image);
            }
           
            //lblPlayerTotal.Content = value;
        }

        public void DealerPlay(Uri imagePath, int value)
        {
            Image image = new Image();
            image.Source = new BitmapImage(imagePath);
            image.Width = 128;
            image.Height = 256;
            dealerCardPanel.Children.Add(image);
            lblDealerTotal.Content = value;
            
        }

        public bool HitOrStand()
        {
            MessageBoxResult mbs = MessageBox.Show("Hit?", "Blackjack", MessageBoxButton.YesNo);
            switch (mbs)
            {
                case MessageBoxResult.Yes:
                    return true;
                    break;
                case MessageBoxResult.No:
                    return false;
                    break;
            }
            return false;
        }
      

    }
}
