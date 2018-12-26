using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumericalAnalysisLibrary.MathStructures;

namespace DecisionMakingMethods.Methods
{
    class RegretRandomMethod : MinMaxRandomMethod
    {
        protected override Matrix AnchorMatrix(Matrix qMatrix)
        {
            var lossesMatrix = GetLossesMatrix(qMatrix);

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
