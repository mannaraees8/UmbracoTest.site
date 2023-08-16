using System.ComponentModel.DataAnnotations;

namespace UmbracoTest.site.umbraco.models
{
    public class ContactModel
    {
        [Required]
        public string? FullName { get; set; }
        [EmailAddress]
        [Required]
        public string? Email { get; set; }
        [Phone]
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Message { get; set; }
    }
}
