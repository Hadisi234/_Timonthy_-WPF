using Microsoft.Win32;
using System.Windows;

namespace _Timonthy_深入浅出WPF
{
    /// <summary>
    /// Lesson_05_不使用MVVM_Demo.xaml 的交互逻辑
    /// </summary>
    public partial class Lesson_05_不使用MVVM_Demo : Window
    {
        public Lesson_05_不使用MVVM_Demo()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            //double d1 = double.Parse(this.lb1.Text);
            //double d2 = double.Parse(this.lb2.Text);
            //double result = d1 + d2;
            //this.lb3.Text = result.ToString();
            this.slider3.Value = slider1.Value + slider2.Value;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
        }
    }
}
