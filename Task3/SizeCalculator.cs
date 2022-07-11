namespace Task2;

public class SizeCalculator
{
    public long CalculateSizeOfFolder(string path)
    {
        long totalSize = 0;
        var directoryInfo = new DirectoryInfo(path);
        var catalogs = directoryInfo.GetDirectories();
        var files = directoryInfo.GetFiles();
        

        foreach (var file in files)
        {
            if (file.Exists)
            {
                totalSize += file.Length;
            }
        }

        foreach (var cat in catalogs)
        {
            if (cat.Exists)
            {
                totalSize += CalculateSizeOfFolder(cat.FullName);
            }
        }

        return totalSize;
    }

    public void CleanFilesNotUsed(string path)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(path);
        var catalogs = directoryInfo.GetDirectories();
        var files = directoryInfo.GetFiles();

        foreach (var file in files)
        {
            if (file.Exists)
            {
                if (Math.Abs(file.LastWriteTime.Subtract(DateTime.Now).TotalMinutes) > 30)
                {
                    try
                    {
                        file.Delete();
                        Console.WriteLine($"Файл {file.Name} удален");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }

        foreach (var cat in catalogs)
        {
            if (cat.Exists)
            {
                CleanFilesNotUsed(cat.FullName);
                if (Math.Abs(cat.LastWriteTime.Subtract(DateTime.Now).TotalMinutes) > 30 && cat.GetFiles().Length == 0)
                {
                    try
                    {
                        cat.Delete();
                        Console.WriteLine($"Каталог {cat.Name} удален");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }
    }
}