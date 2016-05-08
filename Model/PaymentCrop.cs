using Backend.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
    [Table("агроном_РасчетПосевов")]
    public class PaymentCropModel
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
    }
    [Table("агроном_РасчетПосевов")]
    public class PaymentCropFullModel : AgroCultureModel
    {
        [Column("Staffer")]
        public int EmployeeId { get; set; }
        [RelationColumn(
            ReferenceId = "Staffer",
            FromTable = "_Сотрудники",
            PurposeId = "UserID",
            FromColumn = "FIO"
        )]
        public string Employee { get; set; }
        [Column("Year")]
        public int Year{ get; set; }
        [Column("StoreRequestID")]
        public int StoreRequestId { get; set; }
        [RelationColumn(
            ReferenceId = "StoreRequestID",
            FromTable = "агроном_ПланУрожая_1",
            PurposeId = "PlanID",
            FromColumn = "Name"
        )]
        public string StoreRequest { get; set; }
        [Column("DateOfCreation")]
        public int CreationDate { get; set; }
        [Column("Примечание")]
        public string Note { get; set; }
    }
}
