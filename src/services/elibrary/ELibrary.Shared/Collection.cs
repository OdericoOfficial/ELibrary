using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared
{
#nullable disable
    public class Collection : Entity
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CollectedBook> CollectedBooks { get; set; }
    }
}
