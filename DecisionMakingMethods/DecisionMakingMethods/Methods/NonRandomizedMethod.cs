using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumericalAnalysisLibrary.MathStructures;

namespace DecisionMakingMethods.Methods
{
    public abstract class NonRandomizedMethod : DecisionMakingMethod
    {
        protected abstract double GetRateForRow(Matrix matrix, int rowIndex);

        protected int[] DetermineBestDecisions(Matrix lossesMatrix)
        {
            var ratesForDecisions = new List<double>();

            for (int i = 0; i < lossesMatrix.RowsCount; i++)
                ratesForDecisions.Add(GetRateForRow(lossesMatrix, i));

            var minLosses = ratesForDecisions.Min();
            var bestDecisions = Enumerable.Range(0, ratesForDecisions.Count)
                                          .Where(index => ratesForDecisions[index] == minLosses);

            return bestDecisions.ToArray();
        }

        protected virtual Matrix GetAnchorMatrix(Matrix matrix)
        {
            return GetLossesMatrix(matrix);
        }

        protected virtual object ConstructResponse(int[] bestIndexes, double bestValue, Matrix anchorMatrix)
        {
            return new Tuple<int[], double, Matrix>(bestIndexes, bestValue, anchorMatrix);
        }

        public override object Solve(Matrix qMatrix)
        {
            var anchorMatrix = GetAnchorMatrix(qMatrix);

            var best = DetermineBestDecisions(anchorMatrix);
            var bestLoss = GetRateForRow(anchorMatrix, best[0]);

            return ConstructResponse(best, bestLoss, anchorMatrix);
        }
    }
}
