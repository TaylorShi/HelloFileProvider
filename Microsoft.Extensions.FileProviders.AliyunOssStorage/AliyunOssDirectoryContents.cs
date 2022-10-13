using Microsoft.Extensions.FileProviders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.FileProviders.AliyunOssStorage
{
    public class AliyunOssDirectoryContents : IDirectoryContents
    {
        private List<IFileInfo> _listInfos;

        public AliyunOssDirectoryContents(List<IFileInfo> listInfos)
        {
            _listInfos = listInfos;
        }

        public bool Exists => true;

        public IEnumerator<IFileInfo> GetEnumerator()
        {
            return _listInfos.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _listInfos.GetEnumerator();
        }
    }
}
