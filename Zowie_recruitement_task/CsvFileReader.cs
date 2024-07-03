namespace Zowie_recruitement_task
{
    internal class CsvFileReader
    {
        public List<string> ReadCsvFileSkipHeader(string filePath)
        {
            var fileLines = File.ReadAllLines(filePath);

            return fileLines.Skip(1).ToList();
        }
    }
}
