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
            artical.Text = common.selectedfile_Text;
            time.Content = common.selectedfile_CreationTime;
        }
    }
}
