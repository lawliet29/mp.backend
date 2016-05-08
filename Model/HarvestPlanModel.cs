using Backend.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
    [Table("агроном_РасчетПосевов")]
    public class HarvestPlanModel
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
    }
    [Table("агроном_РасчетПосевов")]
    public class HarvestPlanFullModel : HarvestPlanModel
    {
        [Column("Year")]
        public int Year { get; set; }
        [Column("CreatorName")]
        public int CreatorId { get; set; }
        [RelationColumn(
            ReferenceId = "CreatorName",
            FromTable = "_Сотрудники",
            PurposeId = "UserID",
            FromColumn = "FIO"
        )]
        public string CreatorName { get; set; }
        [Column("DateOfCreation")]
        public int CreationDate { get; set; }
    }
}
