using System;
using System.ComponentModel.DataAnnotations;

namespace launchpadApp.Models {

    public class Link {
        [Key]
        public int id { get; set; }
        public int categoryID { get; set; }
        [Required]
        [MaxLength(50)]
        public string name {get; set;}
        [Required]
        [Url]
        public string href {get; set;}
        public bool pinned {get; set;}
    }
}
