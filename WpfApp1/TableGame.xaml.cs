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
using System.Windows.Navigation;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для TableGame.xaml
    /// </summary>
    public partial class TableGame : Window
    {
        OnlinePСGamesEntities context;
        string currentLetter = "";
        public TableGame()
        {
            InitializeComponent();
            ShowLetters();
            context = new OnlinePСGamesEntities();
            CmbCreator.ItemsSource = context.Creators.ToList();
            ShowTable();
        }
        public void ShowTable()
        {
            if (CmbCreator.SelectedItem == null )
                return;
            Creator currentCreator = (Creator)CmbCreator.SelectedItem;
            string searchText = TxtNameGame.Text;
            List<Game> listPlayers = context.Games.ToList();
            listPlayers = listPlayers.Where(x => x.Creator == currentCreator).ToList();
            if (currentLetter.Count() == 1)
            {
                listPlayers = listPlayers.Where(x => x.Наименование.Contains(currentLetter)).ToList();
            }
            DataGames.ItemsSource = listPlayers.OrderBy(x => x.Наименование).ToList();
            DataGames.ItemsSource = context.Games.ToList();
        }
        public void ShowLetters()
        {
            for (char i = 'A'; i <= 'Z'; i++)
            {
                TextBlock letter = new TextBlock
                {
                    Text = i.ToString(),
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.White,
                    Margin = new Thickness(10,20,0,0)
                };
                letter.MouseLeftButtonDown += TextBlock_MouseLeftButtonDown;
                StackLetters.Children.Add(letter);
            }
        }


        private void CmbCreator_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnAddGame_Click(object sender, RoutedEventArgs e)
        {
            var f1 = new Game();
            context.Games.Add(f1);
            var f2 = new TableAddGame(context, f1);
            f2.ShowDialog();
            ShowTable();
        }

        private void BtnDiliteGame_Click(object sender, RoutedEventArgs e)
        {
            var f1 = DataGames.SelectedItem as Game;
            context.Games.Remove(f1);
            context.SaveChanges();
            ShowTable();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button f1 = sender as Button;
            var f2 = f1.DataContext as Game;
            var f3 = new TableAddGame(context, f2);
            f3.ShowDialog();
            ShowTable();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var label = (TextBlock)sender;
            currentLetter = label.Text;
            foreach (TextBlock letter in StackLetters.Children)
            {
                letter.Foreground = Brushes.White;
            }
            label.Foreground = Brushes.Gold;
            ShowTable();
        }
        private void CmbBublisher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
