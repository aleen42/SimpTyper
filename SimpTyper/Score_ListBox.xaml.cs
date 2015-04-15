using System;
using System.Collections.Generic;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpTyper
{
    /// <summary>
    /// Score_ListBox.xaml 的交互逻辑
    /// </summary>
    public partial class Score_ListBox : UserControl
    {
        int begin_time_second = 0;

        public Score_ListBox()
        {
            InitializeComponent();
            ListBox_Load();
        }

        //private void AddContextMenu(object sender)
        //{
        //    ListBoxItem current = sender as ListBoxItem;
        //    ContextMenu contextmenu = new ContextMenu();
        //    MenuItem view_on_editor=new MenuItem();
        //    view_on_editor.Header="View On Editor";
        //    contextmenu.Items.Add(view_on_editor);
        //    current.ContextMenu = contextmenu;
        //}

        private void ListBox_Load()
        {
            string suffix = "spr";
            string private_key = "";
            System.IO.DirectoryInfo text_folder = new System.IO.DirectoryInfo(@"..\..\Data\");
            System.IO.FileInfo[] text_file = text_folder.GetFiles("*." + suffix);                                           //获取后缀名为suffix的文件
            //遍历文件夹
            
            foreach (System.IO.FileInfo NextFile in text_file)
            {
                if (NextFile.Name.Substring(0, common.ASCII_code(common.selectedfile_Name).Length) != common.ASCII_code(common.selectedfile_Name))
                    continue;
                ListBoxItem ListBox_addItem = new ListBoxItem();
                FileStream readfile = new FileStream(NextFile.FullName, FileMode.Open, FileAccess.Read);
                StreamReader text_reader = new StreamReader(readfile, Encoding.GetEncoding("gb2312"));
                text_reader.BaseStream.Seek(0, SeekOrigin.Begin);

                string[] line = new string[4];
                for (int i = 0; i < 4;i++ )
                {
                    line[i] = text_reader.ReadLine();
                }
                private_key = common.Decode(line[3]);

                ListBox_addItem.Content = common.RSADecrypt(private_key, line[1]) + "WPM";
                //ListBox_addItem.Content = ConvertBack(ListBox_addItem.Content);
                ListBox_addItem.Style = (Style)Resources["ListBoxItemStyle_withstaticlogo"];    
                ListBox_addItem.Height = 36;
                ListBox_addItem.FontFamily = new FontFamily("Microsoft JhengHei UI");
                ListBox_addItem.FontSize = 13;
                ListBox_addItem.Margin = new Thickness(0, 0, 0, 3);
                //ListBox_addItem.Background = new SolidColorBrush(Colors.White);
                ListBox_addItem.MouseEnter += new MouseEventHandler(ListBoxItem_MouseEnter);
                ListBox_addItem.MouseLeave += new MouseEventHandler(ListBoxItem_MouseLeave);
                ListBox_addItem.GotFocus += new RoutedEventHandler(ListBoxItem_GotFocus);
                ListBox_addItem.LostFocus += new RoutedEventHandler(ListBoxItem_LostFocus);
                ListBox_addItem.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(Item_Selected);
                ListBox_addItem.PreviewMouseRightButtonDown += new MouseButtonEventHandler(ListBoxItem_PreviewMouseRightButtonDown);
                //ListBox_addItem.PreviewMouseDown += new MouseButtonEventHandler(Item_Selected);
                LeftPartListBox.Items.Add(ListBox_addItem);

                Storyboard show = new Storyboard();
                show = this.Resources["text_bg_load"] as Storyboard;
                Storyboard.SetTarget(show, ListBox_addItem);
                TimeSpan begin_time = new TimeSpan(0, 0, 0, 0, begin_time_second);
                begin_time_second += 30;
                show.BeginTime = begin_time;
                show.Begin();
            }
        }


        private void Item_Selected(object sender, EventArgs e)
        {

        }

        private void ListBoxItem_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void ListBoxItem_LostFocus(object sender, RoutedEventArgs e)
        {
             
        }

        private void ListBoxItem_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void ListBoxItem_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void ListBoxItem_MouseLeave(object sender, MouseEventArgs e)
        {
           
        }
    }
}
