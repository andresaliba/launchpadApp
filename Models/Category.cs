using System;
using System.ComponentModel.DataAnnotations;

namespace launchpadApp.Models {

    public class Category {
        [Key]
        public int categoryID { get; set; }
        [Required]
        [MaxLength(50)]
        public string name {get; set;}
    }
}
