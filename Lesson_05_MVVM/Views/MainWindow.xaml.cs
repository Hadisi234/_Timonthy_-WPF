using Lesson_05_MVVM.ViewModels;
using System.Windows;

namespace Lesson_05_MVVM.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            //this.DataContext = new MainWindowViewModel();//在这里设置程序运行的时候才会识别出来，不会报错。
            //可以在Xaml中设置， xmlns:viewmodels="clr-namespace:Lesson_05_MVVM.ViewModels" d:DataContext="{d:DesignInstance Type=viewmodels:MainWindowViewModel}"
            //设置在Xaml中更方便，可以方便代码推断，突然发现只是推断，没有实际效果
        }

    }
}
