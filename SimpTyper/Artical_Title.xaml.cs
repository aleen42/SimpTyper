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
    /// Artical_Title.xaml 的交互逻辑
    /// </summary>
    public partial class Artical_Title : UserControl
    {
        public Artical_Title()
        {
            InitializeComponent();
            artical_title.Content = common.mouseoverfile_Name;
            artical.Text = common.mouseoverfile_Text;
            time.Content = common.mouseoverfile_CreationTime;
            //artical_title.FontSize = 100 * 3 / common.mouseoverfile_Name.Length;
        }

    }
}
