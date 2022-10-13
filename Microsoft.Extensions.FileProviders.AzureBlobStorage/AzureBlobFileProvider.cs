using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.FileProviders.AzureBlobStorage
{
    public class AzureBlobFileProvider : IFileProvider
    {
        readonly BlobContainerClient blobContainerClient;

        public AzureBlobFileProvider(AzureBlobOptions azureBlobOptions)
        {
            blobContainerClient = new BlobContainerClient(azureBlobOptions.ConnectionString, azureBlobOptions.ContainerName);
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            Pageable<BlobItem> blobPageItems = blobContainerClient.GetBlobs();
            return FromAzureBlobs(blobPageItems);
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            throw new NotImplementedException();
        }

        public IChangeToken Watch(string filter)
        {
            throw new NotImplementedException();
        }

        private IDirectoryContents FromAzureBlobs(Pageable<BlobItem> blobPageItems)
        {
            var files = new List<IFileInfo>();

            foreach (var blobItem in blobPageItems)
            {
                var azureBlobFileInfo = new AzureBlobFileInfo(blobContainerClient)
                {
                    Name = blobItem.Name,
                    Length = blobItem.Properties.ContentLength ?? 0,
                    LastModified = blobItem.Properties.LastModified ?? default,
                };
                azureBlobFileInfo.SetPhysicalPath(blobContainerClient.Uri.OriginalString);
                files.Add(azureBlobFileInfo);
            }

            return new AzureBlobDirectoryContents(files);
        }
    }
}
