using Backend.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
    [Table("агроном_ПланУрожая2")]
    public class HarvestPlanElementaryAreaItem
    {
        [Column("PlanID")]
        public int Id { get; set; }
        [Column("AgroCultureID")]
        public int AgroCultureId { get; set; }
        [RelationColumn(
            ReferenceId = "AgroCultureID",
            FromTable = "агроном_АгроКультуры",
            PurposeId = "ID",
            FromColumn = "Name"
        )]
        public string AgroCulture { get; set; }
        [Column("PlannedYield")]
        public int PlannedYield { get; set; }
    }
    
}
