using Azure.Storage.Blobs;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;

namespace Microsoft.Extensions.FileProviders.AzureBlobStorage
{
    public class AzureBlobFileInfo : IFileInfo
    {
        private readonly BlobContainerClient _blobContainerClient;
        public AzureBlobFileInfo(BlobContainerClient blobContainerClient)
        {
            _blobContainerClient = blobContainerClient;
        }

        public bool Exists => true;

        public long Length { get; set; }

        public string PhysicalPath { get; private set; }

        public string Name { get; set; }

        public DateTimeOffset LastModified { get; set; }

        public bool IsDirectory { get; set; }

        public Stream CreateReadStream()
        {
            var ms = new MemoryStream();
            var response = _blobContainerClient.GetBlobClient(Name).DownloadTo(ms);
            if(response.Status == 200)
            {
                ms.Position = 0;
            }
            return ms;
        }

        public void SetPhysicalPath(string containerRootPath)
        {
            PhysicalPath = $"{containerRootPath}/{Name}";
        }
    }
}
