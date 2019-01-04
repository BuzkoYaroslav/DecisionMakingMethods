namespace DecisionMakingMethods
{
    partial class InputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.taskTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.methodTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.qMatrixDataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.probabilityMatrixDataGridView = new System.Windows.Forms.DataGridView();
            this.probabilityMatrixPanel = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.probabilityMatrixRowsNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.hurwitzAdditionalDataPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.neymanAdditionalDataPanel = new System.Windows.Forms.Panel();
            this.thresholdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.bayesAdditionDataPanel = new System.Windows.Forms.Panel();
            this.probabilityVectorDataGridView = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.solveButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.qMatrixRowsCountNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.qMatrixColumnsCountNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.optimismNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.qMatrixDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityMatrixDataGridView)).BeginInit();
            this.probabilityMatrixPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityMatrixRowsNumUpDown)).BeginInit();
            this.hurwitzAdditionalDataPanel.SuspendLayout();
            this.neymanAdditionalDataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdNumericUpDown)).BeginInit();
            this.bayesAdditionDataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityVectorDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qMatrixRowsCountNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qMatrixColumnsCountNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optimismNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите тип задачи:";
            // 
            // taskTypeComboBox
            // 
            this.taskTypeComboBox.FormattingEnabled = true;
            this.taskTypeComboBox.Items.AddRange(new object[] {
            "Нерандомизированные",
            "Рандомизированные",
            "Статистические"});
            this.taskTypeComboBox.Location = new System.Drawing.Point(17, 34);
            this.taskTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.taskTypeComboBox.Name = "taskTypeComboBox";
            this.taskTypeComboBox.Size = new System.Drawing.Size(175, 28);
            this.taskTypeComboBox.TabIndex = 1;
            this.taskTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.taskTypeComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выберите метод решения:";
            // 
            // methodTypeComboBox
            // 
            this.methodTypeComboBox.FormattingEnabled = true;
            this.methodTypeComboBox.Items.AddRange(new object[] {
            "Минимаксный",
            "Сэвиджа",
            "Гурвица",
            "Байеса",
            "Неймана-Пирсона"});
            this.methodTypeComboBox.Location = new System.Drawing.Point(380, 34);
            this.methodTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.methodTypeComboBox.Name = "methodTypeComboBox";
            this.methodTypeComboBox.Size = new System.Drawing.Size(209, 28);
            this.methodTypeComboBox.TabIndex = 1;
            this.methodTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.methodTypeComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Введите матрицу прибыли:";
            // 
            // qMatrixDataGridView
            // 
            this.qMatrixDataGridView.AllowUserToAddRows = false;
            this.qMatrixDataGridView.AllowUserToDeleteRows = false;
            this.qMatrixDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.qMatrixDataGridView.ColumnHeadersVisible = false;
            this.qMatrixDataGridView.Location = new System.Drawing.Point(19, 202);
            this.qMatrixDataGridView.Name = "qMatrixDataGridView";
            this.qMatrixDataGridView.RowHeadersVisible = false;
            this.qMatrixDataGridView.Size = new System.Drawing.Size(240, 150);
            this.qMatrixDataGridView.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(258, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Введите матрицу вероятностей:";
            // 
            // probabilityMatrixDataGridView
            // 
            this.probabilityMatrixDataGridView.AllowUserToAddRows = false;
            this.probabilityMatrixDataGridView.AllowUserToDeleteRows = false;
            this.probabilityMatrixDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.probabilityMatrixDataGridView.ColumnHeadersVisible = false;
            this.probabilityMatrixDataGridView.Location = new System.Drawing.Point(9, 123);
            this.probabilityMatrixDataGridView.Name = "probabilityMatrixDataGridView";
            this.probabilityMatrixDataGridView.RowHeadersVisible = false;
            this.probabilityMatrixDataGridView.Size = new System.Drawing.Size(240, 150);
            this.probabilityMatrixDataGridView.TabIndex = 4;
            // 
            // probabilityMatrixPanel
            // 
            this.probabilityMatrixPanel.Controls.Add(this.label12);
            this.probabilityMatrixPanel.Controls.Add(this.probabilityMatrixDataGridView);
            this.probabilityMatrixPanel.Controls.Add(this.label4);
            this.probabilityMatrixPanel.Controls.Add(this.probabilityMatrixRowsNumUpDown);
            this.probabilityMatrixPanel.Controls.Add(this.label11);
            this.probabilityMatrixPanel.Location = new System.Drawing.Point(345, 79);
            this.probabilityMatrixPanel.Name = "probabilityMatrixPanel";
            this.probabilityMatrixPanel.Size = new System.Drawing.Size(267, 285);
            this.probabilityMatrixPanel.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(145, 20);
            this.label12.TabIndex = 12;
            this.label12.Text = "количество строк";
            // 
            // probabilityMatrixRowsNumUpDown
            // 
            this.probabilityMatrixRowsNumUpDown.Location = new System.Drawing.Point(196, 27);
            this.probabilityMatrixRowsNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.probabilityMatrixRowsNumUpDown.Name = "probabilityMatrixRowsNumUpDown";
            this.probabilityMatrixRowsNumUpDown.Size = new System.Drawing.Size(57, 26);
            this.probabilityMatrixRowsNumUpDown.TabIndex = 11;
            this.probabilityMatrixRowsNumUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.probabilityMatrixRowsNumUpDown.ValueChanged += new System.EventHandler(this.probabilityMatrixRowsNumUpDown_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(254, 20);
            this.label11.TabIndex = 10;
            this.label11.Text = "Введите размерность матрицы:";
            // 
            // hurwitzAdditionalDataPanel
            // 
            this.hurwitzAdditionalDataPanel.Controls.Add(this.optimismNumericUpDown);
            this.hurwitzAdditionalDataPanel.Controls.Add(this.label5);
            this.hurwitzAdditionalDataPanel.Location = new System.Drawing.Point(17, 396);
            this.hurwitzAdditionalDataPanel.Name = "hurwitzAdditionalDataPanel";
            this.hurwitzAdditionalDataPanel.Size = new System.Drawing.Size(588, 61);
            this.hurwitzAdditionalDataPanel.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(378, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Введите коэффициент оптимизма-пессимизма:";
            // 
            // neymanAdditionalDataPanel
            // 
            this.neymanAdditionalDataPanel.Controls.Add(this.thresholdNumericUpDown);
            this.neymanAdditionalDataPanel.Controls.Add(this.label6);
            this.neymanAdditionalDataPanel.Location = new System.Drawing.Point(17, 396);
            this.neymanAdditionalDataPanel.Name = "neymanAdditionalDataPanel";
            this.neymanAdditionalDataPanel.Size = new System.Drawing.Size(588, 65);
            this.neymanAdditionalDataPanel.TabIndex = 7;
            // 
            // thresholdNumericUpDown
            // 
            this.thresholdNumericUpDown.Location = new System.Drawing.Point(397, 11);
            this.thresholdNumericUpDown.Name = "thresholdNumericUpDown";
            this.thresholdNumericUpDown.Size = new System.Drawing.Size(186, 26);
            this.thresholdNumericUpDown.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(381, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Введите порог для контролируемого состояния:";
            // 
            // bayesAdditionDataPanel
            // 
            this.bayesAdditionDataPanel.Controls.Add(this.probabilityVectorDataGridView);
            this.bayesAdditionDataPanel.Controls.Add(this.label7);
            this.bayesAdditionDataPanel.Location = new System.Drawing.Point(17, 396);
            this.bayesAdditionDataPanel.Name = "bayesAdditionDataPanel";
            this.bayesAdditionDataPanel.Size = new System.Drawing.Size(589, 115);
            this.bayesAdditionDataPanel.TabIndex = 8;
            // 
            // probabilityVectorDataGridView
            // 
            this.probabilityVectorDataGridView.AllowUserToAddRows = false;
            this.probabilityVectorDataGridView.AllowUserToDeleteRows = false;
            this.probabilityVectorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.probabilityVectorDataGridView.ColumnHeadersVisible = false;
            this.probabilityVectorDataGridView.Location = new System.Drawing.Point(18, 34);
            this.probabilityVectorDataGridView.Name = "probabilityVectorDataGridView";
            this.probabilityVectorDataGridView.RowHeadersVisible = false;
            this.probabilityVectorDataGridView.Size = new System.Drawing.Size(553, 60);
            this.probabilityVectorDataGridView.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(248, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Введите вектор вероятностей:";
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(17, 517);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(589, 66);
            this.solveButton.TabIndex = 9;
            this.solveButton.Text = "Решить";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(254, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Введите размерность матрицы:";
            // 
            // qMatrixRowsCountNumUpDown
            // 
            this.qMatrixRowsCountNumUpDown.Location = new System.Drawing.Point(206, 102);
            this.qMatrixRowsCountNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.qMatrixRowsCountNumUpDown.Name = "qMatrixRowsCountNumUpDown";
            this.qMatrixRowsCountNumUpDown.Size = new System.Drawing.Size(57, 26);
            this.qMatrixRowsCountNumUpDown.TabIndex = 11;
            this.qMatrixRowsCountNumUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.qMatrixRowsCountNumUpDown.ValueChanged += new System.EventHandler(this.qMatrixRowsCountNumUpDown_ValueChanged);
            // 
            // qMatrixColumnsCountNumUpDown
            // 
            this.qMatrixColumnsCountNumUpDown.Location = new System.Drawing.Point(206, 134);
            this.qMatrixColumnsCountNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.qMatrixColumnsCountNumUpDown.Name = "qMatrixColumnsCountNumUpDown";
            this.qMatrixColumnsCountNumUpDown.Size = new System.Drawing.Size(57, 26);
            this.qMatrixColumnsCountNumUpDown.TabIndex = 11;
            this.qMatrixColumnsCountNumUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.qMatrixColumnsCountNumUpDown.ValueChanged += new System.EventHandler(this.qMatrixColumnsCountNumUpDown_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "количество строк";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(174, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "количество столбцов";
            // 
            // optimismNumericUpDown
            // 
            this.optimismNumericUpDown.DecimalPlaces = 2;
            this.optimismNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.optimismNumericUpDown.Location = new System.Drawing.Point(397, 19);
            this.optimismNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.optimismNumericUpDown.Name = "optimismNumericUpDown";
            this.optimismNumericUpDown.Size = new System.Drawing.Size(186, 26);
            this.optimismNumericUpDown.TabIndex = 1;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 595);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.qMatrixColumnsCountNumUpDown);
            this.Controls.Add(this.qMatrixRowsCountNumUpDown);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.bayesAdditionDataPanel);
            this.Controls.Add(this.neymanAdditionalDataPanel);
            this.Controls.Add(this.hurwitzAdditionalDataPanel);
            this.Controls.Add(this.probabilityMatrixPanel);
            this.Controls.Add(this.qMatrixDataGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.methodTypeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.taskTypeComboBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "InputForm";
            this.Text = "InputForm";
            ((System.ComponentModel.ISupportInitialize)(this.qMatrixDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityMatrixDataGridView)).EndInit();
            this.probabilityMatrixPanel.ResumeLayout(false);
            this.probabilityMatrixPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityMatrixRowsNumUpDown)).EndInit();
            this.hurwitzAdditionalDataPanel.ResumeLayout(false);
            this.hurwitzAdditionalDataPanel.PerformLayout();
            this.neymanAdditionalDataPanel.ResumeLayout(false);
            this.neymanAdditionalDataPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdNumericUpDown)).EndInit();
            this.bayesAdditionDataPanel.ResumeLayout(false);
            this.bayesAdditionDataPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityVectorDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qMatrixRowsCountNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qMatrixColumnsCountNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optimismNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox taskTypeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox methodTypeComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView qMatrixDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView probabilityMatrixDataGridView;
        private System.Windows.Forms.Panel probabilityMatrixPanel;
        private System.Windows.Forms.Panel hurwitzAdditionalDataPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel neymanAdditionalDataPanel;
        private System.Windows.Forms.NumericUpDown thresholdNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel bayesAdditionDataPanel;
        private System.Windows.Forms.DataGridView probabilityVectorDataGridView;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown qMatrixRowsCountNumUpDown;
        private System.Windows.Forms.NumericUpDown qMatrixColumnsCountNumUpDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown probabilityMatrixRowsNumUpDown;
        private System.Windows.Forms.NumericUpDown optimismNumericUpDown;
    }
}