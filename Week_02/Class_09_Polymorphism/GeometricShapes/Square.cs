using Class_09_Polymorphism.GeometricShapeBase;
using System;

namespace Class_09_Polymorphism.GeometricShapes
{
	public class Square : FlatGeometricShape
	{
		private float Side;

		public Square()
		{
			Side = 0f;
		}

		public override void CalculateArea()
		{
			Console.WriteLine("Informe a o tamanho dos lados do quadrado");

			Side = float.Parse(Console.ReadLine());
			Area = Side * Side;
		}
	}
}