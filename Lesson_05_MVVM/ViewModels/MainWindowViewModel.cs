using Lesson_05_MVVM.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_05_MVVM.ViewModels
{
    internal class MainWindowViewModel : NotificationObject
    {
        #region 数据属性
        private double input1;

        public double Input1
        {
            get { return input1; }
            set
            {
                input1 = value;
                this.RaisePropertyChanged("Input1");
            }
        }
        private double input2;

        public double Input2
        {
            get { return input2; }
            set
            {
                input2 = value;
                this.RaisePropertyChanged("Input2");
            }
        }

        private double result;

        public double Result
        {
            get { return result; }
            set
            {
                result = value;
                this.RaisePropertyChanged("Result");
            }
        }
        #endregion

        #region 命令属性
        public DelegateCommand AddCommand { get; set; }

        private void Add(object parameter)
        {
            this.Result = this.Input1 + this.Input2;
        }

        public DelegateCommand SaveCommand { get; set; }
        private void Save(object parameter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.ShowDialog();
        }
        #endregion

        public MainWindowViewModel()
        {
            AddCommand = new DelegateCommand();
            AddCommand.ExecuteAction += this.Add;
            SaveCommand = new DelegateCommand();
            SaveCommand.ExecuteAction = this.Save;
        }
    }
}
