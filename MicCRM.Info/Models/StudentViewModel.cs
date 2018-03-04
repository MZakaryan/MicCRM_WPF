using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicCRM.Info.Models
{
    public class StudentViewModel
    {
        public StudentViewModel()
        {
            Lessons = new List<LessonViewModel>();
        }
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public bool IsWorker { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<LessonViewModel> Lessons { get; set; }


        public int ApplicantViewModelId { get; set; }
        public ApplicantViewModel ApplicantViewModel { get; set; }
        public TechnologyViewModel LastTechnology { get; set; }
    }
}
