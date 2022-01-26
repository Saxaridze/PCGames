using System;
using System.Collections.Generic;
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
using WpfApp1.Pages;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public string login = "1";
        public string pasword = "1";
        public Login()
        {
            InitializeComponent();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFraim.Navigate(new PageMain());
        }

        private void BtnVhod_Click(object sender, RoutedEventArgs e)
        {
            if (TxtLogin.Text == login && TxtPasword.Text == pasword)
            {
                MessageBox.Show("Добро пожаловать");
                Manager.MainFraim.Navigate(new PageAdminMenu());
                this.Close();
            }
        }
    }
}
