using System.Collections.Generic;

namespace Class_06_OOP.ComputerShop
{
    public class Cart
    {
        public IDictionary<int, Product> Products { get; set; }

        public float TotalCost { get; set; }

        public Cart()
        {
            Products = new Dictionary<int, Product>();
            TotalCost = 0f;
        }

        public void AddProduct(Product product, int amout)
        {
            Products.Add(amout, product);
        }

        public void CalculateTotalCost()
        {
            foreach (KeyValuePair<int, Product> item in Products)
            {
                TotalCost += item.Key * item.Value.Price;
            }
        }
    }
}
