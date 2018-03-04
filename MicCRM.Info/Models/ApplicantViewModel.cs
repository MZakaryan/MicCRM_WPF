using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicCRM.Info.Models
{
    public class ApplicantViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public bool IsStudent { get; set; }
        public bool Deleted { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public TechnologyViewModel Technology; 
    }
}
