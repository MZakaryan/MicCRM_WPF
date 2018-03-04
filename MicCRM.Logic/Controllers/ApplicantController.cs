using MicCRM.Domain.Entities;
using MicCRM.Domain.Repositories;
using MicCRM.Info.Models;
using MicCRM.Logic.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicCRM.Logic.Controllers
{
    public class ApplicantController 
    {
        ApplicantRepository _repository;
        public async Task<List<ApplicantViewModel>> GetAllAsync()
        { 
            List<ApplicantViewModel> list = new List<ApplicantViewModel>();
            using (_repository = new ApplicantRepository())
            {
                list = Mapper.MapingApplicantViewModel((await Task.Run(() => _repository.GetAllAsync())))
                    .Where((item) => item.Deleted != true && item.IsStudent != true)
                    .ToList(); 
            }
            return list;
        }
        public void Delete(int id)
        {
            using(_repository= new ApplicantRepository())
            {
                _repository.Delete(id);
            } 
        }
        public async void AddApplicants(List<ApplicantViewModel> applicants)
        {
            using (_repository = new ApplicantRepository())
            {
                foreach (var item in applicants)
                {
                    _repository.Insert(Mapper.Mapaplicant(item));
                } 
                await _repository.SaveAsync();
            }
        }
        public async Task MakeStudent(int ID)
        {
            using (_repository = new ApplicantRepository())
            {
                var app = await _repository.GetByIDAsync(ID);
                app.IsStudent = true;
                _repository.InsertOrUpdate(app);
                await   _repository.SaveAsync();
            } 
        }
        public async Task UpdateApplicant(int ID, ApplicantViewModel UpDatedApp)
        {
            using (_repository = new ApplicantRepository())
            {
                var app = await _repository.GetByIDAsync(ID);
                app.FirstName = UpDatedApp.FirstName;
                app.LastName = UpDatedApp.LastName;
                app.Phone1 = UpDatedApp.Phone1;
                app.Email = UpDatedApp.Email;
                app.Description = UpDatedApp.Description;
                app.IsStudent = UpDatedApp.IsStudent;
                app.Deleted = UpDatedApp.Deleted;
                app.Date = UpDatedApp.Date;
                app.TechnologyID = UpDatedApp.Technology.Id;
                _repository.Update(app);
                await _repository.SaveAsync(); 
            }
        }
        public async Task<ApplicantViewModel>  GetApplicant(int ID)
        {
            ApplicantViewModel applicantViewModel = null;
            using (_repository = new ApplicantRepository())
            {
                applicantViewModel = Mapper.MapingApplicantViewModel(await _repository.GetByIDAsync(ID));  
            }
            return applicantViewModel;
        }
        public async  void InsertOrUpdate(ApplicantViewModel ap)
        {
            using (_repository = new ApplicantRepository())
            {
                _repository.InsertOrUpdate(Mapper.MapingApplicant(ap));
                await _repository.SaveAsync();
            } 
        }
        public  void Insert(ApplicantViewModel ap)
        {
            using (_repository = new ApplicantRepository())
            {
                _repository.Insert(Mapper.MapingApplicant(ap)); 
            }
        }
        public  void Update(ApplicantViewModel ap)
        {
            using (_repository = new ApplicantRepository())
            {
                _repository.Update(Mapper.MapingApplicant(ap)); 
            }
        }
        public async void SaveApplicant()
        {
            using (_repository = new ApplicantRepository())
            {
              await  _repository.SaveAsync();
            }
        }
        public async Task<ApplicantViewModel> GetByIdAsync(int id)
        {
            ApplicantViewModel ap = new ApplicantViewModel();
            using (_repository = new ApplicantRepository())
            {
                ap = Mapper.MapingApplicantViewModel(await _repository.GetByIDAsync(id));
            }
            return ap; 
        } 
    }
}
