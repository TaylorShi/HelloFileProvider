using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Microsoft.Extensions.FileProviders.AliyunOssStorage
{
    public class AliyunOssFileInfo : IFileInfo
    {
        public bool Exists { get { return true; } }

        public long Length { get; set; }

        public string PhysicalPath { get; set; }

        public string Name { get; set;}

        public DateTimeOffset LastModified { get; set; }

        public bool IsDirectory { get { return false; } }

        public Stream CreateReadStream()
        {
            throw new NotImplementedException();
        }
    }
}
