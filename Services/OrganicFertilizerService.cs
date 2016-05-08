using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IOrganicFertilizerService
    {
        ICollection<OrganicFertilizerModel> List();
        OrganicFertilizerFullModel GetByIdFullModel(int id);
        OrganicFertilizerModel GetByIdShort(int id);

    }

    public class OrganicFertilizerService : IOrganicFertilizerService
    {
        public ICollection<OrganicFertilizerModel> List()
        {
            return new[]
            {
                new OrganicFertilizerModel {ElemAreaId = 1, Fertilizer = ""},
                new OrganicFertilizerModel {ElemAreaId = 4, Fertilizer = ""}
            };
        }

        public OrganicFertilizerFullModel GetByIdFullModel(int id)
        {
            return new OrganicFertilizerFullModel
            {
                ElemAreaId = 1,
                Fertilizer = ""
            };
        }

        public OrganicFertilizerModel GetByIdShort(int id)
        {
            return new OrganicFertilizerFullModel
            {
                ElemAreaId = 1,
                Fertilizer = ""
            };
        }
    }
}
