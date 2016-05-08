using Backend.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
    [Table("агроном_ЭлементарныеУчастки_ИсторияПосевов")]
    public class ElementaryAreaHistoryIItem
    {
        [Column("EA_ID")]
        public int Id { get; set; }
        [Column("Year")]
        public int Year { get; set; }
        [Column("AgroCultureID")]
        public int AgroCultureId { get; set; }
        [Column("EaYield")]
        public int EaYield { get; set; }
        [Column("EaSeedMass")]
        public int EaSeedMass { get; set; }
    }
}
