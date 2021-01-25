using System.ComponentModel.DataAnnotations;

namespace School.ViewModel
{
    public class StudentsVM : Models.Student
    {
        [Required]
        [Display(Name = "Student Name")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Teacher Name")]
        public int TeacherFK { get; set; }
    }
}