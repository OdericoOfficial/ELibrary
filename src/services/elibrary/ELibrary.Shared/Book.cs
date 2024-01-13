using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared
{
#nullable disable
    public class Book : Entity
    {        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }
        public int PublishYear { get; set; }
        public string Classification { get; set; }
        public string Press { get; set; }
        public string Writer { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }

        public string ImageUrl { get; set; }
        public string FileUrl { get; set; }

        public virtual ICollection<CollectedBook> CollectedBooks { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}
