using MicCRM.Domain.Concrete;
using MicCRM.Domain.Entities;
using MicCRM.Info.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicCRM.Domain.Repositories
{
    public class TeacherRepository: MicCRMRepository<Teacher>
    {
        public async override Task<bool> Delete(int id)
        {           
            Teacher teacher = await base.GetByIDAsync(id);
            teacher.IsDeleted = true;
            return await InsertOrUpdate(teacher);
        }
    }
}
