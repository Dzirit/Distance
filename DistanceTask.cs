using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
		// Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
			// Знаменатель этого выражения равен расстоянию между точками а и b. Числитель равен удвоенной площади треугольника с вершинами 
			//var result = Math.Abs((by - ay) * x - (bx - ax) * y + bx * ay - by * ax) / Math.Sqrt(Math.Pow((by - ay), 2) + Math.Pow((bx - ax), 2));			
			var deltaABx = ax - bx;
			var deltaABy = ay - by;
			var deltaACx = ax - x;
			var deltaACy = ay - y;
			var deltaBCx = bx - x;
			var deltaBCy = by - y;
			var scalarAbAc= deltaABx * deltaACx + deltaABy * deltaACy;
			var scalarBcBa = deltaBCx * (-deltaABx) + deltaBCy * (-deltaABy);
			var lenghtAC = Math.Sqrt(Math.Pow((y - ay), 2) + Math.Pow((x - ax), 2));
			var lenghtBC = Math.Sqrt(Math.Pow((y - by), 2) + Math.Pow((x - bx), 2));
			if (scalarAbAc<0 || scalarBcBa<0)
			{
				return Math.Min(lenghtAC, lenghtBC);
			}
			return  Math.Abs((by - ay) *(x-ax) - (bx - ax) * (y-ay)) / Math.Sqrt(Math.Pow((by - ay), 2) + Math.Pow((bx - ax), 2)); 
		}
	}
}