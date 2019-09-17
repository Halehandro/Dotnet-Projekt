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

namespace NewsProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NewsDBEntities newsDatabase;
        public MainWindow()
        {
            InitializeComponent();
            newsDatabase = new NewsDBEntities();
            List<News> AllNews = GetAllNews();
            foreach (News newsPiece in AllNews)
                lb_news.Items.Add(newsPiece);
        }

        private List<News> GetAllNews()
        {
            var AllNews = from News in newsDatabase.News
                          select News;
            return AllNews.ToList<News>();
        }

        private void AddMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddNews addNews = new AddNews();
            addNews.ShowDialog();

            foreach (News news in addNews.Result)
            {
                newsDatabase.News.Add(news);
                lb_news.Items.Add(news);
            }
            newsDatabase.SaveChanges();
        }

        private void RemoveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RemoveNews removeNews = new RemoveNews(GetAllNews());
            removeNews.ShowDialog();

            foreach (News news in removeNews.Result)
            {
                newsDatabase.News.Remove(news);
                lb_news.Items.Remove(news);
            }
            newsDatabase.SaveChanges();
        }

        private void FavoritesAddMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (lb_news.SelectedItem != null)
            {
                News selectedItem = (News)lb_news.SelectedItem;
                if (IsItemInFavorites(selectedItem))
                {
                    MessageBox.Show("Already in favorites");
                    return;
                }
                Favorites newFavoriteItem = new Favorites();
                newFavoriteItem.News = selectedItem;
                newsDatabase.Favorites.Add(newFavoriteItem);
                newsDatabase.SaveChanges();
            }
        }

        private bool IsItemInFavorites(News news)
        {
            var fav = from Favorites in newsDatabase.Favorites
                      where Favorites.NewsPieceId == news.Id
                      select Favorites;
            if (fav.ToList().Count != 0)
                return true;
            return false;
        }

        private void FavoritesAllMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var AllFavoriteNews = from Favorites in newsDatabase.Favorites
                                  select Favorites;
            FavoriteNews favoriteNews = new FavoriteNews(AllFavoriteNews.ToList());
            favoriteNews.ShowDialog();

            foreach (Favorites news in favoriteNews.Result)
                newsDatabase.Favorites.Remove(news);
            newsDatabase.SaveChanges();
        }

        private void Lb_news_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ShowSelectedNewsPiece newsPiece = new ShowSelectedNewsPiece((News)lb_news.SelectedItem);
            newsPiece.ShowDialog();
        }
    }
}
