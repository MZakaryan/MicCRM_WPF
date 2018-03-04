using MicCRM.Domain.Concrete;
using MicCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicCRM.Domain.Repositories
{
    public class TechnologyRepository : MicCRMRepository<Technology>
    { 
        public  Task<Technology> GetByNameAsync(string name)
        {
            return Task.Run((() => _context.Technology.Where(t => t.Name == name).FirstOrDefault()));
        }
    }
}
