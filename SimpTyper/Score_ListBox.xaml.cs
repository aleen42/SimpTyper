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
        int begin_time_second_bg = 0;
        int begin_time_second_x = 0;

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
            int num = 1;
            foreach (System.IO.FileInfo NextFile in text_file)
            {

                if (common.ASCII_code(common.selectedfile_Name).Length > NextFile.Name.Length)
                    continue;
                if (NextFile.Name.Substring(0, common.ASCII_code(common.selectedfile_Name).Length) != common.ASCII_code(common.selectedfile_Name))
                    continue;
                
                FileStream readfile = new FileStream(NextFile.FullName, FileMode.Open, FileAccess.Read);
                StreamReader text_reader = new StreamReader(readfile, Encoding.GetEncoding("gb2312"));
                text_reader.BaseStream.Seek(0, SeekOrigin.Begin);

                string[] line = new string[7];
                for (int i = 0; i < 7;i++ )
                {
                    line[i] = text_reader.ReadLine();
                }
                private_key = common.Decode(line[4]);


                ListBoxItem ListBox_Item = new ListBoxItem();
                Grid Grid_Item = new Grid();
                Grid_Item.Height = 35;
                //Grid_Item.Width = ;
                Grid_Item.Margin = new Thickness(-4, 0, 0, 0);
                //Grid_Item.Background=new SolidColorBrush(Colors.White);
                Label speed = new Label();
                Label time = new Label();
                Label accuracy = new Label();
                Label place = new Label();

                place.FontSize = 10;
                place.Margin = new Thickness(22, 19, 234, -22);
                place.Content = num++;

                speed.FontSize = 23;
                speed.Margin = new Thickness(32, -3, 116, 0);
                BrushConverter conv = new BrushConverter();
                Brush color = conv.ConvertFromInvariantString("#FFa10000") as Brush;
                speed.Foreground = color;
                speed.Content = common.RSADecrypt(private_key,line[1]) + "WPM";

                time.FontSize = 12;
                time.Margin = new Thickness(163, 11, 7, 0);
                time.Content = common.Decode(line[5]) + " " + common.Decode(line[6]);

                accuracy.FontSize = 12;
                accuracy.Margin = new Thickness(163, -3, 7, 10);
                accuracy.Content = common.RSADecrypt(private_key, line[2]) + "%";

                ListBox_Item.Style = (Style)Resources["ListBoxItemStyle"];
                ListBox_Item.Margin = new Thickness(-1, 0, 0, 3);
                ListBox_Item.HorizontalAlignment = HorizontalAlignment.Left;
                ListBox_Item.Width = 320;
                ListBox_Item.Focusable = false;
                TransformGroup transformgroup = new TransformGroup();
                transformgroup.Children.Add(new ScaleTransform());
                transformgroup.Children.Add(new SkewTransform());
                transformgroup.Children.Add(new RotateTransform());
                transformgroup.Children.Add(new TranslateTransform());
                ListBox_Item.RenderTransform = transformgroup;

                Grid_Item.Children.Add(place);
                Grid_Item.Children.Add(speed);
                Grid_Item.Children.Add(time);
                Grid_Item.Children.Add(accuracy);
                ListBox_Item.Content = Grid_Item;
                ScoreListBox.Items.Add(ListBox_Item);

                Storyboard show = new Storyboard();
                show = this.Resources["score_bg_load"] as Storyboard;
                Storyboard.SetTarget(show, ListBox_Item);
                TimeSpan begin_time = new TimeSpan(0, 0, 0, 0, begin_time_second_bg);
                begin_time_second_bg += 30;
                show.BeginTime = begin_time;
                show.Begin();

                show = this.Resources["score_x_load"] as Storyboard;
                Storyboard.SetTarget(show, ListBox_Item);
                begin_time = new TimeSpan(0, 0, 0, 0, begin_time_second_x);
                begin_time_second_x += 30;
                show.BeginTime = begin_time;
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
