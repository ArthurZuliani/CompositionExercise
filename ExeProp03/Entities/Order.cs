using System;
using System.Collections.Generic;
using System.Text;
using ExeProp03.Entities.Enums;
using System.Globalization;

namespace ExeProp03.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Orders { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        public Order()
        {

        }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Orders.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Orders.Remove(item);
        }

        public double Total()
        {
            double sum = 0.0;

            foreach(OrderItem orderitem in Orders)
            {
                sum += orderitem.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ORDER SUMMARY:");
            sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order status: " + (Status));
            sb.AppendLine("Client: " 
                           + Client.Name 
                           + "  (" + Client.BirthDate.ToString("dd/MM/yyyy") 
                           + ") - " + Client.Email);

            sb.AppendLine("Order items: ");

            foreach(OrderItem orderItem in Orders)
            {
                sb.AppendLine(orderItem.Product.Name
                              + ", $"
                              + orderItem.Product.Price.ToString("F2",CultureInfo.InvariantCulture)
                              + ", Quantity: "
                              + orderItem.Quantity
                              + ", Subtotal: $"
                              + orderItem.SubTotal().ToString("F2", CultureInfo.InvariantCulture)
                              );
            }

            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
