using Backend.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
    [Table("агроном_РасчетПосевов2")]
    public class PaymentCropElementaryAreaItem
    {
        [Column("OptimizationID")]
        public int Id { get; set; }
        [Column("EA_ID")]
        public int ElementaryAreaId { get; set; }
    }
    [Table("агроном_РасчетПосевов2")]
    public class PaymentCropElementaryAreaFullModel : AgroCultureModel
    {
        [Column("AgroCultureID")]
        public int AgroCultureId { get; set; }
        [RelationColumn(
            ReferenceId = "AgroCultureID",
            FromTable = "агроном_АгроКультуры",
            PurposeId = "ID",
            FromColumn = "ProductionType"
        )]
        public string AgroCulture { get; set; }
        [Column("PlannedProductivity")]
        public int PlannedProductivity { get; set; }
        [Column("Ka_ToAdd")]
        public int KaToAdd { get; set; }
        [Column("P_ToAdd")]
        public int PToAdd { get; set; }
        [Column("N_ToAdd")]
        public int NToAdd { get; set; }
    }
}
