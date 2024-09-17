using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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

namespace _Timonthy_深入浅出WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Human h = this.FindResource("human") as Human;//铁锰哥说所有的WPF资源都是通过ResourcesDictionary来维护的
            if (h != null && h.Child != null)
            {
                MessageBox.Show(h.Name, "展示内容");
                MessageBox.Show(h.Child.Name, "孩子的名字");
            }
        }
    }

    #region 实现类型转换器
    [TypeConverter(typeof(NameToHumanTypeConverter))]
    public class Human
    {
        public string Name { get; set; }
        public Human Child { get; set; }
    }
    public class NameToHumanTypeConverter : TypeConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value">在Xaml中的字符串的值</param>
        /// <returns></returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string name = value.ToString();
            Human child = new Human();
            child.Name = name;
            return child;//孩子的孩子应该为空，还没有着落。
            //return base.ConvertFrom(context, culture, value);
        }
    }
    #endregion
}
