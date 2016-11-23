using Backend.Model;
using System.Collections.Generic;

namespace Backend.Services
{
    public interface ICropRotationService
    {
        ICollection<CropRotationModel> List();
        CropRotationFullModel GetByIdFullModel(int id);
        CropRotationModel GetByIdShort(int id);

    }

    public class CropRotationService : ICropRotationService
    {
        public ICollection<CropRotationModel> List()
        {
            return new[]
            {
                new CropRotationModel {Id = 1, Name = "test"},
                new CropRotationModel {Id = 2, Name = "test2"}
            };
        }

        public CropRotationFullModel GetByIdFullModel(int id)
        {
            return new CropRotationFullModel();
        }

        public CropRotationModel GetByIdShort(int id)
        {
            return new CropRotationModel
            {
                Id = id,
                Name = "testt"
            };
        }

    }
}
