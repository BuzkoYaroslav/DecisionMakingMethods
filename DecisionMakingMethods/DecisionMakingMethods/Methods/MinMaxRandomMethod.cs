using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumericalAnalysisLibrary.Functions;

namespace DecisionMakingMethods.Methods
{
    public class MinMaxRandomMethod : RandomizedMethod
    {
        protected override MathFunction DownOptimalLevelLine(double loss)
        {
            return 0;
        }

        protected override MathFunction UpperOptimalLevelLine(double loss)
        {
            return loss;
        }

        protected override float WeightForPointDown(PointF point)
        {
            return point.X;
        }

        protected override float WeightForPointUpper(PointF point)
        {
            return point.Y;
        }
    }
}
