using MicCRM.Domain.Concrete;
using MicCRM.Domain.Entities;
using MicCRM.Info.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MicCRM.Domain.Repositories
{
    public class ApplicantRepository : MicCRMRepository<Applicant>
    {

        public async override void Delete(int id)
        {
            Applicant ap = await base.GetByIDAsync(id);
            ap.Deleted = true;
            InsertOrUpdate(ap);
        } 

    }
}
