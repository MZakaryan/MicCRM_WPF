 
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
    public class StudentController
    {
        StudentRepository _repository;
        public async Task<List<StudentViewModel>> GetAllAsync()
        { 
            List<StudentViewModel> list = new List<StudentViewModel>();
            using (_repository = new StudentRepository())
            {
                list = Mapper.MapingStudentViewModel((await Task.Run(() => _repository.GetAllAsync()))).ToList();
            }
            return list;
        }
        public void Delete(int id)
        {
            using (_repository = new StudentRepository())
            {
                _repository.Delete(id);
            }
        } 
        public void InsertOrUpdate(StudentViewModel sd)
        {
            using (_repository = new StudentRepository())
            {
                _repository.InsertOrUpdate(Mapper.MapingStudent(sd));
            }
        }  
        public async void AddStudent(StudentViewModel student)
        {
            using (_repository = new StudentRepository())
            {
                _repository.Insert(Mapper.MapingStudent(student));
                await _repository.SaveAsync();
            }
        }
        public async Task<StudentViewModel> GetByIdAsync(int id)

        {
            StudentViewModel sd = new StudentViewModel();
            using (_repository = new StudentRepository())
            {
                sd = Mapper.MapingStudentViewModel(await _repository.GetByIDAsync(id));
            }
            return sd;
        }
    }
}
