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

namespace InformePOO
{
    /// <summary>
    /// Lógica de interacción para Login2.xaml
    /// </summary>
    public partial class Login2 : Page
    {
        public Login2()
        {
            InitializeComponent();
        }

        List<string> UserName = new List<string>();




        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (txtUserName.Text == "")
                    throw new ApplicationException("Caja Vacia");


                string userName;
                userName = txtUserName.Text;
                UserName.Add(userName);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            foreach (string item in UserName)
            {

                if (txtUserName.Text == item)
                {
                    Welcome w = (Welcome)Window.GetWindow(this);
                    w.frameMain.NavigationService.Navigate(new Game());
                }
                else
                {
                    txtMessages.Text = ("-Could Not Find Player. Have You Registerd?");
                }
            }

        }
    }
}
