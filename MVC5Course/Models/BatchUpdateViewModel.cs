﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class BatchUpdateViewModel
    {
        public int ProductId { get; set; }
        [Required]
        [Range(1,99999)]
        public Nullable<decimal> Price { get; set; }
        [Required]
        public Nullable<bool> Active { get; set; }
        [Required]
        [Range(1,99999)]
        public Nullable<decimal> Stock { get; set; }
    }
}