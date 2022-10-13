using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.AliyunOssStorage;
using System;

namespace consoleForAliyunOssFileProvider31
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var config = builder.Build();
            var aliyunOssConfigSection = config.GetSection("AliyunOss");
            var aliyunOssOptions = new AliyunOssOptions();
            aliyunOssConfigSection.Bind(aliyunOssOptions);
            
            IFileProvider fileProvider = new AliyunOssFileProvider(aliyunOssOptions);

            var dirContents = fileProvider.GetDirectoryContents("/");

            foreach (var fileInfo in dirContents)
            {
                //var fileStream = fileInfo.CreateReadStream();
                Console.WriteLine($"FileName:{fileInfo.Name}");
            }

            Console.ReadKey();
        }
    }
}
