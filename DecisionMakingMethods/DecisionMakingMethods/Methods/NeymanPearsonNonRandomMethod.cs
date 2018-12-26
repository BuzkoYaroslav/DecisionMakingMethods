using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumericalAnalysisLibrary.MathStructures;

namespace DecisionMakingMethods.Methods
{
    public class NeymanPearsonNonRandomMethod : NonRandomizedMethod
    {
        public int Threshold { get; }

        public NeymanPearsonNonRandomMethod(int threshold)
        {
            Threshold = threshold;
        }

        protected override double GetRateForRow(Matrix matrix, int rowIndex)
        {
            return matrix[rowIndex, 1];
        }

        protected override Matrix GetAnchorMatrix(Matrix matrix)
        {
            var lossesMatrix = GetLossesMatrix(matrix);

            var rows = Enumerable.Range(0, lossesMatrix.RowsCount).Where(row => matrix[row, 0] >= Threshold).ToArray();

            var thresholdedMatrix = new double[rows.Length, lossesMatrix.ColumnsCount];

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < lossesMatrix.ColumnsCount; j++)
                {
                    thresholdedMatrix[i, j] = lossesMatrix[rows[i], j]; 
                }
            }

            return thresholdedMatrix;
        }

        public override object Solve(Matrix qMatrix)
        {
            if (qMatrix.ColumnsCount != 2)
            {
                throw new ArgumentException("Matrix columns count must be equal to 2!", "qMatrix");
            }

            return base.Solve(qMatrix);
        }
    }
}
