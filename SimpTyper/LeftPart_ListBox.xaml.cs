using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

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
                ListBox_addItem.Content = Convert(NextFile.Name.Substring(0, NextFile.Name.Length - (suffix.Length + 1)), ListBox_addItem.GetType(), 20);
                if (native_common.shortname_longname_Hashtable.Contains(ListBox_addItem.Content) == false)
                    native_common.shortname_longname_Hashtable.Add(ListBox_addItem.Content, NextFile.Name.Substring(0, NextFile.Name.Length - (suffix.Length + 1)));   //保存省略前和省略后名字的关系

                //ListBox_addItem.Content = ConvertBack(ListBox_addItem.Content);
                ListBox_addItem.Style = (Style)Resources["ListBoxItemStyle_withstaticlogo"];
                ListBox_addItem.Height = 30;
                ListBox_addItem.FontFamily = new FontFamily("Microsoft JhengHei UI");
                ListBox_addItem.FontSize = 13;
                //ListBox_addItem.Background = new SolidColorBrush(Colors.White);
                ListBox_addItem.MouseEnter += new MouseEventHandler(ListBoxItem_MouseEnter);
                ListBox_addItem.MouseLeave += new MouseEventHandler(ListBoxItem_MouseLeave);
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
                common.addtitile_grid.Children.Clear();
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
            common.selectedfile_Name = ConvertBack(current.Content.ToString()).ToString();
            //common.metro_loading.Visibility = Visibility.Visible;
            //MessageBox.Show("start");
            FileStream selectedfile = new FileStream(@"..\..\Txt\" + common.selectedfile_Name + ".txt", FileMode.Open, FileAccess.Read);
            StreamReader text_reader = new StreamReader(selectedfile, Encoding.GetEncoding("gb2312"));      //gb2312coding编码读入中文
            // 把文件指针重新定位到文件的开始
            text_reader.BaseStream.Seek(0, SeekOrigin.Begin);  //0代表开头
            //StreamReader.BaseStream.Seek(offset,origin);
            //SeekOrigin.Begin:表示流的开头
            string s = "";
            common.selectedfile_Text = "";
            common.selectedfile_Text += "\r\n\r\n\r\n";
            common.selectedfile_text_count = 0;
            while ((s = text_reader.ReadLine()) != null)
            {
                common.selectedfile_text_count += s.Length + 1;
                if (s.Substring(0, 0) != " ")
                    common.selectedfile_Text += "        ";
                common.selectedfile_Text += s;
                common.selectedfile_Text += "\r\n";
            }
            common.selectedfile_Text += "\r\n\r\n\r\n";
            common.selectedfile_text_count--;

            FileInfo info_reader = new FileInfo(@"..\..\Txt\" + common.selectedfile_Name + ".txt");
            common.selectedfile_CreationTime = info_reader.CreationTime.ToString();

            selectedfile.Close();
            text_reader.Close();

            if (common.articalinfo_grid.Children != null)
                common.articalinfo_grid.Children.Clear();
            common.articalinfo_grid.Children.Add(new Artical_Show());
            common.artical_show = new Artical_Show();
            common.articalinfo_grid.Children.Add(common.artical_show);
            common.time_Label.Opacity = 1;
            common.count_Label.Opacity = 1;
            common.update_at_Label.Opacity = 0.6;
            common.words_Label.Opacity = 0.6;
            //Thread selected_file_thread = new Thread(selectedfile_show);
            //selected_file_thread.Start();
            //common.selectedfile_Name = ConvertBack(current.Content.ToString()).ToString();
            //FileStream selectedfile = new FileStream(@"..\..\Txt\" + common.selectedfile_Name + ".txt", FileMode.Open, FileAccess.Read);
            //StreamReader text_reader = new StreamReader(selectedfile, Encoding.GetEncoding("gb2312"));      //gb2312coding编码读入中文
            //// 把文件指针重新定位到文件的开始
            //text_reader.BaseStream.Seek(0, SeekOrigin.Begin);  //0代表开头
            ////StreamReader.BaseStream.Seek(offset,origin);
            ////SeekOrigin.Begin:表示流的开头
            //string s = "";
            //common.selectedfile_Text = "";
            //while ((s = text_reader.ReadLine()) != null)
            //{
            //    if (s.Substring(0, 0) != " ")
            //        common.selectedfile_Text += "        ";
            //    common.selectedfile_Text += s;
            //    common.selectedfile_Text += "\r\n";
            //}
            ////读入字符流


            //FileInfo info_reader = new FileInfo(@"..\..\Txt\" + common.selectedfile_Name + ".txt");
            //common.selectedfile_CreationTime = info_reader.CreationTime.ToString();

            current.Foreground = new SolidColorBrush(Colors.White);
            current.Style = (Style)Resources["ListBoxItemStyle_withpressedlogo"];

            common.whether_selectfile = true;
        }

        //private void selectedfile_show()
        //{
        //    FileStream selectedfile = new FileStream(@"..\..\Txt\" + common.selectedfile_Name + ".txt", FileMode.Open, FileAccess.Read);
        //    StreamReader text_reader = new StreamReader(selectedfile, Encoding.GetEncoding("gb2312"));      //gb2312coding编码读入中文
        //    // 把文件指针重新定位到文件的开始
        //    text_reader.BaseStream.Seek(0, SeekOrigin.Begin);  //0代表开头
        //    //StreamReader.BaseStream.Seek(offset,origin);
        //    //SeekOrigin.Begin:表示流的开头
        //    string s = "";
        //    common.selectedfile_Text = "";
        //    common.selectedfile_text_count = 0;
        //    while ((s = text_reader.ReadLine()) != null)
        //    {
        //        common.selectedfile_text_count += s.Length + 1;
        //        if (s.Substring(0, 0) != " ")
        //            common.selectedfile_Text += "        ";
        //        common.selectedfile_Text += s;
        //        common.selectedfile_Text += "\r\n";
        //    }
        //    common.selectedfile_text_count--;

        //    FileInfo info_reader = new FileInfo(@"..\..\Txt\" + common.selectedfile_Name + ".txt");
        //    common.selectedfile_CreationTime = info_reader.CreationTime.ToString();

        //    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
        //    {
        //        //读入字符流
        //        if (common.articalinfo_grid.Children != null)
        //            common.articalinfo_grid.Children.Clear();
        //        common.articalinfo_grid.Children.Add(new Artical_Show());
        //        common.artical_show = new Artical_Show();
        //        common.articalinfo_grid.Children.Add(common.artical_show);
        //        common.time_Label.Opacity = 1;
        //        common.count_Label.Opacity = 1;
        //        common.update_at_Label.Opacity = 0.6;
        //        common.words_Label.Opacity = 0.6;
        //        //MessageBox.Show("stop");
        //    }
        //    );
        //    //读入字符流
            
        //    //MessageBox.Show("stop");
        //}

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
                common.addtitile_grid.Children.Clear();
                common.whether_addartical_open = false;
            }

            ListBoxItem current = sender as ListBoxItem;
            common.selectedfile_Path = @"..\..\Txt\" + ConvertBack(current.Content.ToString()) + ".txt";
            //MessageBox.Show(common.selectedfile_Name);

            UserControl menu = new RightButtonMenu();
            if(common.menu_grid.Children!=null)
            {
                common.menu_grid.Children.Clear();
            }
            Point p = Mouse.GetPosition(this);
            common.menu_grid.Margin = new Thickness(p.X + 4, p.Y + common.leftpart_grid.Margin.Top + common.listbox_grid.Margin.Top - 4, 0, 0);
            common.menu_grid.Children.Add(menu);
        }

        private void ListBoxItem_MouseEnter(object sender, MouseEventArgs e)
        {
            ListBoxItem current = sender as ListBoxItem;


            common.mouseoverfile_Name = ConvertBack(current.Content.ToString()).ToString();
            FileStream mouseoverfile = new FileStream(@"..\..\Txt\" + common.mouseoverfile_Name + ".txt", FileMode.Open, FileAccess.Read);
            StreamReader text_reader = new StreamReader(mouseoverfile, Encoding.GetEncoding("gb2312"));
            // 把文件指针重新定位到文件的开始
            text_reader.BaseStream.Seek(0, SeekOrigin.Begin);  //0代表开头
            //StreamReader.BaseStream.Seek(offset,origin);
            //SeekOrigin.Begin:表示流的开头
            string s = "";
            common.mouseoverfile_Text = "";
            common.mouseoverfile_text_count = 0;
            while ((s = text_reader.ReadLine()) != null)
            {
                common.mouseoverfile_text_count += s.Length + 1;
                if (s.Substring(0, 0) != " ")
                    common.mouseoverfile_Text += "        ";
                common.mouseoverfile_Text += s;
                common.mouseoverfile_Text += "\r\n";
            }
            common.mouseoverfile_text_count--;
            //读入字符流

            mouseoverfile.Close();
            text_reader.Close();

            FileInfo info_reader = new FileInfo(@"..\..\Txt\" + common.mouseoverfile_Name + ".txt");
            common.mouseoverfile_CreationTime = info_reader.CreationTime.ToString();

            if (current.IsSelected == false)
            {
                if (common.articalinfo_grid.Children != null)
                    common.articalinfo_grid.Children.Clear();
                common.articalinfo_grid.Children.Add(new Artical_Title());
            }
            else
            {
                if (common.articalinfo_grid.Children != null)
                    common.articalinfo_grid.Children.Clear();
                common.articalinfo_grid.Children.Add(new Artical_Show());
            }

            if (common.whether_addartical_open == true)
            {
                common.addtitile_grid.Visibility = Visibility.Collapsed;
                common.addtitile_grid.Children.Clear();
                common.whether_addartical_open = false;
            }

            common.time_Label.Opacity = 1;
            common.count_Label.Opacity = 1;
            common.update_at_Label.Opacity = 0.6;
            common.words_Label.Opacity = 0.6;
        }

        private void ListBoxItem_MouseLeave(object sender, MouseEventArgs e)
        {
            ListBoxItem current = sender as ListBoxItem;
            if (current.IsSelected == false && common.whether_selectfile == false)
            {
                common.time_Label.Opacity = 0;
                common.count_Label.Opacity = 0;
                common.update_at_Label.Opacity = 0;
                common.words_Label.Opacity = 0;
                if (common.articalinfo_grid.Children != null)
                    common.articalinfo_grid.Children.Clear();
            }
            else
            {
                if (common.articalinfo_grid.Children != null)
                    common.articalinfo_grid.Children.Clear();
                common.articalinfo_grid.Children.Add(new Artical_Show());
            }
        }

    }


}
