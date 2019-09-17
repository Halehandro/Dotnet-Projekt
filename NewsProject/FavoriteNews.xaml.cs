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

namespace NewsProject
{
    /// <summary>
    /// Interaction logic for FavoriteNews.xaml
    /// </summary>
    public partial class FavoriteNews : Window
    {
        public FavoriteNews(List<Favorites> news)
        {
            InitializeComponent();
            foreach (Favorites newsPiece in news)
                lb_favorites.Items.Add(newsPiece);

            Result = new List<Favorites>();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Result.Clear();
            Close();
        }

        public List<Favorites> Result { get; set; }

        private void ButtonUnfavorite_Click(object sender, RoutedEventArgs e)
        {
            Result.Add((Favorites)lb_favorites.SelectedItem);
            lb_favorites.Items.Remove(lb_favorites.SelectedItem);
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Lb_favorites_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ShowSelectedNewsPiece newsPiece = new ShowSelectedNewsPiece(((Favorites)lb_favorites.SelectedItem).News);
            newsPiece.ShowDialog();
        }
    }
}
