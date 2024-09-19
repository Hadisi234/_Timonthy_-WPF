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

namespace ControlLibrary
{
    /// <summary>
    /// myControlxaml.xaml 的交互逻辑
    /// </summary>
    public partial class myControlxaml : UserControl
    {
        public myControlxaml()
        {
            InitializeComponent();

            #region 没有x:Name去获取对象,间接访问
            Grid g = this.Content as Grid;
            Button b = g.Children[0] as Button;
            b.Content = "Click me";
            #endregion

            #region 有x:Name,直接引用
            button1.Content = "快点击我";
            #endregion
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello WPF!");
        }
    }

    public
}
