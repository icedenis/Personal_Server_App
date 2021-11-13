using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_Server_App.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [DisplayName("Commends")]
        public string Bio { get; set; }

        // Here is the exple that Autho  to book is 1:N rationship  1 autor many books in db
        public virtual IList<BookModel> Books { get; set; }
    }
}
