namespace Task1;

public class FilesCleaner
{
    public void CleanFilesNotUsed(DirectoryInfo directoryInfo)
    {
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
                CleanFilesNotUsed(cat);
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