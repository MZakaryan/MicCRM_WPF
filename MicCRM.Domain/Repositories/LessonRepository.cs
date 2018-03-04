using MicCRM.Domain.Concrete;
using MicCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicCRM.Domain.Repositories
{
    public class LessonRepository:MicCRMRepository<Lesson>
    {
        public async override void Delete(int id)
        {
            Lesson lesson = await base.GetByIDAsync(id);
            lesson.Deleted = true;
            InsertOrUpdate(lesson);
        }
    }
}
