using System.ComponentModel.DataAnnotations;

namespace School.ViewModel
{
    public class SubjectsVM : Models.Subject
    {
        [Required]
        [Display(Name = "Subject Name")]
        public string Name { get; set; }
    }
}