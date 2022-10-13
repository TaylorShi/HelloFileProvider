using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.FileProviders.AliyunOssStorage
{
    public class AliyunOssOptions
    {
        public string Endpoint { get; set; }

        public string AccessKeyId { get; set; }

        public string AccessKeySecret { get; set; }

        public string Bucket { get; set; }
    }
}
