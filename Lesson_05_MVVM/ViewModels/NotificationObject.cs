using System.ComponentModel;
using Lesson_05_MVVM.Commands;

namespace Lesson_05_MVVM.ViewModels
{
    /// <summary>
    /// ViewModel的基类，具有通知能力的类
    /// 1、ViewModel需要和View交互，它需要将变化通知给View,靠的就是WPF的DataBinding
    /// </summary>
    internal class NotificationObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
