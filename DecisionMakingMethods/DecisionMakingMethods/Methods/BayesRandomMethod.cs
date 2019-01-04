using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumericalAnalysisLibrary.Functions;
using NumericalAnalysisLibrary.MathStructures;

namespace DecisionMakingMethods.Methods
{
    public class BayesRandomMethod : RandomizedMethod
    {
        public Vector Probabilities { get; }

        public BayesRandomMethod(Vector probabilities)
        {
            if (probabilities.Count != 2)
            {
                throw new ArgumentException("Probabilities vector length must be equal to 2!", "probabilities");
            }

            Probabilities = probabilities;
        }

        protected override MathFunction DownOptimalLevelLine(double loss)
        {
            return (loss - Probabilities[0] * new XFunction(1.0)) / Probabilities[1];
        }
        protected override MathFunction UpperOptimalLevelLine(double loss)
        {
            return (loss - Probabilities[0] * new XFunction(1.0)) / Probabilities[1];
        }

        protected override float WeightForPointUpper(PointF point)
        {
            return (float)(Probabilities[0] * point.X + Probabilities[1] * point.Y);
        }

        protected override float WeightForPointDown(PointF point)
        {
            return (float)(Probabilities[0] * point.X + Probabilities[1] * point.Y);
        }
    }
}
