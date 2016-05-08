using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IEmployeeService
    {
        ICollection<EmployeeModel> List();
        EmployeeModel GetById(int id);

    }

    public class EmployeeService : IEmployeeService
    {
        public ICollection<EmployeeModel> List()
        {
            return new[]
            {
                new EmployeeModel {Id = 1, Name = "test"},
                new EmployeeModel {Id = 2, Name = "test2"}
            };
        }

        public EmployeeModel GetById(int id)
        {
            return new EmployeeModel
            {
                Id = id,
                Name = "testt"
            };
        }


    }
}
