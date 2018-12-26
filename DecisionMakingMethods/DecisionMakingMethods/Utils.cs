using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumericalAnalysisLibrary.MathStructures;

namespace DecisionMakingMethods
{
    static class Utils
    {
        public static double FindMaxInMatrix(Matrix matrix, int rowStart, int rowEnd, int colStart, int colEnd)
        {
            double max = double.NegativeInfinity;

            for (int i = rowStart; i <= rowEnd; i++)
            {
                for (int j = colStart; j <= colEnd; j++)
                {
                    if (max < matrix[i, j])
                    {
                        max = matrix[i, j];
                    }
                }
            }

            return max;
        }
        public static double FindMinInMatrix(Matrix matrix, int rowStart, int rowEnd, int colStart, int colEnd)
        {
            double min = double.PositiveInfinity;

            for (int i = rowStart; i <= rowEnd; i++)
            {
                for (int j = colStart; j <= colEnd; j++)
                {
                    if (min > matrix[i, j])
                    {
                        min = matrix[i, j];
                    }
                }
            }

            return min;
        }
    }
}
