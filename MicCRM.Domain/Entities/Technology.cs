using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MicCRM.Domain.Entities
{
    public class Technology : Entity
    {
        public Technology()
        {
            Applicants = new List<Applicant>();
        }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Applicant> Applicants { get; set; }
    }
}
