using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared
{
    public class BookUserStatus
    {
        public bool IsScore { get; set; }
        public double Value { get; set; }
        public bool IsCollected { get; set; }
        public string? CollectionId { get; set; }
    }
}
