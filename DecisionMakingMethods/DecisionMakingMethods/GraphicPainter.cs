﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using NumericalAnalysisLibrary.Functions;
using NumericalAnalysisLibrary.MathStructures;


namespace DecisionMakingMethods
{
    class GraphicPainter
    {
        private const int resolutionMultiplier = 3;
        private const double epsilon = 0.01;

        private const string yAxe = "X1";
        private const string xAxe = "X0";

        private int MinX = -10;
        private int MaxX = 10;
        private int MinY = -10;
        private int MaxY = 10;

        private float axesWidth = 2;
        private Color axesColor = Color.Black;

        private class DrawingSettings
        {
            public object drawingObject;
            public Color borderColor;
            public float borderWidth;
            public SolidBrush brush;
        }

        private List<DrawingSettings> content;

        private PictureBox elementToDraw;
        private Bitmap bmp;
        private Graphics context;

        private bool drawAxes;
        private bool isTransparent;

        public GraphicPainter(PictureBox element, bool axes, bool transparent)
        {
            content = new List<DrawingSettings>();
            DrawElement = element;

            drawAxes = axes;
            isTransparent = transparent;
            
            DrawAxes();
        }
        public GraphicPainter()
        {
            content = new List<DrawingSettings>();
        }
        
        #region Drawing content

        private void ReloadGraphicContext()
        {
            if (elementToDraw == null)
                return;

            bmp = new Bitmap(elementToDraw.Width * resolutionMultiplier, elementToDraw.Height * resolutionMultiplier);
            context = Graphics.FromImage(bmp);
        }
        private void RedrawContent()
        {
            if (context == null)
                return;

            ClearContext();
            DrawAxes();

            foreach(DrawingSettings dr in content)
            {
                Draw(dr);
            }

            elementToDraw.Image = bmp;
        }

        private void DrawAxes()
        {
            if (context == null ||
                !drawAxes)
                return;

            float centerX = (float)FunctionXToScreenX(0);
            float centerY = (float)FunctionYToScreenY(0);

            context.DrawLine(new Pen(AxesColor, AxesWidth), centerX, 0, centerX, elementToDraw.Height);
            context.DrawLine(new Pen(AxesColor, AxesWidth), 0, centerY, elementToDraw.Width, centerY);

            context.DrawString(yAxe, new Font("Arial", 15), new SolidBrush(axesColor), new PointF(centerX + 10, 10));
            context.DrawString(xAxe, new Font("Arial", 15), new SolidBrush(axesColor), new PointF(elementToDraw.Width - 30, centerY + 10));

            for (int i = MinX; i <= MaxX; i++)
                context.DrawLine(new Pen(AxesColor, AxesWidth), (float)FunctionXToScreenX(i), centerY - AxesWidth * 2,
                     (float)FunctionXToScreenX(i), centerY + AxesWidth * 2);
            for (int j = MinY; j <= MaxY; j++)
                context.DrawLine(new Pen(AxesColor, AxesWidth), centerX - AxesWidth * 2, (float)FunctionYToScreenY(j),
                        centerX + AxesWidth * 2, (float)FunctionYToScreenY(j));
        }
        private void ClearContext()
        {
            context.Clear(isTransparent ? Color.Transparent : Color.White);
        }

        private void Draw(DrawingSettings drSet)
        {
            if (context == null)
                return;

            if (drSet.drawingObject is MathFunction)
            {
                MathFunction func = drSet.drawingObject as MathFunction;
                Tuple<double, double>[] continuousRegions = func.ContinuousRegions(MinX, MaxX, MinY, MaxY);

                foreach (Tuple<double, double> region in continuousRegions)
                {
                    PointF[] points = PointsForFunction(func, region.Item1, region.Item2);

                    context.DrawLines(new Pen(drSet.borderColor, drSet.borderWidth), points);
                }
            }
            else if (drSet.drawingObject is GraphicsPath)
            {
                GraphicsPath path = drSet.drawingObject as GraphicsPath;

                context.FillPath(drSet.brush, path);
                context.DrawPath(new Pen(drSet.borderColor, drSet.borderWidth), path);
            }
        }

        private void UpdateBounds(Point newBounds, ref int max, ref int min)
        {
            if (newBounds.X < newBounds.Y)
            {
                min = newBounds.X;
                max = newBounds.Y;
            }
        }

        private double FunctionXToScreenX(double x)
        {
            return (x - MinX) * XDifference;
        }
        private double FunctionYToScreenY(double y)
        {
            return (MaxY - y) * YDifference;
        }

        private double XDifference
        {
            get
            {
                return Convert.ToDouble(elementToDraw.Width) / (MaxX - MinX);
            }
        }
        private double YDifference
        {
            get
            {
                return Convert.ToDouble(elementToDraw.Height) / (MaxY - MinY);
            }
        }

        #endregion

        #region Public Interface

        public Color AxesColor
        {
            get
            {
                return axesColor;
            }
            set
            {
                axesColor = value;
                RedrawContent();
            }
        }
        public float AxesWidth
        {
            get
            {
                return axesWidth;
            }
            set
            {
               axesWidth = value;
               RedrawContent();
            }
        }
        
