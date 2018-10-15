using System;
using System.Collections.Generic;
using System.Text;

namespace Mondol.FileService.Server.Models.Output
{
    public class FileDetailData
    {
        public FileData File { get; set; }
        public FileOwnerTypeId Owner { get; set; }
    }

    public class FileData
    {
        public string Name { get; set; }
        public long Length { get; set; }
        public int ServerId { get; set; }
        public int MimeId { get; set; }
        public string Hash { get; set; }
        public DateTime CreateTime { get; set; }
    }

    public class FileOwnerTypeId
    {
        public int OwnerType { get; set; }
        public int OwnerId { get; set; }
    }
}
