using System;
using System.IO;
using System.Threading.Tasks;

namespace Async
{
    public class FileService
    {
        public StreamReader CreateFile(string dirPath, string fileName, string text)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            var fullFileName = $"{dirPath}/{fileName}";
            using (var streamWriter = new StreamWriter(fullFileName, false))
            {
                streamWriter.WriteLine(text);
                streamWriter.Close();
            }

            return new StreamReader(fullFileName);
        }

        public async Task<string> ReadFile(StreamReader streamReader)
        {
            string text = string.Empty;
            using (streamReader)
            {
                text = await streamReader.ReadToEndAsync();
                streamReader.Close();
            }

            return text;
        }
    }
}
