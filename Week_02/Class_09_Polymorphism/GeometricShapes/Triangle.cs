using Class_09_Polymorphism.GeometricShapeBase;
using System;

namespace Class_09_Polymorphism.GeometricShapes
{
	public class Triangle : FlatGeometricShape
	{
		private float Base;
		private float Height;

		public Triangle()
		{
			Base = 0f;
			Height = 0f;
		}

		public override void CalculateArea()
		{
			Console.WriteLine("Informe a base do triângulo");
			Base = float.Parse(Console.ReadLine());

			Console.WriteLine("Informe a altura do triângulo");
			Height = float.Parse(Console.ReadLine());

			Area = (Base * Height) / 2;
		}
	}
}
