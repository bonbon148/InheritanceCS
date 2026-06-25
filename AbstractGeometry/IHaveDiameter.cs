using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;


namespace AbstractGeometry
{
	internal interface IHaveDiameter
	{
		double GetDiameter();
		void DrawDiameter(PaintEventArgs e);
	}
}
