using System;
using System.Collections;
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
    public class native_common
    {
        public static Hashtable shortname_longname_Hashtable = new Hashtable();
    }
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
                ListBox_addItem.Content = Convert(NextFile.Name.Substring(0, NextFile.Name.Length - (suffix.Length + 1)), ListBox_addItem.GetType(), 8);
                native_common.shortname_longname_Hashtable.Add(ListBox_addItem.Content, NextFile.Name.Substring(0, NextFile.Name.Length - (suffix.Length + 1)));   //保存省略前和省略后名字的关系
                ListBox_addItem.Content = ConvertBack(ListBox_addItem.Content);
                ListBox_addItem.Style = (Style)Resources["ListBoxItemStyle_withstaticlogo"];
                ListBox_addItem.Height = 30;
                ListBox_addItem.FontFamily = new FontFamily("Microsoft JhengHei UI");
                ListBox_addItem.FontSize = 13;
                ListBox_addItem.GotFocus += new RoutedEventHandler(ListBoxItem_GotFocus);
                ListBox_addItem.LostFocus += new RoutedEventHandler(ListBoxItem_LostFocus);
                ListBox_addItem.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(Item_Selected);
                ListBox_addItem.PreviewMouseRightButtonDown += new MouseButtonEventHandler(ListBoxItem_PreviewMouseRightButtonDown);
                //ListBox_addItem.PreviewMouseDown += new MouseButtonEventHandler(Item_Selected);
                LeftPartListBox.Items.Add(ListBox_addItem);
            }
        }

        private object Convert(object value, Type targetType, object parameter)
        {
            string s = value.ToString();
            int leng;
            if (int.TryParse(parameter.ToString(), out leng))
            {
                if (s.Length <= leng)
                    return s;
                else
                    return s.Substring(0, leng) + "...";
            }
            else
                return string.Empty;
        }

        private object ConvertBack(object value)
        {
            return native_common.shortname_longname_Hashtable[value.ToString()];
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
            if (common.menu_grid.Children != null)
            {
                common.menu_grid.Children.Clear();
            }
        }

        private void ListBoxItem_GotFocus(object sender, RoutedEventArgs e)
        {
            ListBoxItem current = sender as ListBoxItem;
            current.Foreground = new SolidColorBrush(Colors.White);
            current.Style = (Style)Resources["ListBoxItemStyle_withpressedlogo"];
        }

        private void ListBoxItem_LostFocus(object sender, RoutedEventArgs e)
        {
            ListBoxItem current = sender as ListBoxItem;
            current.Foreground = new SolidColorBrush(Colors.Black);
            current.Style = (Style)Resources["ListBoxItemStyle_withstaticlogo"];
        }

        private void ListBoxItem_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (common.whether_addartical_open == true)
            {
                common.addtitile_grid.Visibility = Visibility.Collapsed;
                common.whether_addartical_open = false;
            }

            ListBoxItem current = sender as ListBoxItem;
            common.selectedfile_Name = @"..\..\Txt\" + current.Content.ToString() + ".txt";
            //MessageBox.Show(current.Content.ToString());

            UserControl menu = new RightButtonMenu();
            if(common.menu_grid.Children!=null)
            {
                common.menu_grid.Children.Clear();
            }
            Point p = Mouse.GetPosition(this);
            common.menu_grid.Margin = new Thickness(p.X + 4, p.Y + common.leftpart_grid.Margin.Top + common.listbox_grid.Margin.Top - 4, 0, 0);
            common.menu_grid.Children.Add(menu);


        }


    }


}
