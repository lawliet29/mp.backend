using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IFieldService
    {
        ICollection<FieldModel> List();
        FieldFullModel GetById(int id);
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

        public FieldFullModel GetById(int id)
        {
            return new FieldFullModel
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
