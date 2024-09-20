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
            StackPanel s = this.Content as StackPanel;
            Button b = s.Children[0] as Button;
            b.Content = "Click me";
            #endregion

            #region 有x:Name,直接引用
            button1.Content = "快点击我";
            #endregion

            #region 没有Name属性，使用x:Name去实现引用
            stu1.ID = 12345;
            #endregion
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello WPF!");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(stu1.ID.ToString());
        }
    }

    [TypeConverter(typeof(StringToIntTypeConverter))]
    public class Student
    {
        public int ID { get; set; }
    }
    //public record Teacher(string Name);

    #region 复习一下实现类型转换器
    internal class StringToIntTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            int id = Convert.ToInt32(value);
            return id;
        }
    }
    #endregion
}
