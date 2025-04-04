using System.ComponentModel.DataAnnotations;

namespace ContactController.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage ="Email is invalid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"\(\d{2}\)\s\d{5}-\d{4}", ErrorMessage = "Phone must be in the format (99) 99999-9999")]
        public string Phone { get; set; }

    }
}
