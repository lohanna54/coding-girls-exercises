using Class_08_Inheritance.Animal.Enums;

namespace Class_08_Inheritance.Animal
{
	public sealed class Fish : Animal
	{
		public string Characteristic { get; set; }

		public Fish(string name, string color, ENaturalHabitat eNaturalHabitat, int numberOfLegs, float averageSpeed, string characteristic)
			: base(name, color, eNaturalHabitat, numberOfLegs, averageSpeed)
		{
			Characteristic = characteristic;
		}
	}
}
