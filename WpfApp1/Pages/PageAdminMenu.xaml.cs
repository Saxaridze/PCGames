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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAdminMenu.xaml
    /// </summary>
    public partial class PageAdminMenu : Page
    {
        public PageAdminMenu()
        {
            InitializeComponent();
        }

        private void BtnClients_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnGames_Click(object sender, RoutedEventArgs e)
        {
            var f1 = new TableGame();
            f1.ShowDialog();
        }

        private void BtnListOfGenre_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEmployee_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
