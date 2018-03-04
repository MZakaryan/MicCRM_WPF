using MicCRM.Domain.Concrete;
using MicCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicCRM.Domain.Repositories
{
    public class StudentRepository : MicCRMRepository<Student>
    {
        public async override void Delete(int id)
        {
            Student sd = await base.GetByIDAsync(id);
            sd.Deleted = true;
            InsertOrUpdate(sd);
        }
    }
}
