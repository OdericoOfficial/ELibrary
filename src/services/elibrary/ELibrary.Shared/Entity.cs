using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared
{
#nullable disable
    public abstract class Entity
    {
        public string Id { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
