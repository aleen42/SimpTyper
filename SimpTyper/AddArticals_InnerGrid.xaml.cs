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
    /// AddArticals_InnerGrid.xaml 的交互逻辑
    /// </summary>
    public partial class AddArticals_InnerGrid : UserControl
    {
        public AddArticals_InnerGrid()
        {
            InitializeComponent();
            //MessageBox.Show(Browse.IsFocused.ToString());
        }

        //private void AddTitle_Grid_Button_Initilization()
        //{
        //    Button AddTitle_Grid_Button = new Button();
        //    AddTitle_Grid_Button.Name = "AddTitle_Grid_Button_Add";
        //    AddTitle_Grid_Button.Loaded += new RoutedEventHandler(AddTitle_Grid_Button_Add_Loaded);

        //    Innergrid_up.Children.Add(AddTitle_Grid_Button);
        //}

        private void AddTitle_Grid_Button_Add_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            common.AddTitle_Grid_Button_Add.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(@"..\..\Pic/Add_mousepressed.png", UriKind.Relative))
            };
            common.whether_AddTitle_Grid_Button_Add_pressed = true;
            common.AddTitle_Grid_ButtonChoise = AddTitle_Grid_Button.Add;
            Innergrid_Add.Visibility = Visibility.Visible;
            AddTitle_Grid_Button_Create_Loaded(common.AddTitle_Grid_Button_Create, null);
        }

        private void AddTitle_Grid_Button_Add_MouseEnter(object sender, MouseEventArgs e)
        {
            if (common.whether_AddTitle_Grid_Button_Add_pressed == false)
            {
                common.AddTitle_Grid_Button_Add.Opacity = 1;
                common.AddTitle_Grid_Button_Add.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"..\..\Pic/Add_mouseover.png", UriKind.Relative))
                };
            }
            else
            {
                common.AddTitle_Grid_Button_Add.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"..\..\Pic/Add_mouseover(pressed).png", UriKind.Relative))
                };
            }

        }

        private void AddTitle_Grid_Button_Add_MouseLeave(object sender, MouseEventArgs e)
        {
            if (common.whether_AddTitle_Grid_Button_Add_pressed == false)
            {
                common.AddTitle_Grid_Button_Add.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"..\..\Pic/Add_static.png", UriKind.Relative))
                };
                common.AddTitle_Grid_Button_Add.Opacity = 0.5;
            }
            else
            {
                common.AddTitle_Grid_Button_Add.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"..\..\Pic/Add_mousepressed.png", UriKind.Relative))
                };
            }

        }

        private void AddTitle_Grid_Button_Add_Loaded(object sender, RoutedEventArgs e)
        {
            common.AddTitle_Grid_Button_Add = sender as Button;
            if (common.AddTitle_Grid_ButtonChoise == AddTitle_Grid_Button.Add)
            {
                common.whether_AddTitle_Grid_Button_Add_pressed = true;
                common.AddTitle_Grid_Button_Add.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"..\..\Pic/Add_mousepressed.png", UriKind.Relative))
                };
                common.AddTitle_Grid_Button_Add.Opacity = 1;
            }
            else
            {
                common.whether_AddTitle_Grid_Button_Add_pressed = false;
                common.AddTitle_Grid_Button_Add.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"..\..\Pic/Add_static.png", UriKind.Relative))
                };
                common.AddTitle_Grid_Button_Add.Opacity = 0.5;
                common.AddTitle_Grid_Button_Create.Opacity = 1;

            }
        }

        private void AddTitle_Grid_Button_Create_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            common.AddTitle_Grid_Button_Create.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(@"..\..\Pic/Create_mousepressed.png", UriKind.Relative))
            };
            common.whether_AddTitle_Grid_Button_Create_pressed = true;
            common.AddTitle_Grid_ButtonChoise = AddTitle_Grid_Button.Create;
            Innergrid_Add.Visibility = Visibility.Collapsed;
            AddTitle_Grid_Button_Add_Loaded(common.AddTitle_Grid_Button_Add, null);
        }

        private void AddTitle_Grid_Button_Create_MouseEnter(object sender, MouseEventArgs e)
        {

            if (common.whether_AddTitle_Grid_Button_Create_pressed == false)
            {
                common.AddTitle_Grid_Button_Create.Opacity = 1;
                common.AddTitle_Grid_Button_Create.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"..\..\Pic/Create_mouseover.png", UriKind.Relative))
                };
            }
            else
            {
                common.AddTitle_Grid_Button_Create.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"..\..\Pic/Create_mouseover(pressed).png", UriKind.Relative))
                };
            }

        }

        private void AddTitle_Grid_Button_Create_MouseLeave(object sender, MouseEventArgs e)
        {
            if (common.whether_AddTitle_Grid_Button_Create_pressed == false)
            {
                common.AddTitle_Grid_Button_Create.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"..\..\Pic/Create_static.png", UriKind.Relative))
                };
                common.AddTitle_Grid_Button_Create.Opacity = 0.5;
            }
            else
            {
                common.AddTitle_Grid_Button_Create.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"..\..\Pic/Create_mousepressed.png", UriKind.Relative))
                };
            }

        }

        private void AddTitle_Grid_Button_Create_Loaded(object sender, RoutedEventArgs e)
        {
            common.AddTitle_Grid_Button_Create = sender as Button;
            if (common.AddTitle_Grid_ButtonChoise == AddTitle_Grid_Button.Create)
            {
                common.whether_AddTitle_Grid_Button_Create_pressed = true;
                common.AddTitle_Grid_Button_Create.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"..\..\Pic/Create_mousepressed.png", UriKind.Relative))
                };
                common.AddTitle_Grid_Button_Create.Opacity = 1;

            }
            else
            {
                common.whether_AddTitle_Grid_Button_Create_pressed = false;
                common.AddTitle_Grid_Button_Create.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"..\..\Pic/Create_static.png", UriKind.Relative))
                };
                common.AddTitle_Grid_Button_Create.Opacity = 0.5;
                common.AddTitle_Grid_Button_Add.Opacity = 1;
            }
        }

        private void Browse_Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.DefaultExt = ".txt";
            ofd.Filter = "txt file|*.txt";
            if (ofd.ShowDialog() == true)
            {
                Browse.Text = ofd.FileName;
            }
        }

        private void Browse_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            common.Browse_Button.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(@"..\..\Pic/Brows_Button_mouseover.png", UriKind.Relative))
            };
        }

        private void Browse_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            common.Browse_Button.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(@"..\..\Pic/Brows_Button_static.png", UriKind.Relative))
            };
        }

        private void Browse_Button_Loaded(object sender, RoutedEventArgs e)
        {
            common.Browse_Button = sender as Button;
            common.Browse_Button.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(@"..\..\Pic/Brows_Button_static.png", UriKind.Relative))
            };
        }

        private void Innergrid_Loaded(object sender, RoutedEventArgs e)
        {
            common.inner_grid = sender as Grid;
        }

        private void Browse_Loaded(object sender, RoutedEventArgs e)
        {
            common.browse_TextBox = sender as TextBox;
            common.browse_TextBox.Focus();
        }

        private void PART_ContentHostClearButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Browse.Text = "";
        }

        private void Browse_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Browse.Text == "")
                PART_ContentHostClearButton.Visibility = Visibility.Collapsed;
            else
                PART_ContentHostClearButton.Visibility = Visibility.Visible;
        }
    }
}
