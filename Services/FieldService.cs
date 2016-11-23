using Backend.Model;
using System.Collections.Generic;

namespace Backend.Services
{
    public interface IFieldService
    {
        ICollection<FieldModel> List();
        FieldFullModel GetByIdFullModel(int id);
        FieldModel GetByIdShort(int id);
        ICollection<FieldHistoryItem> GetHistoryById(int id);
        
    }

    public class FieldService : IFieldService
    {
        public ICollection<FieldModel> List()
        {
            return new[]
            {
                new FieldModel() {Id = 1, Name = "test"},
                new FieldModel() {Id = 2, Name = "test2"}
            };
        }

        public FieldFullModel GetByIdFullModel(int id)
        {
            return new FieldFullModel
            {
                Id = id,
                Name = "testt"
            };
        }

        public FieldModel GetByIdShort(int id)
        {
            return new FieldModel
            {
                Id = id,
                Name = "testt"
            };
        }

        public ICollection<FieldHistoryItem> GetHistoryById(int id)
        {
            return new[]
            {
                new FieldHistoryItem() {Id = 1, Year = 2011},
                new FieldHistoryItem() {Id = 2, Year = 2012}
            };
        }

        
    }
}
