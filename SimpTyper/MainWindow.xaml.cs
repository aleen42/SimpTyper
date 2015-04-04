using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SimpTyper
{
    enum AddTitle_Grid_Button
    {
        Add = 0,
        Create
    }

    class common
    {
        public static bool whether_maximize = false;
        public static bool up_whether_maximize = false;         //记录是否往上拉窗体到顶端
        public static bool first_time_loadLeftPartListBox = true;
        public static bool whether_selectfile = false;
        public static bool whether_addartical_open = false;
        public static bool whether_AddTitle_Grid_Button_Add_pressed = false;
        public static bool whether_AddTitle_Grid_Button_Create_pressed = false;
        public static AddTitle_Grid_Button AddTitle_Grid_ButtonChoise = AddTitle_Grid_Button.Add;
        public static Button AddTitle_Grid_Button_Add;
        public static Button AddTitle_Grid_Button_Create;
        public static Button Browse_Button;
        public static Button addanartial_Button;
        public static int i = 0;    //doubleclick
        public static int num = 1;
        public static long selectedfile_text_count = 0;
        public static long mouseoverfile_text_count = 0;
        public static string Filter_Name = "";
        public static string addfile_Name = "";
        public static string selectedfile_Path = "";
        public static string selectedfile_Name = "";
        public static string selectedfile_Text = "";
        public static string selectedfile_CreationTime = "";
        public static string mouseoverfile_Name = "";
        public static string mouseoverfile_Text = "";
        public static string mouseoverfile_CreationTime = "";
        public static string space_string = "\n\n\n";
        public static Grid leftpart_grid;
        public static Grid addtitile_grid;
        public static Grid inner_grid;
        public static Grid listbox_grid;
        public static Grid menu_grid;
        public static Grid articalinfo_grid;
        public static TextBox filterarticals_TextBox;
        public static TextBox browse_TextBox;
        public static UserControl metro_loading;
        public static Label update_at_Label;
        public static Label time_Label;
        public static Label words_Label;
        public static Label count_Label;
        public static Window mainwindow;
        public static Rect rcnormal;//定义一个全局rect记录还原状态下窗口的位置和大小。
        public static System.Timers.Timer timer;


    }

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        
        //public System.Windows.Threading.DispatcherTimer dispatcherTimer;
        
        //public object s;
        //public MouseButtonEventArgs mouse;

        public MainWindow()
        {
            this.SourceInitialized += new EventHandler(Window_SourceInitialized);
            InitializeComponent();
            Window_Initialize();
            
        }

        private void Window_Initialize()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ShowInTaskbar = true;
            Window_main.Width = SystemParameters.WorkArea.Width * 0.9;
            Window_main.Height = SystemParameters.WorkArea.Height * 0.9;
            Window_main.MinWidth = SystemParameters.WorkArea.Width * 0.85;
            Window_main.MinHeight = SystemParameters.WorkArea.Height * 0.85;
            ListBox_Grid.Children.Add(new LeftPart_ListBox());
            common.first_time_loadLeftPartListBox = false;
        }   


        private const int WM_NCHITTEST = 0x0084;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_TIMER = 0x0113;
        private readonly int agWidth = 12; //拐角宽度   
        private readonly int bThickness = 4; // 边框宽度   
        private Point mousePoint = new Point(); //鼠标坐标   

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
            if (common.menu_grid.Children != null)
            {
                common.menu_grid.Children.Clear();
            }

            Point p = Mouse.GetPosition(this);
            if(common.inner_grid==null)
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
                        if (common.whether_addartical_open == true)
                        {
                            common.addtitile_grid.Visibility = Visibility.Collapsed;
                            common.addtitile_grid.Children.Clear();
                            common.whether_addartical_open = false;
                        }
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

        //private void Window_main_MouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    dispatcherTimer.Stop();
        //    timer.Stop();
        //}

        //void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    timer.Stop();           //通过设置Enalbed为false，马上停止调用Elapsed

        //    Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate()         //按指定的优先级在与 Dispatcher 关联的线程上同步执行指定的委托。
        //    {
        //        Window_main_MouseUp(null, null);
        //        try
        //        {
        //            this.DragMove();
        //        }
        //        catch { }
        //        //MessageBox.Show("长按");
        //    });
        //} 

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
            if (common.menu_grid.Children != null)
            {
                common.menu_grid.Children.Clear();
            }
            Application.Current.Shutdown();
        }
        
        /// <summary>
        /// 最大化，最小化
        /// </summary>
        /// 

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
            if (common.menu_grid.Children != null)
            {
                common.menu_grid.Children.Clear();
            }
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
            if (common.menu_grid.Children != null)
            {
                common.menu_grid.Children.Clear();
            }
            this.WindowState = WindowState.Minimized;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.ActualHeight > SystemParameters.WorkArea.Height || this.ActualWidth > SystemParameters.WorkArea.Width)
            {
                this.WindowState = System.Windows.WindowState.Normal;
                Maximize_button_Click(null, null);
                common.up_whether_maximize = true;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (common.menu_grid.Children != null)
            {
                common.menu_grid.Children.Clear();
            }
            if (common.whether_addartical_open == false) 
            {
                common.addtitile_grid.Visibility = Visibility.Visible;
                common.whether_addartical_open = true;
                common.addtitile_grid.Children.Add(new AddArticals_InnerGrid());
            }
            else
            {
                common.addtitile_grid.Visibility = Visibility.Collapsed;
                common.addtitile_grid.Children.Clear();
                common.whether_addartical_open = false;
            }
        }

        //private void FilterArticals_LostFocus(object sender, RoutedEventArgs e)                   //somethingwrong
        //{
        //    //common.filterarticals.Text = "Filter Articals...";
        //} 

        private void Addarticals_Loaded(object sender, RoutedEventArgs e)
        {
            common.addtitile_grid = sender as Grid;
            
        }

        private void Filter_Loaded(object sender, RoutedEventArgs e)
        {
            common.filterarticals_TextBox = sender as TextBox;
        }

        private void Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (common.filterarticals_TextBox == null)
                return;
            if (common.filterarticals_TextBox.Text != "Filter Articals...")                                                                    //textbox点击或已输入字符
            {
                //MessageBox.Show("1");
                common.Filter_Name = common.filterarticals_TextBox.Text;
                common.listbox_grid.Children.Clear();
                common.listbox_grid.Children.Add(new LeftPart_ListBox());
                common.whether_selectfile = false;
                if (common.articalinfo_grid.Children != null)
                    common.articalinfo_grid.Children.Clear();
            }

            //if (common.filterarticals.Text == "Filter Articals..." && common.first_time_loadLeftPartListBox == false)                 //textbox没字符
            //{
            //    ListBox_Grid.Children.Clear();
            //    ListBox_Grid.Children.Add(new LeftPart_ListBox());
            //    //MessageBox.Show(FilterArticals.Text);
            //}
        }

        private void Filter_GotFocus(object sender, RoutedEventArgs e)
        {
            if (common.menu_grid.Children != null)
                common.menu_grid.Children.Clear();
            if (common.whether_addartical_open == true)
            {
                common.addtitile_grid.Visibility = Visibility.Collapsed;
                common.whether_addartical_open = false;
            }
        }

        private void Window_main_Loaded(object sender, RoutedEventArgs e)
        {
            common.mainwindow = sender as Window;
        }

        private void GridSplitter_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (common.whether_addartical_open == true)
            {
                common.addtitile_grid.Visibility = Visibility.Collapsed;
                common.whether_addartical_open = false;
            }
            if (common.menu_grid.Children != null)
                common.menu_grid.Children.Clear();
        }

        private void ListBox_Grid_Loaded(object sender, RoutedEventArgs e)
        {
            common.listbox_grid = sender as Grid;
        }

        private void Right_Button_Menu_Loaded(object sender, RoutedEventArgs e)
        {
            common.menu_grid = sender as Grid;
        }

        private void LeftPart_Loaded(object sender, RoutedEventArgs e)
        {
            common.leftpart_grid = sender as Grid;
        }

        private void Artical_info_Loaded(object sender, RoutedEventArgs e)
        {
            common.articalinfo_grid = sender as Grid;
        }

        private void metro_Loaded(object sender, RoutedEventArgs e)
        {
            common.metro_loading = sender as UserControl;
        }

        private void time_Loaded(object sender, RoutedEventArgs e)
        {
            common.time_Label = sender as Label;
        }

        private void words_Loaded(object sender, RoutedEventArgs e)
        {
            common.words_Label = sender as Label;
        }

        private void count_Loaded(object sender, RoutedEventArgs e)
        {
            common.count_Label = sender as Label;
        }

        private void update_at_Loaded(object sender, RoutedEventArgs e)
        {
            common.update_at_Label = sender as Label;
        }


        //private void TextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    common.filterarticals.Text = "";
        //}


        //private void FilterArticals_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    if (sender != null)
        //    {
        //        TextBox txb = sender as TextBox;
        //        txb.SelectAll();
        //    }
        //}
 
        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    common.i += 1;
        //    System.Timers.Timer t = new System.Timers.Timer(600);
        //    t.Interval = 600;

        //    t.Elapsed += (s, ee) => { t.Enabled = false; common.i = 0; };
        //    t.Enabled = true;
        //    if (common.i % 2 == 0)
        //    {
        //        t.Enabled = false;
        //        MessageBox.Show("doubleclick");
        //        //Maximize_button_Click(sender, e);
        //        common.i = 0;
        //    }
        //}

        
    }
}
