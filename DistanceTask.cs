using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
		// Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
			//Напишите метод вычисления расстояния от отрезка до точки.

			//Для проверки своего решения запустите скачанный проект.

			//Расстоянием от отрезка до точки называется расстояние от ближайшей точки отрезка до точки.Это либо расстояние до точки от прямой, 
			//содержащей отрезок, либо расстояние до точки от одного из концов отрезка.
			// Знаменатель этого выражения равен расстоянию между точками а и b. Числитель равен удвоенной площади треугольника с вершинами 
			//var result = Math.Abs((by - ay) * x - (bx - ax) * y + bx * ay - by * ax) / Math.Sqrt(Math.Pow((by - ay), 2) + Math.Pow((bx - ax), 2));	
			//вычисляем координаты векторов
			var deltaABx = ax - bx;
			var deltaABy = ay - by;
			var deltaACx = ax - x;
			var deltaACy = ay - y;
			var deltaBCx = bx - x;
			var deltaBCy = by - y;
			//вычисляем скалярное произведение векторов
			var scalarAbAc = deltaABx * deltaACx + deltaABy * deltaACy;
			var scalarBcBa = deltaBCx * (-deltaABx) + deltaBCy * (-deltaABy);
			//скалярное произведение векторов от отрезка до точки отрицательное, значит перепендикуляр от точки не падает на отрезок, а падает на его продолжение
			if (scalarAbAc < 0 || scalarBcBa < 0)
			{
				//находим длину векторов
				var lenghtAC = Math.Sqrt(Math.Pow((y - ay), 2) + Math.Pow((x - ax), 2));
				var lenghtBC = Math.Sqrt(Math.Pow((y - by), 2) + Math.Pow((x - bx), 2));
				return Math.Min(lenghtAC, lenghtBC);
			}
			//else if (deltaABx == 0 || deltaABy == 0) return Math.Sqrt(Math.Pow((ay - y), 2) + Math.Pow((ax - x), 2));
			//иначе находтм длину перпендикуляра, которая является ысотой треугольника.
			if (Math.Sqrt(Math.Pow((by - ay), 2) + Math.Pow((bx - ax), 2)) == 0) return Math.Sqrt(Math.Pow((ay - y), 2) + Math.Pow((ax - x), 2)); // проверка что вектор не нулевой.
			double result = Math.Abs((by - ay) * (x - ax) - (bx - ax) * (y - ay)) / Math.Sqrt(Math.Pow((by - ay), 2) + Math.Pow((bx - ax), 2));
			return result;
		}
	}
}