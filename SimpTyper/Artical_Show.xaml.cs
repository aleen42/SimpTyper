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

namespace SimpTyper
{
    /// <summary>
    /// Artical_Show.xaml 的交互逻辑
    /// </summary>
    public partial class Artical_Show : UserControl
    {
        public Artical_Show()
        {
            InitializeComponent();
            artical_title.Content = common.selectedfile_Name;
            TextBlock artical = new TextBlock();
            artical.Text = common.selectedfile_Text;
            artical.TextWrapping = TextWrapping.Wrap;
            artical.FontSize = 20;
            artical.Foreground = new SolidColorBrush(Color.FromArgb(0xff, 0x5b, 0x5b, 0x5b));
            artical.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(artical_PreviewMouseLeftButonDown);
            sv.Content = artical;
            common.time_Label.Content = common.selectedfile_CreationTime;
            common.count_Label.Content = common.selectedfile_text_count;
        }

        private void artical_title_MouseDown(object sender, MouseButtonEventArgs e)
        {
            common.menu_grid_clear();
        }

        private void artical_PreviewMouseLeftButonDown(object sender, MouseButtonEventArgs e)
        {
            common.menu_grid_clear();
            common.addtitle_grid_clear();
        }



    }
}
