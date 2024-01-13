using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared
{
#nullable disable
    public class Comment : Entity
    {
        public string UserId { get; set; }
        public string UserName { get; set; }

        public string BookId { get; set; }
        public virtual Book Book { get; set; }
        
        public string Description { get; set; }
    }
}
