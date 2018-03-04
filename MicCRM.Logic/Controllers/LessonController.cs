using MicCRM.Domain.Repositories;
using MicCRM.Info.Models;
using MicCRM.Logic.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MicCRM.Logic.Controllers
{
    public class LessonController
    {
        LessonRepository  _repository; 
        public void Delete(int id)
        { 
            using (_repository = new LessonRepository())
            {
               _repository.Delete(id);
            }
        } 
        public void  InsertOrUpdate(LessonViewModel lesson)
        { 
            using (_repository = new LessonRepository())
            {
                 _repository.InsertOrUpdate(Mapper.MapingLesson(lesson));
            }
            
        }
        public async Task<List<LessonViewModel>> GetAllAsync()
        {
            List<LessonViewModel> list = new List<LessonViewModel>();
            using (_repository = new LessonRepository())
            {
                list = Mapper.MapingLessonViewModel(await Task.Run(() => _repository.GetAllAsync())).ToList();
            }
            return list;
        }
        public async Task<LessonViewModel> GetByIdAsync(int id)
        {
            LessonViewModel l = new LessonViewModel();
            using (_repository = new LessonRepository())
            {
                l = Mapper.MapingLessonViewModel(await _repository.GetByIDAsync(id));
            }
            return l;
        }
    }
}
