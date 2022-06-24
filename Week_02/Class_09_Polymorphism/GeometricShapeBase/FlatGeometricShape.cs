namespace Class_09_Polymorphism.GeometricShapeBase
{
	public abstract class FlatGeometricShape
	{
		public const float PI = 3.14f;

		public float Area { get; protected set; }

		public abstract void CalculateArea();
	}
}