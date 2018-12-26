using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumericalAnalysisLibrary.MathStructures;

namespace DecisionMakingMethods.Methods
{
    public class BayesNonRandomMethod : NonRandomizedMethod
    {
        public Vector Probabilities { get; }

        public BayesNonRandomMethod(Vector probabilities)
        {
            if (((double[])probabilities).Sum() != 1)
            {
                throw new ArgumentException("Probabilities must sum up to 1!", "probabilities");
            }

            Probabilities = probabilities;
        }

        protected override double GetRateForRow(Matrix matrix, int rowIndex)
        {
            double rate = 0;

            for (int j = 0; j < matrix.ColumnsCount; j++)
            {
                rate += Probabilities[j] * matrix[rowIndex, j];
            }

            return rate;
        }

        public override object Solve(Matrix qMatrix)
        {
            if (qMatrix.ColumnsCount != Probabilities.Count)
            {
                throw new ArgumentException("Matrix columns count must be the same as probabilities vector length!", "qMatrix");
            }

            return base.Solve(qMatrix);
        }
    }
}
