using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Async
{
    public class Reader
    {
        public FileService FileService { get; set; }
        public async Task<string> ReadFormFiles(StreamReader firstStream, StreamReader secondStream)
        {
            var listOfTasks = new List<Task<string>>();
            listOfTasks.Add(Task<string>.Run<string>(() => { return FileService.ReadFile(firstStream).GetAwaiter().GetResult(); }));
            listOfTasks.Add(Task<string>.Run<string>(() => { return FileService.ReadFile(secondStream).GetAwaiter().GetResult(); }));
            await Task.WhenAll<string>(listOfTasks);
            return listOfTasks[0].Result + listOfTasks[1].Result;
        }
    }
}
