using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Model;

namespace Backend.Services
{
    public interface IElementaryAreaService
    {
        ICollection<ElementaryAreaModel> List();
        ElementaryAreaFullModel GetById(int id);
        ICollection<ElementaryAreaHistoryIItem> GetHistoryById(int id);
        ICollection<ElementaryAreaSoilComposition> GetElAreaSoilCompositionById(int id);
        ICollection<ElementaryAreaModel> GetElementaryAreasByWorkAreaId(int id);
        ICollection<ElementaryAreaModel> GetElementaryAreasByFieldId(int id);
    }

    public class ElementaryAreaService : IElementaryAreaService
    {
        public ICollection<ElementaryAreaModel> List()
        {
            return new[]
            {
                new ElementaryAreaModel {Id = 1, Name = "test"},
                new ElementaryAreaModel {Id = 2, Name = "test2"}
            };
        }

        public ElementaryAreaFullModel GetById(int id)
        {
            return new ElementaryAreaFullModel
            {
                Id = id,
                Name = "testt",
                Number = 42
            };
        }

        public ICollection<ElementaryAreaHistoryIItem> GetHistoryById(int id)
        {
            return new[]
            {
                new ElementaryAreaHistoryIItem() {Id = 1, Year = 2011, AgroCultureId = 2, EaYield = 33, EaSeedMass = 44},
                new ElementaryAreaHistoryIItem() {Id = 2, Year = 2012, AgroCultureId = 3, EaYield = 55, EaSeedMass = 66}
            };
        }

        public ICollection<ElementaryAreaSoilComposition> GetElAreaSoilCompositionById(int id)
        {
            return new[]
            {
                new ElementaryAreaSoilComposition()  {Id = id, Year = 2012},
                new ElementaryAreaSoilComposition()  {Id = id, Year = 2012}
            };
        }

        public ICollection<ElementaryAreaModel> GetElementaryAreasByWorkAreaId(int id)
        {
            return new[]
            {
                new ElementaryAreaModel() {Id = 1, Name = "Элементарный участок 1"},
                new ElementaryAreaModel() {Id = 2, Name = "Элементарный участок 2"}
            };
        }
        public ICollection<ElementaryAreaModel> GetElementaryAreasByFieldId(int id)
        {
            return new[]
            {
                new ElementaryAreaModel() {Id = 1, Name = "Элементарный участок 1"},
                new ElementaryAreaModel() {Id = 2, Name = "Элементарный участок 2"}
            };
        }
    }
}
