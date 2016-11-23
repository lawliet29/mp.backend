using System.Collections.Generic;
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
        private readonly IDbConnectionService _connectionService;
        private readonly IEntityLoader<WorkAreaModel> _entityLoader;

        public WorkAreaService(IDbConnectionService connectionService, IEntityLoader<WorkAreaModel> entityLoader)
        {
            _connectionService = connectionService;
            _entityLoader = entityLoader;
        }

        public ICollection<WorkAreaModel> List()
        {
            using (var connection = _connectionService.Connect())
            {
                return _entityLoader.LoadList(connection);
            }
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
