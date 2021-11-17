using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace DeveloperTest_Fruit_SA.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Product Code")]
        public string productCode { get; set; }
        [Required(ErrorMessage = "Please enter  a product name")]
        [DisplayName("Product Name")]
        public string productName { get; set; }
        [DisplayName("Description")]
        public string description { get; set; }
        [Required(ErrorMessage = "Please choose a product category")]
        [DisplayName("Category Name")]
        public string categoryName { get; set; }
        [Required(ErrorMessage = "Please enter price")]
        [DisplayName("Price")]
        public double price { get; set; }
        [Required]
        public string image { get; set; }
        [NotMapped]
        public HttpPostedFileBase imageFile { get; set; }
        public virtual category Category { get; set; }
    }
}