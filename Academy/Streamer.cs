using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO;
using System.Diagnostics;
using System.Windows.Forms;


namespace Academy
{
	internal class Streamer
	{
		//Single resposibility principle
		public void Print(Human[] group)
		{
			for (int i = 0; i < group.Length; i++)
			{
				Console.WriteLine(group[i]);
			}
			//Save(group, "group.csv");
		}
		public void Save(Human[] group, string filename)
		{
			Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..");
			Console.WriteLine(Directory.GetCurrentDirectory());
			//string filename = "group.csv";
			StreamWriter writer = new StreamWriter(filename);
			foreach (Human h in group)
			{
				writer.WriteLine(h.ToFileString());
			}
			writer.Close();
			Process.Start("notepad", filename);    //CSV - Comma-Separated Values (Значение, разделенные запятыми);
		}
		public Human[] Load(string filename)
		{
			List<Human> group = new List<Human>();
			Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..");
			StreamReader reader = new StreamReader(filename);
			while (!reader.EndOfStream)
			{
				string record = reader.ReadLine();
				Console.WriteLine(record);
				group.Add
					(
					Factory.Create(record.Split(':').First()).//First() и Last()
													   //Init(record.Split(":,;".ToCharArray()))
					Init(record.Split(new char[] { ':', ',', ';' }))
					);
			}
			reader.Close();
			return group.ToArray();
		}
	}
}
