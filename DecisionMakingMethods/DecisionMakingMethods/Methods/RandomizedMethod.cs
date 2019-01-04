using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NumericalAnalysisLibrary.MathStructures;
using NumericalAnalysisLibrary.Functions;

namespace DecisionMakingMethods.Methods
{
    public abstract class RandomizedMethod : DecisionMakingMethod
    {
        protected abstract float WeightForPointUpper(PointF point);
        protected abstract float WeightForPointDown(PointF point);

        protected abstract MathFunction UpperOptimalLevelLine(double loss);
        protected abstract MathFunction DownOptimalLevelLine(double loss);

        protected virtual Tuple<double[], double, PointF> DetermineSolution(List<Tuple<int, PointF>> northwesternCorner, int solutionsCount)
        {
            var solution = new double[solutionsCount];

            var upPart = northwesternCorner.Where(item => item.Item2.Y >= item.Item2.X).ToList();
            var downPart = northwesternCorner.Where(item => item.Item2.Y < item.Item2.X).ToList();

            var downWeight = downPart.Min(item => WeightForPointDown(item.Item2));
            var downBest = downPart.Find(item => WeightForPointDown(item.Item2) == downWeight);

            var upWeight = upPart.Min(item => WeightForPointUpper(item.Item2));
            var upBest = upPart.Find(item => WeightForPointUpper(item.Item2) == upWeight);

            var x = (downBest.Item2.Y - downBest.Item2.X) / (upBest.Item2.X - downBest.Item2.X + downBest.Item2.Y - upBest.Item2.Y);
            var middleWeight = x * upBest.Item2.X + (1 - x) * downBest.Item2.X;
            var middlePoint = new PointF(middleWeight, middleWeight);

            if (middleWeight <= downWeight && middleWeight <= upWeight)
            {
                solution[upBest.Item1] = x;
                solution[downBest.Item1] = 1 - x;

                return new Tuple<double[], double, PointF>(solution, middleWeight, middlePoint);
            }
            else if (downWeight <= middleWeight && downWeight <= upWeight)
            {
                solution[downBest.Item1] = 1;

                return new Tuple<double[], double, PointF>(solution, downWeight, downBest.Item2);
            }
            else
            {
                solution[upBest.Item1] = 1;

                return new Tuple<double[], double, PointF>(solution, upWeight, upBest.Item2);
            }
        }

        public override object Solve(Matrix qMatrix)
        {
            if (qMatrix.ColumnsCount != 2)
            {
                throw new ArgumentException("Matrix columns count must be equal to 2!", "qMatrix");
            }

            var anchorMatrix = AnchorMatrix(qMatrix);
            var points = GetPoints(anchorMatrix);
            var convexHull = ConvexHull(points);
            var northwesternPart = GetNorthWesternPart(convexHull);

            var solution = DetermineSolution(northwesternPart, qMatrix.RowsCount);

            return new Tuple<double[], double, PointF, Matrix, PointF[], Tuple<int, PointF>[], Tuple<int, PointF>[], Tuple<MathFunction, MathFunction>>(
                solution.Item1,
                solution.Item2,
                solution.Item3,
                anchorMatrix,
                points.Select(item => item.Item2).ToArray(),
                convexHull.ToArray(),
                northwesternPart.ToArray(),
                new Tuple<MathFunction, MathFunction>(UpperOptimalLevelLine(solution.Item2), DownOptimalLevelLine(solution.Item2)));
        }

        protected virtual Matrix AnchorMatrix(Matrix qMatrix)
        {
            return GetLossesMatrix(qMatrix);
        }

        protected List<Tuple<int, PointF>> GetPoints(Matrix matrix)
        {
            var points = new List<Tuple<int, PointF>>();

            for (int i = 0; i < matrix.RowsCount; i++)
            {
                points.Add(new Tuple<int, PointF>(i, new PointF((float)matrix[i, 0], (float)matrix[i, 1])));
            }

            return points;
        }

        protected List<Tuple<int, PointF>> ConvexHull(List<Tuple<int, PointF>> points)
        {
            if (points.Count < 3)
            {
                return points;
            }

            List<Tuple<int, PointF>> hull = new List<Tuple<int, PointF>>();

            // get leftmost point
            var minX = points.Min(item => item.Item2.X);
            Tuple<int, PointF> vPointOnHull = points.Where(item => item.Item2.X == minX).First();

            Tuple<int, PointF> vEndpoint;
            do
            {
                hull.Add(vPointOnHull);
                vEndpoint = points[0];

                for (int i = 1; i < points.Count; i++)
                {
                    if ((vPointOnHull.Item2 == vEndpoint.Item2)
                        || (Orientation(vPointOnHull.Item2, vEndpoint.Item2, points[i].Item2) == -1))
                    {
                        vEndpoint = points[i];
                    }
                }

                vPointOnHull = vEndpoint;

            }
            while (vEndpoint != hull[0]);

            return hull;
        }
        private int Orientation(PointF p1, PointF p2, PointF p)
        {
            // Determinant
            float Orin = (p2.X - p1.X) * (p.Y - p1.Y) - (p.X - p1.X) * (p2.Y - p1.Y);

            if (Orin > 0)
                return -1; //          (* Orientation is to the left-hand side  *)
            if (Orin < 0)
                return 1; // (* Orientation is to the right-hand side *)

            return 0; //  (* Orientation is neutral aka collinear  *)
        }

        protected List<Tuple<int, PointF>> GetNorthWesternPart(List<Tuple<int, PointF>> points)
        {
            var minY = points.Min(point => point.Item2.Y);
            var minX = points.Min(point => point.Item2.X);

            var pointX = points.Find(point => point.Item2.X == minX);
            var pointY = points.Find(point => point.Item2.Y == minY);

            var northwestern = points.Where(point => (point.Item2.X >= pointX.Item2.X && point.Item2.X <= pointY.Item2.X) && 
                                         (point.Item2.Y >= pointY.Item2.Y && point.Item2.Y <= pointX.Item2.Y))
                         .ToList();

            var origin = new PointF(0, 0);
            northwestern.Sort((p1, p2) => Orientation(p1.Item2, p2.Item2, origin));

            return northwestern;
        }
    }
}
