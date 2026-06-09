//#define WRITE_TO_FILE
#define READ_FROM_FILE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;   //Input/Output
using System.Diagnostics;

namespace Files
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/*		 
			---------------------
			StreamWriter
			StreamReader
			---------------------
			*/

#if WRITE_TO_FILE
			//1) Создаём и открываем поток:
			StreamWriter sw = new StreamWriter("File.txt");

			//2) Записываем вывод в файл:
			sw.Write("Hello World!");
			sw.WriteLine("Это запись в файл на языке C#");

			//?) Закрываем поток:
			sw.Close();

			Process.Start("notepad", "File.txt"); 
#endif

			//1) Создаём и открываем поток:
			StreamReader sr = new StreamReader("File.txt");

			//2) Читаем файл, и выводим его содержимое на консоль:
			while (!sr.EndOfStream)  //Дошли мы до конца или нет.
			{
				string buffer = sr.ReadLine();
				Console.WriteLine(buffer);
			}

			//?) Закрываем потом
			sr.Close();
		}
	}
}
