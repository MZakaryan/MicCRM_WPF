using MicCRM.Domain.Concrete;
using MicCRM.Domain.Entities;
using MicCRM.Info.Models;
using MicCRM.Logic.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MicCRM.Domain.Repositories;
using System.Threading.Tasks;

namespace MicCRM.Logic.Controllers
{
   public class TechnologyController
    {
        TechnologyRepository _repository;
        public async Task<List<TechnologyViewModel>> GetAllAsync()
        {
            List<TechnologyViewModel> list = new List<TechnologyViewModel>();
            using (_repository = new TechnologyRepository())
            {
                var tech = await Task.Run(() => _repository.GetAllAsync());
                list = Mapper.MapingTechnologyViewModel(tech).ToList(); 
            }
            return list;
        }
        public async Task<TechnologyViewModel> GetByIdAsync(int id) 
        {
            TechnologyViewModel sd = new TechnologyViewModel();
            using (_repository = new TechnologyRepository())
            {
                sd = Mapper.MapingTechnologyViewModel(await _repository.GetByIDAsync(id));
            }
            return sd;
        }
        public async  Task<TechnologyViewModel> GetByNameAsync(string TechnologyName)
        { 
            TechnologyViewModel tech = new TechnologyViewModel();
            using (_repository = new TechnologyRepository())
            {
                tech = Mapper.MapingTechnologyViewModel(await _repository.GetByNameAsync(TechnologyName));
            }
            return tech;
        }
    } 
}
