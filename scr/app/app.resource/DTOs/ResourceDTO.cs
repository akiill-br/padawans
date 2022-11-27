using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ApiResource.Application.DTOs
{
    public class ResourceDTO
    {
        public long ID_RESOURCES { get; set; }
        public int ID_CAMPAIGN { get; set; }
        public string? FULL_PATH { get; set; }
        public string? RELATIVE_PATH { get; set; }
        public string? FILENAME { get; set; }
        public int? ID_RES_TYPE { get; set; }
        public short PRIORITY { get; set; }
        public long? ID_IMG { get; set; }
        public string? MESSAGE { get; set; }
        public int? TIME_SECONDS { get; set; }
        public string? URL { get;  set; }
        public int? ID_TRANSACTION { get; set; }
        public int? ID_CAMPAIGN_PARENT { get; set; }
        public string? CRC { get; set; }
    }
}
