using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumericalAnalysisLibrary.Functions;

namespace DecisionMakingMethods.Methods
{
    public class NeymanPearsonRandomMethod : RandomizedMethod
    {
        public NeymanPearsonRandomMethod(int threshold)
        {

        }

        protected override MathFunction DownOptimalLevelLine(double loss)
        {
            throw new NotImplementedException();
        }

        protected override MathFunction UpperOptimalLevelLine(double loss)
        {
            throw new NotImplementedException();
        }

        protected override float WeightForPointDown(PointF point)
        {
            throw new NotImplementedException();
        }

        protected override float WeightForPointUpper(PointF point)
        {
            throw new NotImplementedException();
        }
    }
}
