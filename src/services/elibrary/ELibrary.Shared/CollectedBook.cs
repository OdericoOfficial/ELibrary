using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared
{
#nullable disable
    public class CollectedBook : Entity
    {
        public string CollectionId { get; set; }
        public virtual Collection Collection { get; set; }

        public string BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
