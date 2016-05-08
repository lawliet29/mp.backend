using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Model;

namespace Backend.Services
{
    public interface IWorkAreaService
    {
        ICollection<WorkAreaModel> List();
        WorkAreaFullModel GetByIdFullModel(int id);
        WorkAreaModel GetByIdShort(int id);
        ICollection<WorkAreaHistoryItem> GetHistoryById(int id);
    }

    public class WorkAreaService : IWorkAreaService
    {
        public ICollection<WorkAreaModel> List()
        {
            return new[]
            {
                new WorkAreaModel {Id = 1, Name = "test"},
                new WorkAreaModel {Id = 2, Name = "test2"}
            };
        }

        public WorkAreaFullModel GetByIdFullModel(int id)
        {
            return new WorkAreaFullModel
            {
                Id = id,
                Name = "testt",
                Active = true
            };
        }

        public WorkAreaModel GetByIdShort(int id)
        {
            return new WorkAreaModel
            {
                Id = id,
                Name = "testt"
            };
        }

        public ICollection<WorkAreaHistoryItem> GetHistoryById(int id)
        {
            return new[]
            {
                new WorkAreaHistoryItem() {Id = 1, Year = 2011, AgroCulture = "", WorkAreaYield = 33, WorkAreaSeedMass = 44},
                new WorkAreaHistoryItem() {Id = 2, Year = 2012, AgroCulture = "", WorkAreaYield = 55, WorkAreaSeedMass = 66}
            };
        }
    }
}
