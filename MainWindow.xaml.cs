using BlackjackBLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Blackjack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private GameManager gameManager;
        public MainWindow()
        {
            InitializeComponent();
            
            
        }

        private void btnStartgame_Click(object sender, EventArgs e)
        {
            gameManager = new GameManager();
            // add conditions
            this.Hide();
        }

        public delegate void TestDelegate(object sender, EventArgs args);
    }


}
