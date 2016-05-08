using Backend.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
    [Table("агроном_РабочиеУчестки_ИсторияПосевов")]
    public class WorkAreaHistoryItem
    {
        [Column("WorkAreaID")]
        public int Id { get; set; }
        [Column("Year")]
        public int Year { get; set; }
        [Column("AgroCultureID")]
        public int AgroCultureId { get; set; }
        [RelationColumn(
            ReferenceId = "AgrroCultureID",
            FromTable = "агроном_АгроКультуры",
            PurposeId = "ID",
            FromColumn = "Name"
        )]
        public string AgroCulture { get; set; }
        [Column("WorkAreaYield")]
        public int WorkAreaYield { get; set; }
        [Column("WorkAreaSeedMass")]
        public int WorkAreaSeedMass { get; set; }
    }
}
