using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Metadata;

namespace Backend.Model
{
    [Table("агроном_АгроКультуры")]
    public class AgroCultureModel
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
    }
    [Table("агроном_АгроКультуры")]
    public class AgroCultureFullModel : AgroCultureModel
    {
        [Column("AddedByUser")]
        public bool AddedByUser { get; set; }
        [Column("ProductionType")]
        public int ProductionTypeId { get; set; }
        [Column("BiologicalType")]
        public int BiologicalTypeId { get; set; }
        [Column("Intermediate")]
        public bool Intermediate { get; set; }
        [Column("AgroCultureType")]
        public int AgroCultureTypeId { get; set; }
        [Column("CurrentlySelected")]
        public bool CurrentlySelected { get; set; }
        [Column("ReferenceCultureID")]
        public int ReferenceCultureId { get; set; }
        [Column("AvgProductivity")]
        public int AvgProductivity { get; set; }
        [Column("SeedsAvgExpense")]
        public int SeedsAvgExpense { get; set; }
    }
}
