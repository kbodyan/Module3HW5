using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Async
{
    public class Program
    {
        private const string File1 = "first_file.txt";
        private const string File2 = "second_file.txt";
        private const string Directory = ".. /Files";
        private static FileService _fileService = new FileService();
        public static void Main(string[] args)
        {
            var streamReader1 = _fileService.CreateFile(Directory, File1, "Hello");
            var streamReader2 = _fileService.CreateFile(Directory, File2, "World");
            var reader = new Reader { FileService = _fileService };
            var result = reader.ReadFormFiles(streamReader1, streamReader2).GetAwaiter().GetResult();
            Console.WriteLine(result);
        }
    }
}
