using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.FileProviders.AzureBlobStorage
{
    public class AzureBlobOptions
    {
        public string ConnectionString { get; set; }

        public string ContainerName { get; set; }
    }
}
