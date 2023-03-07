using System;
using System.ComponentModel.DataAnnotations;
using GridCore.Server;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;

namespace GridTest
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string Street { get; set; }
    }

    public class OrderService
    {
        public ItemsDTO<Order> GetOrdersGridRows(Action<IGridColumnCollection<Order>> columns,
                QueryDictionary<StringValues> query)
        {
            var items = new List<Order>() {
                new Order() {CustomerID = "1", OrderID = 1, Street = "Test"},
                new Order() {CustomerID = "2", OrderID = 2, Street = "Test"},
                new Order() {CustomerID = "3", OrderID = 3, Street = "Test"}
            };
            var server = new GridCoreServer<Order>(items, query,
                true, "ordersGrid", columns, 10).Sortable().Filterable();

            // return items to displays
            return server.ItemsToDisplay;
        }
    }
}

