using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpTyper
{
    /// <summary>
    /// RightButtonMenu.xaml 的交互逻辑
    /// </summary>
    public partial class RightButtonMenu : UserControl
    {
        public RightButtonMenu()
        {
            InitializeComponent();
        }

        private void Edit_on_Notepad_MouseEnter(object sender, MouseEventArgs e)
        {
            Edit_on_Notepad.Foreground = new SolidColorBrush(Colors.White);
            Edit_on_Notepad.Style = (Style)Resources["ListBoxItemStyle_withtxtpressedlogo"];
        }

        private void Edit_on_Notepad_MouseLeave(object sender, MouseEventArgs e)
        {
            Edit_on_Notepad.Foreground = new SolidColorBrush(Colors.Black);
            Edit_on_Notepad.Style = (Style)Resources["ListBoxItemStyle_withtxtstaticlogo"];
        }

        private void Remove_It_MouseEnter(object sender, MouseEventArgs e)
        {
            Remove_It.Foreground = new SolidColorBrush(Colors.White);
            Remove_It.Style = (Style)Resources["ListBoxItemStyle_withdeletepressedlogo"];
        }

        private void Remove_It_MouseLeave(object sender, MouseEventArgs e)
        {
            Remove_It.Foreground = new SolidColorBrush(Colors.Black);
            Remove_It.Style = (Style)Resources["ListBoxItemStyle_withdeletestaticlogo"];
        }

        private void Remove_It_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (common.menu_grid.Children != null)
            {
                common.menu_grid.Children.Clear();
            }
            File.Delete(common.selectedfile_Name);
            common.selectedfile_Name = "";
            //更新左側listbox
            common.Filter_Name = common.filterarticals_TextBox.Text;
            common.listbox_grid.Children.Clear();
            common.listbox_grid.Children.Add(new LeftPart_ListBox());
            //MessageBox.Show(common.selectedfile_Name);
        }

        private void Edit_on_Notepad_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            //MessageBox.Show(common.selectedfile_Name);
            //File.OpenText(common.selectedfile_Name);
            Process.Start(common.selectedfile_Name);
            if (common.menu_grid.Children != null)
            {
                common.menu_grid.Children.Clear();
            }
            //File.Open(common.selectedfile_Name, FileMode.Open, FileAccess.ReadWrite);
        }
    }
}
