namespace Class_06_OOP.ComputerShop
{
    public class Bill
    {
        public int Number { get; set; }

        public Cart Items { get; set; }

        public float Total { get; set; }

        public Bill(int number, Cart cart)
        {
            Number = number;
            Items = cart;
            Total = cart.TotalCost;
        }
    }
}
