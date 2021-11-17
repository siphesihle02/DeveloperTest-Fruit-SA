﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DeveloperTest_Fruit_SA.Models
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        [DisplayName("Category Code")]
        public string categoryCode { get; set; }
        [Required]
        public bool isActive { get; set; }
        public virtual ICollection<Product> products { get; set; }
    }
}