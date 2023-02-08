using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DemoShoppingApp.DataAccess.Models
{
    public class Product
    {
        public int ID { get; set; }

        public int ProductCategoryID { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public double ProductPrice { get; set; }

        [ValidateNever]
        public string ProductImageUrl { get; set; }

        [ValidateNever]
        public Category ProductCategory { get; set; } // nav prop | 1 to many
    }
}
