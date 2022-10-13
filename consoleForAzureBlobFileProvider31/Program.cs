using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.AzureBlobStorage;
using System;

namespace consoleForAzureBlobFileProvider31
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var config = builder.Build();
            var aliyunOssConfigSection = config.GetSection("AzureBlobConfig");
            var aliyunOssOptions = new AzureBlobOptions();
            aliyunOssConfigSection.Bind(aliyunOssOptions);

            IFileProvider fileProvider = new AzureBlobFileProvider(aliyunOssOptions);

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
