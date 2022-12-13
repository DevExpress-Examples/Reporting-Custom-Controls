using System.Collections.Generic;
using DevExpress.XtraReports.CustomControls.SwissQRBill;

namespace CustomControlExample {
    public class OrderItem {
        public int ProductCode { get; set; }
        public double Amount { get; set; }
        public int Count { get; set; }
        public string ProductName { get; set; }
    }

    public class Order {
        public List<OrderItem> InvoiceItems { get; } = new List<OrderItem>();
        public int OrderNumber { get; set; }
        public string BillItemStringInfo { get; set; }
    }

    public static class DataSource {
        public static List<Order> GetOrders() {
            return new List<Order>() {
                new Order() { BillItemStringInfo = TestData.BillWithTwoProcedures, OrderNumber=564245, 
                    InvoiceItems = { new OrderItem() { Amount = 20, Count = 3, ProductCode = 1, ProductName = "Coffee" },
                                     new OrderItem() { Amount = 10, Count = 2, ProductCode = 2, ProductName = "Tea" },
                                     new OrderItem() { Amount = 2.30, Count = 1, ProductCode = 3, ProductName = "Gum" },
                                     new OrderItem() { Amount = 5, Count = 1, ProductCode = 4, ProductName = "Small Coffee" },
                                     new OrderItem() { Amount = 20, Count = 10, ProductCode = 5, ProductName = "Milk" },
                }},
                new Order() { BillItemStringInfo = TestData.BillWithFullBillInfo, OrderNumber=564246, 
                    InvoiceItems = { new OrderItem() { Amount = 30, Count = 2, ProductCode = 1, ProductName = "Coffee"},
                                     new OrderItem() { Amount = 5, Count = 4, ProductCode = 2, ProductName = "Tea"},
                                     new OrderItem() { Amount = 2.30, Count = 1, ProductCode = 3, ProductName = "Gum"},
                                     new OrderItem() { Amount = 5, Count = 1, ProductCode = 4, ProductName = "Small Coffee"},
                                     new OrderItem() { Amount = 10, Count = 20, ProductCode = 5, ProductName = "Milk"},
                }},
            };
        }
    }
}
