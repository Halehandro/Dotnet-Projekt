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
    /// Interaction logic for AddNews.xaml
    /// </summary>
    public partial class AddNews : Window
    {
        public AddNews()
        {
            InitializeComponent();
            Result = new List<News>();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            News newsPiece = new News();
            newsPiece.Headline = tb_headline.Text;
            newsPiece.Content = tb_content.Text;
            newsPiece.PublishTime = DateTime.Now;
            Result.Add(newsPiece);
            tb_headline.Text = "";
            tb_content.Text = "";
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public List<News> Result { get; set; }
    }
}
