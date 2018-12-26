using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumericalAnalysisLibrary.MathStructures;

namespace DecisionMakingMethods.Methods
{
    public abstract class DecisionMakingMethod
    {
        protected Matrix GetLossesMatrix(Matrix matrix)
        {
            var maxElement = ((double[,])matrix).Cast<double>().Max();
            var lossesMatrix = new Matrix((double[,])matrix);
            
            for (int i = 0; i < lossesMatrix.RowsCount; i++)
            {
                for (int j = 0; j < lossesMatrix.ColumnsCount; j++)
                {
                    lossesMatrix[i, j] = maxElement - lossesMatrix[i, j];
                }
            }

            return lossesMatrix;
        }

        public abstract object Solve(Matrix qMatrix);
    }
}
