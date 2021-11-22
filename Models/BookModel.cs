﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_Server_App.Models
{
    public class BookModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public string Isbn { get; set; }

        public string Summary { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        public int? AuthorId { get; set; }
        public virtual AuthorModel Author { get; set; }
    }
}
