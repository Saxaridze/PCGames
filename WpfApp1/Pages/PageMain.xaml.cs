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
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public PageMain()
        {
            InitializeComponent();
            OnlinePСGamesEntities context = new OnlinePСGamesEntities();
            ListViewPictures.ItemsSource = context.Games.ToList();
        }

        private void BtnVisior_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данная функция находится в разработке");
        }

        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            var f1 = new Login();
            f1.ShowDialog();
        }
    }
}
