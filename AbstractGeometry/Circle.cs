using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace AbstractGeometry
{
	class Circle:Shape, IHaveDiameter
	{
		public double Radius {  get; set; }
		int angle;
		int opposite_angle;
		public Circle
			(
				double radius,
				int startX, int startY, int lineWidth, Color color
			): base(startX, startY, lineWidth, color )
		{
			this.Radius = radius;
			angle = 30;
			opposite_angle = angle + 180;
		}
		public override double GetArea()
		{
			return Math.PI * Math.Pow(Radius, 2); 
		}
		public override double GetPerimeter()
		{
			return Math.PI * Radius * 2;
		}
		public Point GetCenter()
		{
			return new Point(StartX + (int)Radius, StartX + (int)Radius);
		}
		public double GetDiameter()
		{
			return 2 * Radius;
		}
		public override void Draw(PaintEventArgs e)
		{
			Pen pen = new Pen(Color, LineWidht);
			e.Graphics.DrawEllipse(pen, StartX, StartY, (float)Radius * 2, (float)Radius * 2);
			DrawRadius(e);
			DrawDiameter(e);
			DrawCenter(e);
		}
		void DrawCenter(PaintEventArgs e)
		{
			Point center = GetCenter();
			Pen pen = new Pen(Color, 4);
			e.Graphics.DrawEllipse
				(
				pen,
				center.X-2, center.Y-2,
				4, 4
				);
		}
		public void DrawRadius(PaintEventArgs e)
		{
			Pen pen = new Pen(Color, 1);
			e.Graphics.DrawLine
				(
					pen,
					StartX + (int)Radius, StartY + (int)Radius,
					StartX + (int)Radius + (int)(Radius * Math.Cos(angle*Math.PI/180)), 
					StartY + (int)Radius + (int)(Radius * Math.Sin(angle*Math.PI/180))
				);



		}
		public void DrawDiameter(PaintEventArgs e)
		{
			Pen pen = new Pen (Color, 1);
			e.Graphics.DrawLine

				(
				pen, 
				
				StartX + (int)Radius + (int)(Radius * Math.Cos(opposite_angle*Math.PI/180)),
				StartY + (int)Radius + (float)(Radius * Math.Sin(opposite_angle*Math.PI/180)),
				
				StartX + (int)Radius + (float)(Radius * Math.Cos(angle*Math.PI/180)),
				StartY + (int)Radius + (float)(Radius * Math.Sin(angle*Math.PI/180))
				);
		}
		public override void Info(PaintEventArgs e)
		{
			Console.WriteLine($"Радиус: {Radius}");
			Console.WriteLine($"Диаметр: {GetDiameter()}");
			DrawDiameter(e);
			base.Info(e);
		}
	}
}
