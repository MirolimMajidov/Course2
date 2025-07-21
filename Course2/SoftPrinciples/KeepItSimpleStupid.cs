namespace SoftPrinciples
{
    public class KissClass
    {
        public void ProcessOrder(Order order)
        {
            // Validate order
            if (order == null || order.Items == null || !order.Items.Any())
            {
                Console.WriteLine("Invalid order.");
                return;
            }

            // Calculate total
            decimal total = 0;
            foreach (var item in order.Items)
            {
                total += item.Price * item.Quantity;
            }

            // Apply discount
            if (order.Customer.IsPremium)
            {
                total *= 0.9m; // 10% discount
            }

            // Save to database (simulated)
            Console.WriteLine("Saving order to database...");

            // Send confirmation email (simulated)
            Console.WriteLine($"Sending confirmation email to {order.Customer.Email}...");

            Console.WriteLine($"Order processed. Total: {total:C}");
        }
        
        public void ProcessOrder2(Order order)
        {
            if (!IsValidOrder(order))
            {
                Console.WriteLine("Invalid order.");
                return;
            }

            decimal total = CalculateTotal(order);
            SaveOrder(order, total);
            SendConfirmationEmail(order.Customer);

            Console.WriteLine($"Order processed. Total: {total:C}");
        }

        private bool IsValidOrder(Order order)
        {
            return order != null && order.Items != null && order.Items.Any();
        }

        private decimal CalculateTotal(Order order)
        {
            decimal total = order.Items.Sum(item => item.Price * item.Quantity);
            if (order.Customer.IsPremium)
            {
                total *= 0.9m; // Apply 10% discount
            }
            return total;
        }

        private void SaveOrder(Order order, decimal total)
        {
            Console.WriteLine("Saving order to database...");
            // Simulated save
        }

        private void SendConfirmationEmail(Customer customer)
        {
            Console.WriteLine($"Sending confirmation email to {customer.Email}...");
            // Simulated email
        }

    }
}
