using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumericalAnalysisLibrary.MathStructures;

namespace DecisionMakingMethods.Methods
{
    public class RegretNonRandomMethod : NonRandomizedMethod
    {
        protected override double GetRateForRow(Matrix matrix, int rowIndex)
        {
            return Utils.FindMaxInMatrix(matrix, rowIndex, rowIndex, 0, matrix.ColumnsCount - 1);
        }

        protected override Matrix GetAnchorMatrix(Matrix matrix)
        {
            var lossesMatrix = GetLossesMatrix(matrix);

            for (int j = 0; j < lossesMatrix.ColumnsCount; j++)
            {
                var colMin = Utils.FindMinInMatrix(lossesMatrix, 0, lossesMatrix.RowsCount - 1, j, j);

                for (int i = 0; i < lossesMatrix.RowsCount; i++)
                {
                    lossesMatrix[i, j] -= colMin;
                }
            }

            return lossesMatrix;
        }
    }
}
