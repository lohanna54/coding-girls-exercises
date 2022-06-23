using System;

namespace Class_06_OOP.ComputerShop
{
    public static class Shop
    {
        private static readonly Cart Cart = new();
        private static int BillCount;

        public static void Start()
        {
            bool shouldExecute;

            do
            {
                var product = CreateProcuct();

                UpdateCart(product);

                Console.WriteLine("Deseja inserir outro produto? S/N");

                shouldExecute = char.ToUpper(Console.ReadLine()[0]) is 'S';

            } while (shouldExecute);

            var bill = BuildCartBill(Cart);

            Console.WriteLine($"Valor da fatura: {bill.Total}");
        }

        private static void UpdateCart(Product product)
        {
            Console.WriteLine("Insira a quantidade desejada");
            var amount = int.Parse(Console.ReadLine());

            Cart.AddProduct(product, amount);
        }

        private static Product CreateProcuct()
        {
            Console.WriteLine("Insira o nome do produto que deseja adicionar ao carrinho");
            var productName = Console.ReadLine();

            Console.WriteLine("Insira o valor deste produto");
            var productPrice = float.Parse(Console.ReadLine());

            return new Product(productName, productPrice);
        }

        private static Bill BuildCartBill(Cart cart)
        {
            cart.CalculateTotalCost();

            var billNumber = BillCount++;

            return new Bill(billNumber, cart);
        }
    }
}
