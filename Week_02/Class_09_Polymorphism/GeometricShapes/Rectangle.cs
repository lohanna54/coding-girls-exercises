using Class_09_Polymorphism.GeometricShapeBase;
using System;

namespace Class_09_Polymorphism.GeometricShapes
{
	public class Rectangle : FlatGeometricShape
	{
		private float Base;
		private float Height;

		public Rectangle()
		{
			Base = 0f;
			Height = 0f;
		}

		public override void CalculateArea()
		{
			Console.WriteLine("Informe a base do retângulo");
			Base = float.Parse(Console.ReadLine());

			Console.WriteLine("Informe a altura do retângulo");
			Height = float.Parse(Console.ReadLine());

			Area = Base * Height;
		}
	}
}
