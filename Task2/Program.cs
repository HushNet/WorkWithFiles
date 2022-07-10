using System.Threading.Channels;
using Task2;

string path = @"C:\Users\Alexey\Desktop\hohoho";
SizeCalculator sc = new SizeCalculator();

Console.WriteLine(sc.CalculateSizeOfFolder(path));
