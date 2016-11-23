using Backend.Model;
using System.Collections.Generic;

namespace Backend.Services
{
    public interface IAgroCultureService
    {
        ICollection<AgroCultureModel> List();
        AgroCultureFullModel GetByIdFullModel(int id);
        AgroCultureModel GetByIdShort(int id);

    }

    public class AgroCultureService : IAgroCultureService
    {
        public ICollection<AgroCultureModel> List()
        {
            return new[]
            {
                new AgroCultureModel {Id = 1, Name = "test"},
                new AgroCultureModel {Id = 2, Name = "test2"}
            };
        }

        public AgroCultureFullModel GetByIdFullModel(int id)
        {
            return new AgroCultureFullModel
            {
                Id = id,
                Name = "testt"
            };
        }

        public AgroCultureModel GetByIdShort(int id)
        {
            return new AgroCultureModel
            {
                Id = id,
                Name = "testt"
            };
        }
    }
}
