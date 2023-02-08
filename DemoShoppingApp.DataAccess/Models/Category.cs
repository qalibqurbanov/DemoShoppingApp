using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace DemoShoppingApp.DataAccess.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Category name")]
        [Required]
        public string CategoryName{ get; set; }

        [DisplayName("Display order")]
        public int CategoryDisplayOrder { get; set; }

        [DisplayName("Created date")]
        public DateTime CategoryCreatedDate { get; set; } = DateTime.Now;
    }
}
