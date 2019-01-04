using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumericalAnalysisLibrary.Functions;

namespace DecisionMakingMethods.Methods
{
    public class HurwitzRandomMethod : RandomizedMethod
    {
        public double Lambda { get; }

        public HurwitzRandomMethod(double optimism)
        {
            if (optimism < 0 || optimism > 1)
            {
                throw new ArgumentException("Optimism must be a value from range [0, 1]!", "optimism");
            }

            Lambda = optimism;
        }

        protected override float WeightForPointDown(PointF point)
        {
            return (float)(Lambda * point.Y + (1.0 - Lambda) * point.X);
        }

        protected override float WeightForPointUpper(PointF point)
        {
            return (float)(Lambda * point.X + (1.0 - Lambda) * point.Y);
        }

        protected override MathFunction UpperOptimalLevelLine(double loss)
        {
            return (loss - Lambda * new XFunction(1.0)) / (1 - Lambda);
        }

        protected override MathFunction DownOptimalLevelLine(double loss)
        {
            return (loss - (1 - Lambda) * new XFunction(1.0)) / Lambda;
        }
    }
}
