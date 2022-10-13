using Aliyun.OSS;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Extensions.FileProviders.AliyunOssStorage
{
    public class AliyunOssFileProvider : IFileProvider
    {
        readonly OssClient ossClient;
        readonly Bucket bucket;

        public AliyunOssFileProvider(AliyunOssOptions aliyunOssOptions)
        {
            ossClient = new OssClient(aliyunOssOptions.Endpoint, aliyunOssOptions.AccessKeyId, aliyunOssOptions.AccessKeySecret);
            var buckets = ossClient.ListBuckets();
            bucket = buckets.FirstOrDefault(x => x.Name == aliyunOssOptions.Bucket);
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            var listObjectsRequest = new ListObjectsRequest(bucket.Name)
            {
                // 通过MaxKeys指定列举文件的最大个数为200。 MaxKeys默认值为100，最大值为1000。
                MaxKeys = 200,
            };
            var oSSObjects = ossClient.ListObjects(listObjectsRequest);
            return FromAliyunObjects(oSSObjects);
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            return null;
        }

        public IChangeToken Watch(string filter)
        {
            return null;
        }

        private IDirectoryContents FromAliyunObjects(ObjectListing oSSObjects)
        {
            var files = new List<IFileInfo>();

            foreach (var aliyunObject in oSSObjects.ObjectSummaries)
            {
                var aliyunOssFileInfo = new AliyunOssFileInfo()
                {
                    Name = aliyunObject.Key,
                };
                files.Add(aliyunOssFileInfo);
            }
            
            return new AliyunOssDirectoryContents(files);
        }
    }
}
