using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NumericalAnalysisLibrary.MathStructures;
using NumericalAnalysisLibrary.Functions;

namespace DecisionMakingMethods
{
    public partial class TextOutput : Form
    {
        public TextOutput(object response, MethodType method, TaskType task)
        {
            InitializeComponent();

            DisplayResponse(response, method, task);
        }

        private void DisplayResponse(object response, MethodType method, TaskType task)
        {
            richTextBox1.Text = "";

            richTextBox1.Text += $"{Constants.methodLabel}:{method.ToString()}{Environment.NewLine}" +
                $"{Constants.taskLabel}:{task.ToString()}{Environment.NewLine}";

            switch (task)
            {
                case TaskType.NonRandomized:
                    var castedNonRandResponse = response as Tuple<int[], double, Matrix>;

                    richTextBox1.Text += $"{Constants.bestDecisionsLabel}: {string.Format("{0}", string.Join(", ", castedNonRandResponse.Item1))}" +
                        $"{Environment.NewLine}";
                    richTextBox1.Text += $"{Constants.bestLossLabel}:{castedNonRandResponse.Item2}{Environment.NewLine}";
                    richTextBox1.Text += $"{Constants.anchorMatrixLabel}:{Environment.NewLine}{GetMatrixText(castedNonRandResponse.Item3)}";

                    break;
                case TaskType.Randomized:
                    var castedRandResponse = response as 
                        Tuple<double[], double, PointF, Matrix, PointF[], Tuple<int, PointF>[], Tuple<int, PointF>[], Tuple<MathFunction, MathFunction>>;

                    richTextBox1.Text += $"{Constants.randomizedDecisionlabel}:{string.Format("({0})", string.Join(", ", castedRandResponse.Item1))}" +
                        $"{Environment.NewLine}";
                    richTextBox1.Text += $"{Constants.bestLossLabel}:{castedRandResponse.Item2}{Environment.NewLine}";
                    richTextBox1.Text += $"{Constants.anchorMatrixLabel}:{Environment.NewLine}{GetMatrixText(castedRandResponse.Item4)}{Environment.NewLine}";

                    break;
                case TaskType.Statistical:

                    break;
            }
        }

        private string GetMatrixText(Matrix matrix)
        {
            var str = "";

            for (int i = 0; i < matrix.RowsCount; i++)
            {
                for (int j = 0; j < matrix.ColumnsCount; j++)
                {
                    str += matrix[i, j];

                    if (j != matrix.ColumnsCount)
                    {
                        str += " ";
                    }
                }

                str += Environment.NewLine;
            }

            return str;
        }
    }
}
