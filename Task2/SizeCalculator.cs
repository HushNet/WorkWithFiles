namespace Task2;

public class SizeCalculator
{
    public long totalSize = 0;

    public long CalculateSizeOfFolder(string path)
    {
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
}