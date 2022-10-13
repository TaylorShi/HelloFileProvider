using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.FileProviders.AzureBlobStorage
{
    public class AzureBlobDirectoryContents : IDirectoryContents
    {
        private List<IFileInfo> _fileInfos;

        public AzureBlobDirectoryContents(List<IFileInfo> fileInfos)
        {
            this._fileInfos = fileInfos;
        }

        public bool Exists => true;

        public IEnumerator<IFileInfo> GetEnumerator()
        {
            return _fileInfos.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _fileInfos.GetEnumerator();
        }
    }
}
