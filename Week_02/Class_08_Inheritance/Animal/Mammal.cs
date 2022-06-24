using Class_08_Inheritance.Animal.Enums;

namespace Class_08_Inheritance.Animal
{
	public sealed class Mammal : Animal
	{
		public string Food { get; set; }

		public Mammal(string name, string color, ENaturalHabitat eNaturalHabitat, int numberOfLegs, float averageSpeed, string food)
			: base(name, color, eNaturalHabitat, numberOfLegs, averageSpeed)
		{
			Food = food;
		}
	}
}