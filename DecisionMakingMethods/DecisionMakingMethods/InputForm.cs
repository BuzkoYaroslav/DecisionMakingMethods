using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DecisionMakingMethods.Methods;
using NumericalAnalysisLibrary.MathStructures;

namespace DecisionMakingMethods
{
    public enum TaskType
    {
        NonRandomized = 0,
        Randomized,
        Statistical
    }
    public enum MethodType
    {
        MinMax = 0,
        Regret,
        Hurwitz,
        Bayes,
        NeymanPearson
    }

    public partial class InputForm : Form
    {
        private TaskType taskType = TaskType.NonRandomized;
        private MethodType methodType = MethodType.MinMax;

        public InputForm()
        {
            InitializeComponent();

            probabilityMatrixPanel.Enabled = false;
            HideAdditionalDataPanels();

            UpdateQMatrixDataGridView();
            UpdateProbabilityMatrixGridView();
            UpdateBayesVectorDataGridView();
        }

        private void HideAdditionalDataPanels()
        {
            hurwitzAdditionalDataPanel.Visible = false;
            bayesAdditionDataPanel.Visible = false;
            neymanAdditionalDataPanel.Visible = false;
        }

        private void taskTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            taskType = (TaskType)taskTypeComboBox.SelectedIndex;

            switch (taskType)
            {
                case TaskType.Statistical:
                    probabilityMatrixPanel.Enabled = true;
                    break;
                default:
                    probabilityMatrixPanel.Enabled = false;
                    break;
            }
        }

        private void methodTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            methodType = (MethodType)methodTypeComboBox.SelectedIndex;

            HideAdditionalDataPanels();
            switch (methodType)
            {
                case MethodType.Bayes:
                    bayesAdditionDataPanel.Visible = true;
                    break;
                case MethodType.Hurwitz:
                    hurwitzAdditionalDataPanel.Visible = true;
                    break;
                case MethodType.NeymanPearson:
                    neymanAdditionalDataPanel.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void InitializeDataGridView(DataGridView dataGridView, int rowsCount, int colsCount)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            for (int i = 0; i < colsCount; i++)
                dataGridView.Columns.Add(GetNewColumn());

            for (int i = 0; i < rowsCount; i++)
            {
                var row = new DataGridViewRow();

                for (int j = 0; j < colsCount; j++)
                    row.Cells.Add(new DataGridViewTextBoxCell());

                dataGridView.Rows.Add(row);
            }
        }

        private DataGridViewColumn GetNewColumn()
        {
            return new DataGridViewColumn
            {
                CellTemplate = new DataGridViewTextBoxCell()
            };
        }

        private void qMatrixRowsCountNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateQMatrixDataGridView();
        }

        private void UpdateQMatrixDataGridView()
        {
            var rows = Convert.ToInt32(qMatrixRowsCountNumUpDown.Value);
            var cols = Convert.ToInt32(qMatrixColumnsCountNumUpDown.Value);

            InitializeDataGridView(qMatrixDataGridView, rows, cols);
        }

        private void UpdateProbabilityMatrixGridView()
        {
            var rows = Convert.ToInt32(probabilityMatrixRowsNumUpDown.Value);
            var cols = Convert.ToInt32(qMatrixColumnsCountNumUpDown.Value);

            InitializeDataGridView(probabilityMatrixDataGridView, rows, cols);
        }

        private void UpdateBayesVectorDataGridView()
        {
            var cols = Convert.ToInt32(qMatrixRowsCountNumUpDown.Value);

            InitializeDataGridView(probabilityVectorDataGridView, 1, cols);
        }

        private void qMatrixColumnsCountNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateQMatrixDataGridView();
            UpdateProbabilityMatrixGridView();
            UpdateBayesVectorDataGridView();
        }

        private void probabilityMatrixRowsNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateProbabilityMatrixGridView();
        }

        private double[,] GetDataGridViewValues(DataGridView dataGridView)
        {
            var rows = dataGridView.RowCount;
            var cols = dataGridView.ColumnCount;
            var values = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    values[i, j] = Convert.ToDouble(dataGridView[j, i].Value);
                }
            }

            return values;
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            try
            {
                double[,] probabilityMatrix = null;
                var qMatrix = GetDataGridViewValues(qMatrixDataGridView);
                double lambda = 0;
                int threshold = 0;
                Vector bayesVect = null;

                if (taskType == TaskType.Statistical)
                {
                    probabilityMatrix = GetDataGridViewValues(probabilityMatrixDataGridView);
                }

                switch (methodType)
                {
                    case MethodType.Hurwitz:
                        lambda = Convert.ToDouble(optimismNumericUpDown.Value);
                        break;
                    case MethodType.Bayes:
                        var data = GetDataGridViewValues(probabilityVectorDataGridView);

                        double[] vect = new double[data.GetLength(1)];
                        for (int i = 0; i < vect.Length; i++)
                            vect[i] = data[0, i];
                        bayesVect = vect;

                        break;
                    case MethodType.NeymanPearson:
                        threshold = Convert.ToInt32(thresholdNumericUpDown.Value);
                        break;
                    default:
                        break;
                }

                DecisionMakingMethod method = null;

                switch (taskType)
                {
                    case TaskType.NonRandomized:
                        switch (methodType)
                        {
                            case MethodType.Bayes:
                                method = new BayesNonRandomMethod(bayesVect);

                                break;
                            case MethodType.Hurwitz:
                                method = new HurwitzNonRandomMethod(lambda);

                                break;
                            case MethodType.MinMax:
                                method = new MinMaxNonRandomMethod();

                                break;
                            case MethodType.NeymanPearson:
                                method = new NeymanPearsonNonRandomMethod(threshold);

                                break;
                            case MethodType.Regret:
                                method = new RegretNonRandomMethod();

                                break;
                        }

                        break;
                    case TaskType.Randomized:
                        switch (methodType)
                        {
                            case MethodType.Bayes:
                                method = new BayesRandomMethod(bayesVect);

                                break;
                            case MethodType.Hurwitz:
                                method = new HurwitzRandomMethod(lambda);

                                break;
                            case MethodType.MinMax:
                                method = new MinMaxRandomMethod();

                                break;
                            case MethodType.NeymanPearson:
                                method = new NeymanPearsonRandomMethod(threshold);

                                break;
                            case MethodType.Regret:
                                method = new RegretRandomMethod();

                                break;
                        }

                        break;
                    case TaskType.Statistical:
                        RandomizedMethod innerMethod = null;

                        switch (methodType)
                        {
                            case MethodType.Bayes:
                                innerMethod = new BayesRandomMethod(bayesVect);

                                break;
                            case MethodType.Hurwitz:
                                innerMethod = new HurwitzRandomMethod(lambda);

                                break;
                            case MethodType.MinMax:
                                innerMethod = new MinMaxRandomMethod();

                                break;
                            case MethodType.NeymanPearson:
                                innerMethod = new NeymanPearsonRandomMethod(threshold);

                                break;
                            case MethodType.Regret:
                                innerMethod = new RegretRandomMethod();

                                break;
                        }

                        method = new StatisticalMethod(innerMethod);

                        break;
                }

                if (taskType == TaskType.Statistical)
                {

                } else
                {
                    var response = method.Solve(qMatrix);
                    var textForm = new TextOutput(response, methodType, taskType);

                    textForm.Show();
                    if (taskType == TaskType.Randomized)
                    {
                        var graphForm = new Graphic(response);

                        graphForm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
