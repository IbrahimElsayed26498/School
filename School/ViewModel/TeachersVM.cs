using System.ComponentModel.DataAnnotations;

namespace School.ViewModel
{
    public class TeachersVM : Models.Teacher
    {

        [Required]
        [Display(Name = "Teacher Name")]
        public string Name { get; set; }
    }
}