using System.Collections.Generic;

namespace MicCRM.Info.Models
{
    public class TeacherViewModel
    {
        public TeacherViewModel()
        {
            Lessons = new List<LessonViewModel>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
      
        public bool IsDeleted { get; set; }
        public IEnumerable<LessonViewModel> Lessons { get; set; }
    }
}
