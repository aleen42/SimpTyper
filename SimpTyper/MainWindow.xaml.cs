using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
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
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Interop;
using System.Security.Principal;
using System.Reflection;

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
        public static bool first_input = false;
        public static bool up_whether_maximize = false;         //记录是否往上拉窗体到顶端
        public static bool first_time_loadLeftPartListBox = true;
        public static bool whether_selectfile = false;
        public static bool whether_addartical_open = false;
        public static bool whether_AddTitle_Grid_Button_Add_pressed = false;
        public static bool whether_AddTitle_Grid_Button_Create_pressed = false;
        public static bool whether_first_space_count = false;   //处理第一次空格错误输入是否计数
        public static AddTitle_Grid_Button AddTitle_Grid_ButtonChoise = AddTitle_Grid_Button.Add;
        public static Button AddTitle_Grid_Button_Add;
        public static Button AddTitle_Grid_Button_Create;
        public static Button Browse_Button;
        public static Button addanartial_Button;
        

        //public static int num = 1;
        public static int i = 0;    //doubleclick
        public static int leftpart_row_num = 0;
        public static long wrong_type_count = 0;
        public static long last_input_length = 0;
        public static long selectedfile_text_count = 0;
        public static long mouseoverfile_text_count = 0;
        public static long words = 0;

        public static double Artical_left = 0.0;
        public static double Artical_right = 0.0;
        public static double Artical_top = 0.0;
        public static double Artical_bottom = 0.0;
        public static double type_point_left = 0.0;
        public static double type_point_right = 0.0;
        public static double type_point_top = 0.0;
        public static double type_point_bottom = 0.0;
        //public static double move_x;
        //public static double move_y;

        public static string Filter_Name = "";
        public static string addfile_Name = "";
        public static string selectedfile_Path = "";
        public static string selectedfile_Name = "";
        public static string selectedfile_Text = "";
        public static string selectedfile_Type_Text = "";
        public static string selectedfile_CreationTime = "";
        public static string mouseoverfile_Name = "";
        public static string mouseoverfile_Text = "";
        public static string mouseoverfile_CreationTime = "";
        public static string space_string = "\n\n\n";
        public static string Key_64 = "Aleen's ";
        public static string Iv_64 = "Simp'sCo";
        public static string public_key = "";
        public static string private_key = "";

        public static Button type_Button;
        public static Grid leftpart_grid;
        public static Grid addtitile_grid;
        public static Grid inner_grid;
        public static Grid listbox_grid;
        public static Grid score_grid;
        public static Grid menu_grid;
        public static Grid articalinfo_grid;
        public static TextBox filterarticals_TextBox;
        public static TextBox input_TextBox;
        public static TextBox browse_TextBox;
        public static UserControl metro_loading;
        public static Label loadmorearticals_Label;
        public static Label update_at_Label;
        public static Label time_Label;
        public static Label words_Label;
        public static Label count_Label;
        public static Window mainwindow;
        public static Rect rcnormal;//定义一个全局rect记录还原状态下窗口的位置和大小。
        //public static Border Txt_bg;
        public static TimeSpan timer_time;
        public static DispatcherTimer type_timer;
        public static DispatcherTimer speed_timer;
        //public static TimeSpan timer_time1 = new TimeSpan(0, 0, 0, 0, 0);
        public static System.Timers.Timer timer;

        public static void listbox_grid_clear()
        {
            if (common.listbox_grid != null && common.listbox_grid.Children != null)
                common.listbox_grid.Children.Clear();
        }

        public static void score_grid_clear()
        {
            if (common.score_grid.Children != null)
                common.score_grid.Children.Clear();    
        }

        public static void menu_grid_clear()
        {
            if (common.menu_grid.Children != null)
            {
                common.menu_grid.Children.Clear();
            }
        }

        public static void addtitile_grid_set()
        {
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

        public static void addtitle_grid_clear()
        {
            if (common.whether_addartical_open == true)
            {
                common.addtitile_grid.Visibility = Visibility.Collapsed;
                common.addtitile_grid.Children.Clear();
                common.whether_addartical_open = false;
            }
        }

        public static void loadmorearticals_set()
        {
            if (common.leftpart_row_num > 13)
                common.loadmorearticals_Label.Opacity = 1;
            else
                common.loadmorearticals_Label.Opacity = 0;
        }

        public static void Set_RSA_key()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            common.private_key = rsa.ToXmlString(true);
            common.public_key = rsa.ToXmlString(false);
        }

        public static string RSAEncrypt(string publickey, string content)       //RSA加密
        {
            //publickey = @"<RSAKeyValue><Modulus>5m9m14XH3oqLJ8bNGw9e4rGpXpcktv9MSkHSVFVMjHbfv+SJ5v0ubqQxa5YjLN4vc49z7SVju8s0X4gZ6AzZTn06jzWOgyPRV54Q4I0DCYadWW4Ze3e+BOtwgVU1Og3qHKn8vygoj40J6U85Z/PTJu3hN1m75Zr195ju7g9v4Hk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(publickey);
            cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(content), false);

            return Convert.ToBase64String(cipherbytes);
        }

        public static string RSADecrypt(string privatekey, string content)
        {
            //privatekey = @"<RSAKeyValue><Modulus>5m9m14XH3oqLJ8bNGw9e4rGpXpcktv9MSkHSVFVMjHbfv+SJ5v0ubqQxa5YjLN4vc49z7SVju8s0X4gZ6AzZTn06jzWOgyPRV54Q4I0DCYadWW4Ze3e+BOtwgVU1Og3qHKn8vygoj40J6U85Z/PTJu3hN1m75Zr195ju7g9v4Hk=</Modulus><Exponent>AQAB</Exponent><P>/hf2dnK7rNfl3lbqghWcpFdu778hUpIEBixCDL5WiBtpkZdpSw90aERmHJYaW2RGvGRi6zSftLh00KHsPcNUMw==</P><Q>6Cn/jOLrPapDTEp1Fkq+uz++1Do0eeX7HYqi9rY29CqShzCeI7LEYOoSwYuAJ3xA/DuCdQENPSoJ9KFbO4Wsow==</Q><DP>ga1rHIJro8e/yhxjrKYo/nqc5ICQGhrpMNlPkD9n3CjZVPOISkWF7FzUHEzDANeJfkZhcZa21z24aG3rKo5Qnw==</DP><DQ>MNGsCB8rYlMsRZ2ek2pyQwO7h/sZT8y5ilO9wu08Dwnot/7UMiOEQfDWstY3w5XQQHnvC9WFyCfP4h4QBissyw==</DQ><InverseQ>EG02S7SADhH1EVT9DD0Z62Y0uY7gIYvxX/uq+IzKSCwB8M2G7Qv9xgZQaQlLpCaeKbux3Y59hHM+KpamGL19Kg==</InverseQ><D>vmaYHEbPAgOJvaEXQl+t8DQKFT1fudEysTy31LTyXjGu6XiltXXHUuZaa2IPyHgBz0Nd7znwsW/S44iql0Fen1kzKioEL3svANui63O3o5xdDeExVM6zOf1wUUh/oldovPweChyoAdMtUzgvCbJk1sYDJf++Nr0FeNW1RB1XG30=</D></RSAKeyValue>";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(privatekey);
            cipherbytes = rsa.Decrypt(Convert.FromBase64String(content), false);

            return Encoding.UTF8.GetString(cipherbytes);
        }

        public static string ASCII_code(string file_name)
        {
            byte[] array = System.Text.Encoding.ASCII.GetBytes(file_name);  //数组array为对应的ASCII数组     
            string ASCIIstr2 = null;
            for (int i = 0; i < array.Length; i++)
            {
                int asciicode = (int)(array[i]);
                ASCIIstr2 += Convert.ToString(asciicode);//字符串ASCIIstr2 为对应的ASCII字符串
            }
            return ASCIIstr2;

        }

        public static string Encode(string data)          //MD5加密
        {
            string KEY_64 = common.Key_64;// "VavicApp";
            string IV_64 = common.Key_64;// "VavicApp";
            try
            {
                byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
                byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                int i = cryptoProvider.KeySize;
                MemoryStream ms = new MemoryStream();
                CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);
                StreamWriter sw = new StreamWriter(cst);
                sw.Write(data);
                sw.Flush();
                cst.FlushFinalBlock();
                sw.Flush();
                return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
            }
            catch (Exception x)
            {
                return x.Message;
            }
        }

        public static string Decode(string data)
        {
            string KEY_64 = common.Key_64;// "VavicApp";密钥
            string IV_64 = common.Key_64;// "VavicApp"; 向量
            try
            {
                byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
                byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);
                byte[] byEnc;
                byEnc = Convert.FromBase64String(data); //把需要解密的字符串转为8位无符号数组
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream(byEnc);
                CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cst);
                return sr.ReadToEnd();
            }
            catch (Exception x)
            {
                return x.Message;
            }
        }
    }

    //public class MouseHook
    //{
    //    //private const int WM_MOUSEMOVE = 0x200;
    //    //private const int WM_LBUTTONDOWN = 0x201;
    //    //private const int WM_RBUTTONDOWN = 0x204;
    //    //private const int WM_MBUTTONDOWN = 0x207;
    //    //private const int WM_LBUTTONUP = 0x202;
    //    //private const int WM_RBUTTONUP = 0x205;
    //    //private const int WM_MBUTTONUP = 0x208;
    //    //private const int WM_LBUTTONDBLCLK = 0x203;
    //    //private const int WM_RBUTTONDBLCLK = 0x206;
    //    //private const int WM_MBUTTONDBLCLK = 0x209;

    //    //全局的事件
    //    public event System.Windows.Forms.MouseEventHandler OnMouseActivity;

    //    static int hMouseHook = 0; //鼠标钩子句柄

    //    //鼠标常量
    //    public const int WH_MOUSE_LL = 14; //mouse hook constant

    //    HookProc MouseHookProcedure; //声明鼠标钩子事件类型.

    //    //声明一个Point的封送类型
    //    [StructLayout(LayoutKind.Sequential)]
    //    public class POINT
    //    {
    //        public int x;
    //        public int y;
    //    }

    //    //声明鼠标钩子的封送结构类型
    //    [StructLayout(LayoutKind.Sequential)]
    //    public class MouseHookStruct
    //    {
    //        public POINT pt;
    //        public int hWnd;
    //        public int wHitTestCode;
    //        public int dwExtraInfo;
    //    }


    //    //装置钩子的函数
    //    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    //    public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

    //    //卸下钩子的函数
    //    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    //    public static extern bool UnhookWindowsHookEx(int idHook);

    //    //下一个钩挂的函数
    //    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    //    public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

    //    public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);

    //    [DllImport("kernel32.dll")]
    //    private static extern IntPtr GetModuleHandle(IntPtr path);

    //    /// <summary>
    //    /// 墨认的构造函数构造当前类的实例.
    //    /// </summary>
    //    public MouseHook()
    //    {
    //    }

    //    //析构函数.
    //    ~MouseHook()
    //    {
    //        try
    //        {
    //            Stop();
    //        }
    //        catch (Exception e)
    //        {
    //            //nothing
    //        }
    //    }

    //    public void Start()
    //    {
    //        //安装鼠标钩子
    //        if (hMouseHook == 0)
    //        {
    //            //生成一个HookProc的实例.
    //            MouseHookProcedure = new HookProc(MouseHookProc);

    //            hMouseHook = SetWindowsHookEx(WH_MOUSE_LL, MouseHookProcedure, GetModuleHandle(IntPtr.Zero), 0);

    //            //如果装置失败停止钩子
    //            if (hMouseHook == 0)
    //            {
    //                try
    //                {
    //                    Stop();
    //                }
    //                catch (Exception e)
    //                {
    //                    //nothing
    //                }
    //                throw new Exception("SetWindowsHookEx failed.");
    //            }
    //        }
    //    }

    //    public void Stop()
    //    {
    //        bool retMouse = true;
    //        if (hMouseHook != 0)
    //        {
    //            retMouse = UnhookWindowsHookEx(hMouseHook);
    //            hMouseHook = 0;
    //        }

    //        //如果卸下钩子失败
    //        if (!(retMouse)) throw new Exception("UnhookWindowsHookEx failed.");
    //    }

    //    private int MouseHookProc(int nCode, Int32 wParam, IntPtr lParam)
    //    {
    //        //如果正常运行并且用户要监听鼠标的消息
    //        if ((nCode >= 0) && (OnMouseActivity != null))
    //        {
    //            System.Windows.Forms.MouseButtons button = new System.Windows.Forms.MouseButtons();
    //            int clickCount = 0;

    //            //switch (wParam)
    //            //{
    //            //    case WM_LBUTTONDOWN:
    //            //        button = MouseButtons.Left;
    //            //        clickCount = 1;
    //            //        break;
    //            //    case WM_LBUTTONUP:
    //            //        button = MouseButtons.Left;
    //            //        clickCount = 1;
    //            //        break;
    //            //    case WM_LBUTTONDBLCLK:
    //            //        button = MouseButtons.Left;
    //            //        clickCount = 2;
    //            //        break;
    //            //    case WM_RBUTTONDOWN:
    //            //        button = MouseButtons.Right;
    //            //        clickCount = 1;
    //            //        break;
    //            //    case WM_RBUTTONUP:
    //            //        button = MouseButtons.Right;
    //            //        clickCount = 1;
    //            //        break;
    //            //    case WM_RBUTTONDBLCLK:
    //            //        button = MouseButtons.Right;
    //            //        clickCount = 2;
    //            //        break;
    //            //}

    //            //从回调函数中得到鼠标的信息
    //            MouseHookStruct MyMouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
    //            System.Windows.Forms.MouseEventArgs e = new System.Windows.Forms.MouseEventArgs(button, clickCount, MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y, 0);
    //            //if(e.X>700)return 1;//如果想要限制鼠标在屏幕中的移动区域可以在此处设置
    //            OnMouseActivity(this, e);
    //        }
    //        return CallNextHookEx(hMouseHook, nCode, wParam, lParam);
    //    }
    //}       //监控鼠标钩子类


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
            //mouse.OnMouseActivity += new System.Windows.Forms.MouseEventHandler(mouse_OnMouseActivity);
            //mouse.Start();          //装载钩子

            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ShowInTaskbar = true;
            Window_main.Width = SystemParameters.WorkArea.Width * 0.9;
            Window_main.Height = SystemParameters.WorkArea.Height * 0.9;
            Window_main.MinWidth = SystemParameters.WorkArea.Width * 0.85;
            Window_main.MinHeight = SystemParameters.WorkArea.Height * 0.85;
            main_grid_Initialize();
            //Process[] processcollection = Process.GetProcessesByName("SimpTyper");
            //if (processcollection.Length >= 1)
            //{
            //    //WindowInteropHelper wndHelper = new WindowInteropHelper(this);
            //    //IntPtr TyperHwnd = wndHelper.Handle;                                    //获得窗口句柄
            //    //Window frm = Application.Current.Windows[1];
            //    common.mainwindow.Show();
            //    common.mainwindow.Focus();                                        //获得已有的窗体并聚焦
            //}
            //else
            //{
                
            //}    
        }

        

        
        //void mouse_OnMouseActivity(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    //x_label.Content = e.X;
        //    //y_label.Content = e.Y;
        //    common.move_x = e.X - (Artical.Margin.Left + 0.5 * (this.Width - Artical.Margin.Left - Artical.Margin.Right));
        //    common.move_y = e.Y - (Artical.Margin.Top + 0.5 * (this.Height - Artical.Margin.Top - Artical.Margin.Bottom));
        //    double time = 0.03;
        //    Artical.Margin = new Thickness(common.Artical_left - time * common.move_x, common.Artical_top - time * common.move_y, common.Artical_right, common.Artical_bottom);
        //    type_point.Margin = new Thickness(common.type_point_left - time * common.move_x, common.type_point_top - time * common.move_y, common.type_point_right, common.type_point_bottom);
        //}

        private void main_grid_Initialize()
        {
            //MessageBox.Show("1");
            load_main_grid();
            common.listbox_grid_clear();
            ListBox_Grid.Children.Add(new LeftPart_ListBox());
            common.first_time_loadLeftPartListBox = false;
            if (common.type_Button != null)
                common.type_Button.IsEnabled = false;
            if (common.leftpart_row_num > 13)
                Loadmorearticals.Opacity = 1;
        }

        private void type_grid_Initialize()
        {
            load_type_grid();
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
            common.input_TextBox.Visibility = Visibility.Visible;
            common.input_TextBox.Focus();
            common.first_input = false;
            timer_label.Content = "00:00:00";
            type_speed.Content = "0000";
            common.score_grid_clear();
            common.score_grid.Children.Add(new Score_ListBox());
        }

        private void score_grid_Initialize()
        {
            show_score_grid();
            score_artical_title.Content = common.selectedfile_Name;
            score_date.Content = Convert_Date(DateTime.Now.ToLongDateString());
            score_time.Content = DateTime.Now.ToLongTimeString();
            var speed = string.Format("{0:D4}", (int)((double)common.words / (common.timer_time.Hours * 60 * 60 + common.timer_time.Minutes * 60 + common.timer_time.Seconds) * 60));
            speed_show.Content = speed;
            int accuracy = 100 - (int)((double)common.wrong_type_count / (common.words + common.wrong_type_count) * 100);
            accuracy_show.Content = accuracy.ToString() + "%";
            common.wrong_type_count = 0;
        }

        string space = "";
        //MouseHook mouse = new MouseHook();
        private const int WM_NCHITTEST = 0x0084;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_TIMER = 0x0113;
        private readonly int agWidth = 12; //拐角宽度   
        private readonly int bThickness = 4; // 边框宽度   

        private Point mousePoint = new Point(); //鼠标坐标   

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

        public enum Month
        {
            Jan = 1,
            Feb,
            Mar,
            Apr,
            Jun,
            Jul,
            Aug,
            Sep,
            Oct,
            Nov,
            Dec,
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            System.Windows.Interop.HwndSource hwndSource = PresentationSource.FromVisual((Visual)sender) as System.Windows.Interop.HwndSource;
            hwndSource.AddHook(new System.Windows.Interop.HwndSourceHook(WndProc));

        }   //处理鼠标信息

        private static string Convert_Date(string today)
        {
            int index_year = today.IndexOf('年');    //4
            int index_month = today.IndexOf('月');   //6 or 7
            int index_day = today.IndexOf('日');     //9
            int year = Convert.ToInt16(today.Substring(0, index_year));
            int month = Convert.ToInt16(today.Substring(index_year + 1, index_month - index_year - 1));
            int day = Convert.ToInt16(today.Substring(index_month + 1, index_day - index_month - 1));
            return (Month)month + " " + day + ", " + year;
        }

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

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
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
            common.menu_grid_clear();

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
                        common.addtitle_grid_clear();
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
            common.menu_grid_clear();
            //mouse.Stop();
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
            common.menu_grid_clear();
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
            common.menu_grid_clear();
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

        private void Window_main_Loaded(object sender, RoutedEventArgs e)
        {
            common.mainwindow = sender as Window;
        }

        #region main_grid
        private void load_main_grid()
        {
            Storyboard load = new Storyboard();
            load = this.Resources["load"] as Storyboard;
            load.Begin();

            Timer timer = new Timer(500);
            timer.Elapsed += new ElapsedEventHandler(set_main_grid_visible);
            timer.Start();

            load = this.Resources["show_main_grid"] as Storyboard;
            load.Begin();
        }


        void set_main_grid_visible(object sender, ElapsedEventArgs e)
        {
            Timer current = sender as Timer;
            current.Stop();
            Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate()
            {
                type_grid.Visibility = Visibility.Collapsed;
                score_grid.Visibility = Visibility.Collapsed;
                main_grid.Visibility = Visibility.Visible;
            });
        } 

        private void main_grid_show()
        {
            main_grid.Opacity = 1;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            common.menu_grid_clear();
            common.addtitile_grid_set();
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
            if (Filter.Text == "")
            {
                PART_ClearButton.Visibility = Visibility.Collapsed;
                common.Filter_Name = common.filterarticals_TextBox.Text;
                common.listbox_grid.Children.Clear();
                common.listbox_grid.Children.Add(new LeftPart_ListBox());
                common.whether_selectfile = false;
                common.type_Button.IsEnabled = false;
                if (common.articalinfo_grid.Children != null)
                    common.articalinfo_grid.Children.Clear();
            }
            else
            {
                PART_ClearButton.Visibility = Visibility.Visible;
                if (common.filterarticals_TextBox.Text != "Filter Articals...")                                                                    //textbox点击或已输入字符
                {
                    //MessageBox.Show("1");
                    common.Filter_Name = common.filterarticals_TextBox.Text;
                    common.listbox_grid.Children.Clear();
                    common.listbox_grid.Children.Add(new LeftPart_ListBox());
                    common.whether_selectfile = false;
                    common.type_Button.IsEnabled = false;
                    if (common.articalinfo_grid.Children != null)
                        common.articalinfo_grid.Children.Clear();
                }
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
            common.menu_grid_clear();
            common.addtitle_grid_clear();
        }

        private void GridSplitter_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            common.menu_grid_clear();
            common.addtitle_grid_clear();
        }

        private void ListBox_Grid_Loaded(object sender, RoutedEventArgs e)
        {
            common.listbox_grid = sender as Grid;
            //common.listbox_grid.Height = common.leftpart_row_num * 33;
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

        private void Gear_Loading_Loaded(object sender, RoutedEventArgs e)
        {
            common.metro_loading = sender as UserControl;
            //MessageBox.Show("2");
        }

        private void Loadmorearticals_Loaded(object sender, RoutedEventArgs e)
        {
            common.loadmorearticals_Label = sender as Label;
        }

        private void Type_Loaded(object sender, RoutedEventArgs e)
        {
            common.type_Button=sender as Button;
        }

        private void Type_Click(object sender, RoutedEventArgs e)
        {
            type_grid_Initialize();                       
        }

        #endregion

        #region type_grid

        private void load_type_grid()
        {
            Storyboard load = new Storyboard();
            load = this.Resources["load"] as Storyboard;
            load.Begin();

            Timer timer = new Timer(500);
            timer.Elapsed += new ElapsedEventHandler(set_type_grid_visible);
            timer.Start();

            load = this.Resources["show_type_grid"] as Storyboard;
            load.Begin();
            
        }

        private void ScoreList_Loaded(object sender, RoutedEventArgs e)
        {
            common.score_grid = sender as Grid;
        }

        void set_type_grid_visible(object sender, ElapsedEventArgs e)
        {
            Timer current = sender as Timer;
            current.Stop();
            Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate()
            {
                score_grid.Visibility = Visibility.Collapsed;
                main_grid.Visibility = Visibility.Collapsed;
                type_grid.Visibility = Visibility.Visible;
                common.input_TextBox.Focus();
            });
        } 

        private void InputBox_Loaded(object sender, RoutedEventArgs e)
        {
            common.input_TextBox = sender as TextBox;
            common.input_TextBox.Visibility = Visibility.Visible;
            common.input_TextBox.Focus();
        }

        private void Artical_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock current = sender as TextBlock;
            common.Artical_left = current.Margin.Left;
            common.Artical_top = current.Margin.Top;
            common.Artical_right = current.Margin.Right;
            common.Artical_bottom = current.Margin.Bottom;
        }

        private void type_point_Loaded(object sender, RoutedEventArgs e)
        {
            Image current = sender as Image;
            common.type_point_left = current.Margin.Left;
            common.type_point_top = current.Margin.Top;
            common.type_point_right = current.Margin.Right;
            common.type_point_bottom = current.Margin.Bottom;
        }

        private void words_update()
        {
            words.Content = common.words.ToString() + "/" + (common.selectedfile_Type_Text.Length - 1).ToString();
        }
    
        private void InputBox_PreviewTextInput(object sender, TextCompositionEventArgs e)           //处理中英文输入
        {
            if (common.first_input == false)
            {
                set_timer();
                common.first_input = true;
            }

            

            if (InputBox.Text != "")           //前面有英文字母再输入正确字符的时候不处理
            {                                                                                                                               //InputBox.Text!="" 表示英文输入错误，所以要正规式判断最后输入的是否为英文字母，得清空才能继续输入
                char[] inputbox_ch = InputBox.Text.Substring(0, 1).ToCharArray();
                if ((int)inputbox_ch[0] >= 0 && (int)inputbox_ch[0] <= 127)
                {
                    common.wrong_type_count += e.Text.Length;
                    return;
                }
            }

            if (InputBox.Text.Length != 0 && InputBox.Text.Substring(0, 1) == " ")                                                      //前面有空格再输入正确字符
            {
                common.wrong_type_count += e.Text.Length;
                
                return;
            }

            int i = e.Text.Length;

            
            char[] artical_ch = Artical.Text.Substring(0, 1).ToCharArray();

            if (InputBox.Text.Length != 0)             //前面有中文再输入正确字符
            {
                char[] inputbox_ch = InputBox.Text.Substring(0, 1).ToCharArray();
                if ((int)artical_ch[0] >= 0 && (int)artical_ch[0] <= 127 && (int)inputbox_ch[0] > 127)
                {
                    common.wrong_type_count += e.Text.Length;
                    
                    return;
                }      
            }

            if (Artical.Text.Length == 0)
            {
                stop_time();
                common.first_input = false;
                return;
            }

            
            //int j;

            //if (Regex.Match(e.Text, "^[a-zA-Z]+$").Success)     //英文状态输入的时候 由于inputbox的文本长度会自动归零
            //{
            //    j = e.Text.Length;
            //}
            //else
            //{
            //    j = 0;
            //}

            if (artical_ch[0] > 127)
            {
                if ((InputBox.Text == Artical.Text.Substring(space.Length, i)))             //有前面输入的时候不能进入
                {
                    //if (!Regex.Match(e.Text, "^[a-zA-Z]+$").Success)
                    InputBox.Text = "";
                    //pre_Artical.Text = pre_Artical.Text.Substring(i, pre_Artical.Text.Length - i);
                    //pre_Artical.Text += Artical.Text.Substring(0, i);
                    Artical.Text = Artical.Text.Substring(i, Artical.Text.Length - i);
                    common.words += i;
                    words_update();
                    e.Handled = true;
                }
                else
                {
                    common.wrong_type_count += i;

                    e.Handled = false;
                }
            }
            else
            {
                if ((e.Text == Artical.Text.Substring(space.Length, i)))             //有前面输入的时候不能进入
                {
                    //if (!Regex.Match(e.Text, "^[a-zA-Z]+$").Success)
                    InputBox.Text = "";
                    //pre_Artical.Text = pre_Artical.Text.Substring(i, pre_Artical.Text.Length - i);
                    //pre_Artical.Text += Artical.Text.Substring(0, i);
                    Artical.Text = Artical.Text.Substring(i, Artical.Text.Length - i);
                    common.words += i;
                    words_update();
                    e.Handled = true;
                }
                else
                {
                    common.wrong_type_count += i;

                    e.Handled = false;
                }
            }

            

            if (common.words == common.selectedfile_Type_Text.Length - 1)       //为空则停止计时
            {
                stop_time();
                common.first_input = false;
                common.input_TextBox.Visibility = Visibility.Collapsed;
                save_grade();
                
            }
            //TextBox current = sender as TextBox;
            //InputMethod.Current.ImeSentenceMode = ImeSentenceModeValues.Automatic;
            //MessageBox.Show(e.Text);  

        }

        private void save_grade()
        {
            var speed = string.Format("{0:D4}", (int)((double)common.words / (common.timer_time.Hours * 60 * 60 + common.timer_time.Minutes * 60 + common.timer_time.Seconds) * 60));
            int accuracy = 100 - (int)((double)common.wrong_type_count / (common.words + common.wrong_type_count) * 100);
            string save_file_Path = @"..\..\Data\" + common.ASCII_code(common.selectedfile_Name) + "-" + common.ASCII_code(DateTime.Now.ToLongTimeString()) +".spr";
            FileStream score_file;
            if (File.Exists(save_file_Path) == false)
                score_file = File.Create(save_file_Path);
            else
                score_file = File.Open(save_file_Path, FileMode.Open);

            StreamWriter write_score = new StreamWriter(score_file);
            write_score.BaseStream.Seek(0, SeekOrigin.End);
            common.Set_RSA_key();
            write_score.WriteLine(common.RSAEncrypt(common.public_key, common.selectedfile_Name) + "\n" + common.RSAEncrypt(common.public_key, speed) + "\n" + common.RSAEncrypt(common.public_key, accuracy.ToString()) + "\n" + common.Encode(common.public_key) + "\n" + common.Encode(common.private_key) + "\n" + common.Encode(Convert_Date(DateTime.Now.ToLongDateString())) + "\n" + common.Encode(DateTime.Now.ToLongTimeString()));
            //write_score.WriteLine(common.RSADecrypt(common.private_key, common.RSAEncrypt(common.public_key, common.selectedfile_Name)) + " " + common.RSADecrypt(common.private_key, common.RSAEncrypt(common.public_key, speed)));
            write_score.Flush();
            score_file.Close();

            score_grid_Initialize();//显示score信息
        }

        private void InputBox_TextChanged(object sender, TextChangedEventArgs e)                    //处理空格输入
        {
            if (common.words == common.selectedfile_Type_Text.Length - 1)
            {
                stop_time();
                common.first_input = false;
                common.input_TextBox.Visibility = Visibility.Collapsed;
                save_grade();
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
                e.Handled = true;
            }

            /*处理空格错误输入*/
            if (InputBox.Text.Length <= 1)
            {
                if (InputBox.Text == " " && common.whether_first_space_count == false && Artical.Text.Substring(space.Length, 1) != " ")
                {
                    common.last_input_length = InputBox.Text.Length;
                    common.whether_first_space_count = true;
                    common.wrong_type_count += 1;
                    
                    e.Handled = false;
                }
            }
            else
            {
                if (InputBox.Text.Length > common.last_input_length && InputBox.Text.Substring(InputBox.Text.Length - 1, 1) == " " && Artical.Text.Substring(space.Length, 1) != " ")
                {
                    common.last_input_length = InputBox.Text.Length;
                    common.wrong_type_count += 1;
                    
                    e.Handled = false;
                }
                else
                    common.last_input_length = InputBox.Text.Length;
            }

            if (InputBox.Text == "")
                common.whether_first_space_count = false;
            
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
            var speed = string.Format("{0:D4}", (int)((double)common.words / (common.timer_time.Hours * 60 * 60 + common.timer_time.Minutes * 60 + common.timer_time.Seconds) * 60));
            type_speed.Content = speed;
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

        private void type_grid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Escape)
            {
                show_pause_grid();
                e.Handled = true;
            }
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
        #endregion

        #region score_grid

        private void show_score_grid()
        {
            score_grid.Visibility = Visibility.Visible;
            Storyboard show = new Storyboard();
            show = this.Resources["show_score_grid"] as Storyboard;
            show.Begin();
        }

        private void hide_score_grid()
        {
            Storyboard show = new Storyboard();
            show = this.Resources["hide_score_grid"] as Storyboard;
            show.Begin();
            Timer timer = new Timer(100);
            timer.Elapsed += new ElapsedEventHandler(hide_score_grid_visible);
            timer.Start();            
        }

        void hide_score_grid_visible(object sender, ElapsedEventArgs e)
        {
            Timer current = sender as Timer;
            current.Stop();
            Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate()
            {
                score_grid.Visibility = Visibility.Collapsed;
            });
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            hide_score_grid();
            common.whether_selectfile = false;
            common.time_Label.Opacity = 0;
            common.count_Label.Opacity = 0;
            common.update_at_Label.Opacity = 0;
            common.words_Label.Opacity = 0;
            if (common.articalinfo_grid.Children != null)
                common.articalinfo_grid.Children.Clear();
            main_grid_Initialize();
        }

        private void TryButton_Click(object sender, RoutedEventArgs e)
        {
            hide_score_grid();
            type_grid_Initialize();
        }

        private void PART_ClearButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Filter.Text = "";
        }

        #endregion

        #region pause_grid

        private void ReturnButton_pause_Click(object sender, RoutedEventArgs e)
        {
            hide_pause_grid();
            common.whether_selectfile = false;
            common.time_Label.Opacity = 0;
            common.count_Label.Opacity = 0;
            common.update_at_Label.Opacity = 0;
            common.words_Label.Opacity = 0;
            if (common.articalinfo_grid.Children != null)
                common.articalinfo_grid.Children.Clear();
            main_grid_Initialize();
        }

        private void CancelButton_pause_Click(object sender, RoutedEventArgs e)
        {
            hide_pause_grid();
            if (common.type_timer != null)
                common.type_timer.Start();
            if (common.speed_timer != null)
                common.speed_timer.Start();
            common.input_TextBox.Focus();
        }

        private void TryButton_pause_Click(object sender, RoutedEventArgs e)
        {
            hide_pause_grid();
            type_grid_Initialize();
        }

        private void show_pause_grid()
        {
            if (common.type_timer != null)
                common.type_timer.Stop();
            if (common.speed_timer != null)
                common.speed_timer.Stop();
            pause_grid.Visibility = Visibility.Visible;
            Storyboard show = new Storyboard();
            show = this.Resources["show_pause_grid"] as Storyboard;
            show.Begin();    
        }

        private void hide_pause_grid()
        {
            Storyboard show = new Storyboard();
            show = this.Resources["hide_pause_grid"] as Storyboard;
            show.Begin();
            Timer timer = new Timer(100);
            timer.Elapsed += new ElapsedEventHandler(hide_pause_grid_visible);
            timer.Start();
        }

        void hide_pause_grid_visible(object sender, ElapsedEventArgs e)
        {
            Timer current = sender as Timer;
            current.Stop();
            Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate()
            {
                pause_grid.Visibility = Visibility.Collapsed;
            });
        }

        #endregion

        

        

        

    }
}
