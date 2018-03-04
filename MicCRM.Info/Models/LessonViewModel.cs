using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicCRM.Info.Models
{
    public class LessonViewModel
    {
        public LessonViewModel()
        {
            Teachers = new List<TeacherViewModel>();
            Students = new List<StudentViewModel>();
        }
        public int Id { get; set; } 
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public TechnologyViewModel TechnologyModel { get; set; }
        public IEnumerable<TeacherViewModel> Teachers { get; set; }
        public IEnumerable<StudentViewModel> Students { get; set; }
        
    }
}
