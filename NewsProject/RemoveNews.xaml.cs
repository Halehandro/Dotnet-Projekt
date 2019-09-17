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
    /// Interaction logic for RemoveNews.xaml
    /// </summary>
    public partial class RemoveNews : Window
    {
        public RemoveNews(List<News> news)
        {
            InitializeComponent();
            foreach (News newsPiece in news)
                lb_newsList.Items.Add(newsPiece);

            Result = new List<News>();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Result.Clear();
            Close();
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            Result.Add((News)lb_newsList.SelectedItem);
            lb_newsList.Items.Remove(lb_newsList.SelectedItem);
        }

        public List<News> Result { get; set; }
    }
}
