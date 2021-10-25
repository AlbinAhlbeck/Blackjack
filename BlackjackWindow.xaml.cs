using BlackjackBLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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
    public delegate void Hit(object sender, EventArgs e);
    public delegate void Stand(object sender, EventArgs e);
    /// <summary>
    /// Interaction logic for BlackjackWindow.xaml
    /// </summary>

    public partial class BlackjackWindow : Window
    {
        public event EventHandler Hit;
        public event EventHandler Stand;

        public BlackjackWindow()
        {                              
            InitializeComponent();          
        }    
       
        private void btnHit_Click(object sender, RoutedEventArgs e)
        {
            EventHandler handler = Hit;
            handler?.Invoke(this, e);
        }

        public void Fat()
        {
            MessageBox.Show("You got fat");
        }

        public void Turn(List<Uri> imagePaths, string name, int value)
        {
            playerCardPanel.Children.Clear(); // reset
            lblPlayer.Content = "It's " + name + "'s turn!";
            for (int i = 0; i < imagePaths.Count; i++)
            {
                try
                {
                    Debug.WriteLine(imagePaths[i]);
                    Image image = new Image();
                    image.Source = new BitmapImage(imagePaths[i]);
                    image.Width = 128;
                    image.Height = 256;
                    playerCardPanel.Children.Add(image);
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
           
            lblPlayerTotal.Content = value;
        }

        public void DealerPlay(List<Uri> imagePaths, int value)
        {
            dealerCardPanel.Children.Clear(); // reset
            for (int i = 0; i < imagePaths.Count; i++)
            {
                try
                {
                    Debug.WriteLine(imagePaths[i]);
                    Image image = new Image();
                    image.Source = new BitmapImage(imagePaths[i]);
                    image.Width = 128;
                    image.Height = 256;
                    dealerCardPanel.Children.Add(image);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
            lblDealerTotal.Content = value;
        }        

        private void btnStand_Click(object sender, RoutedEventArgs e)
        {
            EventHandler handler = Stand;
            handler?.Invoke(this, e);
        }

        public void Restart()
        {
           // MessageBox.Show("Game is restarted");
            playerCardPanel.Children.Clear();
            dealerCardPanel.Children.Clear();
            lblDealerTotal.Content = "";
            lblPlayerTotal.Content = "";
        }
    }
}
