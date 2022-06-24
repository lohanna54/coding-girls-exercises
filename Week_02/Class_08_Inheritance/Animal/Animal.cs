using Class_08_Inheritance.Animal.Enums;
using System;

namespace Class_08_Inheritance.Animal
{
	public abstract class Animal
	{
		protected string Name { get; set; }

		protected string Color { get; set; }

		protected ENaturalHabitat NaturalHabitat { get; set; }

		protected int NumberOfLegs { get; set; }

		protected float AverageSpeed { get; set; }

		protected Animal(string name, string color, ENaturalHabitat eNaturalHabitat, int numberOfLegs, float averageSpeed)
		{
			Name = name;
			Color = color;
			NaturalHabitat = eNaturalHabitat;
			NumberOfLegs = numberOfLegs;
			AverageSpeed = averageSpeed;
		}

		public void ShowData()
		{
			Console.WriteLine("\n--- Dados do animal ---");
			Console.WriteLine($"Nome: {Name}");
			Console.WriteLine($"Cor: {Color}");
			Console.WriteLine($"Habitat Natural: {NaturalHabitat}");
			Console.WriteLine($"Quantidade de patas/nadadeiras: {NumberOfLegs}");
			Console.WriteLine($"Velocidade média: {AverageSpeed}");
		}
	}
}
