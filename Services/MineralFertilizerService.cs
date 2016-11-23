using Backend.Model;
using System.Collections.Generic;

namespace Backend.Services
{
    public interface IMineralFertilizerService
    {
        ICollection<MineralFertilizerModel> List();
        MineralFertilizerFullModel GetByIdFullModel(int id);
        MineralFertilizerModel GetByIdShort(int id);

    }

    public class MineralFertilizerService : IMineralFertilizerService
    {
        public ICollection<MineralFertilizerModel> List()
        {
            return new[]
            {
                new MineralFertilizerModel {ElemAreaId = 1, Fertilizer = ""},
                new MineralFertilizerModel {ElemAreaId = 1, Fertilizer = ""}
            };
        }

        public MineralFertilizerFullModel GetByIdFullModel(int id)
        {
            return new MineralFertilizerFullModel
            {
                ElemAreaId = 1,
                Fertilizer = ""
            };
        }

        public MineralFertilizerModel GetByIdShort(int id)
        {
            return new MineralFertilizerModel
            {
                ElemAreaId = 1,
                Fertilizer = ""
            };
        }
    }
}
