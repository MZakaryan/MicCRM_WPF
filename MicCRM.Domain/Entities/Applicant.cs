using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicCRM.Domain.Entities
{
    public class Applicant : Entity
    {
        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]   
        [DefaultValue(false)]
        public bool IsStudent { get; set; }
        [Required]
        public DateTime Date { get; set; }  
        public string Description { get; set; }
        [ForeignKey(nameof(Technology))]
        public int TechnologyID { get; set; }
        public virtual Technology  Technology { get; set; }
    }
}
