using Class_09_Polymorphism.GeometricShapes;
using System;
using System.Threading;

namespace Class_09_Polymorphism
{
	public static class Program
	{
		public static void Main()
		{
			Console.WriteLine("\n--- Cálculo de Formas Geométricas ---\n");
			Console.WriteLine("1. Quadrado\n2. Retângulo\n3. Triângulo\n4. Círculo");

			if (int.TryParse(Console.ReadLine(), out int shape) && shape is >= 1 and <= 4)
			{
				switch (shape)
				{
					case 1:
						var square = new Square();
						square.CalculateArea();

						Console.WriteLine(square.Area);

						break;
					case 2:
						var rectangle = new Rectangle();
						rectangle.CalculateArea();

						Console.WriteLine(rectangle.Area);

						break;
					case 3:
						var triangle = new Triangle();
						triangle.CalculateArea();

						Console.WriteLine(triangle.Area);

						break;
					case 4:
						var circle = new Circle();
						circle.CalculateArea();

						Console.WriteLine(circle.Area);

						break;
				}

				AskToExecuteAgain();
			}
			else
			{
				Console.WriteLine("Opção inválida");
			}
		}

		public static void AskToExecuteAgain()
		{
			Console.WriteLine("\nDeseja realizar outra operação? S/N");
			var executeAgain = Console.ReadLine();

			if (string.Equals(executeAgain, "s", StringComparison.OrdinalIgnoreCase))
			{
				Main();
			}
			else
			{
				Console.WriteLine("Finalizando...");
				Thread.Sleep(3000);
				Environment.Exit(0);
			}
		}
	}
}