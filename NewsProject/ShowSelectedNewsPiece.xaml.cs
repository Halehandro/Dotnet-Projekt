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
    /// Interaction logic for ShowSelectedNewsPiece.xaml
    /// </summary>
    public partial class ShowSelectedNewsPiece : Window
    {
        public ShowSelectedNewsPiece(News newsPiece)
        {
            InitializeComponent();
            lb_headline.FontWeight = FontWeights.ExtraBold;
            lb_headline.FontSize = 30;
            lb_headline.Content = newsPiece.Headline;
            tb_content.Text = newsPiece.Content;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
