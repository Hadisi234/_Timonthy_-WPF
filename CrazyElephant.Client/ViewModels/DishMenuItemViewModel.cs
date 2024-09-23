using CrazyElephant.Client.Models;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyElephant.Client.ViewModels
{
    internal class DishMenuItemViewModel : NotificationObject
    {
        public Dish dish { get; set; }

		private bool isSelected;
		public bool IsSelected
		{
			get { return isSelected; }
			set 
			{ 
				isSelected = value; 
				this.RaisePropertyChanged(nameof(IsSelected));
			}
		}

	}
}
