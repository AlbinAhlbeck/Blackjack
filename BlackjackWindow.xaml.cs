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
        private GameManager gameManager;
        public BlackjackWindow(GameManager gameManager)
        {
            InitializeComponent();
            this.gameManager = gameManager;
            //imgDeck.Source = new BitmapImage(new Uri("D:\\GitHub\\Blackjack\\Blackjack\\Resources\\10_of_clubs.png"));
            //imgDeck.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\ace_of_hearts.png", UriKind.Absolute));
            //Debug.WriteLine(gameManager.deck.DealCard().ImagePath.ToString());
            Uri uri = null;
            try
            {
                uri = gameManager.deck.DealCard().ImagePath;
            }
            catch(Exception e)
            {
                Debug.WriteLine("error in uri " + e);
            }
           
            imgDeck.Source = new BitmapImage(uri);

        }

        private void btnHit_Click(object sender, RoutedEventArgs e)
        {

        }

      

    }
}
