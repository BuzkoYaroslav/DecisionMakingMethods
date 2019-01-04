using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using NumericalAnalysisLibrary.MathStructures;
using NumericalAnalysisLibrary.Functions;

namespace DecisionMakingMethods
{
    public partial class Graphic : Form
    {
        private GraphicPainter painter;
        private Random rnd = new Random();
        private PictureBox pictureBox1;
        private ListView listView1;
        private const int width = 3;

        public Graphic()
        {
            InitializeComponent();
            painter = new GraphicPainter(pictureBox1, true, false);
        }

        public Graphic(object response): this()
        {
            DrawResponse(response);
        }

        private void DrawResponse(object response)
        {
            if (!(response is Tuple<double[], double, PointF, NumericalAnalysisLibrary.MathStructures.Matrix, PointF[], Tuple<int, PointF>[], Tuple<int, PointF>[], Tuple<MathFunction, MathFunction>>))
            {
                throw new ArgumentException("Invalid input!", "response");
            }

            var castedResponse = response as
                Tuple<double[], double, PointF, NumericalAnalysisLibrary.MathStructures.Matrix, PointF[], Tuple<int, PointF>[], Tuple<int, PointF>[], Tuple<MathFunction, MathFunction>>;

            painter.XBounds = new Point(-1, (int)Math.Floor(castedResponse.Item5.Select(point => point.X).Max()) + 1);
            painter.YBounds = new Point(-1, (int)Math.Floor(castedResponse.Item5.Select(point => point.Y).Max()) + 1);

            var allDotsPath = painter.DotsPathFromDots(castedResponse.Item5);
            var convexHull = painter.LinePathFromDots(castedResponse.Item6.Select(tuple => tuple.Item2).ToArray());
            var northwesternCorner = painter.LinePathFromDots(castedResponse.Item7.Select(tuple => tuple.Item2).ToArray());
            var solutionDotPath = painter.DotsPathFromDots(new PointF[] { castedResponse.Item3 });

            var function1Path = painter.FunctionToPath(castedResponse.Rest.Item1, -1, castedResponse.Item2);
            var function2Path = painter.FunctionToPath(castedResponse.Rest.Item2, castedResponse.Item2, painter.XBounds.Y);

            painter.DrawPath(convexHull, Color.GreenYellow, 2, Color.GreenYellow, 0.5);
            painter.DrawPath(northwesternCorner, Color.Blue, 2, Color.Black, 0);
            painter.DrawPath(allDotsPath, Color.Black, 1, Color.Black, 1);
            painter.DrawPath(solutionDotPath, Color.Red, 2, Color.Red, 1);

            painter.DrawPath(function1Path, Color.Green, 2, Color.Black, 0);
            painter.DrawPath(function2Path, Color.Green, 2, Color.Black, 0);
        }

        private T MaxValue<T>(params T[] vals) where T : IComparable
        {
            T max = vals[0];
            for (int i = 0; i < vals.Length; i++)
                if (vals[i].CompareTo(max) > 0)
                    max = vals[i];

            return max;
        }
        private Color GetRandColor()
        {
            return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listView1 = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(186, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(688, 434);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(180, 434);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Graphic
            // 
            this.ClientSize = new System.Drawing.Size(873, 434);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Graphic";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
