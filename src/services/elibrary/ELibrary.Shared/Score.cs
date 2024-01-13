using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared
{
#nullable disable
    public class Score : Entity
    {
        public string UserId { get; set; }

        public string BookId { get; set; }
        public virtual Book Book { get; set; }

        public double Value { get; set; }
    }
}
