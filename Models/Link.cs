using System;
using System.ComponentModel.DataAnnotations;

namespace launchpadApp.Models {

    public class Link {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name="Category ID")]
        public int categoryID { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name="Link Name")]
        public string linkName {get; set;}

        [Required]
        [Url(ErrorMessage = "Link must be an URL")]
        [Display(Name="Link URL")]
        public string url {get; set;}

        public bool pinned {get; set;}
    }
}
 