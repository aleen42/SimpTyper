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
    /// LeftPart_ListBox.xaml 的交互逻辑
    /// </summary>
    public partial class LeftPart_ListBox : UserControl
    {
        public LeftPart_ListBox()
        {
            InitializeComponent();
            ListBox_Load();
        }

        private void ListBox_Load()
        {
            string suffix = "txt";
            System.IO.DirectoryInfo text_folder = new System.IO.DirectoryInfo(@"..\..\Txt\");
            System.IO.FileInfo[] text_file = text_folder.GetFiles("*." + suffix);                                           //获取后缀名为suffix的文件
            //遍历文件夹
            foreach (System.IO.FileInfo NextFile in text_file)
            {
                if (common.Filter_Name.Length > NextFile.Name.Substring(0, NextFile.Name.Length - (suffix.Length + 1)).Length)
                    continue;
                if (common.Filter_Name != "" && common.Filter_Name != NextFile.Name.Substring(0, common.Filter_Name.Length))
                    continue;
                ListBoxItem ListBox_addItem = new ListBoxItem();
                ListBox_addItem.Content = NextFile.Name.Substring(0, NextFile.Name.Length - (suffix.Length + 1));
                ListBox_addItem.Style = (Style)Resources["ListBoxItemStyle"];
                ListBox_addItem.Height = 30;
                ListBox_addItem.FontFamily = new FontFamily("Arial");
                ListBox_addItem.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(Item_Selected);
                //ListBox_addItem.PreviewMouseDown += new MouseButtonEventHandler(Item_Selected);
                LeftPartListBox.Items.Add(ListBox_addItem);
            }
        }

        private void Item_Selected(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(200);
            //ListBoxItem Current_Item = sender as ListBoxItem;
            //common.AddTitle_grid
            //MessageBox.Show("1");
            //BrushConverter conv = new BrushConverter();
            //Brush background_color = conv.ConvertFromInvariantString("#FFa10000") as Brush;
            //Current_Item.Background = background_color; 
            if (common.whether_addartical_open == true)
            {
                common.addtitile_grid.Visibility = Visibility.Collapsed;
                common.mainwindow.ResizeMode = ResizeMode.CanResizeWithGrip;
                common.whether_addartical_open = false;
            }
        }


        private void ListBox_MouseEnter(object sender, MouseEventArgs e)
        {
            LeftPartListBox.Style = (Style)Resources["ListBoxStyle1"];
        }

        private void LeftPartListBox_MouseLeave(object sender, MouseEventArgs e)
        {
            LeftPartListBox.Style = (Style)Resources["ListBoxStyle"];
        }

    }
}
