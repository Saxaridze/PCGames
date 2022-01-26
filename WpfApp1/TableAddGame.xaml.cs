using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для TableAddGame.xaml
    /// </summary>
    public partial class TableAddGame : Window
    {
        OnlinePСGamesEntities context;
        public TableAddGame(OnlinePСGamesEntities context1, Game game)
        {
            InitializeComponent();
            this.context = context1;
            CmbBublisher.ItemsSource = context.Bublishers.ToList();
            CmbCreator.ItemsSource = context.Creators.ToList();
            this.DataContext = game;
        }
        public void SaveImg()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files: *.jpg, *.png| *.jpg;*.png";
            openFile.ShowDialog();
            if (openFile.FileName.Length != 0)
            {
                string nameFile = openFile.FileName;
                byte[] image = File.ReadAllBytes(nameFile);
                var games = (Game)this.DataContext;
                games.Фото = image;
                ImgPhoto.Source = new BitmapImage(new Uri(nameFile));
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveImg();
            context.SaveChanges();
            this.Close();
        }
    }
}
