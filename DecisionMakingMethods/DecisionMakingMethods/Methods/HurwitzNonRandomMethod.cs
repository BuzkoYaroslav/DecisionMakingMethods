using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumericalAnalysisLibrary.MathStructures;

namespace DecisionMakingMethods.Methods
{
    public class HurwitzNonRandomMethod : NonRandomizedMethod
    {
        public double Lambda { get; }

        public HurwitzNonRandomMethod(double optimism)
        {
            if (optimism < 0 || optimism > 1)
            {
                throw new ArgumentException("Parameter optimism must be from range [0; 1]!", "optimism");
            }

            Lambda = optimism;
        }

        protected override double GetRateForRow(Matrix matrix, int rowIndex)
        {
            var rowMin = Utils.FindMinInMatrix(matrix, rowIndex, rowIndex, 0, matrix.ColumnsCount - 1);
            var rowMax = Utils.FindMaxInMatrix(matrix, rowIndex, rowIndex, 0, matrix.ColumnsCount - 1);

            return Lambda * rowMin + (1 - Lambda) * rowMax;
        }
    }
}
