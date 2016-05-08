using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IHarvestPlanService
    {
        ICollection<HarvestPlanModel> List();
        HarvestPlanFullModel GetByIdFullModel(int id);
        HarvestPlanModel GetByIdShort(int id);
        HarvestPlanElementaryAreaItem GetHarvestPlanElementaryArea(int id);
    }

    public class HarvestPlanService : IHarvestPlanService
    {
        public ICollection<HarvestPlanModel> List()
        {
            return new[]
            {
                new HarvestPlanModel {Id = 1, Name = "test"},
                new HarvestPlanModel {Id = 2, Name = "test2"}
            };
        }

        public HarvestPlanFullModel GetByIdFullModel(int id)
        {
            return new HarvestPlanFullModel
            {
                Id = id,
                Name = "testt"
            };
        }

        public HarvestPlanModel GetByIdShort(int id)
        {
            return new HarvestPlanModel
            {
                Id = id,
                Name = "testt"
            };
        }

        public HarvestPlanElementaryAreaItem GetHarvestPlanElementaryArea(int id)
        {
            return new HarvestPlanElementaryAreaItem
            {
                Id = id
            };
        }
    }
}
