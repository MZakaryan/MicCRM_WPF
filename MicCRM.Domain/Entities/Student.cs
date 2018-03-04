using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicCRM.Domain.Entities
{
    public class Student : Entity
    {
        public Student()
        {
            Lessons = new List<Lesson>(); 
        }
        [ForeignKey(nameof(Applicant))]
        public int ApplicantId { get; set; }
        public virtual Applicant Applicant { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool IsWorker { get; set; }
        public string Description { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        public virtual  ICollection<Lesson> Lessons { get; set; } 
    }
}
