using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SimpTyper
{
    /// <summary>
    /// WindowContainer.xaml 的交互逻辑
    /// </summary>
    public partial class WindowContainer : Window
    {
        string space = "";

        public WindowContainer()
        {
        this.SourceInitialized += new EventHandler(Window_SourceInitialized);
            InitializeComponent();
            Window_Initialize();
        }

        private void words_update()
        {
            words.Content = common.words.ToString() + "/" + (common.selectedfile_Type_Text.Length - 1).ToString();
        }

        private void Window_Initialize()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ShowInTaskbar = true;
            Window_main.Width = SystemParameters.WorkArea.Width * 0.9;
            Window_main.Height = SystemParameters.WorkArea.Height * 0.9;
            Window_main.MinWidth = SystemParameters.WorkArea.Width * 0.85;
            Window_main.MinHeight = SystemParameters.WorkArea.Height * 0.85;

            artical_title.Content = common.selectedfile_Name;
            FileStream selectedfile = new FileStream(common.selectedfile_Path, FileMode.Open, FileAccess.Read);
            StreamReader text_reader = new StreamReader(selectedfile, Encoding.GetEncoding("gb2312"));      //gb2312coding编码读入中文
            // 把文件指针重新定位到文件的开始
            text_reader.BaseStream.Seek(0, SeekOrigin.Begin);  //0代表开头
            //StreamReader.BaseStream.Seek(offset,origin);
            //SeekOrigin.Begin:表示流的开头
            string s = "";
            common.selectedfile_Type_Text = "";
            while ((s = text_reader.ReadLine()) != null)
            {
                common.selectedfile_Type_Text += s.Trim();
                common.selectedfile_Type_Text += " ";
            }
            common.words = 0;
            words_update();

            

            Artical.Text = space + common.selectedfile_Type_Text;
            selectedfile.Close();
            text_reader.Close();

        }

        private const int WM_NCHITTEST = 0x0084;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_TIMER = 0x0113;
        private readonly int agWidth = 12; //拐角宽度   
        private readonly int bThickness = 4; // 边框宽度   
        private Point mousePoint = new Point(); //鼠标坐标   


        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.ActualHeight > SystemParameters.WorkArea.Height || this.ActualWidth > SystemParameters.WorkArea.Width)
            {
                this.WindowState = System.Windows.WindowState.Normal;
                Maximize_button_Click(null, null);
                common.up_whether_maximize = true;
            }
        }

        void Window_SourceInitialized(object sender, EventArgs e)
        {
            System.Windows.Interop.HwndSource hwndSource = PresentationSource.FromVisual((Visual)sender) as System.Windows.Interop.HwndSource;
            hwndSource.AddHook(new System.Windows.Interop.HwndSourceHook(WndProc));

        }   //处理鼠标信息

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_NCHITTEST)
            {
                this.mousePoint.X = (lParam.ToInt32() & 0xFFFF);
                this.mousePoint.Y = (lParam.ToInt32() >> 16);


                // 窗口左上角   
                if (this.mousePoint.Y - this.Top <= this.agWidth
                    && this.mousePoint.X - this.Left <= this.agWidth)
                {
                    handled = true;
                    return new IntPtr((int)HitTest.HTTOPLEFT);
                }
                // 窗口左下角       
                else if (this.ActualHeight + this.Top - this.mousePoint.Y <= this.agWidth
                    && this.mousePoint.X - this.Left <= this.agWidth)
                {
                    handled = true;
                    return new IntPtr((int)HitTest.HTBOTTOMLEFT);
                }
                // 窗口右上角   
                else if (this.mousePoint.Y - this.Top <= this.agWidth
                    && this.ActualWidth + this.Left - this.mousePoint.X <= this.agWidth)
                {
                    handled = true;
                    return new IntPtr((int)HitTest.HTTOPRIGHT);
                }
                // 窗口右下角   
                else if (this.ActualWidth + this.Left - this.mousePoint.X <= this.agWidth
                    && this.ActualHeight + this.Top - this.mousePoint.Y <= this.agWidth)
                {
                    handled = true;
                    return new IntPtr((int)HitTest.HTBOTTOMRIGHT);
                }
                // 窗口左侧   
                else if (this.mousePoint.X - this.Left <= this.bThickness)
                {
                    handled = true;
                    return new IntPtr((int)HitTest.HTLEFT);
                }
                // 窗口右侧   
                else if (this.ActualWidth + this.Left - this.mousePoint.X <= this.bThickness)
                {
                    handled = true;
                    return new IntPtr((int)HitTest.HTRIGHT);
                }
                // 窗口上方   
                else if (this.mousePoint.Y - this.Top <= this.bThickness)
                {
                    handled = true;
                    return new IntPtr((int)HitTest.HTTOP);
                }
                // 窗口下方   
                else if (this.ActualHeight + this.Top - this.mousePoint.Y <= this.bThickness)
                {
                    handled = true;
                    return new IntPtr((int)HitTest.HTBOTTOM);
                }
                //else // 窗口移动   
                //{
                //    handled = true;
                //    return new IntPtr((int)HitTest.HTCAPTION);
                //}
            }
            else if (msg == WM_LBUTTONDOWN)
            {
                common.timer = new System.Timers.Timer(140);
                common.timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
                if (common.whether_maximize == true)
                    common.timer.Start();                  //通过设置Enalbed为true，马上开始调用Elapsed
            }
            else if (msg == WM_LBUTTONUP)
            {
                if (common.timer != null)
                    common.timer.Close();
            }
            return IntPtr.Zero;
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            common.timer.Stop();           //通过设置Enalbed为false，马上停止调用Elapsed

            Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate()         //按指定的优先级在与 Dispatcher 关联的线程上同步执行指定的委托。
            {
                Point p = Mouse.GetPosition(this);
                if (p.X > 0 && p.X < this.Width && p.Y > 0 && p.Y < 40)
                {

                    Maximize_button.Style = (Style)Resources["MaximizeButton"];
                    move_Normal_Click();
                    common.whether_maximize = false;

                    try { this.DragMove(); }
                    catch { }
                }
            });
        }

        public static Int32 GET_X_LPARAM(int lParam)
        {

            return (lParam & 0xffff);

        }
        public static Int32 GET_Y_LPARAM(int lParam)
        {

            return (lParam >> 16);

        }
        public enum HitTest
        {

            HTERROR = -2,
            HTTRANSPARENT = -1,
            HTNOWHERE = 0,
            HTCLIENT = 1,
            HTCAPTION = 2,
            HTSYSMENU = 3,
            HTGROWBOX = 4,
            HTSIZE = HTGROWBOX,
            HTMENU = 5,
            HTHSCROLL = 6,
            HTVSCROLL = 7,
            HTMINBUTTON = 8,
            HTMAXBUTTON = 9,
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17,
            HTBORDER = 18,
            HTREDUCE = HTMINBUTTON,
            HTZOOM = HTMAXBUTTON,
            HTSIZEFIRST = HTLEFT,
            HTSIZELAST = HTBOTTOMRIGHT,
            HTOBJECT = 19,
            HTCLOSE = 20,
            HTHELP = 21,
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //    s = sender;
            //    mouse = e;
            //    if (common.i != 0)
            //    {
            //        common.i = 0;
            //        return;
            //    }
            //    dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

            //    timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);

            //    timer.Start();                  //通过设置Enalbed为true，马上开始调用Elapsed
            //    dispatcherTimer.Start();
            //    if (common.whether_maximize == true)
            //    {
            //        Maximize_button.Style = (Style)Resources["MaximizeButton"];
            //        move_Normal_Click();
            //        common.whether_maximize = false;
            //    }
            

            Point p = Mouse.GetPosition(this);
            if (common.inner_grid == null)
            {
                //null
            }
            else
            {
                if (p.X > (common.addtitile_grid.Margin.Left + common.inner_grid.Margin.Left) && p.X < (common.addtitile_grid.Margin.Left + common.addtitile_grid.Width - common.inner_grid.Margin.Right) && p.Y > (this.Height - common.addtitile_grid.Margin.Bottom - common.addtitile_grid.Height + common.inner_grid.Margin.Top) && p.Y < (this.Height - common.addtitile_grid.Margin.Bottom - common.inner_grid.Margin.Bottom - 12))
                {
                    //cannot close the addarticle_grid
                }
                else
                {
                    if (p.X > (common.addtitile_grid.Margin.Left + common.inner_grid.Margin.Left + 17) && p.X < (common.addtitile_grid.Margin.Left + common.inner_grid.Margin.Left + 27) && p.Y > (this.Height - common.addtitile_grid.Margin.Bottom - common.inner_grid.Margin.Bottom - 12) && p.Y < (this.Height - common.addtitile_grid.Margin.Bottom - common.inner_grid.Margin.Bottom - 5))
                    {
                        //cannot close the addarticle_grid
                    }
                    else
                    {
                        
                    }
                }
            }

            if (p.X > 0 && p.X < this.Width && p.Y > 0 && p.Y < 30 && e.LeftButton == MouseButtonState.Pressed && common.whether_maximize == false)
            {
                try { this.DragMove(); }
                catch { }
            }
            //    System.Threading.Thread.Sleep(200);
            //    if (common.i != 0)
            //    {
            //        common.i = 0;
            //        return;
            //    }
            //    if (common.whether_maximize == true)
            //    {
            //        Maximize_button.Style = (Style)Resources["MaximizeButton"];
            //        move_Normal_Click();
            //        common.whether_maximize = false;
            //    }
        }

        private void Window_main_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Point p = Mouse.GetPosition(this);
            if (p.X > 0 && p.X < (this.Width - 87) && p.Y > 0 && p.Y < 30 && e.LeftButton == MouseButtonState.Pressed)
            {
                Maximize_button_Click(null, null);
            }
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            stop_time();
            common.first_input = false;
            this.Close();
        }

        private void Maximize_Click()
        {
            common.rcnormal = new Rect(this.Left, this.Top, this.Width, this.Height);//保存下当前位置与大小
            this.Left = 0;//设置位置
            this.Top = 0;
            Rect rc = SystemParameters.WorkArea;//获取工作区大小
            this.Width = rc.Width;
            this.Height = rc.Height;
        }

        private void Normal_Click()
        {
            this.Left = common.rcnormal.Left;
            this.Top = common.rcnormal.Top;
            this.Width = common.rcnormal.Width;
            this.Height = common.rcnormal.Height;
        }

        private void move_Normal_Click()
        {
            Rect rc = SystemParameters.WorkArea;//获取工作区大小
            Point p = Mouse.GetPosition(this);
            this.Left = p.X - p.X / rc.Width * common.rcnormal.Width;
            this.Top = p.Y - 20;
            this.Width = common.rcnormal.Width;
            this.Height = common.rcnormal.Height;
            common.up_whether_maximize = false;
        }

        private void Maximize_button_Click(object sender, RoutedEventArgs e)
        {
            
            if (common.whether_maximize == false)
            {
                Maximize_button.Style = (Style)Resources["NormalButton"];
                Maximize_Click();
                common.whether_maximize = true;
            }
            else
            {
                Maximize_button.Style = (Style)Resources["MaximizeButton"];
                Normal_Click();
                common.whether_maximize = false;
            }
        }

        private void Minimize_button_Click(object sender, RoutedEventArgs e)
        {
            
            this.WindowState = WindowState.Minimized;
        }

        private void InputBox_Loaded(object sender, RoutedEventArgs e)
        {
            common.input_TextBox = sender as TextBox;
            common.input_TextBox.Visibility = Visibility.Visible;
            common.input_TextBox.Focus();
        }

        //private void InputBox_TextChanged(object sender, TextChangedEventArgs e)            //error for chinese input
        //{

                
        //}

        private void InputBox_PreviewTextInput(object sender, TextCompositionEventArgs e)           //处理中英文输入
        {
            if (common.first_input == false)
            {
                set_timer();
                common.first_input = true;
            }
            if (InputBox.Text != "" && Regex.Match(InputBox.Text.Substring(InputBox.Text.Length - 1, 1), "^[a-zA-Z]+$").Success)         //InputBox.Text!="" 表示英文输入错误，所以要正规式判断最后输入的是否为英文字母，得清空才能继续输入
                return;
            if (Artical.Text.Length == 0)
            {
                stop_time();
                common.first_input = false;
                return;
            }
            int i = e.Text.Length;
            if (e.Text == Artical.Text.Substring(space.Length, i))
            {
                if (!Regex.Match(e.Text, "^[a-zA-Z]+$").Success)
                    InputBox.Text = "";
                //pre_Artical.Text = pre_Artical.Text.Substring(i, pre_Artical.Text.Length - i);
                //pre_Artical.Text += Artical.Text.Substring(0, i);
                Artical.Text = Artical.Text.Substring(i, Artical.Text.Length - i);
                common.words += i;
                words_update();
                e.Handled = true;
            }

            if (common.words == common.selectedfile_Type_Text.Length - 1)       //为空则停止计时
            {
                stop_time();
                common.first_input = false;
                common.input_TextBox.Visibility = Visibility.Collapsed;
            }    
            //TextBox current = sender as TextBox;
            //InputMethod.Current.ImeSentenceMode = ImeSentenceModeValues.Automatic;
            //MessageBox.Show(e.Text);  
            
        }

        private void InputBox_TextChanged(object sender, TextChangedEventArgs e)                    //处理空格输入
        {
            if (common.words == common.selectedfile_Type_Text.Length - 1)
            {
                stop_time();
                common.first_input = false;
                return;
            }         
   

            if (InputBox.Text == " " && Artical.Text.Substring(space.Length, 1) == " ")
            {
                //pre_Artical.Text = pre_Artical.Text.Substring(1, pre_Artical.Text.Length - 1);
                //pre_Artical.Text += Artical.Text.Substring(0, 1);
                common.words++;
                words_update();
                Artical.Text = Artical.Text.Substring(1, Artical.Text.Length - 1);
                InputBox.Text = "";
            }
    
            e.Handled = false;  
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            common.input_TextBox.Focus();
            e.Handled = true;
        }

        private void set_timer()
        {

            common.type_timer = new DispatcherTimer();
            common.timer_time = new TimeSpan(0, 0, 0, 0, 0);
            common.type_timer.Interval = new TimeSpan(0, 0, 1);
            common.type_timer.Tick += new EventHandler(Timer_Tick);
            common.type_timer.Start();

            common.speed_timer = new DispatcherTimer();
            common.speed_timer.Interval = new TimeSpan(0, 0, 1);
            common.speed_timer.Tick += new EventHandler(Timer_Speed);
            common.speed_timer.Start();
        }

        private void stop_time()
        {
            if (common.type_timer != null)
                common.type_timer.Stop();
        }

        void Timer_Tick(object send, EventArgs e)
        {
            common.timer_time += new TimeSpan(0, 0, 1);
            //if (common.timer_time.Milliseconds % 100 == 0 && common.timer_time.Milliseconds % 1000 != 0)
            //    common.timer_time += new TimeSpan(0, 0, 1);
            var time = string.Format("{0:D2}:{1:D2}:{2:D2}", common.timer_time.Hours, common.timer_time.Minutes, common.timer_time.Seconds);
            timer_label.Content = time;
        }

        void Timer_Speed(object send, EventArgs e)
        {
            if (common.words != 0 && common.words != common.selectedfile_Type_Text.Length - 1)
            {
                var speed = string.Format("{0:D4}", (int)((double)common.words / (common.timer_time.Hours * 60 * 60 + common.timer_time.Minutes * 60 + common.timer_time.Seconds) * 60));
                type_speed.Content = speed;
            }
            if (common.words == common.selectedfile_Type_Text.Length - 1)
                common.speed_timer.Stop();
        }

    }
}
