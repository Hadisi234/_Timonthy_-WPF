using System.ComponentModel;
using System.Globalization;
using System.Windows;

namespace _Timonthy_深入浅出WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    internal partial class MainWindow : Window
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

        /// <summary>
        /// 这个事件实际上就是自己的事件被自己的对象订阅，事件处理器就是这个方法。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello WPF!");
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
