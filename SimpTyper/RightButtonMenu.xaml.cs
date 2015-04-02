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
            File.Delete(common.selectedfile_Path);
            common.selectedfile_Path = "";
            //更新左側listbox
            common.Filter_Name = common.filterarticals_TextBox.Text;
            common.listbox_grid.Children.Clear();
            common.listbox_grid.Children.Add(new LeftPart_ListBox());
            //MessageBox.Show(common.selectedfile_Name);
        }

        private void Edit_on_Notepad_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (common.menu_grid.Children != null)
            {
                common.menu_grid.Children.Clear();
            } 
            //MessageBox.Show(common.selectedfile_Path);
            //File.OpenText(common.selectedfile_Path);
            //MessageBox.Show(common.selectedfile_Path);
            Process editor = new Process();
            editor.StartInfo.FileName = common.selectedfile_Path;
            editor.Start();
            //Process.Start(common.selectedfile_Path);
            //MessageBox.Show("1");
            //editor.Exited += new EventHandler(editor_exit); 
            editor.WaitForExit();


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

            selectedfile.Close();
            text_reader.Close();

            FileInfo info_reader = new FileInfo(@"..\..\Txt\" + common.selectedfile_Name + ".txt");
            common.selectedfile_CreationTime = info_reader.CreationTime.ToString();

            if (common.articalinfo_grid.Children != null)
                common.articalinfo_grid.Children.Clear();
            common.articalinfo_grid.Children.Add(new Artical_Show());
            //File.Open(common.selectedfile_Name, FileMode.Open, FileAccess.ReadWrite);
        }

        //private void editor_exit(object sender, EventArgs e)
        //{ 
        //    MessageBox.Show("1");
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

        //    if (common.articalinfo_grid.Children != null)
        //        common.articalinfo_grid.Children.Clear();
        //    common.articalinfo_grid.Children.Add(new Artical_Show());

        //    MessageBox.Show("1");
        //}
    }
}
