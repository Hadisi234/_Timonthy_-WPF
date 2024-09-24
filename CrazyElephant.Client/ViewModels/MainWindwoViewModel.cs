using CrazyElephant.Client.Models;
using CrazyElephant.Client.Services;
using CrazyElephant.Client.Views;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CrazyElephant.Client.ViewModels
{
    internal class MainWindwoViewModel : NotificationObject
    {
        public DelegateCommand PlaceOrderCommand { get; set; }
        public DelegateCommand SelectMenuItemCommand { get; set; }

        private int count;
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
                this.RaisePropertyChanged(nameof(Count));
            }
        }

        private Restaurant restaurant;
        public Restaurant Restaurant
        {
            get
            {
                return restaurant;
            }
            set
            {
                restaurant = value;
                this.RaisePropertyChanged(nameof(Restaurant));
            }
        }

        private List<DishMenuItemViewModel> dishMenu;
        public List<DishMenuItemViewModel> DishMenu
        {
            get
            {
                return dishMenu;
            }
            set
            {
                dishMenu = value;
                this.RaisePropertyChanged(nameof(DishMenu));
            }
        }
        public MainWindwoViewModel()
        {
            this.LoadRestaurant();
            this.LoadDishMenu();
            this.PlaceOrderCommand = new DelegateCommand(new Action(PlaceOrderCommandExcute));
            this.SelectMenuItemCommand = new DelegateCommand(new Action(SelectMenuItemCommandExcute));
        }


        private void LoadRestaurant()
        {
            Restaurant = new Restaurant();
            Restaurant.Name = "Crazy大象";
            Restaurant.Addresss = "北京市海淀区万泉河路紫金庄园1号楼 1层113室";
            Restaurant.PhoneNumber = "1234567890";
        }

        private void LoadDishMenu()
        {
            XmlDataService ds = new XmlDataService();
            var dishes = ds.GetAllDishes();
            this.DishMenu = new List<DishMenuItemViewModel>();
            foreach (var dish in dishes)
            {
                DishMenuItemViewModel dishMenuItem = new DishMenuItemViewModel();
                dishMenuItem.dish = dish;
                this.DishMenu.Add(dishMenuItem);
            }
        }

        private void PlaceOrderCommandExcute()
        {
            var selectedDishes = this.DishMenu.Where(i => i.IsSelected == true)
                .Select(i => i.dish.Name).ToList();
            IOrderService orderService = new MockOrderService();
            orderService.PlaceOrder(selectedDishes);
            MessageBox.Show("订餐成功！");
        }

        private void SelectMenuItemCommandExcute()
        {
            this.Count = this.DishMenu.Count(i => i.IsSelected == true);
        }
    }
}
