using Class_09_Polymorphism.GeometricShapeBase;
using System;

namespace Class_09_Polymorphism.GeometricShapes
{
	public class Circle : FlatGeometricShape
	{
		private float Radius;

		public Circle()
		{
			Radius = 0f;
		}

		public override void CalculateArea()
		{
			Console.WriteLine("Informe o raio do círculo");
			Radius = float.Parse(Console.ReadLine());

			Area = PI * (Radius * Radius);
		}
	}
}
