using System;
using System.Collections.Generic;
using System.Text;
using Mondol.FileService.Db.Entities;

namespace Mondol.FileService.Service.Models
{
    public class FileStorageInfo
    {
        public File File { get; set; }
        public FileOwner Owner { get; set; }

        public Service.Options.Server Server { get; set; }

        public uint PseudoId { get; set; }
    }
}
