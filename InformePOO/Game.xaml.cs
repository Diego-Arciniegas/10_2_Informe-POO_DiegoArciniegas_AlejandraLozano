using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library;

namespace InformePOO
{
    /// <summary>
    /// Lógica de interacción para Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        Player player = new Player();
        Dealer dealer = new Dealer();

        public Game()
        {
            InitializeComponent();
        }



        public int Check(List<Card> hand)
        {
            int value = 0;
            foreach (Card c in hand)
            {
                if (value + c.Score > 21 && c.Score == 11)
                {
                    value += 1;
                }
                else
                {
                    value += c.Score;
                }
            }
            return value;
        }

        private void btnHit_Click(object sender, RoutedEventArgs e)
        {
            if (player.Hand == null || player.Hand.Count == 0)
            {
                dealer.Generade();
                dealer.Randomize();
                dealer.Init();

                Card c1 = dealer.Deal();
                Card c2 = dealer.Deal();

                player.Init(c1, c2);

                RefreshPlayerCards();
            }
            else
            {
                Card c = dealer.Deal();
                player.AddCard(c);
                RefreshPlayerCards();
            }
            int handValue = Check(player.Hand);
            lblPlayerScore.Content = handValue;

            if (handValue >= 22)
            {
                btnHit.IsEnabled = false;
                btnStand.IsEnabled = false;
                MessageBox.Show("Dealer Win");
            }


        }
        private void btnStand_Click(object sender, RoutedEventArgs e)
        {


            txtDealer.Text = "";

            foreach (Card c in dealer.Hand)
            {
                txtDealer.Text += c.Symbol + c.Suit + "\n";
            }

            while (Check(dealer.Hand) < Check(player.Hand))
            {
                Card c = dealer.Deal();
                dealer.AddCard(c);

                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    txtDealer.Text += c.Symbol + c.Suit + "\n";
                    lblDealerScore.Content = Check(dealer.Hand);


                });

            }
            int DealerValue = Check(dealer.Hand);
            lblDealerScore.Content = DealerValue;

            int handValue = Check(player.Hand);
            lblPlayerScore.Content = handValue;

            if (DealerValue >= 22)
            {
                btnHit.IsEnabled = false;
                btnStand.IsEnabled = false;
                MessageBox.Show("Player Win");

            }

            if (handValue > DealerValue && handValue <= 21)
            {
                btnHit.IsEnabled = false;
                btnStand.IsEnabled = false;
                MessageBox.Show("Player Win");

            }
            else
            {
                if (handValue == DealerValue)
                {
                    btnHit.IsEnabled = false;
                    btnStand.IsEnabled = false;
                    MessageBox.Show("Tie");
                }
                else
                {
                    btnHit.IsEnabled = false;
                    btnStand.IsEnabled = false;
                    MessageBox.Show("Dealer Win");
                }

            }




        }

        private string GetText()
        {

            return txtDealer.Text;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {

            txtDealer.Text = "";
            txtPlayer.Text = "";
            lblDealerScore.Content = "";
            lblPlayerScore.Content = "";
            btnHit.IsEnabled = true;
            btnStand.IsEnabled = true;


            Welcome w = (Welcome)Window.GetWindow(this);
            w.frameMain.NavigationService.Navigate(new Login());

        }

        private void RefreshPlayerCards()
        {
            txtPlayer.Text = "";

            foreach (Card c in player.Hand)
            {
                txtPlayer.Text += c.Symbol + c.Suit + "\n";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Welcome w = (Welcome)Window.GetWindow(this);
            w.frameMain.NavigationService.Navigate(new Login2());
        }
    }
}
