//#define CHECK_1

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using System.Threading;

namespace AbstractGeometry
{
	internal class Program
	{
		static bool finish = false;
		static void Main(string[] args)
		{
			IntPtr hwnd = GetConsoleWindow();
			Graphics graphics = Graphics.FromHwnd(hwnd);
			System.Drawing.Rectangle window_rect = new System.Drawing.Rectangle
				(
					Console.WindowLeft, Console.WindowTop,
					Console.WindowWidth, Console.WindowHeight
				);
			PaintEventArgs e = new PaintEventArgs(graphics, window_rect);
			Pen pen = new Pen(Color.AliceBlue, 5);
			e.Graphics.DrawRectangle(pen, 600, 150, 250, 130);

			/////////////////////////////////////////////////////////////////////

#if CHECK_1
			Rectangle rectangle = new Rectangle(450, 200, 150, 200, 5, Color.Red);
			rectangle.Info(e);

			Square square = new Square(150, 200, 220, 3, Color.AliceBlue);
			square.Info(e);

			Circle circle = new Circle(65, 100, 350, 3, Color.Yellow);
			circle.Info(e); 
#endif

			Shape[] shapes = new Shape[]
			{
				new Rectangle(450, 200, 150, 200, 5, Color.Red),
				new Square(150, 200, 220, 3, Color.AliceBlue),
				new Circle(65, 100, 350, 3, Color.Yellow)
			};

			//Info(shapes, e);
			Draw(shapes, e);
			Console.Read();
			finish = true;

		}
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetConsoleWindow();
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetDC(IntPtr hWnd);
		static void Info(Shape[] shapes, PaintEventArgs e)
		{
			for (int i = 0; i < shapes.Length; i++)
			{
				shapes[1].Info(e);
			}
		}
		static void Draw(Shape[] shapes, PaintEventArgs e)
		{
			while (!finish)
			{
				for (int i = 0;i < shapes.Length;i++)
				{
					shapes[1].Draw(e);
				}
			}	
		}

		
	}
}
/*
---------------------------------------------------- 
I... - Interface;
...able - способен, имеет такую возможность;
I...able;
IMoveable, IFlyable, ISortable....
----------------------------------------------------
 */
