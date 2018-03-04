using MicCRM.Domain.Repositories;
using MicCRM.Info.Models;
using MicCRM.Logic.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicCRM.Logic.Controllers
{
    public class TeacherController
    {
        TeacherRepository _repository;

        public TeacherController()
        {

        }

        public async Task<List<TeacherViewModel>> GetAllAsync()
        {

            List<TeacherViewModel> list = new List<TeacherViewModel>();
            using (_repository = new TeacherRepository())
            {
                list = Mapper.MapingTeacherViewModel((await Task.Run(() => _repository.GetAllAsync()))).ToList();
               
            }
            return list;
        }

        public async Task<bool> InsertOrUpdate(TeacherViewModel teacher)
        {
            using (_repository = new TeacherRepository())
            {
                return await _repository.InsertOrUpdate(Mapper.MapingTeacher(teacher));
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (_repository = new TeacherRepository())
            {
                return await _repository.Delete(id);
            }
        }

        public async Task<TeacherViewModel> GetByIdAsync(int id)
        {
            TeacherViewModel teacher = new TeacherViewModel();
            using (_repository = new TeacherRepository())
            {
                teacher = Mapper.MapingTeacherViewModel(await _repository.GetByIDAsync(id));
            }
            return teacher;
        }



    }
}