        public Point XBounds
        {
            set
            {
                UpdateBounds(value, ref MaxX, ref MinX);
                RedrawContent();
            }
            get
            {
                return new Point(MinX, MaxX);
            }
        }
        public Point YBounds
        {
            set
            {
                UpdateBounds(value, ref MaxY, ref MinY);
                RedrawContent();
            }
            get
            {
                return new Point(MinY, MaxY);
            }
        }

        public PictureBox DrawElement
        {
            set
            {
                elementToDraw = value;
                ReloadGraphicContext();

                RedrawContent();
            }
        }

        public void Draw(MathFunction func, Color funcColor, float width)
        {
            DrawingSettings drSet = new DrawingSettings();
            drSet.drawingObject = func;
            drSet.borderColor = funcColor;
            drSet.borderWidth = width;

            content.Add(drSet);

            Draw(drSet);

            if (elementToDraw != null)
                elementToDraw.Image = bmp;
        }
        public void DrawPath(GraphicsPath path, Color borderColor, float borderWidth, Color brushColor, double brushAlpha)
        {
            DrawingSettings drSet = new DrawingSettings();
            drSet.drawingObject = path;
            drSet.borderColor = borderColor;
            drSet.borderWidth = borderWidth;
            drSet.brush = new SolidBrush(Color.FromArgb(Convert.ToInt32(brushAlpha * 255), brushColor));

            content.Add(drSet);

            Draw(drSet);

            if (elementToDraw != null)
                elementToDraw.Image = bmp;
        }

        public void UpdateUI()
        {
            if (elementToDraw == null)
                return;

            elementToDraw.Image = bmp;
        }

        public void Clear()
        {
            content.Clear();

            RedrawContent();
        }

        #endregion

        #region Points and paths for functions

        private PointF[] PointsForFunction(MathFunction func, double a, double b)
        {
            int multiplier = a > b ? -1 : 1;
            int count = Convert.ToInt32(multiplier * (b - a) / epsilon) + 1;

            List<PointF> points = new List<PointF>();

            for (int i = 0; i < count; i++)
            {
                var argument = (float)(a + multiplier * i * epsilon);
                var value = (float)(func.Calculate(a + multiplier * i * epsilon));

                if (!float.IsNaN(value) && !float.IsInfinity(value))
                    points.Add(new PointF(argument, value));
            }

            return points.Select(x => new PointF((float)FunctionXToScreenX(x.X), (float)FunctionYToScreenY(x.Y))).ToArray();
        }

        public GraphicsPath PathForFunction(MathFunction func, double a, double b)
        {
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            path.AddLines(PointsForFunction(func, a, b));

            path.AddLine(new PointF((float)FunctionXToScreenX(b), (float)FunctionYToScreenY(func.Calculate(b))), 
                         new PointF((float)FunctionXToScreenX(b), (float)FunctionYToScreenY(0)));
            path.AddLine(new PointF((float)FunctionXToScreenX(b), (float)FunctionYToScreenY(0)),
                         new PointF((float)FunctionXToScreenX(a), (float)FunctionYToScreenY(0)));
            path.CloseFigure();

            return path;
        }
        public GraphicsPath FunctionToPath(MathFunction func, double a, double b)
        {
            GraphicsPath path = new GraphicsPath();

            var points = PointsForFunction(func, a, b);

            for (int i = 0; i < points.Length - 1; i++)
                path.AddLine(points[i], points[i + 1]);

            if (points.Length <= 1)
                return null;

            return path;
        }

        private const int dotHalfWidth = 5;
        public GraphicsPath PathForDots(KeyValuePair<double, double>[] dots)
        {
            GraphicsPath path = new GraphicsPath();

            foreach(KeyValuePair<double, double> pair in dots)
            {
                path.AddEllipse((float)FunctionXToScreenX(pair.Key) - dotHalfWidth,
                    (float)FunctionYToScreenY(pair.Value) - dotHalfWidth,
                    dotHalfWidth * 2, dotHalfWidth * 2);
            }

            return path;
        }

        public GraphicsPath DotsPathFromDots(PointF[] dots)
        {
            GraphicsPath path = new GraphicsPath();

            foreach (PointF point in dots)
            {
                path.AddEllipse((float)FunctionXToScreenX(point.X) - dotHalfWidth,
                    (float)FunctionYToScreenY(point.Y) - dotHalfWidth,
                    dotHalfWidth * 2, dotHalfWidth * 2);
            }

            return path;
        }
        public GraphicsPath LinePathFromDots(PointF[] dots)
        {
            GraphicsPath path = new GraphicsPath();
            PointF[] newDots = new PointF[dots.Length];

            for (int i = 0; i < dots.Length; i++)
                newDots[i] = new PointF((float)FunctionXToScreenX(dots[i].X), 
                    (float)FunctionYToScreenY(dots[i].Y));

            path.AddLines(newDots);

            return path;
        }

        #endregion
    }
}
