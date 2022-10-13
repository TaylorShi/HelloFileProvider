using Microsoft.Extensions.FileProviders;
using System;

namespace consoleForFileProvider31
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFileProvider embeddedFileProvider = new EmbeddedFileProvider(typeof(Program).Assembly);
            IFileProvider physicalFileProvider = new PhysicalFileProvider(AppDomain.CurrentDomain.BaseDirectory);
            IFileProvider fileProvider = new CompositeFileProvider(embeddedFileProvider, physicalFileProvider);

            var dirContents = fileProvider.GetDirectoryContents("/");

            foreach (var fileInfo in dirContents)
            {
                var fileStream = fileInfo.CreateReadStream();
                Console.WriteLine($"FileName:{fileInfo.Name}, FileLength:{fileStream.Length}");
            }

            Console.ReadKey();
        }
    }
}
