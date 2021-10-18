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
    public delegate string PlayerTurn(string s);
    public partial class BlackjackWindow : Window
    {
        public BlackjackWindow()
        {
                                  
            InitializeComponent();
            /*
            Uri uri = null;
            try
            {
                uri = gameManager.deck.DealCard().ImagePath;
            }
            catch(Exception e)
            {
                Debug.WriteLine("error in uri " + e);
            }
            pt("test");
            imgDeck.Source = new BitmapImage(uri);
            */

        }       

        private void btnHit_Click(object sender, RoutedEventArgs e)
        {

        }
        public string Turn(string s)
        {
            return s;
        }

        public void DealerPlay(Uri imagePath, int value)
        {
            Image image = new Image();
            image.Source = new BitmapImage(imagePath);
            image.Width = 128;
            image.Height = 256;
            wrapPanel.Children.Add(image);
            lblDealerTotal.Content = value;
            
        }
      

    }
}
