using Task1;

DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Users\Alexey\Desktop\hohoho");

FilesCleaner filesCleaner = new FilesCleaner();

filesCleaner.CleanFilesNotUsed(directoryInfo);