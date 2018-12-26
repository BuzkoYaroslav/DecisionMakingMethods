using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumericalAnalysisLibrary.MathStructures;

namespace DecisionMakingMethods.Methods
{
    public class MinMaxNonRandomMethod : NonRandomizedMethod
    {
        protected override double GetRateForRow(Matrix matrix, int rowIndex)
        {
            return Utils.FindMaxInMatrix(matrix, rowIndex, rowIndex, 0, matrix.ColumnsCount - 1);
        }
    }
}
