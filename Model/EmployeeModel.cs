using Backend.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
    [Table("_Сотрудники")]
    public class EmployeeModel
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("FIO")]
        public string Name { get; set; }
        [Column("Password")]
        public string Password { get; set; }
    }
    
}
