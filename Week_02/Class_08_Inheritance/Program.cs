using Class_08_Inheritance.Animal;
using Class_08_Inheritance.Animal.Enums;
using System;
using System.Threading;

namespace Class_08_Inheritance
{
	public static class Program
	{
		public static void Main()
		{
			var fish = new Fish("Nemo", "Vermelho-ferrugem", ENaturalHabitat.Aquatic, 7, 3.2f, "Nadar");

			AnimalKingdom.AddFish(fish);

			fish.ShowData();

			var cat = new Mammal("Garfield", "Caramelo", ENaturalHabitat.Terrestrial, 6, 48f, "Whiskas");

			AnimalKingdom.AddMammal(cat);

			cat.ShowData();

			AnimalKingdom.ShowAnimals();

			Console.WriteLine("Pressione qualquer tecla para sair");
			Console.ReadKey();

			Console.WriteLine("Finalizando...");
			Thread.Sleep(3000);
			Environment.Exit(0);
		}
	}
}
