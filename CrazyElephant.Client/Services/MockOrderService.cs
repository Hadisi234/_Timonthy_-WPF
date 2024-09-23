using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyElephant.Client.Services
{
    internal class MockOrderService : IOrderService
    {
        public void PlaceOrder(List<string> dishes)
        {
            string filePath = @"D:\CodeFiles\TestDirectory";
            string fileName = "order.txt";
            string path = Path.Combine(filePath, fileName);
            if (!Directory.Exists(filePath))Directory.CreateDirectory(filePath);
            System.IO.File.WriteAllLines(path, dishes.ToArray());
        }
    }
}
