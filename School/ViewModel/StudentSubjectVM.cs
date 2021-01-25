using System.ComponentModel.DataAnnotations;

namespace School.ViewModel
{
    public class StudentSubjectVM : Models.StudentSubject
    {
        [Required]
        [Display (Name = "Student Name")]
        public int StudentFK { get; set; }
        [Required]
        [Display (Name = "Subject Name")]
        public int SubjectFK { get; set; }
    }
}