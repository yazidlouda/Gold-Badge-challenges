using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Repo
{
    public class MenuRepository
    {
        private List<Menu> _orders = new List<Menu>();
        public void AddOrder(Menu order)
        {
            _orders.Add(order);
        }

        public Menu GetdOrderByNumber(int orderNumber)
        {
            foreach (Menu menuItem in _orders)
            {
                if (menuItem.OrderNumber == orderNumber)
                {
                    return menuItem;
                }
            }
            return null;
        }

        public bool RemoveOrder(Menu order)
        {
            int initialCount = _orders.Count;

            _orders.Remove(order);

            if (initialCount > _orders.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Menu> ListOrders()
        {
            return _orders;
        }

    }
}
