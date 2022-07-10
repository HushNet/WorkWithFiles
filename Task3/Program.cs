using System.Threading.Channels;
using Task2;

string path = @"C:\Users\Alexey\Desktop\hohoho";
SizeCalculator sc = new SizeCalculator();

Console.WriteLine("Размер до удаления: ");
Console.WriteLine(sc.CalculateSizeOfFolder(path));


sc.CleanFilesNotUsed(path);

Console.WriteLine("Размер после удаления: ");
Console.WriteLine(sc.CalculateSizeOfFolder(path));