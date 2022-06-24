using System;
using System.Collections.Generic;

namespace Class_08_Inheritance.Animal
{
	public static class AnimalKingdom
	{
		private static IList<Fish> Fish { get; }

		private static IList<Mammal> Mammals { get; }

		static AnimalKingdom()
		{
			Fish = new List<Fish>();
			Mammals = new List<Mammal>();
		}

		public static void AddFish(Fish fish)
		{
			Fish.Add(fish);
		}

		public static void AddMammal(Mammal mammal)
		{
			Mammals.Add(mammal);
		}

		public static void ShowAnimals()
		{
			Console.WriteLine("\n--- Lista animais cadastrados ---\n");
			foreach (var fish in Fish)
			{
				fish.ShowData();
			}

			foreach (var mammal in Mammals)
			{
				mammal.ShowData();
			}
		}
	}
}
